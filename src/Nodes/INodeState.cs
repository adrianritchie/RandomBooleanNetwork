using System.Collections.Generic;

namespace RandomBooleanNetwork.Nodes
{
    /// <summary>
    /// Interface for object the hold node state
    /// </summary>
    public interface INodeState
    {
        /// <summary>
        /// The label is the node
        /// </summary>
        int Label { get; }

        /// <summary>
        /// The labels of the other nodes this node is linked to
        /// </summary>
        IEnumerable<int> LinkLabels { get; }

        /// <summary>
        /// The current state of the node
        /// </summary>
        bool State { get; }
    }
}
