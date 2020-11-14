using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RandomBooleanNetwork.Nodes;

namespace RandomBooleanNetwork
{
    /// <summary>
    /// Sets the links between all the nodes in the network
    /// </summary>
    public class NodeLinker
    {
        /// <summary>
        /// Creates the links in the network using the LinkLabels set on each node.
        /// </summary>
        /// <param name="nodes">The nodes that require linking</param>
        public void Link(List<Node> nodes)
        {
            Parallel.ForEach(nodes, node =>
                node.SetNodeLinks(
                    node.LinkLabels.Select(label => nodes.Where(n => n.Label == label).First())
                                   .ToList()
                )
            );
        }
    }
}