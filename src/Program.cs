using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Combinatorics.Collections;
using System.Text.Json;
using System.Threading.Tasks;
using RandomBooleanNetwork.Matrix;
using RandomBooleanNetwork.Nodes;
using System.CommandLine.Invocation;

namespace RandomBooleanNetwork
{
    class Program
    {
        /// <param name="generations">Number of generations to run the network for</param>
        /// <param name="links">Number of links between nodes when creating random network</param>
        /// <param name="nodes">Number of nodes to add when creating random network</param>
        /// <param name="stateFile">Saved SystemState file to re-run</param>
        static void Main(int generations = 100, int links = 4, int nodes = 20, FileInfo stateFile = null)
        {
            List<Node> networkNodes;
            GenerationMatrix matrix;
            Guid systemStateId;
            var nodeLinker = new NodeLinker();
            var outputRenderer = new OutputRenderer();

            if (stateFile == null || !stateFile.Exists) {
                var nodeLabels = Enumerable.Range(0, nodes).ToList();
                var combs = new Variations<int>(nodeLabels, links);
                var nodeBuilder = new NodeBuilder(combs);
                matrix = new GenerationMatrix(links);

                networkNodes = nodeLabels.Select(label => nodeBuilder.CreateNode(label)).ToList();

                var systemState = new SystemState<GenerationMatrix, Node> { MatrixState = matrix, NodeStates = networkNodes };
                systemStateId = systemState.StateId;
                File.WriteAllText(
                    $"state_{systemState.StateId}.json", 
                    JsonSerializer.Serialize(systemState, new JsonSerializerOptions { WriteIndented = true }));
            }
            else {
                using var streamReader = stateFile.OpenText();
                var json = streamReader.ReadToEnd();

                var systemState = JsonSerializer.Deserialize<SystemState<MatrixState, NodeState>>(json);
                systemStateId = systemState.StateId;

                matrix = new GenerationMatrix(systemState.MatrixState);
                networkNodes = systemState.NodeStates.Select(ns => new Node(ns)).ToList();
            }


            nodeLinker.Link(networkNodes);
            var nodeIterator = new NodeIterator(networkNodes);

            List<string> output = new List<string>();
            for (int i = 0; i < generations; i++)
            {
                var states = new List<string>();
                nodeIterator.Execute(n => states.Add(n.ToString()));
                output.Add(string.Join(' ', states));

                nodeIterator.Execute(n => n.PrepareState(matrix));
                nodeIterator.Execute(n => n.UpdateState());
            }
            
            outputRenderer.Render(output);
            Console.WriteLine($"State Id: {systemStateId}");

            Console.WriteLine("\nDo you want to keep this system state? [y/n]");
            var input = Console.ReadLine();

            if ( (stateFile == null && input.ToLower() != "y") || input.ToLower() == "n") {
                File.Delete($"state_{systemStateId}.json");
            }
        }
    }
}
