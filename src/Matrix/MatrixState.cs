using System.Collections.Generic;

namespace RandomBooleanNetwork.Matrix
{
    /// <summary>
    /// Concrete implemntation of matrix state for deserialization
    /// </summary>
    public class MatrixState : IMatrixState
    {
        /// <summary>
        /// Current state of the matrix
        /// </summary>
        public Dictionary<string, bool> Matrix { get; set; }
    }
}