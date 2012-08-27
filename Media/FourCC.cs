﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Ibasa.Media
{
    public struct FourCC : IEquatable<FourCC>, IEquatable<string>, IEquatable<int>
    {
        int Code;

        public FourCC(int code)
        {
            Code = code;
        }

        public FourCC(char a, char b, char c, char d)
        {
            Code = (((byte)a << 0) | ((byte)b << 8) | ((byte)c << 16) | ((byte)d << 24));
        }

        public FourCC(string code)
        {
            Contract.Requires(code != null, "code cannot be null.");
            Contract.Requires(code.Length == 4, "code must have a length of 4.");

            Code = (((byte)code[0] << 0) | ((byte)code[1] << 8) | ((byte)code[2] << 16) | ((byte)code[3] << 24));
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        #region Equals
        public override bool Equals(object obj)
        {
            if (obj is FourCC)
                return Equals((FourCC)obj);
            if (obj is string)
                return Equals((string)obj);
            if (obj is int)
                return Equals((int)obj);
            return false;
        }

        #region FourCC
        public bool Equals(FourCC other)
        {
            return Equals(this, other);
        }

        public static bool Equals(FourCC left, FourCC right)
        {
            return left.Code == right.Code;
        }

        public static bool operator ==(FourCC left, FourCC right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FourCC left, FourCC right)
        {
            return !Equals(left, right);
        }
        #endregion
        #region string
        public bool Equals(string other)
        {
            return Equals(this, other);
        }

        public static bool Equals(FourCC left, string right)
        {
            return left.ToString() == right;
        }

        public static bool Equals(string left, FourCC right)
        {
            return Equals(right, left);
        }

        public static bool operator ==(FourCC left, string right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FourCC left, string right)
        {
            return !Equals(left, right);
        }

        public static bool operator ==(string left, FourCC right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(string left, FourCC right)
        {
            return !Equals(left, right);
        }
        #endregion
        #region int
        public bool Equals(int other)
        {
            return Equals(this, other);
        }

        public static bool Equals(FourCC left, int right)
        {
            return left.Code == right;
        }

        public static bool Equals(int left, FourCC right)
        {
            return Equals(right, left);
        }

        public static bool operator ==(FourCC left, int right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FourCC left, int right)
        {
            return !Equals(left, right);
        }

        public static bool operator ==(int left, FourCC right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(int left, FourCC right)
        {
            return !Equals(left, right);
        }
        #endregion
        #endregion

        public override string ToString()
        {
            char a = (char)((Code >> 0) & 0xFF);
            char b = (char)((Code >> 8) & 0xFF);
            char c = (char)((Code >> 16) & 0xFF);
            char d = (char)((Code >> 24) & 0xFF);

            return string.Concat(a.ToString(), b.ToString(), c.ToString(), d.ToString());
        }

        public static explicit operator int(FourCC fourCC)
        {
            return fourCC.Code;
        }
    }
}