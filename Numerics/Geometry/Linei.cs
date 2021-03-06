using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Ibasa.Numerics.Geometry
{
	/// <summary>
	/// Represents a line in a one-dimensional space.
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	[StructLayout(LayoutKind.Sequential)]
	public struct Linei: IEquatable<Linei>, IFormattable
	{
		#region Constants
		/// <summary>
		/// Returns a new empty <see cref="Linei"/>.
		/// </summary>
		public static readonly Linei Empty = new Linei(0, 0);
		#endregion
		#region Fields
		/// <summary>
		/// The coordinates of the start of this line.
		/// </summary>
		public readonly int Start;
		/// <summary>
		/// The coordinates of the end of this line.
		/// </summary>
		public readonly int End;
		#endregion
		#region Properties
		/// <summary>
		/// Returns the length of this line.
		/// </summary>
		/// <returns>The length of this line.</returns>
		public double Length
		{
			get
			{
				return Functions.Abs(End - Start);
			}
		}
		/// <summary>
		/// Gets the coordinates of the center of this line.
		/// </summary>
		public int Center
		{
			get
			{
				return (Start + End) / 2;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Linei"/> using the specified values.
		/// </summary>
		/// <param name="start">Start point of the line.</param>
		/// <param name="end">End point of the line.</param>
		public Linei(int start, int end)
		{
			Start = start;
			End = end;
		}
		#endregion
		#region Operations
		#endregion
		#region Conversions
		/// <summary>
		/// Defines an explicit conversion of a Lined value to a Linei.
		/// </summary>
		/// <param name="value">The value to convert to a Linei.</param>
		/// <returns>A Linei that has all components equal to value.</returns>
		public static explicit operator Linei(Lined value)
		{
			return new Linei((int)value.Start, (int)value.End);
		}
		/// <summary>
		/// Defines an explicit conversion of a Linef value to a Linei.
		/// </summary>
		/// <param name="value">The value to convert to a Linei.</param>
		/// <returns>A Linei that has all components equal to value.</returns>
		public static explicit operator Linei(Linef value)
		{
			return new Linei((int)value.Start, (int)value.End);
		}
		/// <summary>
		/// Defines an explicit conversion of a Linel value to a Linei.
		/// </summary>
		/// <param name="value">The value to convert to a Linei.</param>
		/// <returns>A Linei that has all components equal to value.</returns>
		public static explicit operator Linei(Linel value)
		{
			return new Linei((int)value.Start, (int)value.End);
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns the hash code for the current <see cref="Linei"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return Start.GetHashCode() + End.GetHashCode();
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// object have the same value.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>true if the obj parameter is a <see cref="Linei"/> object or a type capable
		/// of implicit conversion to a <see cref="Linei"/> object, and its value
		/// is equal to the current <see cref="Linei"/> object; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Linei) return Equals((Linei)obj);
			return false;
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// line have the same value.
		/// </summary>
		/// <param name="other">The line to compare.</param>
		/// <returns>true if this line and value have the same value; otherwise, false.</returns>
		public bool Equals(Linei other)
		{
			return this == other;
		}
		/// <summary>
		/// Returns a value that indicates whether two lines are equal.
		/// </summary>
		/// <param name="left">The first line to compare.</param>
		/// <param name="right">The second line to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool operator ==(Linei left, Linei right)
		{
			return left.Start == right.Start && left.End == right.End;
		}
		/// <summary>
		/// Returns a value that indicates whether two lines are not equal.
		/// </summary>
		/// <param name="left">The first line to compare.</param>
		/// <param name="right">The second line to compare.</param>
		/// <returns>true if left and right are not equal; otherwise, false.</returns>
		public static bool operator !=(Linei left, Linei right)
		{
			return left.Start != right.Start || left.End != right.End;
		}
		#endregion
		#region ToString
		/// <summary>
		/// Converts the value of the current line to its equivalent string
		/// representation.
		/// </summary>
		/// <returns>The string representation of the current instance.</returns>
		public override string ToString()
		{
			Contract.Ensures(Contract.Result<string>() != null);
			return ToString("G", CultureInfo.CurrentCulture);
		}
		/// <summary>
		/// Converts the value of the current line to its equivalent string
		/// representation by using the specified culture-specific
		/// formatting information.
		/// </summary>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>The string representation of the current instance, as specified
		/// by provider.</returns>
		public string ToString(IFormatProvider provider)
		{
			Contract.Ensures(Contract.Result<string>() != null);
			return ToString("G", provider);
		}
		/// <summary>
		/// Converts the value of the current line to its equivalent string
		/// representation by using the specified format for its components.
		/// </summary>
		/// <param name="format">A standard or custom numeric format string.</param>
		/// <returns>The string representation of the current instance.</returns>
		/// <exception cref="System.FormatException">format is not a valid format string.</exception>
		public string ToString(string format)
		{
			Contract.Ensures(Contract.Result<string>() != null);
			return ToString(format, CultureInfo.CurrentCulture);
		}
		/// <summary>
		/// Converts the value of the current line to its equivalent string
		/// representation by using the specified format and culture-specific
		/// format information for its components.
		/// </summary>
		/// <param name="format">A standard or custom numeric format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>The string representation of the current instance, as specified
		/// by format and provider.</returns>
		/// <exception cref="System.FormatException">format is not a valid format string.</exception>
		public string ToString(string format, IFormatProvider provider)
		{
			Contract.Ensures(Contract.Result<string>() != null);
			return String.Format("({0}, {1})", Start.ToString(format, provider), End.ToString(format, provider));
		}
		#endregion
	}
	/// <summary>
	/// Provides static methods for line functions.
	/// </summary>
	public static partial class Line
	{
		#region Binary
		/// <summary>
		/// Writes the given <see cref="Linei"/> to an <see cref="Ibasa.IO.BinaryWriter">.
		/// </summary>
		public static void Write(this Ibasa.IO.BinaryWriter writer, Linei line)
		{
			writer.Write(line.Start);
			writer.Write(line.End);
		}
		/// <summary>
		/// Reads a <see cref="Linei"/> from an <see cref="Ibasa.IO.BinaryReader">.
		/// </summary>
		public static Linei ReadLinei(this Ibasa.IO.BinaryReader reader)
		{
			return new Linei(reader.ReadInt32(), reader.ReadInt32());
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns a value that indicates whether two lines are equal.
		/// </summary>
		/// <param name="left">The first line to compare.</param>
		/// <param name="right">The second line to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool Equals(Linei left, Linei right)
		{
			return left == right;
		}
		#endregion
		#region Intersect
		/// <summary>
		/// Returns the intersection of two lines.
		/// </summary>
		/// <param name="left">The first line.</param>
		/// <param name="right">The second line.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static Linei? Intersect(Linei left, Linei right)
		{
			var left_min = Functions.Min(left.Start, left.End);
			var left_max = Functions.Max(left.Start, left.End);
			var right_min = Functions.Min(right.Start, right.End);
			var right_max = Functions.Max(right.Start, right.End);
			var min = Functions.Max(left_min, right_min);
			var max = Functions.Min(left_max, right_max);
			return min <= max ? new Linei?(new Linei(min, max)) : null;
		}
		#endregion
	}
}
