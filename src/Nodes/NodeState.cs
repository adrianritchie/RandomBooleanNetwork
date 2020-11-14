using System.Collections.Generic;

namespace RandomBooleanNetwork.Nodes
{
    /// <summary>
    /// Concrete implementation of INodeState for deserialization
    /// </summary>
    public class NodeState : INodeState
    {
        /// <inheritdoc/>
        public int Label { get; set; }
        
        /// <inheritdoc/>
        public IEnumerable<int> LinkLabels { get; set; }

        /// <inheritdoc/>
        public bool State { get; set; }
    }
}