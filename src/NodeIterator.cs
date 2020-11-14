using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RandomBooleanNetwork.Nodes;

namespace RandomBooleanNetwork
{
    /// <summary>
    /// Performs actions on the nodes provided in the constructor
    /// </summary>
    public class NodeIterator
    {
        private readonly IEnumerable<Node> nodes;

        /// <summary>
        /// Create an instance of the NodeIterator
        /// </summary>
        /// <param name="nodes">The nodes that actions will be performed against</param>
        public NodeIterator(IEnumerable<Node> nodes)
        {
            this.nodes = nodes;
        }

        /// <summary>
        /// Perform the action on each node sequentially
        /// </summary>
        /// <param name="action">The action to be performed</param>
        public void Execute(Action<Node> action)
        {
            foreach (var node in nodes)
            {
                action(node);
            }
        }

        /// <summary>
        /// Perform the action on all the nodes in parallel
        /// </summary>
        /// <param name="action">The action to be performed</param>
        public void ParallelExecute(Action<Node> action)
        {
            Parallel.ForEach(nodes, action);
        }
    }
}