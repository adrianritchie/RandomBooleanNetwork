using System;
using System.Collections.Generic;
using RandomBooleanNetwork.Matrix;
using RandomBooleanNetwork.Nodes;

namespace RandomBooleanNetwork
{
    /// <summary>
    /// Defined state of the system for (de)serialization
    /// </summary>
    public class SystemState<TMatrix, TNode> 
        where TMatrix : IMatrixState 
        where TNode : class, INodeState
    {
        /// <summary>
        /// The Id of this system state for future use
        /// </summary>
        public Guid StateId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// State of the matrix
        /// </summary>
        public TMatrix MatrixState { get; set; }

        /// <summary>
        /// Collection of state of nodes in the network
        /// </summary>
        public IEnumerable<TNode> NodeStates {get; set; }
    }
}