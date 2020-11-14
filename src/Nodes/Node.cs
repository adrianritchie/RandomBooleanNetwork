using System;
using System.Collections.Generic;
using RandomBooleanNetwork.Matrix;

namespace RandomBooleanNetwork.Nodes
{
    /// <summary>
    /// A node in the network
    /// </summary>
    public class Node : INodeState
    {
        private List<Node> linkedNodes;
        private bool nextState;

        /// <summary>
        /// Contructor for a new node in the network
        /// </summary>
        /// <param name="label">The label for this node</param>
        /// <param name="linkLabels">The labels of nodes this node will be linked to</param>
        /// <param name="initialState">The initial state of this node</param>
        public Node(int label, IEnumerable<int> linkLabels, bool initialState)
        {
            Label = label;
            LinkLabels = linkLabels;
            State = initialState;
        }

        /// <summary>
        /// Constructor from an existing node state
        /// </summary>
        /// <param name="nodeState">The state to be used for this node</param>
        public Node(NodeState nodeState)
        {
            Label = nodeState.Label;
            LinkLabels = nodeState.LinkLabels;
            State = nodeState.State;
        }

        /// <inheritdoc/>
        public int Label { get; }
        
        /// <inheritdoc/>
        public IEnumerable<int> LinkLabels { get; }
        
        /// <inheritdoc/>
        public bool State { get; private set; }

        /// <summary>
        /// Store the references to nodes this node is linked to
        /// </summary>
        /// <param name="linkedNodes"></param>
        public void SetNodeLinks(List<Node> linkedNodes) => this.linkedNodes = linkedNodes;

        /// <summary>
        /// Calculates the next state for this node
        /// </summary>
        /// <param name="matrix">The matrix used to determine the next state</param>
        public void PrepareState(GenerationMatrix matrix)
        {
            this.nextState = matrix.GetNextState(this.linkedNodes);
        }

        /// <summary>
        /// Updates the actual state of this node
        /// </summary>
        public void UpdateState()
        {
            this.State = nextState;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return State ? "#" : " ";
        }
    }
}