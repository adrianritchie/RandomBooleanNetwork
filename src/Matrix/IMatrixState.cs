using System.Collections.Generic;

namespace RandomBooleanNetwork.Matrix
{
    /// <summary>
    /// Interface for objects that hold matrix state
    /// </summary>
    public interface IMatrixState
    {
        /// <summary>
        /// The state of the matrix
        /// </summary>
        Dictionary<string, bool> Matrix { get; }
    }
}