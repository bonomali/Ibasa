using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Ibasa.Numerics.Geometry
{
	/// <summary>
	/// Represents an ordered tuple of integer x, y, width, and height components that defines a
	/// location and size in a two-dimensional space.
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	[StructLayout(LayoutKind.Sequential)]
	public struct Rectanglei: IEquatable<Rectanglei>, IFormattable
	{
		#region Constants
		/// <summary>
		/// Returns a new <see cref="Rectanglei"/> that has an X, Y, Width and Height value of 0.
		/// </summary>
		public static readonly Rectanglei Empty = new Rectanglei(0, 0, 0, 0);
		#endregion
		#region Fields
		/// <summary>
		/// The X component of the rectangle.
		/// </summary>
		public readonly int X;
		/// <summary>
		/// The Y component of the rectangle.
		/// </summary>
		public readonly int Y;
		/// <summary>
		/// The Width component of the rectangle.
		/// </summary>
		public readonly int Width;
		/// <summary>
		/// The Height component of the rectangle.
		/// </summary>
		public readonly int Height;
		#endregion
		#region Properties
		/// <summary>
		/// Gets the y-coordinate of the top edge of this rectangle.
		/// </summary>
		public int Top { get { return Y + Height; } }
		/// <summary>
		/// Gets the y-coordinate of the bottom edge of this rectangle.
		/// </summary>
		public int Bottom { get { return Y; } }
		/// <summary>
		/// Gets the x-coordinate of the left edge of this rectangle.
		/// </summary>
		public int Left { get { return X; } }
		/// <summary>
		/// Gets the x-coordinate of the right edge of this rectangle.
		/// </summary>
		public int Right { get { return X + Width; } }
		/// <summary>
		/// Gets the coordinates of the center of this rectangle.
		/// </summary>
		public Point2i Center { get { return new Point2i(X + (Width / 2), Y + (Height / 2)); } }
		/// <summary>
		/// Gets the size of this rectangle.
		/// </summary>
		public Size2i Size { get { return new Size2i(Width, Height); } }
		/// <summary>
		/// Gets the coordinates of the lower-left corner of this rectangle.
		/// </summary>
		public Point2i Location { get { return new Point2i(X, Y); } }
		/// <summary>
		/// Gets the corners of this rectangle, from lower-left clockwise.
		/// </summary>
		public Point2i[] Corners
		{
			get
			{
				return new Point2i[] { new Point2i(X, Y), new Point2i(X + Width, Y), new Point2i(X + Width, Y + Height), new Point2i(X, Y + Height) };
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Rectanglei"/> using the specified values.
		/// </summary>
		/// <param name="x">Value for the X component of the rectangle.</param>
		/// <param name="y">Value for the Y component of the rectangle.</param>
		/// <param name="width">Value for the Width component of the rectangle.</param>
		/// <param name="height">Value for the Height component of the rectangle.</param>
		public Rectanglei(int x, int y, int width, int height)
		{
			Contract.Requires(0 <= width);
			Contract.Requires(0 <= height);
			
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Rectanglei"/> using the specified location and size.
		/// </summary>
		/// <param name="location">The lower-left corner of the rectangle.</param>
		/// <param name="size">The size of the rectangle.</param>
		public Rectanglei(Point2i location, Size2i size)
		{
			X = location.X;
			Y = location.Y;
			Width = size.Width;
			Height = size.Height;
		}
		#endregion
		#region Operations
		#endregion
		#region Conversions
		/// <summary>
		/// Defines an explicit conversion of a Rectangled value to a Rectanglei.
		/// </summary>
		/// <param name="value">The value to convert to a Rectanglei.</param>
		/// <returns>A Rectanglei that has all components equal to value.</returns>
		public static explicit operator Rectanglei(Rectangled value)
		{
			return new Rectanglei((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
		}
		/// <summary>
		/// Defines an explicit conversion of a Rectanglef value to a Rectanglei.
		/// </summary>
		/// <param name="value">The value to convert to a Rectanglei.</param>
		/// <returns>A Rectanglei that has all components equal to value.</returns>
		public static explicit operator Rectanglei(Rectanglef value)
		{
			return new Rectanglei((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
		}
		/// <summary>
		/// Defines an explicit conversion of a Rectanglel value to a Rectanglei.
		/// </summary>
		/// <param name="value">The value to convert to a Rectanglei.</param>
		/// <returns>A Rectanglei that has all components equal to value.</returns>
		public static explicit operator Rectanglei(Rectanglel value)
		{
			return new Rectanglei((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns the hash code for the current <see cref="Rectanglei"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return X.GetHashCode() + Y.GetHashCode() + Width.GetHashCode() + Height.GetHashCode();
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// object have the same value.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>true if the obj parameter is a <see cref="Rectanglei"/> object or a type capable
		/// of implicit conversion to a <see cref="Rectanglei"/> object, and its value
		/// is equal to the current <see cref="Rectanglei"/> object; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Rectanglei) return Equals((Rectanglei)obj);
			return false;
		}
		/// <summary>
		/// Returns a value that indicates whether the current instance and a specified
		/// rectangle have the same value.
		/// </summary>
		/// <param name="other">The rectangle to compare.</param>
		/// <returns>true if this rectangle and value have the same value; otherwise, false.</returns>
		public bool Equals(Rectanglei other)
		{
			return this == other;
		}
		/// <summary>
		/// Returns a value that indicates whether two rectangles are equal.
		/// </summary>
		/// <param name="left">The first rectangle to compare.</param>
		/// <param name="right">The second rectangle to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool operator ==(Rectanglei left, Rectanglei right)
		{
			return left.X == right.X & left.Y == right.Y & left.Width == right.Width & left.Height == right.Height;
		}
		/// <summary>
		/// Returns a value that indicates whether two rectangles are not equal.
		/// </summary>
		/// <param name="left">The first rectangle to compare.</param>
		/// <param name="right">The second rectangle to compare.</param>
		/// <returns>true if left and right are not equal; otherwise, false.</returns>
		public static bool operator !=(Rectanglei left, Rectanglei right)
		{
			return left.X != right.X | left.Y != right.Y | left.Width != right.Width | left.Height != right.Height;
		}
		#endregion
		#region ToString
		/// <summary>
		/// Converts the value of the current rectangle to its equivalent string
		/// representation.
		/// </summary>
		/// <returns>The string representation of the current instance.</returns>
		public override string ToString()
		{
			Contract.Ensures(Contract.Result<string>() != null);
			return ToString("G", CultureInfo.CurrentCulture);
		}
		/// <summary>
		/// Converts the value of the current rectangle to its equivalent string
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
		/// Converts the value of the current rectangle to its equivalent string
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
		/// Converts the value of the current rectangle to its equivalent string
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
			return String.Format("({0}, {1})", Location.ToString(format, provider), Size.ToString(format, provider));
		}
		#endregion
	}
	/// <summary>
	/// Provides static methods for rectangle functions.
	/// </summary>
	public static partial class Rectangle
	{
		#region Binary
		/// <summary>
		/// Writes the given <see cref="Rectanglei"/> to a System.IO.BinaryWriter.
		/// </summary>
		public static void Write(this System.IO.BinaryWriter writer, Rectanglei rectangle)
		{
			writer.Write(rectangle.X);
			writer.Write(rectangle.Y);
			writer.Write(rectangle.Width);
			writer.Write(rectangle.Height);
		}
		/// <summary>
		/// Reads a <see cref="Rectanglei"/> to a System.IO.BinaryReader.
		/// </summary>
		public static Rectanglei ReadRectanglei(this System.IO.BinaryReader reader)
		{
			return new Rectanglei(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
		}
		#endregion
		#region Equatable
		/// <summary>
		/// Returns a value that indicates whether two rectangles are equal.
		/// </summary>
		/// <param name="left">The first rectangle to compare.</param>
		/// <param name="right">The second rectangle to compare.</param>
		/// <returns>true if the left and right are equal; otherwise, false.</returns>
		public static bool Equals(Rectanglei left, Rectanglei right)
		{
			return left == right;
		}
		#endregion
		#region Contains
		public static bool Contains(Rectanglei rectangle, Point2i point)
		{
			return (rectangle.Left <= point.X) && (rectangle.Right >= point.X) &&
			       (rectangle.Bottom <= point.Y) && (rectangle.Top >= point.Y);
		}
		#endregion
	}
}
