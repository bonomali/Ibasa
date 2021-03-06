using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;
using Ibasa.Numerics.Geometry;

namespace Ibasa.Numerics
{
	/// <summary>
	/// Represents a eight component vector of floats.
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector8f: IEquatable<Vector8f>, IFormattable
	{
		#region Constants
		/// <summary>
		/// Returns a new <see cref="Vector8f"/> with all of its components equal to zero.
		/// </summary>
		public static readonly Vector8f Zero = new Vector8f(0);
		/// <summary>
		/// Returns a new <see cref="Vector8f"/> with all of its components equal to one.
		/// </summary>
		public static readonly Vector8f One = new Vector8f(1);
		#endregion
		#region Fields
		/// <summary>
		/// The first component of the vector.
		/// </summary>
		public readonly float V0;
		/// <summary>
		/// The second component of the vector.
		/// </summary>
		public readonly float V1;
		/// <summary>
		/// The third component of the vector.
		/// </summary>
		public readonly float V2;
		/// <summary>
		/// The fourth component of the vector.
		/// </summary>
		public readonly float V3;
		/// <summary>
		/// The fifth component of the vector.
		/// </summary>
		public readonly float V4;
		/// <summary>
		/// The sixth component of the vector.
		/// </summary>
		public readonly float V5;
		/// <summary>
		/// The seventh component of the vector.
		/// </summary>
		public readonly float V6;
		/// <summary>
		/// The eighth component of the vector.
		/// </summary>
		public readonly float V7;
		#endregion
		#region Properties
		/// <summary>
		/// Returns the indexed component of this vector.
		/// </summary>
		/// <param name="index">The index of the component.</param>
		/// <returns>The value of the indexed component.</returns>
		public float this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return V0;
					case 1:
						return V1;
					case 2:
						return V2;
					case 3:
						return V3;
					case 4:
						return V4;
					case 5:
						return V5;
					case 6:
						return V6;
					case 7:
						return V7;
					default:
						throw new IndexOutOfRangeException("Indices for Vector8f run from 0 to 7, inclusive.");
				}
			}
		}
		public float[] ToArray()
		{
			return new float[]
			{
				V0, V1, V2, V3, V4, V5, V6, V7
			};
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector8f"/> using the specified value.
		/// </summary>
		/// <param name="value">The value that will be assigned to all components.</param>
		public Vector8f(float value)
		{
			V0 = value;
			V1 = value;
			V2 = value;
			V3 = value;
			V4 = value;
			V5 = value;
			V6 = value;
			V7 = value;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector8f"/> using the specified vector and values.
		/// </summary>
		/// <param name="value">A vector containing the values with which to initialize the first 2 components</param>
		/// <param name="v2">Value for the V2 component of the vector.</param>
		/// <param name="v3">Value for the V3 component of the vector.</param>
		/// <param name="v4">Value for the V4 component of the vector.</param>
		/// <param name="v5">Value for the V5 component of the vector.</param>
		/// <param name="v6">Value for the V6 component of the vector.</param>
		/// <param name="v7">Value for the V7 component of the vector.</param>
		public Vector8f(Vector2f value, float v2, float v3, float v4, float v5, float v6, float v7, float v8, float v9)
		{
			V0 = value.X;
			V1 = value.Y;
			V2 = v2;
			V3 = v3;
			V4 = v4;
			V5 = v5;
			V6 = v6;
			V7 = v7;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector8f"/> using the specified vector and values.
		/// </summary>
		/// <param name="value">A vector containing the values with which to initialize the first 3 components</param>
		/// <param name="v3">Value for the V3 component of the vector.</param>
		/// <param name="v4">Value for the V4 component of the vector.</param>
		/// <param name="v5">Value for the V5 component of the vector.</param>
		/// <param name="v6">Value for the V6 component of the vector.</param>
		/// <param name="v7">Value for the V7 component of the vector.</param>
		public Vector8f(Vector3f value, float v3, float v4, float v5, float v6, float v7, float v8, float v9, float v10)
		{
			V0 = value.X;
			V1 = value.Y;
			V2 = value.Z;
			V3 = v3;
			V4 = v4;
			V5 = v5;
			V6 = v6;
			V7 = v7;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector8f"/> using the specified vector and values.
		/// </summary>
		/// <param name="value">A vector containing the values with which to initialize the first 4 components</param>
		/// <param name="v4">Value for the V4 component of the vector.</param>
		/// <param name="v5">Value for the V5 component of the vector.</param>
		/// <param name="v6">Value for the V6 component of the vector.</param>
		/// <param name="v7">Value for the V7 component of the vector.</param>
		public Vector8f(Vector4f value, float v4, float v5, float v6, float v7, float v8, float v9, float v10, float v11)
		{
			V0 = value.X;
			V1 = value.Y;
			V2 = value.Z;
			V3 = value.W;
			V4 = v4;
			V5 = v5;
			V6 = v6;
			V7 = v7;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector8f"/> using the specified values.
		/// </summary>
		/// <param name="v0">Value for the V0 component of the vector.</param>
		/// <param name="v1">Value for the V1 component of the vector.</param>
		/// <param name="v2">Value for the V2 component of the vector.</param>
		/// <param name="v3">Value for the V3 component of the vector.</param>
		/// <param name="v4">Value for the V4 component of the vector.</param>
		/// <param name="v5">Value for the V5 component of the vector.</param>
		/// <param name="v6">Value for the V6 component of the vector.</param>
		/// <param name="v7">Value for the V7 component of the vector.</param>
		public Vector8f(float v0, float v1, float v2, float v3, float v4, float v5, float v6, float v7)
		{
			V0 = v0;
			V1 = v1;
			V2 = v2;
			V3 = v3;
			V4 = v4;
			V5 = v5;
			V6 = v6;
			V7 = v7;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector8f"/> using the specified array.
		/// </summary>
		/// <param name="array">Array of values for the vector.</param>
		public Vector8f(float[] array)
		{
			if (array.Length < 2)
				throw new ArgumentException("Not enough elements in array.", "array");
			V0 = array[0];
			V1 = array[1];
			V2 = array[2];
			V3 = array[3];
			V4 = array[4];
			V5 = array[5];
			V6 = array[6];
			V7 = array[7];
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector8f"/> using the specified array.
		/// </summary>
		/// <param name="array">Array of values for the vector.</param>
		/// <param name="offset">Offset to start copying values from.</param>
		public Vector8f(float[] array, int offset)
		{
			if (array.Length < 2)
				throw new ArgumentException("Not enough elements in array.", "array");
			V0 = array[offset + 0];
			V1 = array[offset + 1];
			V2 = array[offset + 2];
			V3 = array[offset + 3];
			V4 = array[offset + 4];
			V5 = array[offset + 5];
			V6 = array[offset + 6];
			V7 = array[offset + 7];
		}
		#endregion
		#region Operations
		/// <summary>
		/// Returns the identity of a specified vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The identity of value.</returns>
		public static Vector8f operator +(Vector8f value)
		{
			return value;
		}
		/// <summary>
		/// Returns the additive inverse of a specified vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The negative of value.</returns>
		public static Vector8f operator -(Vector8f value)
		{
			return Vector.Negative(value);
		}
		/// <summary>
		/// Adds two vectors and returns the result.
		/// </summary>
		/// <param name="left">The first value to add.</param>
		/// <param name="right">The second value to add.</param>
		/// <returns>The sum of left and right.</returns>
		public static Vector8f operator +(Vector8f left, Vector8f right)
		{
			return Vector.Add(left, right);
		}
		/// <summary>
		/// Subtracts one vector from another and returns the result.
		/// </summary>
		/// <param name="left">The value to subtract from (the minuend).</param>
		/// <param name="right">The value to subtract (the subtrahend).</param>
		/// <returns>The result of subtracting right from left (the difference).</returns>
		public static Vector8f operator -(Vector8f left, Vector8f right)
		{
			return Vector.Subtract(left, right);
		}
		/// <summary>
		/// Returns the product of a vector and scalar.
		/// </summary>
		/// <param name="left">The vector to multiply.</param>
		/// <param name="right">The scalar to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector8f operator *(Vector8f left, float right)
		{
			return Vector.Multiply(left, right);
		}
		/// <summary>
		/// Returns the product of a scalar and vector.
		/// </summary>
		/// <param name="left">The scalar to multiply.</param>
		/// <param name="right">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector8f operator *(float left, Vector8f right)
		{
			return Vector.Multiply(right, left);
		}
		/// <summary>
		/// Divides a vector by a scalar and returns the result.
		/// </summary>
		/// <param name="left">The vector to be divided (the dividend).</param>
		/// <param name="right">The scalar to divide by (the divisor).</param>
		/// <returns>The result of dividing left by right (the quotient).</returns>
		public static Vector8f operator /(Vector8f left, float right)
		{
			return Vector.Divide(left, right);
		}
		#endregion
		#region Conversions
		/// <summary>
		/// Defines an explicit conversion of a Vector8d value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		public static explicit operator Vector8f(Vector8d value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8h value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		public static implicit operator Vector8f(Vector8h value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8ul value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector8f(Vector8ul value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8l value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		public static implicit operator Vector8f(Vector8l value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8ui value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector8f(Vector8ui value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8i value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		public static implicit operator Vector8f(Vector8i value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8us value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector8f(Vector8us value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8s value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		public static implicit operator Vector8f(Vector8s value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8b value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		public static implicit operator Vector8f(Vector8b value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector8sb value to a Vector8f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector8f.</param>
		/// <returns>A Vector8f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector8f(Vector8sb value)
		{
			return new Vector8f((float)value.V0, (float)value.V1, (float)value.V2, (float)value.V3, (float)value.V4, (float)value.V5, (float)value.V6, (float)value.V7);
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns the hash code for the current <see cref="Vector8f"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return V0.GetHashCode() + V1.GetHashCode() + V2.GetHashCode() + V3.GetHashCode() + V4.GetHashCode() + V5.GetHashCode() + V6.GetHashCode() + V7.GetHashCode();
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// object have the same value.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>true if the obj parameter is a <see cref="Vector8f"/> object or a type capable
		/// of implicit conversion to a <see cref="Vector8f"/> object, and its value
		/// is equal to the current <see cref="Vector8f"/> object; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Vector8f) { return Equals((Vector8f)obj); }
			return false;
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// vector have the same value.
		/// </summary>
		/// <param name="other">The vector to compare.</param>
		/// <returns>true if this vector and value have the same value; otherwise, false.</returns>
		public bool Equals(Vector8f other)
		{
			return this == other;
		}
		/// <summary>
		/// Returns a value that indicates whether two vectors are equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool operator ==(Vector8f left, Vector8f right)
		{
			return left.V0 == right.V0 & left.V1 == right.V1 & left.V2 == right.V2 & left.V3 == right.V3 & left.V4 == right.V4 & left.V5 == right.V5 & left.V6 == right.V6 & left.V7 == right.V7;
		}
		/// <summary>
		/// Returns a value that indicates whether two vectors are not equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <returns>true if the left and right are not equal; otherwise, false.</returns>
		public static bool operator !=(Vector8f left, Vector8f right)
		{
			return left.V0 != right.V0 | left.V1 != right.V1 | left.V2 != right.V2 | left.V3 != right.V3 | left.V4 != right.V4 | left.V5 != right.V5 | left.V6 != right.V6 | left.V7 != right.V7;
		}
		#endregion
		#region ToString
		/// <summary>
		/// Converts the value of the current vector to its equivalent string
		/// representation in Cartesian form.
		/// </summary>
		/// <returns>The string representation of the current instance in Cartesian form.</returns>
		public override string ToString()
		{
			return ToString("G", CultureInfo.CurrentCulture);
		}
		/// <summary>
		/// Converts the value of the current vector to its equivalent string
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
		/// Converts the value of the current vector to its equivalent string
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
		/// Converts the value of the current vector to its equivalent string
		/// representation in Cartesian form by using the specified format and culture-specific
		/// format information for its components.
		/// </summary>
		/// <param name="format">A standard or custom numeric format string.</param>
		/// <returns>The string representation of the current instance in Cartesian form, as specified
		/// by format and provider.</returns>
		/// <exception cref="System.FormatException">format is not a valid format string.</exception>
		public string ToString(string format, IFormatProvider provider)
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", V0.ToString(format, provider), V1.ToString(format, provider), V2.ToString(format, provider), V3.ToString(format, provider), V4.ToString(format, provider), V5.ToString(format, provider), V6.ToString(format, provider), V7.ToString(format, provider));
		}
		#endregion
	}
	/// <summary>
	/// Provides static methods for vector functions.
	/// </summary>
	public static partial class Vector
	{
		#region Binary
		/// <summary>
		/// Writes the given <see cref="Vector8f"/> to an <see cref="Ibasa.IO.BinaryWriter">.
		/// </summary>
		public static void Write(this Ibasa.IO.BinaryWriter writer, Vector8f vector)
		{
			writer.Write(vector.V0);
			writer.Write(vector.V1);
			writer.Write(vector.V2);
			writer.Write(vector.V3);
			writer.Write(vector.V4);
			writer.Write(vector.V5);
			writer.Write(vector.V6);
			writer.Write(vector.V7);
		}
		/// <summary>
		/// Reads a <see cref="Vector8f"/> from an <see cref="Ibasa.IO.BinaryReader">.
		/// </summary>
		public static Vector8f ReadVector8f(this Ibasa.IO.BinaryReader reader)
		{
			return new Vector8f(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}
		#endregion
		#region Operations
		/// <summary>
		/// Returns the additive inverse of a vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The negative of value.</returns>
		public static Vector8f Negative(Vector8f value)
		{
			return new Vector8f(-value.V0, -value.V1, -value.V2, -value.V3, -value.V4, -value.V5, -value.V6, -value.V7);
		}
		/// <summary>
		/// Adds two vectors and returns the result.
		/// </summary>
		/// <param name="left">The first value to add.</param>
		/// <param name="right">The second value to add.</param>
		/// <returns>The sum of left and right.</returns>
		public static Vector8f Add(Vector8f left, Vector8f right)
		{
			return new Vector8f(left.V0 + right.V0, left.V1 + right.V1, left.V2 + right.V2, left.V3 + right.V3, left.V4 + right.V4, left.V5 + right.V5, left.V6 + right.V6, left.V7 + right.V7);
		}
		/// <summary>
		/// Subtracts one vectors from another and returns the result.
		/// </summary>
		/// <param name="left">The value to subtract from (the minuend).</param>
		/// <param name="right">The value to subtract (the subtrahend).</param>
		/// <returns>The result of subtracting right from left (the difference).</returns>
		public static Vector8f Subtract(Vector8f left, Vector8f right)
		{
			return new Vector8f(left.V0 - right.V0, left.V1 - right.V1, left.V2 - right.V2, left.V3 - right.V3, left.V4 - right.V4, left.V5 - right.V5, left.V6 - right.V6, left.V7 - right.V7);
		}
		/// <summary>
		/// Returns the product of a vector and scalar.
		/// </summary>
		/// <param name="vector">The vector to multiply.</param>
		/// <param name="scalar">The scalar to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector8f Multiply(Vector8f vector, float scalar)
		{
			return new Vector8f(vector.V0 * scalar, vector.V1 * scalar, vector.V2 * scalar, vector.V3 * scalar, vector.V4 * scalar, vector.V5 * scalar, vector.V6 * scalar, vector.V7 * scalar);
		}
		/// <summary>
		/// Divides a vector by a scalar and returns the result.
		/// </summary>
		/// <param name="vector">The vector to be divided (the dividend).</param>
		/// <param name="scalar">The scalar to divide by (the divisor).</param>
		/// <returns>The result of dividing left by right (the quotient).</returns>
		public static Vector8f Divide(Vector8f vector, float scalar)
		{
			return new Vector8f(vector.V0 / scalar, vector.V1 / scalar, vector.V2 / scalar, vector.V3 / scalar, vector.V4 / scalar, vector.V5 / scalar, vector.V6 / scalar, vector.V7 / scalar);
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns a value that indicates whether two vectors are equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool Equals(Vector8f left, Vector8f right)
		{
			return left == right;
		}
		#endregion
		#region Products
		/// <summary>
		/// Calculates the dot product (inner product) of two vectors.
		/// </summary>
		/// <param name="left">First source vector.</param>
		/// <param name="right">Second source vector.</param>
		/// <returns>The dot product of the two vectors.</returns>
		public static float Dot(Vector8f left, Vector8f right)
		{
			return left.V0 * right.V0 + left.V1 * right.V1 + left.V2 * right.V2 + left.V3 * right.V3 + left.V4 * right.V4 + left.V5 * right.V5 + left.V6 * right.V6 + left.V7 * right.V7;
		}
		#endregion
		#region Test
		/// <summary>
		/// Determines whether all components of a vector are non-zero.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>true if all components are non-zero; false otherwise.</returns>
		public static bool All(Vector8f value)
		{
			return value.V0 != 0 && value.V1 != 0 && value.V2 != 0 && value.V3 != 0 && value.V4 != 0 && value.V5 != 0 && value.V6 != 0 && value.V7 != 0;
		}
		/// <summary>
		/// Determines whether all components of a vector satisfy a condition.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="predicate">A function to test each component for a condition.</param>
		/// <returns>true if every component of the vector passes the test in the specified
		/// predicate; otherwise, false.</returns>
		public static bool All(Vector8f value, Predicate<float> predicate)
		{
			return predicate(value.V0) && predicate(value.V1) && predicate(value.V2) && predicate(value.V3) && predicate(value.V4) && predicate(value.V5) && predicate(value.V6) && predicate(value.V7);
		}
		/// <summary>
		/// Determines whether any component of a vector is non-zero.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>true if any components are non-zero; false otherwise.</returns>
		public static bool Any(Vector8f value)
		{
			return value.V0 != 0 || value.V1 != 0 || value.V2 != 0 || value.V3 != 0 || value.V4 != 0 || value.V5 != 0 || value.V6 != 0 || value.V7 != 0;
		}
		/// <summary>
		/// Determines whether any components of a vector satisfy a condition.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="predicate">A function to test each component for a condition.</param>
		/// <returns>true if any component of the vector passes the test in the specified
		/// predicate; otherwise, false.</returns>
		public static bool Any(Vector8f value, Predicate<float> predicate)
		{
			return predicate(value.V0) || predicate(value.V1) || predicate(value.V2) || predicate(value.V3) || predicate(value.V4) || predicate(value.V5) || predicate(value.V6) || predicate(value.V7);
		}
		#endregion
		#region Properties
		/// <summary>
		/// Computes the absolute squared value of a vector and returns the result.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The absolute squared value of value.</returns> 
		public static float AbsoluteSquared(Vector8f value)
		{
			return Dot(value, value);
		}
		/// <summary>
		/// Computes the absolute value (or modulus or magnitude) of a vector and returns the result.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The absolute value of value.</returns>
		public static float Absolute(Vector8f value)
		{
			return Functions.Sqrt(AbsoluteSquared(value));
		}
		/// <summary>
		/// Computes the normalized value (or unit) of a vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The normalized value of value.</returns>
		public static Vector8f Normalize(Vector8f value)
		{
			var absolute = Absolute(value);
			if(absolute <= float.Epsilon)
			{
				return Vector8f.Zero;
			}
			else
			{
				return (Vector8f)value / absolute;
			}
		}
		#endregion
		#region Per component
		#region Map
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8d Map(Vector8f value, Func<float, double> mapping)
		{
			return new Vector8d(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8f Map(Vector8f value, Func<float, float> mapping)
		{
			return new Vector8f(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8h Map(Vector8f value, Func<float, Half> mapping)
		{
			return new Vector8h(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8ul Map(Vector8f value, Func<float, ulong> mapping)
		{
			return new Vector8ul(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8l Map(Vector8f value, Func<float, long> mapping)
		{
			return new Vector8l(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8ui Map(Vector8f value, Func<float, uint> mapping)
		{
			return new Vector8ui(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8i Map(Vector8f value, Func<float, int> mapping)
		{
			return new Vector8i(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8us Map(Vector8f value, Func<float, ushort> mapping)
		{
			return new Vector8us(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8s Map(Vector8f value, Func<float, short> mapping)
		{
			return new Vector8s(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8b Map(Vector8f value, Func<float, byte> mapping)
		{
			return new Vector8b(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector8sb Map(Vector8f value, Func<float, sbyte> mapping)
		{
			return new Vector8sb(mapping(value.V0), mapping(value.V1), mapping(value.V2), mapping(value.V3), mapping(value.V4), mapping(value.V5), mapping(value.V6), mapping(value.V7));
		}
		#endregion
		/// <summary>
		/// Multiplys the components of two vectors and returns the result.
		/// </summary>
		/// <param name="left">The first vector to modulate.</param>
		/// <param name="right">The second vector to modulate.</param>
		/// <returns>The result of multiplying each component of left by the matching component in right.</returns>
		public static Vector8f Modulate(Vector8f left, Vector8f right)
		{
			return new Vector8f(left.V0 * right.V0, left.V1 * right.V1, left.V2 * right.V2, left.V3 * right.V3, left.V4 * right.V4, left.V5 * right.V5, left.V6 * right.V6, left.V7 * right.V7);
		}
		/// <summary>
		/// Returns the absolute value (per component).
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The absolute value (per component) of value.</returns>
		public static Vector8f Abs(Vector8f value)
		{
			return new Vector8f(Functions.Abs(value.V0), Functions.Abs(value.V1), Functions.Abs(value.V2), Functions.Abs(value.V3), Functions.Abs(value.V4), Functions.Abs(value.V5), Functions.Abs(value.V6), Functions.Abs(value.V7));
		}
		/// <summary>
		/// Returns a vector that contains the lowest value from each pair of components.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The lowest of each component in left and the matching component in right.</returns>
		public static Vector8f Min(Vector8f value1, Vector8f value2)
		{
			return new Vector8f(Functions.Min(value1.V0, value2.V0), Functions.Min(value1.V1, value2.V1), Functions.Min(value1.V2, value2.V2), Functions.Min(value1.V3, value2.V3), Functions.Min(value1.V4, value2.V4), Functions.Min(value1.V5, value2.V5), Functions.Min(value1.V6, value2.V6), Functions.Min(value1.V7, value2.V7));
		}
		/// <summary>
		/// Returns a vector that contains the highest value from each pair of components.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The highest of each component in left and the matching component in right.</returns>
		public static Vector8f Max(Vector8f value1, Vector8f value2)
		{
			return new Vector8f(Functions.Max(value1.V0, value2.V0), Functions.Max(value1.V1, value2.V1), Functions.Max(value1.V2, value2.V2), Functions.Max(value1.V3, value2.V3), Functions.Max(value1.V4, value2.V4), Functions.Max(value1.V5, value2.V5), Functions.Max(value1.V6, value2.V6), Functions.Max(value1.V7, value2.V7));
		}
		/// <summary>
		/// Constrains each component to a given range.
		/// </summary>
		/// <param name="value">A vector to constrain.</param>
		/// <param name="min">The minimum values for each component.</param>
		/// <param name="max">The maximum values for each component.</param>
		/// <returns>A vector with each component constrained to the given range.</returns>
		public static Vector8f Clamp(Vector8f value, Vector8f min, Vector8f max)
		{
			return new Vector8f(Functions.Clamp(value.V0, min.V0, max.V0), Functions.Clamp(value.V1, min.V1, max.V1), Functions.Clamp(value.V2, min.V2, max.V2), Functions.Clamp(value.V3, min.V3, max.V3), Functions.Clamp(value.V4, min.V4, max.V4), Functions.Clamp(value.V5, min.V5, max.V5), Functions.Clamp(value.V6, min.V6, max.V6), Functions.Clamp(value.V7, min.V7, max.V7));
		}
		/// <summary>
		/// Constrains each component to the range 0 to 1.
		/// </summary>
		/// <param name="value">A vector to saturate.</param>
		/// <returns>A vector with each component constrained to the range 0 to 1.</returns>
		public static Vector8f Saturate(Vector8f value)
		{
			return new Vector8f(Functions.Saturate(value.V0), Functions.Saturate(value.V1), Functions.Saturate(value.V2), Functions.Saturate(value.V3), Functions.Saturate(value.V4), Functions.Saturate(value.V5), Functions.Saturate(value.V6), Functions.Saturate(value.V7));
		}
		/// <summary>
		/// Returns a vector where each component is the smallest integral value that
		/// is greater than or equal to the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The ceiling of value.</returns>
		public static Vector8f Ceiling(Vector8f value)
		{
			return new Vector8f(Functions.Ceiling(value.V0), Functions.Ceiling(value.V1), Functions.Ceiling(value.V2), Functions.Ceiling(value.V3), Functions.Ceiling(value.V4), Functions.Ceiling(value.V5), Functions.Ceiling(value.V6), Functions.Ceiling(value.V7));
		}
		/// <summary>
		/// Returns a vector where each component is the largest integral value that
		/// is less than or equal to the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The floor of value.</returns>
		public static Vector8f Floor(Vector8f value)
		{
			return new Vector8f(Functions.Floor(value.V0), Functions.Floor(value.V1), Functions.Floor(value.V2), Functions.Floor(value.V3), Functions.Floor(value.V4), Functions.Floor(value.V5), Functions.Floor(value.V6), Functions.Floor(value.V7));
		}
		/// <summary>
		/// Returns a vector where each component is the integral part of the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The integral of value.</returns>
		public static Vector8f Truncate(Vector8f value)
		{
			return new Vector8f(Functions.Truncate(value.V0), Functions.Truncate(value.V1), Functions.Truncate(value.V2), Functions.Truncate(value.V3), Functions.Truncate(value.V4), Functions.Truncate(value.V5), Functions.Truncate(value.V6), Functions.Truncate(value.V7));
		}
		/// <summary>
		/// Returns a vector where each component is the fractional part of the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The fractional of value.</returns>
		public static Vector8f Fractional(Vector8f value)
		{
			return new Vector8f(Functions.Fractional(value.V0), Functions.Fractional(value.V1), Functions.Fractional(value.V2), Functions.Fractional(value.V3), Functions.Fractional(value.V4), Functions.Fractional(value.V5), Functions.Fractional(value.V6), Functions.Fractional(value.V7));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector8f Round(Vector8f value)
		{
			return new Vector8f(Functions.Round(value.V0), Functions.Round(value.V1), Functions.Round(value.V2), Functions.Round(value.V3), Functions.Round(value.V4), Functions.Round(value.V5), Functions.Round(value.V6), Functions.Round(value.V7));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector8f Round(Vector8f value, int digits)
		{
			return new Vector8f(Functions.Round(value.V0, digits), Functions.Round(value.V1, digits), Functions.Round(value.V2, digits), Functions.Round(value.V3, digits), Functions.Round(value.V4, digits), Functions.Round(value.V5, digits), Functions.Round(value.V6, digits), Functions.Round(value.V7, digits));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector8f Round(Vector8f value, MidpointRounding mode)
		{
			return new Vector8f(Functions.Round(value.V0, mode), Functions.Round(value.V1, mode), Functions.Round(value.V2, mode), Functions.Round(value.V3, mode), Functions.Round(value.V4, mode), Functions.Round(value.V5, mode), Functions.Round(value.V6, mode), Functions.Round(value.V7, mode));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector8f Round(Vector8f value, int digits, MidpointRounding mode)
		{
			return new Vector8f(Functions.Round(value.V0, digits, mode), Functions.Round(value.V1, digits, mode), Functions.Round(value.V2, digits, mode), Functions.Round(value.V3, digits, mode), Functions.Round(value.V4, digits, mode), Functions.Round(value.V5, digits, mode), Functions.Round(value.V6, digits, mode), Functions.Round(value.V7, digits, mode));
		}
		/// <summary>
		/// Calculates the reciprocal of each component in the vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>A vector with the reciprocal of each of values components.</returns>
		public static Vector8f Reciprocal(Vector8f value)
		{
			return new Vector8f(1 / value.V0, 1 / value.V1, 1 / value.V2, 1 / value.V3, 1 / value.V4, 1 / value.V5, 1 / value.V6, 1 / value.V7);
		}
		#endregion
		#region Coordinate spaces
		#endregion
		#region Barycentric, Reflect, Refract
		/// <summary>
		/// Returns the Cartesian coordinate for one axis of a point that is defined
		/// by a given triangle and two normalized barycentric (areal) coordinates.
		/// </summary>
		/// <param name="value1">The coordinate of vertex 1 of the defining triangle.</param>
		/// <param name="value2">The coordinate of vertex 2 of the defining triangle.</param>
		/// <param name="value3">The coordinate of vertex 3 of the defining triangle.</param>
		/// <param name="amount1">The normalized barycentric (areal) coordinate b2, equal to the weighting
		/// factor for vertex 2, the coordinate of which is specified in value2.</param>
		/// <param name="amount2">The normalized barycentric (areal) coordinate b3, equal to the weighting
		/// factor for vertex 3, the coordinate of which is specified in value3.</param>
		/// <returns>Cartesian coordinate of the specified point.</returns>
		public static Vector8f Barycentric(Vector8f value1, Vector8f value2, Vector8f value3, float amount1, float amount2)
		{
			return ((1 - amount1 - amount2) * value1) + (amount1 * value2) + (amount2 * value3);
		}
		/// <summary>
		/// Returns the reflection of a vector off a surface that has the specified normal.
		/// </summary>
		/// <param name="vector">The source vector.</param>
		/// <param name="normal">Normal of the surface.</param>
		/// <returns>The reflected vector.</returns>
		/// <remarks>Reflect only gives the direction of a reflection off a surface, it does not determine
		/// whether the original vector was close enough to the surface to hit it.</remarks>
		public static Vector8f Reflect(Vector8f vector, Vector8f normal)
		{
			return vector - ((2 * Dot(vector, normal)) * normal);
		}
		/// <summary>
		/// Returns the refraction of a vector off a surface that has the specified normal, and refractive index.
		/// </summary>
		/// <param name="vector">The source vector.</param>
		/// <param name="normal">Normal of the surface.</param>
		/// <param name="index">The refractive index, destination index over source index.</param>
		/// <returns>The refracted vector.</returns>
		/// <remarks>Refract only gives the direction of a refraction off a surface, it does not determine
		/// whether the original vector was close enough to the surface to hit it.</remarks>
		public static Vector8f Refract(Vector8f vector, Vector8f normal, float index)
		{
			var cos1 = Dot(vector, normal);
			var radicand = 1 - (index * index) * (1 - (cos1 * cos1));
			if (radicand < 0)
			{
				return Vector8f.Zero;
			}
			return (index * vector) + ((Functions.Sqrt(radicand) - index * cos1) * normal);
		}
		#endregion
		#region Interpolation
		/// <summary>
		/// Performs a linear interpolation between two values.
		/// </summary>
		/// <param name="value1">First value.</param>
		/// <param name="value2">Second value.</param>
		/// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="value2"/>.</param>
		/// <returns>The linear interpolation of the two values.</returns>
		public static Vector8f Lerp(Vector8f value1, Vector8f value2, float amount)
		{
			return (1 - amount) * value1 + amount * value2;
		}
		#endregion
	}
}
