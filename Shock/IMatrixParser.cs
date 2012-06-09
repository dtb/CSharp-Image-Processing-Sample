using System;
using System.Collections.Generic;
using System.Text;

namespace Shock
{
	public interface IMatrixParser
	{
		/// <summary>
		/// Returns true if the input can be parsed by the current implementation
		/// </summary>
		/// <param name="matrix">The input matrix</param>
		/// <returns>True if the input is a valid (parsable) matrix</returns>
		bool Validate(string matrix);

		/// <summary>
		/// Returns the input matrix.
		/// </summary>
		/// <param name="matrix">The input matrix</param>
		/// <returns>2-d array containing parsed matrix</returns>
		short [,] Parse(string matrix);
	}
}
