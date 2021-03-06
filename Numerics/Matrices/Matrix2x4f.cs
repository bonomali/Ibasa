using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Ibasa.Numerics
{
	/// <summary>
	/// Represents a 2 by 4 matrix of floats.
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	[StructLayout(LayoutKind.Sequential)]
	public struct Matrix2x4f: IEquatable<Matrix2x4f>, IFormattable
	{
		#region Constants
		/// <summary>
		/// Returns a new <see cref="Matrix2x4f"/> with all of its elements equal to zero.
		/// </summary>
		public static readonly Matrix2x4f Zero = new Matrix2x4f(0);
		/// <summary>
		/// Returns a new <see cref="Matrix2x4f"/> with all of its elements equal to one.
		/// </summary>
		public static readonly Matrix2x4f One = new Matrix2x4f(1);
		#endregion
		#region Fields
		/// <summary>
		/// Gets the element of the matrix that exists in the first row and first column.
		/// </summary>
		public readonly float M11;
		/// <summary>
		/// Gets the element of the matrix that exists in the second row and first column.
		/// </summary>
		public readonly float M21;
		/// <summary>
		/// Gets the element of the matrix that exists in the first row and second column.
		/// </summary>
		public readonly float M12;
		/// <summary>
		/// Gets the element of the matrix that exists in the second row and second column.
		/// </summary>
		public readonly float M22;
		/// <summary>
		/// Gets the element of the matrix that exists in the first row and third column.
		/// </summary>
		public readonly float M13;
		/// <summary>
		/// Gets the element of the matrix that exists in the second row and third column.
		/// </summary>
		public readonly float M23;
		/// <summary>
		/// Gets the element of the matrix that exists in the first row and fourth column.
		/// </summary>
		public readonly float M14;
		/// <summary>
		/// Gets the element of the matrix that exists in the second row and fourth column.
		/// </summary>
		public readonly float M24;
		#endregion
		#region Properties
		public float this[int row, int column]
		{
			get
			{
				if (row < 0 || row > 1)
					throw new ArgumentOutOfRangeException("row", "Rows for Matrix2x4f run from 0 to 1, inclusive.");
				if (column < 0 || column > 3)
					throw new ArgumentOutOfRangeException("column", "Columns for Matrix2x4f run from 0 to 3, inclusive.");
				int index = row + column * 2;
				return this[index];
			}
		}
		public float this[int index]
		{
			get
			{
				if (index < 0 || index > 7)
					throw new ArgumentOutOfRangeException("index", "Indices for Matrix2x4f run from 0 to 7, inclusive.");
				switch (index)
				{
					case 0: return M11;
					case 1: return M21;
					case 2: return M12;
					case 3: return M22;
					case 4: return M13;
					case 5: return M23;
					case 6: return M14;
					case 7: return M24;
				}
				return 0;
			}
		}
		public Vector4f GetRow(int row)
		{
			if (row < 0 || row > 1)
				throw new ArgumentOutOfRangeException("row", "Rows for Matrix2x4f run from 0 to 1, inclusive.");
			switch (row)
			{
				case 0:
					return new Vector4f(M11, M12, M13, M14);
				case 1:
					return new Vector4f(M21, M22, M23, M24);
			}
			return Vector4f.Zero;
		}
		public Vector2f GetColumn(int column)
		{
			if (column < 0 || column > 3)
				throw new ArgumentOutOfRangeException("column", "Columns for Matrix2x4f run from 0 to 3, inclusive.");
			switch (column)
			{
				case 0:
					return new Vector2f(M11, M21);
				case 1:
					return new Vector2f(M12, M22);
				case 2:
					return new Vector2f(M13, M23);
				case 3:
					return new Vector2f(M14, M24);
			}
			return Vector2f.Zero;
		}
		public float[] ToArray()
		{
			return new float[]
			{
				M11, M21, M12, M22, M13, M23, M14, M24
			};
		}
		#endregion
		#region Constructors
		public Matrix2x4f(float value)
		{
			M11 = value;
			M12 = value;
			M13 = value;
			M14 = value;
			M21 = value;
			M22 = value;
			M23 = value;
			M24 = value;
		}
		public Matrix2x4f(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24)
		{
			M11 = m11;
			M21 = m21;
			M12 = m12;
			M22 = m22;
			M13 = m13;
			M23 = m23;
			M14 = m14;
			M24 = m24;
		}
		#endregion
		#region Operations
		public static Matrix2x4f operator +(Matrix2x4f value)
		{
			return value;
		}
		public static Matrix2x4f operator -(Matrix2x4f value)
		{
			return Matrix.Negate(value);
		}
		public static Matrix2x4f operator +(Matrix2x4f left, Matrix2x4f right)
		{
			return Matrix.Add(left, right);
		}
		public static Matrix2x4f operator -(Matrix2x4f left, Matrix2x4f right)
		{
			return Matrix.Subtract(left, right);
		}
		public static Matrix2x4f operator *(Matrix2x4f matrix, float scalar)
		{
			return Matrix.Multiply(matrix, scalar);
		}
		public static Matrix2x4f operator *(float scalar, Matrix2x4f matrix)
		{
			return Matrix.Multiply(matrix, scalar);
		}
		public static Matrix2x2f operator *(Matrix2x4f left, Matrix4x2f right)
		{
			return Matrix.Multiply(left, right);
		}
		public static Matrix2x3f operator *(Matrix2x4f left, Matrix4x3f right)
		{
			return Matrix.Multiply(left, right);
		}
		public static Matrix2x4f operator *(Matrix2x4f left, Matrix4x4f right)
		{
			return Matrix.Multiply(left, right);
		}
		public static Matrix2x4f operator /(Matrix2x4f matrix, float scalar)
		{
			return Matrix.Divide(matrix, scalar);
		}
		#endregion
		#region Conversions
		/// <summary>
		/// Defines an explicit conversion of a Matrix2x4d value to a Matrix2x4f.
		/// </summary>
		/// <param name="value">The value to convert to a Matrix2x4f.</param>
		/// <returns>A Matrix2x4f that has all components equal to value.</returns>
		public static explicit operator Matrix2x4f(Matrix2x4d value)
		{
			return new Matrix2x4f((float)value.M11, (float)value.M21, (float)value.M12, (float)value.M22, (float)value.M13, (float)value.M23, (float)value.M14, (float)value.M24);
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns the hash code for the current <see cref="Matrix2x4f"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return M11.GetHashCode() + M21.GetHashCode() + M12.GetHashCode() + M22.GetHashCode() + M13.GetHashCode() + M23.GetHashCode() + M14.GetHashCode() + M24.GetHashCode();
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// object have the same value.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>true if the obj parameter is a <see cref="Matrix2x4f"/> object or a type capable
		/// of implicit conversion to a <see cref="Matrix2x4f"/> object, and its value
		/// is equal to the current <see cref="Matrix2x4f"/> object; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Matrix2x4f) { return Equals((Matrix2x4f)obj); }
			return false;
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// matrix have the same value.
		/// </summary>
		/// <param name="other">The matrix to compare.</param>
		/// <returns>true if this matrix and value have the same value; otherwise, false.</returns>
		public bool Equals(Matrix2x4f other)
		{
			return this == other;
		}
		/// <summary>
		/// Returns a value that indicates whether two matrices are equal.
		/// </summary>
		/// <param name="left">The first matrix to compare.</param>
		/// <param name="right">The second matrix to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool Equals(Matrix2x4f left, Matrix2x4f right)
		{
			return left == right;
		}
		/// <summary>
		/// Returns a value that indicates whether two matrices are equal.
		/// </summary>
		/// <param name="left">The first matrix to compare.</param>
		/// <param name="right">The second matrix to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool operator ==(Matrix2x4f left, Matrix2x4f right)
		{
			return left.M11 == right.M11 & left.M21 == right.M21 & left.M12 == right.M12 & left.M22 == right.M22 & left.M13 == right.M13 & left.M23 == right.M23 & left.M14 == right.M14 & left.M24 == right.M24;
		}
		/// <summary>
		/// Returns a value that indicates whether two matrices are not equal.
		/// </summary>
		/// <param name="left">The first matrix to compare.</param>
		/// <param name="right">The second matrix to compare.</param>
		/// <returns>true if the left and right are not equal; otherwise, false.</returns>
		public static bool operator !=(Matrix2x4f left, Matrix2x4f right)
		{
			return left.M11 != right.M11 | left.M21 != right.M21 | left.M12 != right.M12 | left.M22 != right.M22 | left.M13 != right.M13 | left.M23 != right.M23 | left.M14 != right.M14 | left.M24 != right.M24;
		}
		#endregion
		#region ToString
		/// <summary>
		/// Converts the value of the current matrix to its equivalent string
		/// representation in Cartesian form.
		/// </summary>
		/// <returns>The string representation of the current instance in Cartesian form.</returns>
		public override string ToString()
		{
			return ToString("G", CultureInfo.CurrentCulture);
		}
		/// <summary>
		/// Converts the value of the current matrix to its equivalent string
		/// representation in Cartesian form by using the specified culture-specific
		/// formatting information.
		/// </summary>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>The string representation of the current instance in Cartesian form, as specified
		/// by provider.</returns>
		public string ToString(IFormatProvider provider)
		{
			return ToString("G", provider);
		}
		/// <summary>
		/// Converts the value of the current matrix to its equivalent string
		/// representation in Cartesian form by using the specified format for its components.
		/// formatting information.
		/// </summary>
		/// <param name="format">A standard or custom numeric format string.</param>
		/// <returns>The string representation of the current instance in Cartesian form.</returns>
		/// <exception cref="System.FormatException">format is not a valid format string.</exception>
		public string ToString(string format)
		{
			return ToString(format, CultureInfo.CurrentCulture);
		}
		/// <summary>
		/// Converts the value of the current matrix to its equivalent string
		/// representation in Cartesian form by using the specified format and culture-specific
		/// format information for its components.
		/// </summary>
		/// <param name="format">A standard or custom numeric format string.</param>
		/// <returns>The string representation of the current instance in Cartesian form, as specified
		/// by format and provider.</returns>
		/// <exception cref="System.FormatException">format is not a valid format string.</exception>
		public string ToString(string format, IFormatProvider provider)
		{
			return String.Format("[({0}, {1}, {2}, {3})({4}, {5}, {6}, {7})]", M11.ToString(format, provider), M21.ToString(format, provider), M12.ToString(format, provider), M22.ToString(format, provider), M13.ToString(format, provider), M23.ToString(format, provider), M14.ToString(format, provider), M24.ToString(format, provider));
		}
		#endregion
	}
	/// <summary>
	/// Provides static methods for matrix functions.
	/// </summary>
	public static partial class Matrix
	{
		#region Operations
		public static Matrix2x4f Negate(Matrix2x4f value)
		{
			return new Matrix2x4f(-value.M11, -value.M21, -value.M12, -value.M22, -value.M13, -value.M23, -value.M14, -value.M24);
		}
		public static Matrix2x4f Add(Matrix2x4f left, Matrix2x4f right)
		{
			return new Matrix2x4f(left.M11 + right.M11, left.M21 + right.M21, left.M12 + right.M12, left.M22 + right.M22, left.M13 + right.M13, left.M23 + right.M23, left.M14 + right.M14, left.M24 + right.M24);
		}
		public static Matrix2x4f Subtract(Matrix2x4f left, Matrix2x4f right)
		{
			return new Matrix2x4f(left.M11 - right.M11, left.M21 - right.M21, left.M12 - right.M12, left.M22 - right.M22, left.M13 - right.M13, left.M23 - right.M23, left.M14 - right.M14, left.M24 - right.M24);
		}
		public static Matrix2x2f Multiply(Matrix2x4f left, Matrix4x2f right)
		{
			return new Matrix2x2f(left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41, left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41, left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42, left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42);
		}
		public static Matrix2x3f Multiply(Matrix2x4f left, Matrix4x3f right)
		{
			return new Matrix2x3f(left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41, left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41, left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42, left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42, left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43, left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43);
		}
		public static Matrix2x4f Multiply(Matrix2x4f left, Matrix4x4f right)
		{
			return new Matrix2x4f(left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41, left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41, left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42, left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42, left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43, left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43, left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44, left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44);
		}
		public static Matrix2x4f Multiply(Matrix2x4f matrix, float scalar)
		{
			return new Matrix2x4f(matrix.M11 * scalar, matrix.M21 * scalar, matrix.M12 * scalar, matrix.M22 * scalar, matrix.M13 * scalar, matrix.M23 * scalar, matrix.M14 * scalar, matrix.M24 * scalar);
		}
		public static Matrix2x4f Divide(Matrix2x4f matrix, float scalar)
		{
			return new Matrix2x4f(matrix.M11 / scalar, matrix.M21 / scalar, matrix.M12 / scalar, matrix.M22 / scalar, matrix.M13 / scalar, matrix.M23 / scalar, matrix.M14 / scalar, matrix.M24 / scalar);
		}
		#endregion
		#region Test
		/// <summary>
		/// Determines whether all elements of a matrix are non-zero.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>true if all elements are non-zero; false otherwise.</returns>
		public static bool All(Matrix2x4f value)
		{
			return value.M11 != 0 && value.M21 != 0 && value.M12 != 0 && value.M22 != 0 && value.M13 != 0 && value.M23 != 0 && value.M14 != 0 && value.M24 != 0;
		}
		/// <summary>
		/// Determines whether all elements of a matrix satisfy a condition.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>true if every element of the matrix passes the test in the specified
		/// predicate; otherwise, false.</returns>
		public static bool All(Matrix2x4f value, Predicate<float> predicate)
		{
			return predicate(value.M11) && predicate(value.M21) && predicate(value.M12) && predicate(value.M22) && predicate(value.M13) && predicate(value.M23) && predicate(value.M14) && predicate(value.M24);
		}
		/// <summary>
		/// Determines whether any element of a matrix is non-zero.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>true if any elements are non-zero; false otherwise.</returns>
		public static bool Any(Matrix2x4f value)
		{
			return value.M11 != 0 || value.M21 != 0 || value.M12 != 0 || value.M22 != 0 || value.M13 != 0 || value.M23 != 0 || value.M14 != 0 || value.M24 != 0;
		}
		/// <summary>
		/// Determines whether any elements of a matrix satisfy a condition.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>true if any element of the matrix passes the test in the specified
		/// predicate; otherwise, false.</returns>
		public static bool Any(Matrix2x4f value, Predicate<float> predicate)
		{
			return predicate(value.M11) || predicate(value.M21) || predicate(value.M12) || predicate(value.M22) || predicate(value.M13) || predicate(value.M23) || predicate(value.M14) || predicate(value.M24);
		}
		#endregion
		#region Per element
		#region Map
		/// <summary>
		/// Maps the elements of a matrix and returns the result.
		/// </summary>
		/// <param name="value">The matrix to map.</param>
		/// <param name="mapping">A mapping function to apply to each element.</param>
		/// <returns>The result of mapping each element of value.</returns>
		public static Matrix2x4d Map(Matrix2x4f value, Func<float, double> mapping)
		{
			return new Matrix2x4d(mapping(value.M11), mapping(value.M21), mapping(value.M12), mapping(value.M22), mapping(value.M13), mapping(value.M23), mapping(value.M14), mapping(value.M24));
		}
		/// <summary>
		/// Maps the elements of a matrix and returns the result.
		/// </summary>
		/// <param name="value">The matrix to map.</param>
		/// <param name="mapping">A mapping function to apply to each element.</param>
		/// <returns>The result of mapping each element of value.</returns>
		public static Matrix2x4f Map(Matrix2x4f value, Func<float, float> mapping)
		{
			return new Matrix2x4f(mapping(value.M11), mapping(value.M21), mapping(value.M12), mapping(value.M22), mapping(value.M13), mapping(value.M23), mapping(value.M14), mapping(value.M24));
		}
		#endregion
		/// <summary>
		/// Multiplys the elements of two matrices and returns the result.
		/// </summary>
		/// <param name="left">The first matrix to modulate.</param>
		/// <param name="right">The second matrix to modulate.</param>
		/// <returns>The result of multiplying each element of left by the matching element in right.</returns>
		public static Matrix2x4f Modulate(Matrix2x4f left, Matrix2x4f right)
		{
			return new Matrix2x4f(left.M11 * right.M11, left.M21 * right.M21, left.M12 * right.M12, left.M22 * right.M22, left.M13 * right.M13, left.M23 * right.M23, left.M14 * right.M14, left.M24 * right.M24);
		}
		/// <summary>
		/// Returns the absolute value (per element).
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>The absolute value (per element) of value.</returns>
		public static Matrix2x4f Abs(Matrix2x4f value)
		{
			return new Matrix2x4f(Functions.Abs(value.M11), Functions.Abs(value.M21), Functions.Abs(value.M12), Functions.Abs(value.M22), Functions.Abs(value.M13), Functions.Abs(value.M23), Functions.Abs(value.M14), Functions.Abs(value.M24));
		}
		/// <summary>
		/// Returns a matrix that contains the lowest value from each pair of elements.
		/// </summary>
		/// <param name="value1">The first matrix.</param>
		/// <param name="value2">The second matrix.</param>
		/// <returns>The lowest of each element in left and the matching element in right.</returns>
		public static Matrix2x4f Min(Matrix2x4f value1, Matrix2x4f value2)
		{
			return new Matrix2x4f(Functions.Min(value1.M11, value2.M11), Functions.Min(value1.M21, value2.M21), Functions.Min(value1.M12, value2.M12), Functions.Min(value1.M22, value2.M22), Functions.Min(value1.M13, value2.M13), Functions.Min(value1.M23, value2.M23), Functions.Min(value1.M14, value2.M14), Functions.Min(value1.M24, value2.M24));
		}
		/// <summary>
		/// Returns a matrix that contains the highest value from each pair of elements.
		/// </summary>
		/// <param name="value1">The first matrix.</param>
		/// <param name="value2">The second matrix.</param>
		/// <returns>The highest of each element in left and the matching element in right.</returns>
		public static Matrix2x4f Max(Matrix2x4f value1, Matrix2x4f value2)
		{
			return new Matrix2x4f(Functions.Max(value1.M11, value2.M11), Functions.Max(value1.M21, value2.M21), Functions.Max(value1.M12, value2.M12), Functions.Max(value1.M22, value2.M22), Functions.Max(value1.M13, value2.M13), Functions.Max(value1.M23, value2.M23), Functions.Max(value1.M14, value2.M14), Functions.Max(value1.M24, value2.M24));
		}
		/// <summary>
		/// Constrains each element to a given range.
		/// </summary>
		/// <param name="value">A matrix to constrain.</param>
		/// <param name="min">The minimum values for each element.</param>
		/// <param name="max">The maximum values for each element.</param>
		/// <returns>A matrix with each element constrained to the given range.</returns>
		public static Matrix2x4f Clamp(Matrix2x4f value, Matrix2x4f min, Matrix2x4f max)
		{
			return new Matrix2x4f(Functions.Clamp(value.M11, min.M11, max.M11), Functions.Clamp(value.M21, min.M21, max.M21), Functions.Clamp(value.M12, min.M12, max.M12), Functions.Clamp(value.M22, min.M22, max.M22), Functions.Clamp(value.M13, min.M13, max.M13), Functions.Clamp(value.M23, min.M23, max.M23), Functions.Clamp(value.M14, min.M14, max.M14), Functions.Clamp(value.M24, min.M24, max.M24));
		}
		/// <summary>
		/// Constrains each element to the range 0 to 1.
		/// </summary>
		/// <param name="value">A matrix to saturate.</param>
		/// <returns>A matrix with each element constrained to the range 0 to 1.</returns>
		public static Matrix2x4f Saturate(Matrix2x4f value)
		{
			return new Matrix2x4f(Functions.Saturate(value.M11), Functions.Saturate(value.M21), Functions.Saturate(value.M12), Functions.Saturate(value.M22), Functions.Saturate(value.M13), Functions.Saturate(value.M23), Functions.Saturate(value.M14), Functions.Saturate(value.M24));
		}
		/// <summary>
		/// Returns a matrix where each element is the smallest integral value that
		/// is greater than or equal to the specified element.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>The ceiling of value.</returns>
		public static Matrix2x4f Ceiling(Matrix2x4f value)
		{
			return new Matrix2x4f(Functions.Ceiling(value.M11), Functions.Ceiling(value.M21), Functions.Ceiling(value.M12), Functions.Ceiling(value.M22), Functions.Ceiling(value.M13), Functions.Ceiling(value.M23), Functions.Ceiling(value.M14), Functions.Ceiling(value.M24));
		}
		/// <summary>
		/// Returns a matrix where each element is the largest integral value that
		/// is less than or equal to the specified element.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>The floor of value.</returns>
		public static Matrix2x4f Floor(Matrix2x4f value)
		{
			return new Matrix2x4f(Functions.Floor(value.M11), Functions.Floor(value.M21), Functions.Floor(value.M12), Functions.Floor(value.M22), Functions.Floor(value.M13), Functions.Floor(value.M23), Functions.Floor(value.M14), Functions.Floor(value.M24));
		}
		/// <summary>
		/// Returns a matrix where each element is the integral part of the specified element.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>The integral of value.</returns>
		public static Matrix2x4f Truncate(Matrix2x4f value)
		{
			return new Matrix2x4f(Functions.Truncate(value.M11), Functions.Truncate(value.M21), Functions.Truncate(value.M12), Functions.Truncate(value.M22), Functions.Truncate(value.M13), Functions.Truncate(value.M23), Functions.Truncate(value.M14), Functions.Truncate(value.M24));
		}
		/// <summary>
		/// Returns a matrix where each element is the fractional part of the specified element.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>The fractional of value.</returns>
		public static Matrix2x4f Fractional(Matrix2x4f value)
		{
			return new Matrix2x4f(Functions.Fractional(value.M11), Functions.Fractional(value.M21), Functions.Fractional(value.M12), Functions.Fractional(value.M22), Functions.Fractional(value.M13), Functions.Fractional(value.M23), Functions.Fractional(value.M14), Functions.Fractional(value.M24));
		}
		/// <summary>
		/// Returns a matrix where each element is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>The result of rounding value.</returns>
		public static Matrix2x4f Round(Matrix2x4f value)
		{
			return new Matrix2x4f(Functions.Round(value.M11), Functions.Round(value.M21), Functions.Round(value.M12), Functions.Round(value.M22), Functions.Round(value.M13), Functions.Round(value.M23), Functions.Round(value.M14), Functions.Round(value.M24));
		}
		/// <summary>
		/// Returns a matrix where each element is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <returns>The result of rounding value.</returns>
		public static Matrix2x4f Round(Matrix2x4f value, int digits)
		{
			return new Matrix2x4f(Functions.Round(value.M11, digits), Functions.Round(value.M21, digits), Functions.Round(value.M12, digits), Functions.Round(value.M22, digits), Functions.Round(value.M13, digits), Functions.Round(value.M23, digits), Functions.Round(value.M14, digits), Functions.Round(value.M24, digits));
		}
		/// <summary>
		/// Returns a matrix where each element is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
		/// <returns>The result of rounding value.</returns>
		public static Matrix2x4f Round(Matrix2x4f value, MidpointRounding mode)
		{
			return new Matrix2x4f(Functions.Round(value.M11, mode), Functions.Round(value.M21, mode), Functions.Round(value.M12, mode), Functions.Round(value.M22, mode), Functions.Round(value.M13, mode), Functions.Round(value.M23, mode), Functions.Round(value.M14, mode), Functions.Round(value.M24, mode));
		}
		/// <summary>
		/// Returns a matrix where each element is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
		/// <returns>The result of rounding value.</returns>
		public static Matrix2x4f Round(Matrix2x4f value, int digits, MidpointRounding mode)
		{
			return new Matrix2x4f(Functions.Round(value.M11, digits, mode), Functions.Round(value.M21, digits, mode), Functions.Round(value.M12, digits, mode), Functions.Round(value.M22, digits, mode), Functions.Round(value.M13, digits, mode), Functions.Round(value.M23, digits, mode), Functions.Round(value.M14, digits, mode), Functions.Round(value.M24, digits, mode));
		}
		/// <summary>
		/// Calculates the reciprocal of each element in the matrix.
		/// </summary>
		/// <param name="value">A matrix.</param>
		/// <returns>A matrix with the reciprocal of each of values elements.</returns>
		public static Matrix2x4f Reciprocal(Matrix2x4f value)
		{
			return new Matrix2x4f(1 / value.M11, 1 / value.M21, 1 / value.M12, 1 / value.M22, 1 / value.M13, 1 / value.M23, 1 / value.M14, 1 / value.M24);
		}
		#endregion
		#region Submatrix
		/// <summary>
		/// Returns the specified submatrix of the given matrix.
		/// </summary>
		/// <param name="matrix">The matrix whose submatrix is to returned.</param>
		/// <param name="row">The row to be removed.</param>
		/// <param name="column">The column to be removed.</param>
		public static Vector3f Submatrix(Matrix2x4f matrix, int row, int column)
		{
			if (row < 0 || row > 1)
				throw new ArgumentOutOfRangeException("row", "Rows for Matrix2x4f run from 0 to 1, inclusive.");
			if (column < 0 || column > 3)
				throw new ArgumentOutOfRangeException("column", "Columns for Matrix2x4f run from 0 to 3, inclusive.");
			if (row == 0 && column == 0)
			{
				return new Vector3f(matrix.M22, matrix.M23, matrix.M24);
			}
			else if (row == 0 && column == 1)
			{
				return new Vector3f(matrix.M21, matrix.M23, matrix.M24);
			}
			else if (row == 0 && column == 2)
			{
				return new Vector3f(matrix.M21, matrix.M22, matrix.M24);
			}
			else if (row == 0 && column == 3)
			{
				return new Vector3f(matrix.M21, matrix.M22, matrix.M23);
			}
			else if (row == 1 && column == 0)
			{
				return new Vector3f(matrix.M12, matrix.M13, matrix.M14);
			}
			else if (row == 1 && column == 1)
			{
				return new Vector3f(matrix.M11, matrix.M13, matrix.M14);
			}
			else if (row == 1 && column == 2)
			{
				return new Vector3f(matrix.M11, matrix.M12, matrix.M14);
			}
			else
			{
				return new Vector3f(matrix.M11, matrix.M12, matrix.M13);
			}
		}
		#endregion
		#region Transpose
		/// <summary>
		/// Calculates the transpose of the specified matrix.
		/// </summary>
		/// <param name="matrix">The matrix whose transpose is to be calculated.</param>
		/// <returns>The transpose of the specified matrix.</returns>
		public static Matrix4x2f Transpose(Matrix2x4f matrix)
		{
			return new Matrix4x2f(matrix.M11, matrix.M12, matrix.M13, matrix.M14, matrix.M21, matrix.M22, matrix.M23, matrix.M24);
		}
		#endregion
	}
}
