using System;
using System.Linq;
using System.Collections.Generic;
using RandomBooleanNetwork.Nodes;

namespace RandomBooleanNetwork.Matrix
{
    /// <summary>
    /// Default Generation matrix
    /// </summary>
    public class GenerationMatrix : IMatrixState
    {
        /// <summary>
        /// Defined matrix for calculating future states
        /// </summary>
        public Dictionary<string, bool> Matrix { get; } = new Dictionary<string, bool>();

        /// <summary>
        /// Contructor for generating random matrix
        /// </summary>
        /// <param name="links">Number of links between nodes in the network</param>
        public GenerationMatrix(int links)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var states = Enumerable.Range(0, (int)Math.Pow(2, links))
                                    .Select(i =>
                                        Enumerable.Range(0, links)
                                            .Select(b => ((i & (1 << b)) > 0))
                                            .ToArray()
                                    ).ToArray();

            foreach (var state in states)
            {
                Matrix.Add(
                    string.Join("-", state.Select(s => s.ToString())),
                    rand.Next(0, 2) == 1
                );
            }
        }

        /// <summary>
        /// Contructor for restoring saved state
        /// </summary>
        /// <param name="matrixState">State to be restore</param>
        public GenerationMatrix(MatrixState matrixState) {
            Matrix = matrixState.Matrix;
        }

        /// <summary>
        /// Method to determine the future state from a list of nodes.
        /// </summary>
        /// <param name="nodes">The nodes used to determine the state</param>
        /// <returns>The state derived from the given nodes</returns>
        public bool GetNextState(IEnumerable<Node> nodes)
        {
            var state = string.Join("-", nodes.Select(n => n.State.ToString()));
            return Matrix[state];
        }
    }
}