//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool
// Runtime Version: 1.0.0.0
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace HellEngine.Mathematics;

/// <summary>Vector containing two int values</summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct int2 : IEquatable<int2>, IFormattable {
    #region Members

    /// <summary>x Vector component</summary>
    public int x;

    /// <summary>y Vector component</summary>
    public int y;

    #endregion Members

    #region Index Accessor

    /// <summary>Access the int at index</summary>
    public int this[int index] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
#if VALIDATION_CHECKS
            if (index >= 2) {
                throw new IndexOutOfRangeException("Index must be between [0..1]");
            }
#endif
            fixed (int2* array = &this) { return ((int*)array)[index]; }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set {
#if VALIDATION_CHECKS
            if (index >= 2) {
                throw new IndexOutOfRangeException("Index must be between [0..1]");
            }
#endif
            fixed (int* array = &x) { array[index] = value; }
        }
    }

    #endregion Index Accessor

    #region Static Fields

    /// <summary>int2 zero value</summary>
    public static readonly int2 zero = new int2(0, 0);

    /// <summary>int2 one value</summary>
    public static readonly int2 one = new int2(1, 1);

    /// <summary>int2 unit x value</summary>
    public static readonly int2 unitX = new int2(1, 0);

    /// <summary>int2 unit y value</summary>
    public static readonly int2 unitY = new int2(0, 1);

    #endregion Static Fields

    #region Constructors

    /// <summary>Creates a new int2</summary>
    /// <param name="x">Value of x component</param>
    /// <param name="y">Value of y component</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(int x, int y) {
        this.x = x;
        this.y = y;
    }

    /// <summary>Creates a new int2</summary>
    /// <param name="xy">Value of xy components</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(int2 xy) {
        this.x = xy.x;
        this.y = xy.y;
    }

    #endregion Constructors

    #region Conversion

    /// <summary>Creates an int2 vector from an int value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(int v) {
        this.x = v;
        this.y = v;
    }

    /// <summary>Creates an int2 vector from a bool value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(bool v) {
        this.x = v ? 1 : 0;
        this.y = v ? 1 : 0;
    }

    /// <summary>Creates an int2 vector from a bool2 vector</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(bool2 v) {
        this.x = v.x ? 1 : 0;
        this.y = v.y ? 1 : 0;
    }

    /// <summary>Creates an int2 vector from an uint value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(uint v) {
        this.x = (int)v;
        this.y = (int)v;
    }

    /// <summary>Creates an int2 vector from a float value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(float v) {
        this.x = (int)v;
        this.y = (int)v;
    }

    /// <summary>Creates an int2 vector from a float2 vector</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(float2 v) {
        this.x = (int)v.x;
        this.y = (int)v.y;
    }

    /// <summary>Creates an int2 vector from a double value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2(double v) {
        this.x = (int)v;
        this.y = (int)v;
    }

    /// <summary>Converts an int value to an int2 vector</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator int2(int v) => new int2(v);

    /// <summary>Converts a bool value to an int2 vector</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2(bool v) => new int2(v);

    /// <summary>Converts a bool2 vector to an int2 vector</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2(bool2 v) => new int2(v);

    /// <summary>Converts an uint value to an int2 vector</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2(uint v) => new int2(v);

    /// <summary>Converts a float value to an int2 vector</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2(float v) => new int2(v);

    /// <summary>Converts a float2 vector to an int2 vector</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2(float2 v) => new int2(v);

    /// <summary>Converts a double value to an int2 vector</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2(double v) => new int2(v);

    #endregion Conversion

    #region Operators

    /// <summary>Componentwise addition operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for addition</param>
    /// <param name="right">Right hand side int2 vector for addition</param>
    /// <returns>Componentwise addition result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator +(in int2 left, in int2 right) {
        return new int2(left.x + right.x, left.y + right.y);
    }

    /// <summary>Componentwise addition operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for addition</param>
    /// <param name="right">Right hand side int value for addition</param>
    /// <returns>Componentwise addition result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator +(in int2 left, in int right) {
        return new int2(left.x + right, left.y + right);
    }

    /// <summary>Componentwise addition operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for addition</param>
    /// <param name="right">Right hand side int2 vector for addition</param>
    /// <returns>Componentwise addition result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator +(in int left, in int2 right) {
        return new int2(left + right.x, left + right.y);
    }

    /// <summary>Componentwise subtraction operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for subtraction</param>
    /// <param name="right">Right hand side int2 vector for subtraction</param>
    /// <returns>Componentwise subtraction result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator -(in int2 left, in int2 right) {
        return new int2(left.x - right.x, left.y - right.y);
    }

    /// <summary>Componentwise subtraction operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for subtraction</param>
    /// <param name="right">Right hand side int value for subtraction</param>
    /// <returns>Componentwise subtraction result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator -(in int2 left, in int right) {
        return new int2(left.x - right, left.y - right);
    }

    /// <summary>Componentwise subtraction operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for subtraction</param>
    /// <param name="right">Right hand side int2 vector for subtraction</param>
    /// <returns>Componentwise subtraction result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator -(in int left, in int2 right) {
        return new int2(left - right.x, left - right.y);
    }

    /// <summary>Componentwise multiplication operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for multiplication</param>
    /// <param name="right">Right hand side int2 vector for multiplication</param>
    /// <returns>Componentwise multiplication result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator *(in int2 left, in int2 right) {
        return new int2(left.x * right.x, left.y * right.y);
    }

    /// <summary>Componentwise multiplication operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for multiplication</param>
    /// <param name="right">Right hand side int value for multiplication</param>
    /// <returns>Componentwise multiplication result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator *(in int2 left, in int right) {
        return new int2(left.x * right, left.y * right);
    }

    /// <summary>Componentwise multiplication operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for multiplication</param>
    /// <param name="right">Right hand side int2 vector for multiplication</param>
    /// <returns>Componentwise multiplication result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator *(in int left, in int2 right) {
        return new int2(left * right.x, left * right.y);
    }

    /// <summary>Componentwise division operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for division</param>
    /// <param name="right">Right hand side int2 vector for division</param>
    /// <returns>Componentwise division result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator /(in int2 left, in int2 right) {
        return new int2(left.x / right.x, left.y / right.y);
    }

    /// <summary>Componentwise division operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for division</param>
    /// <param name="right">Right hand side int value for division</param>
    /// <returns>Componentwise division result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator /(in int2 left, in int right) {
        return new int2(left.x / right, left.y / right);
    }

    /// <summary>Componentwise division operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for division</param>
    /// <param name="right">Right hand side int2 vector for division</param>
    /// <returns>Componentwise division result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator /(in int left, in int2 right) {
        return new int2(left / right.x, left / right.y);
    }

    /// <summary>Componentwise remainder operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for remainder</param>
    /// <param name="right">Right hand side int2 vector for remainder</param>
    /// <returns>Componentwise remainder result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator %(in int2 left, in int2 right) {
        return new int2(left.x % right.x, left.y % right.y);
    }

    /// <summary>Componentwise remainder operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for remainder</param>
    /// <param name="right">Right hand side int value for remainder</param>
    /// <returns>Componentwise remainder result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator %(in int2 left, in int right) {
        return new int2(left.x % right, left.y % right);
    }

    /// <summary>Componentwise remainder operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for remainder</param>
    /// <param name="right">Right hand side int2 vector for remainder</param>
    /// <returns>Componentwise remainder result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator %(in int left, in int2 right) {
        return new int2(left % right.x, left % right.y);
    }

    /// <summary>Componentwise increment operation on an int2 vector</summary>
    /// <param name="value">Value for componentwise increment</param>
    /// <returns>Componentwise increment int2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator ++(int2 value) {
        return new int2(++value.x, ++value.y);
    }

    /// <summary>Componentwise decrement operation on an int2 vector</summary>
    /// <param name="value">Value for componentwise decrement</param>
    /// <returns>Componentwise decrement int2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator --(int2 value) {
        return new int2(--value.x, --value.y);
    }

    /// <summary>Componentwise unary minus operation on an int2 vector</summary>
    /// <param name="value">Value for componentwise unary minus</param>
    /// <returns>Componentwise unary minus int2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator -(int2 value) {
        return new int2(-value.x, -value.y);
    }

    /// <summary>Componentwise unary plus operation on an int2 vector</summary>
    /// <param name="value">Value for componentwise unary plus</param>
    /// <returns>Componentwise unary plus int2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator +(int2 value) {
        return new int2(+value.x, +value.y);
    }

    /// <summary>Componentwise less than operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for less than</param>
    /// <param name="right">Right hand side int2 vector for less than</param>
    /// <returns>Componentwise less than result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator <(in int2 left, in int2 right) {
        return new bool2(left.x < right.x, left.y < right.y);
    }

    /// <summary>Componentwise less than operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for less than</param>
    /// <param name="right">Right hand side int value for less than</param>
    /// <returns>Componentwise less than result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator <(in int2 left, in int right) {
        return new bool2(left.x < right, left.y < right);
    }

    /// <summary>Componentwise less than operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for less than</param>
    /// <param name="right">Right hand side int2 vector for less than</param>
    /// <returns>Componentwise less than result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator <(in int left, in int2 right) {
        return new bool2(left < right.x, left < right.y);
    }

    /// <summary>Componentwise less than or equal operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for less than or equal</param>
    /// <param name="right">Right hand side int2 vector for less than or equal</param>
    /// <returns>Componentwise less than or equal result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator <=(in int2 left, in int2 right) {
        return new bool2(left.x <= right.x, left.y <= right.y);
    }

    /// <summary>Componentwise less than or equal operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for less than or equal</param>
    /// <param name="right">Right hand side int value for less than or equal</param>
    /// <returns>Componentwise less than or equal result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator <=(in int2 left, in int right) {
        return new bool2(left.x <= right, left.y <= right);
    }

    /// <summary>Componentwise less than or equal operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for less than or equal</param>
    /// <param name="right">Right hand side int2 vector for less than or equal</param>
    /// <returns>Componentwise less than or equal result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator <=(in int left, in int2 right) {
        return new bool2(left <= right.x, left <= right.y);
    }

    /// <summary>Componentwise greater than operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for greater than</param>
    /// <param name="right">Right hand side int2 vector for greater than</param>
    /// <returns>Componentwise greater than result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator >(in int2 left, in int2 right) {
        return new bool2(left.x > right.x, left.y > right.y);
    }

    /// <summary>Componentwise greater than operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for greater than</param>
    /// <param name="right">Right hand side int value for greater than</param>
    /// <returns>Componentwise greater than result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator >(in int2 left, in int right) {
        return new bool2(left.x > right, left.y > right);
    }

    /// <summary>Componentwise greater than operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for greater than</param>
    /// <param name="right">Right hand side int2 vector for greater than</param>
    /// <returns>Componentwise greater than result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator >(in int left, in int2 right) {
        return new bool2(left > right.x, left > right.y);
    }

    /// <summary>Componentwise greater than or equal operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for greater than or equal</param>
    /// <param name="right">Right hand side int2 vector for greater than or equal</param>
    /// <returns>Componentwise greater than or equal result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator >=(in int2 left, in int2 right) {
        return new bool2(left.x >= right.x, left.y >= right.y);
    }

    /// <summary>Componentwise greater than or equal operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for greater than or equal</param>
    /// <param name="right">Right hand side int value for greater than or equal</param>
    /// <returns>Componentwise greater than or equal result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator >=(in int2 left, in int right) {
        return new bool2(left.x >= right, left.y >= right);
    }

    /// <summary>Componentwise greater than or equal operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for greater than or equal</param>
    /// <param name="right">Right hand side int2 vector for greater than or equal</param>
    /// <returns>Componentwise greater than or equal result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator >=(in int left, in int2 right) {
        return new bool2(left >= right.x, left >= right.y);
    }

    /// <summary>Componentwise equality operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for equality</param>
    /// <param name="right">Right hand side int2 vector for equality</param>
    /// <returns>Componentwise equality result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator ==(in int2 left, in int2 right) {
        return new bool2(left.x == right.x, left.y == right.y);
    }

    /// <summary>Componentwise equality operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for equality</param>
    /// <param name="right">Right hand side int value for equality</param>
    /// <returns>Componentwise equality result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator ==(in int2 left, in int right) {
        return new bool2(left.x == right, left.y == right);
    }

    /// <summary>Componentwise equality operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for equality</param>
    /// <param name="right">Right hand side int2 vector for equality</param>
    /// <returns>Componentwise equality result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator ==(in int left, in int2 right) {
        return new bool2(left == right.x, left == right.y);
    }

    /// <summary>Componentwise inequality operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for inequality</param>
    /// <param name="right">Right hand side int2 vector for inequality</param>
    /// <returns>Componentwise inequality result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator !=(in int2 left, in int2 right) {
        return new bool2(left.x != right.x, left.y != right.y);
    }

    /// <summary>Componentwise inequality operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for inequality</param>
    /// <param name="right">Right hand side int value for inequality</param>
    /// <returns>Componentwise inequality result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator !=(in int2 left, in int right) {
        return new bool2(left.x != right, left.y != right);
    }

    /// <summary>Componentwise inequality operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for inequality</param>
    /// <param name="right">Right hand side int2 vector for inequality</param>
    /// <returns>Componentwise inequality result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool2 operator !=(in int left, in int2 right) {
        return new bool2(left != right.x, left != right.y);
    }

    /// <summary>Componentwise left shift operation on an int2 vector</summary>
    /// <param name="value">Value to left shift</param>
    /// <param name="shiftAmount">Number of bits to left shift</param>
    /// <returns>CComponentwise left shift result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator <<(in int2 value, in int shiftAmount) {
        return new int2(value.x << shiftAmount, value.y << shiftAmount);
    }

    /// <summary>Componentwise right shift operation on an int2 vector</summary>
    /// <param name="value">Value to right shift</param>
    /// <param name="shiftAmount">Number of bits to right shift</param>
    /// <returns>CComponentwise right shift result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator >>(in int2 value, in int shiftAmount) {
        return new int2(value.x >> shiftAmount, value.y >> shiftAmount);
    }

    /// <summary>Componentwise bitwise complement operation on an int2 vector</summary>
    /// <param name="value">Value for componentwise bitwise complement</param>
    /// <returns>Componentwise bitwise complement int2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator ~(int2 value) {
        return new int2(~value.x, ~value.y);
    }

    /// <summary>Componentwise bitwise and operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for bitwise and</param>
    /// <param name="right">Right hand side int2 vector for bitwise and</param>
    /// <returns>Componentwise bitwise and result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator &(in int2 left, in int2 right) {
        return new int2(left.x & right.x, left.y & right.y);
    }

    /// <summary>Componentwise bitwise and operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for bitwise and</param>
    /// <param name="right">Right hand side int value for bitwise and</param>
    /// <returns>Componentwise bitwise and result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator &(in int2 left, in int right) {
        return new int2(left.x & right, left.y & right);
    }

    /// <summary>Componentwise bitwise and operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for bitwise and</param>
    /// <param name="right">Right hand side int2 vector for bitwise and</param>
    /// <returns>Componentwise bitwise and result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator &(in int left, in int2 right) {
        return new int2(left & right.x, left & right.y);
    }

    /// <summary>Componentwise bitwise or operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for bitwise or</param>
    /// <param name="right">Right hand side int2 vector for bitwise or</param>
    /// <returns>Componentwise bitwise or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator |(in int2 left, in int2 right) {
        return new int2(left.x | right.x, left.y | right.y);
    }

    /// <summary>Componentwise bitwise or operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for bitwise or</param>
    /// <param name="right">Right hand side int value for bitwise or</param>
    /// <returns>Componentwise bitwise or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator |(in int2 left, in int right) {
        return new int2(left.x | right, left.y | right);
    }

    /// <summary>Componentwise bitwise or operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for bitwise or</param>
    /// <param name="right">Right hand side int2 vector for bitwise or</param>
    /// <returns>Componentwise bitwise or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator |(in int left, in int2 right) {
        return new int2(left | right.x, left | right.y);
    }

    /// <summary>Componentwise bitwise exclusive or operation on two int2 vectors</summary>
    /// <param name="left">Left hand side int2 vector for bitwise exclusive or</param>
    /// <param name="right">Right hand side int2 vector for bitwise exclusive or</param>
    /// <returns>Componentwise bitwise exclusive or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator ^(in int2 left, in int2 right) {
        return new int2(left.x ^ right.x, left.y ^ right.y);
    }

    /// <summary>Componentwise bitwise exclusive or operation on an int2 vector and an int value</summary>
    /// <param name="left">Left hand side int2 vector for bitwise exclusive or</param>
    /// <param name="right">Right hand side int value for bitwise exclusive or</param>
    /// <returns>Componentwise bitwise exclusive or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator ^(in int2 left, in int right) {
        return new int2(left.x ^ right, left.y ^ right);
    }

    /// <summary>Componentwise bitwise exclusive or operation on an int value and an int2 vector</summary>
    /// <param name="left">Left hand side int value for bitwise exclusive or</param>
    /// <param name="right">Right hand side int2 vector for bitwise exclusive or</param>
    /// <returns>Componentwise bitwise exclusive or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 operator ^(in int left, in int2 right) {
        return new int2(left ^ right.x, left ^ right.y);
    }

    #endregion Operators

    #region Swizzle

    /// <summary>Swizzles the int2 vector</summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
    public int2 xx {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new int2(x, x);
    }

    /// <summary>Swizzles the int2 vector</summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
    public int2 xy {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new int2(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set {
            this.x = value.x;
            this.y = value.y;
        }
    }

    /// <summary>Swizzles the int2 vector</summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
    public int2 yx {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new int2(y, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set {
            this.y = value.x;
            this.x = value.y;
        }
    }

    /// <summary>Swizzles the int2 vector</summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
    public int2 yy {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new int2(y, y);
    }

    #endregion Swizzle

    #region Equals

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() {
        return HashCode.Combine(x, y);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(int2 other) {
        return x == other.x && y == other.y;
    }

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is int2 value && Equals(value);

    #endregion Equals

    #region ToString

    /// <summary>Returns a string that represents the current values</summary>
    /// <returns>The values of the current instance with the specified format</returns>
    public override string ToString() {
        return string.Format("int2({0} {1})", x, y);
    }

    /// <summary>Formats the values of the current instance using the specified format</summary>
    /// <param name="format">The format to use</param>
    /// <param name="formatProvider">The provider to use to format the values</param>
    /// <returns>The values of the current instance with the specified format</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) {
        return string.Format("int2({0} {1})", x.ToString(format, formatProvider), y.ToString(format, formatProvider));
    }

    #endregion ToString
}

public static unsafe partial class math {
    #region Component Math

    /// <summary>Returns the bit pattern of an int2 vector as a float2 vector</summary>
    /// <param name="value">The int2 bits to copy</param>
    /// <returns>The float2 with the same bit pattern as the input</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float2 asfloat(int2 value) {
        return *(float2*)&value;
    }
    /// <summary>Minimum of two int2 vectors</summary>
    /// <param name="x">The first of two values to compare</param>
    /// <param name="y">The second of two values to compare</param>
    /// <returns>Componentwise Minimum</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 min(in int2 x, in int2 y) {
        return new int2(math.min(x.x, y.x), math.min(x.y, y.y));
    }
    /// <summary>Maximum of two int2 vectors</summary>
    /// <param name="x">The first of two values to compare</param>
    /// <param name="y">The second of two values to compare</param>
    /// <returns>Componentwise Maximum</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 max(in int2 x, in int2 y) {
        return new int2(math.max(x.x, y.x), math.max(x.y, y.y));
    }
    /// <summary>Returns the result of clamping the value x into the interval [a, b], where x, a and b are byte values</summary>
    /// <param name="x">Input value to be clamped</param>
    /// <param name="a">Lower bound of the interval</param>
    /// <param name="b">Upper bound of the interval</param>
    /// <returns>The clamping of the input x into the interval [a, b]</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 clamp(in int2 x, in int2 a, in int2 b) {
        return max(a, min(b, x));
    }
    /// <summary>Returns the absolute value of an int2 vector</summary>
    /// <param name="x">Input value</param>
    /// <returns>The absolute value of the input</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 abs(in int2 x) {
        return new int2(math.abs(x.x), math.abs(x.y));
    }
    /// <summary>Returns the sign of an int2 vector value. -1 if it is less than zero, 0 if it is zero and 1 if it greater than zero</summary>
    /// <param name="x">Input value</param>
    /// <returns>The sign of the input</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 sign(in int2 x) {
        return new int2(math.sign(x.x), math.sign(x.y));
    }
    /// <summary>Returns the dot product of two int2 vectors values. Equivalent to multiplication</summary>
    /// <param name="x">The first value</param>
    /// <param name="y">The second value</param>
    /// <returns>The dot product of two values</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int dot(in int2 x, in int2 y) {
        return x.x * y.x + x.y * y.y;
    }
    /// <summary>Returns the minimum component of an int2 vector</summary>
    /// <param name="x">The vector to use when computing the minimum component</param>
    /// <returns>The value of the minimum component of the vector</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int cmin(in int2 x) {
        return min(x.x, x.y);
    }
    /// <summary>Returns the maximum component of an int2 vector</summary>
    /// <param name="x">The vector to use when computing the maximum component</param>
    /// <returns>The value of the maximum component of the vector</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int cmax(in int2 x) {
        return max(x.x, x.y);
    }
    /// <summary>Returns the horizontal sum of components of an int2 vector</summary>
    /// <param name="x">The vector to use when computing the horizontal sum</param>
    /// <returns>The horizontal sum of of components of the vector</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int csum(in int2 x) {
        return x.x + x.y;
    }
    /// <summary>Returns b if c is true, a otherwise</summary>
    /// <param name="a">Value to use if c is false</param>
    /// <param name="b">Value to use if c is false</param>
    /// <param name="c">Bool value to choose between a and b</param>
    /// <returns>The selection between a and b according to bool c</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 select(in int2 a, in int2 b, in bool c) {
        return c ? b : a;
    }
    /// <summary>Returns a componentwise selection between two int2 vectors a and b based on a bool2 vector selection mask c. Per component, the component from b is selected when c is true, otherwise the component from a is selected</summary>
    /// <param name="a">Value to use if c is false</param>
    /// <param name="b">Value to use if c is false</param>
    /// <param name="c">Selection mask to choose between a and b</param>
    /// <returns>The componentwise selection between a and b according to selection mask c</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2 select(in int2 a, in int2 b, in bool2 c) {
        return new int2(math.select(a.x, b.x, c.x), math.select(a.y, b.y, c.y));
    }
    #endregion Component Math

}
