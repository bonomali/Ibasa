using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;
using Ibasa.Numerics.Geometry;

namespace Ibasa.Numerics
{
	/// <summary>
	/// Represents a two component vector of floats, of the form (X, Y).
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector2f: IEquatable<Vector2f>, IFormattable
	{
		#region Constants
		/// <summary>
		/// Returns a new <see cref="Vector2f"/> with all of its components equal to zero.
		/// </summary>
		public static readonly Vector2f Zero = new Vector2f(0);
		/// <summary>
		/// Returns a new <see cref="Vector2f"/> with all of its components equal to one.
		/// </summary>
		public static readonly Vector2f One = new Vector2f(1);
		/// <summary>
		/// Returns the X unit <see cref="Vector2f"/> (1, 0).
		/// </summary>
		public static readonly Vector2f UnitX = new Vector2f(1, 0);
		/// <summary>
		/// Returns the Y unit <see cref="Vector2f"/> (0, 1).
		/// </summary>
		public static readonly Vector2f UnitY = new Vector2f(0, 1);
		#endregion
		#region Fields
		/// <summary>
		/// The X component of the vector.
		/// </summary>
		public readonly float X;
		/// <summary>
		/// The Y component of the vector.
		/// </summary>
		public readonly float Y;
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
						return X;
					case 1:
						return Y;
					default:
						throw new IndexOutOfRangeException("Indices for Vector2f run from 0 to 1, inclusive.");
				}
			}
		}
		public float[] ToArray()
		{
			return new float[]
			{
				X, Y
			};
		}
		#region Swizzles
		/// <summary>
		/// Returns the vector (X, X).
		/// </summary>
		public Vector2f XX
		{
			get
			{
				return new Vector2f(X, X);
			}
		}
		/// <summary>
		/// Returns the vector (X, Y).
		/// </summary>
		public Vector2f XY
		{
			get
			{
				return new Vector2f(X, Y);
			}
		}
		/// <summary>
		/// Returns the vector (Y, X).
		/// </summary>
		public Vector2f YX
		{
			get
			{
				return new Vector2f(Y, X);
			}
		}
		/// <summary>
		/// Returns the vector (Y, Y).
		/// </summary>
		public Vector2f YY
		{
			get
			{
				return new Vector2f(Y, Y);
			}
		}
		/// <summary>
		/// Returns the vector (X, X, X).
		/// </summary>
		public Vector3f XXX
		{
			get
			{
				return new Vector3f(X, X, X);
			}
		}
		/// <summary>
		/// Returns the vector (X, X, Y).
		/// </summary>
		public Vector3f XXY
		{
			get
			{
				return new Vector3f(X, X, Y);
			}
		}
		/// <summary>
		/// Returns the vector (X, Y, X).
		/// </summary>
		public Vector3f XYX
		{
			get
			{
				return new Vector3f(X, Y, X);
			}
		}
		/// <summary>
		/// Returns the vector (X, Y, Y).
		/// </summary>
		public Vector3f XYY
		{
			get
			{
				return new Vector3f(X, Y, Y);
			}
		}
		/// <summary>
		/// Returns the vector (Y, X, X).
		/// </summary>
		public Vector3f YXX
		{
			get
			{
				return new Vector3f(Y, X, X);
			}
		}
		/// <summary>
		/// Returns the vector (Y, X, Y).
		/// </summary>
		public Vector3f YXY
		{
			get
			{
				return new Vector3f(Y, X, Y);
			}
		}
		/// <summary>
		/// Returns the vector (Y, Y, X).
		/// </summary>
		public Vector3f YYX
		{
			get
			{
				return new Vector3f(Y, Y, X);
			}
		}
		/// <summary>
		/// Returns the vector (Y, Y, Y).
		/// </summary>
		public Vector3f YYY
		{
			get
			{
				return new Vector3f(Y, Y, Y);
			}
		}
		/// <summary>
		/// Returns the vector (X, X, X, X).
		/// </summary>
		public Vector4f XXXX
		{
			get
			{
				return new Vector4f(X, X, X, X);
			}
		}
		/// <summary>
		/// Returns the vector (X, X, X, Y).
		/// </summary>
		public Vector4f XXXY
		{
			get
			{
				return new Vector4f(X, X, X, Y);
			}
		}
		/// <summary>
		/// Returns the vector (X, X, Y, X).
		/// </summary>
		public Vector4f XXYX
		{
			get
			{
				return new Vector4f(X, X, Y, X);
			}
		}
		/// <summary>
		/// Returns the vector (X, X, Y, Y).
		/// </summary>
		public Vector4f XXYY
		{
			get
			{
				return new Vector4f(X, X, Y, Y);
			}
		}
		/// <summary>
		/// Returns the vector (X, Y, X, X).
		/// </summary>
		public Vector4f XYXX
		{
			get
			{
				return new Vector4f(X, Y, X, X);
			}
		}
		/// <summary>
		/// Returns the vector (X, Y, X, Y).
		/// </summary>
		public Vector4f XYXY
		{
			get
			{
				return new Vector4f(X, Y, X, Y);
			}
		}
		/// <summary>
		/// Returns the vector (X, Y, Y, X).
		/// </summary>
		public Vector4f XYYX
		{
			get
			{
				return new Vector4f(X, Y, Y, X);
			}
		}
		/// <summary>
		/// Returns the vector (X, Y, Y, Y).
		/// </summary>
		public Vector4f XYYY
		{
			get
			{
				return new Vector4f(X, Y, Y, Y);
			}
		}
		/// <summary>
		/// Returns the vector (Y, X, X, X).
		/// </summary>
		public Vector4f YXXX
		{
			get
			{
				return new Vector4f(Y, X, X, X);
			}
		}
		/// <summary>
		/// Returns the vector (Y, X, X, Y).
		/// </summary>
		public Vector4f YXXY
		{
			get
			{
				return new Vector4f(Y, X, X, Y);
			}
		}
		/// <summary>
		/// Returns the vector (Y, X, Y, X).
		/// </summary>
		public Vector4f YXYX
		{
			get
			{
				return new Vector4f(Y, X, Y, X);
			}
		}
		/// <summary>
		/// Returns the vector (Y, X, Y, Y).
		/// </summary>
		public Vector4f YXYY
		{
			get
			{
				return new Vector4f(Y, X, Y, Y);
			}
		}
		/// <summary>
		/// Returns the vector (Y, Y, X, X).
		/// </summary>
		public Vector4f YYXX
		{
			get
			{
				return new Vector4f(Y, Y, X, X);
			}
		}
		/// <summary>
		/// Returns the vector (Y, Y, X, Y).
		/// </summary>
		public Vector4f YYXY
		{
			get
			{
				return new Vector4f(Y, Y, X, Y);
			}
		}
		/// <summary>
		/// Returns the vector (Y, Y, Y, X).
		/// </summary>
		public Vector4f YYYX
		{
			get
			{
				return new Vector4f(Y, Y, Y, X);
			}
		}
		/// <summary>
		/// Returns the vector (Y, Y, Y, Y).
		/// </summary>
		public Vector4f YYYY
		{
			get
			{
				return new Vector4f(Y, Y, Y, Y);
			}
		}
		#endregion
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector2f"/> using the specified value.
		/// </summary>
		/// <param name="value">The value that will be assigned to all components.</param>
		public Vector2f(float value)
		{
			X = value;
			Y = value;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector2f"/> using the specified values.
		/// </summary>
		/// <param name="x">Value for the X component of the vector.</param>
		/// <param name="y">Value for the Y component of the vector.</param>
		public Vector2f(float x, float y)
		{
			X = x;
			Y = y;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector2f"/> using the specified array.
		/// </summary>
		/// <param name="array">Array of values for the vector.</param>
		public Vector2f(float[] array)
		{
			if (array.Length < 2)
				throw new ArgumentException("Not enough elements in array.", "array");
			X = array[0];
			Y = array[1];
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vector2f"/> using the specified array.
		/// </summary>
		/// <param name="array">Array of values for the vector.</param>
		/// <param name="offset">Offset to start copying values from.</param>
		public Vector2f(float[] array, int offset)
		{
			if (array.Length < 2)
				throw new ArgumentException("Not enough elements in array.", "array");
			X = array[offset + 0];
			Y = array[offset + 1];
		}
		#endregion
		#region Operations
		/// <summary>
		/// Returns the identity of a specified vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The identity of value.</returns>
		public static Vector2f operator +(Vector2f value)
		{
			return value;
		}
		/// <summary>
		/// Returns the additive inverse of a specified vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The negative of value.</returns>
		public static Vector2f operator -(Vector2f value)
		{
			return Vector.Negative(value);
		}
		/// <summary>
		/// Adds two vectors and returns the result.
		/// </summary>
		/// <param name="left">The first value to add.</param>
		/// <param name="right">The second value to add.</param>
		/// <returns>The sum of left and right.</returns>
		public static Vector2f operator +(Vector2f left, Vector2f right)
		{
			return Vector.Add(left, right);
		}
		/// <summary>
		/// Subtracts one vector from another and returns the result.
		/// </summary>
		/// <param name="left">The value to subtract from (the minuend).</param>
		/// <param name="right">The value to subtract (the subtrahend).</param>
		/// <returns>The result of subtracting right from left (the difference).</returns>
		public static Vector2f operator -(Vector2f left, Vector2f right)
		{
			return Vector.Subtract(left, right);
		}
		/// <summary>
		/// Returns the product of a vector and scalar.
		/// </summary>
		/// <param name="left">The vector to multiply.</param>
		/// <param name="right">The scalar to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector2f operator *(Vector2f left, float right)
		{
			return Vector.Multiply(left, right);
		}
		/// <summary>
		/// Returns the product of a scalar and vector.
		/// </summary>
		/// <param name="left">The scalar to multiply.</param>
		/// <param name="right">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector2f operator *(float left, Vector2f right)
		{
			return Vector.Multiply(right, left);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="left">The matrix to multiply.</param>
		/// <param name="right">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector2f operator *(Matrix2x2f left, Vector2f right)
		{
			return new Vector2f(left.M11 * right.X + left.M12 * right.Y, left.M21 * right.X + left.M22 * right.Y);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="right">The vector to multiply.</param>
		/// <param name="left">The matrix to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector2f operator *(Vector2f left, Matrix2x2f right)
		{
			return new Vector2f(left.X * right.M11 + left.Y * right.M21, left.X * right.M12 + left.Y * right.M22);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="left">The matrix to multiply.</param>
		/// <param name="right">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector3f operator *(Matrix3x2f left, Vector2f right)
		{
			return new Vector3f(left.M11 * right.X + left.M12 * right.Y, left.M21 * right.X + left.M22 * right.Y, left.M31 * right.X + left.M32 * right.Y);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="right">The vector to multiply.</param>
		/// <param name="left">The matrix to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector3f operator *(Vector2f left, Matrix2x3f right)
		{
			return new Vector3f(left.X * right.M11 + left.Y * right.M21, left.X * right.M12 + left.Y * right.M22, left.X * right.M13 + left.Y * right.M23);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="left">The matrix to multiply.</param>
		/// <param name="right">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector4f operator *(Matrix4x2f left, Vector2f right)
		{
			return new Vector4f(left.M11 * right.X + left.M12 * right.Y, left.M21 * right.X + left.M22 * right.Y, left.M31 * right.X + left.M32 * right.Y, left.M41 * right.X + left.M42 * right.Y);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="right">The vector to multiply.</param>
		/// <param name="left">The matrix to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector4f operator *(Vector2f left, Matrix2x4f right)
		{
			return new Vector4f(left.X * right.M11 + left.Y * right.M21, left.X * right.M12 + left.Y * right.M22, left.X * right.M13 + left.Y * right.M23, left.X * right.M14 + left.Y * right.M24);
		}
		/// <summary>
		/// Divides a vector by a scalar and returns the result.
		/// </summary>
		/// <param name="left">The vector to be divided (the dividend).</param>
		/// <param name="right">The scalar to divide by (the divisor).</param>
		/// <returns>The result of dividing left by right (the quotient).</returns>
		public static Vector2f operator /(Vector2f left, float right)
		{
			return Vector.Divide(left, right);
		}
		#endregion
		#region Conversions
		/// <summary>
		/// Defines an explicit conversion of a Vector2d value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		public static explicit operator Vector2f(Vector2d value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2h value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		public static implicit operator Vector2f(Vector2h value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2ul value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector2f(Vector2ul value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2l value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		public static implicit operator Vector2f(Vector2l value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2ui value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector2f(Vector2ui value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2i value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		public static implicit operator Vector2f(Vector2i value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2us value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector2f(Vector2us value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2s value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		public static implicit operator Vector2f(Vector2s value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2b value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		public static implicit operator Vector2f(Vector2b value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		/// <summary>
		/// Defines an implicit conversion of a Vector2sb value to a Vector2f.
		/// </summary>
		/// <param name="value">The value to convert to a Vector2f.</param>
		/// <returns>A Vector2f that has all components equal to value.</returns>
		[CLSCompliant(false)]
		public static implicit operator Vector2f(Vector2sb value)
		{
			return new Vector2f((float)value.X, (float)value.Y);
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns the hash code for the current <see cref="Vector2f"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return X.GetHashCode() + Y.GetHashCode();
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// object have the same value.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>true if the obj parameter is a <see cref="Vector2f"/> object or a type capable
		/// of implicit conversion to a <see cref="Vector2f"/> object, and its value
		/// is equal to the current <see cref="Vector2f"/> object; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Vector2f) { return Equals((Vector2f)obj); }
			return false;
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// vector have the same value.
		/// </summary>
		/// <param name="other">The vector to compare.</param>
		/// <returns>true if this vector and value have the same value; otherwise, false.</returns>
		public bool Equals(Vector2f other)
		{
			return this == other;
		}
		/// <summary>
		/// Returns a value that indicates whether two vectors are equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool operator ==(Vector2f left, Vector2f right)
		{
			return left.X == right.X & left.Y == right.Y;
		}
		/// <summary>
		/// Returns a value that indicates whether two vectors are not equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <returns>true if the left and right are not equal; otherwise, false.</returns>
		public static bool operator !=(Vector2f left, Vector2f right)
		{
			return left.X != right.X | left.Y != right.Y;
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
			return String.Format("({0}, {1})", X.ToString(format, provider), Y.ToString(format, provider));
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
		/// Writes the given <see cref="Vector2f"/> to an <see cref="Ibasa.IO.BinaryWriter">.
		/// </summary>
		public static void Write(this Ibasa.IO.BinaryWriter writer, Vector2f vector)
		{
			writer.Write(vector.X);
			writer.Write(vector.Y);
		}
		/// <summary>
		/// Reads a <see cref="Vector2f"/> from an <see cref="Ibasa.IO.BinaryReader">.
		/// </summary>
		public static Vector2f ReadVector2f(this Ibasa.IO.BinaryReader reader)
		{
			return new Vector2f(reader.ReadSingle(), reader.ReadSingle());
		}
		#endregion
		#region Operations
		/// <summary>
		/// Returns the additive inverse of a vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The negative of value.</returns>
		public static Vector2f Negative(Vector2f value)
		{
			return new Vector2f(-value.X, -value.Y);
		}
		/// <summary>
		/// Adds two vectors and returns the result.
		/// </summary>
		/// <param name="left">The first value to add.</param>
		/// <param name="right">The second value to add.</param>
		/// <returns>The sum of left and right.</returns>
		public static Vector2f Add(Vector2f left, Vector2f right)
		{
			return new Vector2f(left.X + right.X, left.Y + right.Y);
		}
		/// <summary>
		/// Subtracts one vectors from another and returns the result.
		/// </summary>
		/// <param name="left">The value to subtract from (the minuend).</param>
		/// <param name="right">The value to subtract (the subtrahend).</param>
		/// <returns>The result of subtracting right from left (the difference).</returns>
		public static Vector2f Subtract(Vector2f left, Vector2f right)
		{
			return new Vector2f(left.X - right.X, left.Y - right.Y);
		}
		/// <summary>
		/// Returns the product of a vector and scalar.
		/// </summary>
		/// <param name="vector">The vector to multiply.</param>
		/// <param name="scalar">The scalar to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector2f Multiply(Vector2f vector, float scalar)
		{
			return new Vector2f(vector.X * scalar, vector.Y * scalar);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="matrix">The matrix to multiply.</param>
		/// <param name="vector">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector2f Multiply(Matrix2x2f matrix, Vector2f vector)
		{
			return new Vector2f(matrix.M11 * vector.X + matrix.M12 * vector.Y, matrix.M21 * vector.X + matrix.M22 * vector.Y);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="matrix">The matrix to multiply.</param>
		/// <param name="vector">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector3f Multiply(Matrix3x2f matrix, Vector2f vector)
		{
			return new Vector3f(matrix.M11 * vector.X + matrix.M12 * vector.Y, matrix.M21 * vector.X + matrix.M22 * vector.Y, matrix.M31 * vector.X + matrix.M32 * vector.Y);
		}
		/// <summary>
		/// Returns the product of a matrix and vector.
		/// </summary>
		/// <param name="matrix">The matrix to multiply.</param>
		/// <param name="vector">The vector to multiply.</param>
		/// <returns>The product of the left and right parameters.</returns>
		public static Vector4f Multiply(Matrix4x2f matrix, Vector2f vector)
		{
			return new Vector4f(matrix.M11 * vector.X + matrix.M12 * vector.Y, matrix.M21 * vector.X + matrix.M22 * vector.Y, matrix.M31 * vector.X + matrix.M32 * vector.Y, matrix.M41 * vector.X + matrix.M42 * vector.Y);
		}
		/// <summary>
		/// Divides a vector by a scalar and returns the result.
		/// </summary>
		/// <param name="vector">The vector to be divided (the dividend).</param>
		/// <param name="scalar">The scalar to divide by (the divisor).</param>
		/// <returns>The result of dividing left by right (the quotient).</returns>
		public static Vector2f Divide(Vector2f vector, float scalar)
		{
			return new Vector2f(vector.X / scalar, vector.Y / scalar);
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns a value that indicates whether two vectors are equal.
		/// </summary>
		/// <param name="left">The first vector to compare.</param>
		/// <param name="right">The second vector to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool Equals(Vector2f left, Vector2f right)
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
		public static float Dot(Vector2f left, Vector2f right)
		{
			return left.X * right.X + left.Y * right.Y;
		}
		#endregion
		#region Test
		/// <summary>
		/// Determines whether all components of a vector are non-zero.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>true if all components are non-zero; false otherwise.</returns>
		public static bool All(Vector2f value)
		{
			return value.X != 0 && value.Y != 0;
		}
		/// <summary>
		/// Determines whether all components of a vector satisfy a condition.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="predicate">A function to test each component for a condition.</param>
		/// <returns>true if every component of the vector passes the test in the specified
		/// predicate; otherwise, false.</returns>
		public static bool All(Vector2f value, Predicate<float> predicate)
		{
			return predicate(value.X) && predicate(value.Y);
		}
		/// <summary>
		/// Determines whether any component of a vector is non-zero.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>true if any components are non-zero; false otherwise.</returns>
		public static bool Any(Vector2f value)
		{
			return value.X != 0 || value.Y != 0;
		}
		/// <summary>
		/// Determines whether any components of a vector satisfy a condition.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="predicate">A function to test each component for a condition.</param>
		/// <returns>true if any component of the vector passes the test in the specified
		/// predicate; otherwise, false.</returns>
		public static bool Any(Vector2f value, Predicate<float> predicate)
		{
			return predicate(value.X) || predicate(value.Y);
		}
		#endregion
		#region Properties
		/// <summary>
		/// Computes the absolute squared value of a vector and returns the result.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The absolute squared value of value.</returns> 
		public static float AbsoluteSquared(Vector2f value)
		{
			return Dot(value, value);
		}
		/// <summary>
		/// Computes the absolute value (or modulus or magnitude) of a vector and returns the result.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The absolute value of value.</returns>
		public static float Absolute(Vector2f value)
		{
			return Functions.Sqrt(AbsoluteSquared(value));
		}
		/// <summary>
		/// Computes the normalized value (or unit) of a vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The normalized value of value.</returns>
		public static Vector2f Normalize(Vector2f value)
		{
			var absolute = Absolute(value);
			if(absolute <= float.Epsilon)
			{
				return Vector2f.Zero;
			}
			else
			{
				return (Vector2f)value / absolute;
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
		public static Vector2d Map(Vector2f value, Func<float, double> mapping)
		{
			return new Vector2d(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2f Map(Vector2f value, Func<float, float> mapping)
		{
			return new Vector2f(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2h Map(Vector2f value, Func<float, Half> mapping)
		{
			return new Vector2h(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2ul Map(Vector2f value, Func<float, ulong> mapping)
		{
			return new Vector2ul(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2l Map(Vector2f value, Func<float, long> mapping)
		{
			return new Vector2l(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2ui Map(Vector2f value, Func<float, uint> mapping)
		{
			return new Vector2ui(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2i Map(Vector2f value, Func<float, int> mapping)
		{
			return new Vector2i(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2us Map(Vector2f value, Func<float, ushort> mapping)
		{
			return new Vector2us(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2s Map(Vector2f value, Func<float, short> mapping)
		{
			return new Vector2s(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2b Map(Vector2f value, Func<float, byte> mapping)
		{
			return new Vector2b(mapping(value.X), mapping(value.Y));
		}
		/// <summary>
		/// Maps the components of a vector and returns the result.
		/// </summary>
		/// <param name="value">The vector to map.</param>
		/// <param name="mapping">A mapping function to apply to each component.</param>
		/// <returns>The result of mapping each component of value.</returns>
		public static Vector2sb Map(Vector2f value, Func<float, sbyte> mapping)
		{
			return new Vector2sb(mapping(value.X), mapping(value.Y));
		}
		#endregion
		/// <summary>
		/// Multiplys the components of two vectors and returns the result.
		/// </summary>
		/// <param name="left">The first vector to modulate.</param>
		/// <param name="right">The second vector to modulate.</param>
		/// <returns>The result of multiplying each component of left by the matching component in right.</returns>
		public static Vector2f Modulate(Vector2f left, Vector2f right)
		{
			return new Vector2f(left.X * right.X, left.Y * right.Y);
		}
		/// <summary>
		/// Returns the absolute value (per component).
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The absolute value (per component) of value.</returns>
		public static Vector2f Abs(Vector2f value)
		{
			return new Vector2f(Functions.Abs(value.X), Functions.Abs(value.Y));
		}
		/// <summary>
		/// Returns a vector that contains the lowest value from each pair of components.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The lowest of each component in left and the matching component in right.</returns>
		public static Vector2f Min(Vector2f value1, Vector2f value2)
		{
			return new Vector2f(Functions.Min(value1.X, value2.X), Functions.Min(value1.Y, value2.Y));
		}
		/// <summary>
		/// Returns a vector that contains the highest value from each pair of components.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The highest of each component in left and the matching component in right.</returns>
		public static Vector2f Max(Vector2f value1, Vector2f value2)
		{
			return new Vector2f(Functions.Max(value1.X, value2.X), Functions.Max(value1.Y, value2.Y));
		}
		/// <summary>
		/// Constrains each component to a given range.
		/// </summary>
		/// <param name="value">A vector to constrain.</param>
		/// <param name="min">The minimum values for each component.</param>
		/// <param name="max">The maximum values for each component.</param>
		/// <returns>A vector with each component constrained to the given range.</returns>
		public static Vector2f Clamp(Vector2f value, Vector2f min, Vector2f max)
		{
			return new Vector2f(Functions.Clamp(value.X, min.X, max.X), Functions.Clamp(value.Y, min.Y, max.Y));
		}
		/// <summary>
		/// Constrains each component to the range 0 to 1.
		/// </summary>
		/// <param name="value">A vector to saturate.</param>
		/// <returns>A vector with each component constrained to the range 0 to 1.</returns>
		public static Vector2f Saturate(Vector2f value)
		{
			return new Vector2f(Functions.Saturate(value.X), Functions.Saturate(value.Y));
		}
		/// <summary>
		/// Returns a vector where each component is the smallest integral value that
		/// is greater than or equal to the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The ceiling of value.</returns>
		public static Vector2f Ceiling(Vector2f value)
		{
			return new Vector2f(Functions.Ceiling(value.X), Functions.Ceiling(value.Y));
		}
		/// <summary>
		/// Returns a vector where each component is the largest integral value that
		/// is less than or equal to the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The floor of value.</returns>
		public static Vector2f Floor(Vector2f value)
		{
			return new Vector2f(Functions.Floor(value.X), Functions.Floor(value.Y));
		}
		/// <summary>
		/// Returns a vector where each component is the integral part of the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The integral of value.</returns>
		public static Vector2f Truncate(Vector2f value)
		{
			return new Vector2f(Functions.Truncate(value.X), Functions.Truncate(value.Y));
		}
		/// <summary>
		/// Returns a vector where each component is the fractional part of the specified component.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The fractional of value.</returns>
		public static Vector2f Fractional(Vector2f value)
		{
			return new Vector2f(Functions.Fractional(value.X), Functions.Fractional(value.Y));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector2f Round(Vector2f value)
		{
			return new Vector2f(Functions.Round(value.X), Functions.Round(value.Y));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector2f Round(Vector2f value, int digits)
		{
			return new Vector2f(Functions.Round(value.X, digits), Functions.Round(value.Y, digits));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector2f Round(Vector2f value, MidpointRounding mode)
		{
			return new Vector2f(Functions.Round(value.X, mode), Functions.Round(value.Y, mode));
		}
		/// <summary>
		/// Returns a vector where each component is rounded to the nearest integral value.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <param name="mode">Specification for how to round value if it is midway between two other numbers.</param>
		/// <returns>The result of rounding value.</returns>
		public static Vector2f Round(Vector2f value, int digits, MidpointRounding mode)
		{
			return new Vector2f(Functions.Round(value.X, digits, mode), Functions.Round(value.Y, digits, mode));
		}
		/// <summary>
		/// Calculates the reciprocal of each component in the vector.
		/// </summary>
		/// <param name="value">A vector.</param>
		/// <returns>A vector with the reciprocal of each of values components.</returns>
		public static Vector2f Reciprocal(Vector2f value)
		{
			return new Vector2f(1 / value.X, 1 / value.Y);
		}
		#endregion
		#region Coordinate spaces
		/// <summary>
		/// Transforms a vector in cartesian coordinates to polar coordinates.
		/// </summary>
		/// <param name="value">The vector to transform.</param>
		/// <returns>The polar coordinates of value.</returns>
		public static PolarCoordinate CartesianToPolar(Vector2f value)
		{
			double theta = Functions.Atan2(value.Y, value.X);
			if (theta < 0)
				theta += 2 * Constants.Pi;
			return new PolarCoordinate(
			     theta,
			     (double)Functions.Sqrt(value.X * value.X + value.Y * value.Y));
		}
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
		public static Vector2f Barycentric(Vector2f value1, Vector2f value2, Vector2f value3, float amount1, float amount2)
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
		public static Vector2f Reflect(Vector2f vector, Vector2f normal)
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
		public static Vector2f Refract(Vector2f vector, Vector2f normal, float index)
		{
			var cos1 = Dot(vector, normal);
			var radicand = 1 - (index * index) * (1 - (cos1 * cos1));
			if (radicand < 0)
			{
				return Vector2f.Zero;
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
		public static Vector2f Lerp(Vector2f value1, Vector2f value2, float amount)
		{
			return (1 - amount) * value1 + amount * value2;
		}
		#endregion
	}
}
