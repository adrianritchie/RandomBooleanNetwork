using System;
using System.Linq;
using System.Collections.Generic;
using RandomBooleanNetwork.Nodes;

namespace RandomBooleanNetwork
{
    /// <summary>
    /// Builds a nodes from a set of provided conditions
    /// </summary>
    public class NodeBuilder
    {
        private readonly IEnumerable<IEnumerable<int>> combinations;
        private readonly bool allowSelfLink;
        private readonly Random rand = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="combinations">Collection of pre-calculated possible node links</param>
        /// <param name="allowSelfLink">Whether a node should be able to link back to itself</param>
        public NodeBuilder(IEnumerable<IEnumerable<int>> combinations, bool allowSelfLink = false)
        {
            this.combinations = combinations;
            this.allowSelfLink = allowSelfLink;
        }

        /// <summary>
        /// Create a node for the given label
        /// </summary>
        /// <param name="label">The label for the node to be created</param>
        /// <returns>A <seealso cref="Node"/> with given Label, random linked node labels and a random state.</returns>
        public Node CreateNode(int label)
        {
            do
            {
                var comb = combinations.Skip(rand.Next(0, this.combinations.Count()))
                                       .First();

                if (!comb.Contains(label) || allowSelfLink)
                {
                    return new Node(label, comb, rand.Next(2) == 1);
                }
            } while (true);
        }

    }
}