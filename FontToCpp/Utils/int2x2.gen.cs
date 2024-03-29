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

/// <summary>Matrix containing 2 Rows and 2 Columns stored as int2 vector for each row</summary>
/// <remarks>row-major</remarks>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct int2x2 : IEquatable<int2x2>, IFormattable {
    #region Members

    /// <summary>Row 0 of the Matrix</summary>
    public int2 v0;

    /// <summary>Row 1 of the Matrix</summary>
    public int2 v1;

    #endregion Members

    #region Index Accessor

    /// <summary>Access the int2 at index</summary>
    public ref int2 this[int index] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
#if VALIDATION_CHECKS
            if (index >= 2) {
                throw new IndexOutOfRangeException("Index must be between [0..1]");
            }
#endif
            fixed (int2x2* array = &this) { return ref ((int2*)array)[index]; }
        }
    }

    #endregion Index Accessor

    #region Static Fields

    /// <summary>int2x2 identity matrix</summary>
    public static readonly int2x2 identity = new int2x2(
        1, 0,
        0, 1
    );

    /// <summary>int2x2 zero value</summary>
    public static readonly int2x2 zero = new int2x2(
        0, 0,
        0, 0
    );

    /// <summary>int2x2 one value</summary>
    public static readonly int2x2 one = new int2x2(
        1, 1,
        1, 1
    );

    #endregion Static Fields

    #region Constructors

    /// <summary>Creates an int2x2 matrix from two int2 vectors</summary>
    /// <param name="r0">Row 0 values</param>
    /// <param name="r1">Row 1 values</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2x2(int2 r0, int2 r1) {
        this.v0 = r0;
        this.v1 = r1;
    }

    /// <summary>Creates an int2x2 matrix from four int values</summary>
    /// <param name="m00">Row 0, Column 0 value</param>
    /// <param name="m01">Row 0, Column 1 value</param>
    /// <param name="m10">Row 1, Column 0 value</param>
    /// <param name="m11">Row 1, Column 1 value</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2x2(int m00, int m01, int m10, int m11) {
        this.v0 = new int2(m00, m01);
        this.v1 = new int2(m10, m11);
    }

    #endregion Constructors

    #region Conversion

    /// <summary>Creates an int2x2 matrix from an int value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2x2(int v) {
        this.v0 = v;
        this.v1 = v;
    }

    /// <summary>Creates an int2x2 matrix from a bool value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2x2(bool v) {
        this.v0 = math.select(int2.zero, int2.one, v);
        this.v1 = math.select(int2.zero, int2.one, v);
    }

    /// <summary>Creates an int2x2 matrix from an uint value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2x2(uint v) {
        this.v0 = (int2)v;
        this.v1 = (int2)v;
    }

    /// <summary>Creates an int2x2 matrix from a float value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2x2(float v) {
        this.v0 = (int2)v;
        this.v1 = (int2)v;
    }


    /// <summary>Creates an int2x2 matrix from a double value</summary>
    /// <param name="v">Component values. Converted if necessary</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int2x2(double v) {
        this.v0 = (int2)v;
        this.v1 = (int2)v;
    }

    /// <summary>Converts an int value to an int2x2 matrix</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator int2x2(int v) => new int2x2(v);

    /// <summary>Converts a bool value to an int2x2 matrix</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2x2(bool v) => new int2x2(v);

    /// <summary>Converts an uint value to an int2x2 matrix</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2x2(uint v) => new int2x2(v);

    /// <summary>Converts a float value to an int2x2 matrix</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2x2(float v) => new int2x2(v);

    /// <summary>Converts a double value to an int2x2 matrix</summary>
    /// <param name="v">Value to convert</param>
    /// <returns>Converted value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int2x2(double v) => new int2x2(v);

    #endregion Conversion

    #region Operators

    /// <summary>Componentwise addition operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for addition</param>
    /// <param name="right">Right hand side int2x2 matrix for addition</param>
    /// <returns>Componentwise addition result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator +(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 + right.v0, left.v1 + right.v1);
    }

    /// <summary>Componentwise addition operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for addition</param>
    /// <param name="right">Right hand side int value for addition</param>
    /// <returns>Componentwise addition result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator +(in int2x2 left, in int right) {
        return new int2x2(left.v0 + right, left.v1 + right);
    }

    /// <summary>Componentwise addition operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for addition</param>
    /// <param name="right">Right hand side int2x2 matrix for addition</param>
    /// <returns>Componentwise addition result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator +(in int left, in int2x2 right) {
        return new int2x2(left + right.v0, left + right.v1);
    }

    /// <summary>Componentwise subtraction operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for subtraction</param>
    /// <param name="right">Right hand side int2x2 matrix for subtraction</param>
    /// <returns>Componentwise subtraction result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator -(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 - right.v0, left.v1 - right.v1);
    }

    /// <summary>Componentwise subtraction operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for subtraction</param>
    /// <param name="right">Right hand side int value for subtraction</param>
    /// <returns>Componentwise subtraction result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator -(in int2x2 left, in int right) {
        return new int2x2(left.v0 - right, left.v1 - right);
    }

    /// <summary>Componentwise subtraction operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for subtraction</param>
    /// <param name="right">Right hand side int2x2 matrix for subtraction</param>
    /// <returns>Componentwise subtraction result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator -(in int left, in int2x2 right) {
        return new int2x2(left - right.v0, left - right.v1);
    }

    /// <summary>Componentwise multiplication operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for multiplication</param>
    /// <param name="right">Right hand side int2x2 matrix for multiplication</param>
    /// <returns>Componentwise multiplication result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator *(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 * right.v0, left.v1 * right.v1);
    }

    /// <summary>Componentwise multiplication operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for multiplication</param>
    /// <param name="right">Right hand side int value for multiplication</param>
    /// <returns>Componentwise multiplication result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator *(in int2x2 left, in int right) {
        return new int2x2(left.v0 * right, left.v1 * right);
    }

    /// <summary>Componentwise multiplication operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for multiplication</param>
    /// <param name="right">Right hand side int2x2 matrix for multiplication</param>
    /// <returns>Componentwise multiplication result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator *(in int left, in int2x2 right) {
        return new int2x2(left * right.v0, left * right.v1);
    }

    /// <summary>Componentwise division operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for division</param>
    /// <param name="right">Right hand side int2x2 matrix for division</param>
    /// <returns>Componentwise division result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator /(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 / right.v0, left.v1 / right.v1);
    }

    /// <summary>Componentwise division operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for division</param>
    /// <param name="right">Right hand side int value for division</param>
    /// <returns>Componentwise division result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator /(in int2x2 left, in int right) {
        return new int2x2(left.v0 / right, left.v1 / right);
    }

    /// <summary>Componentwise division operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for division</param>
    /// <param name="right">Right hand side int2x2 matrix for division</param>
    /// <returns>Componentwise division result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator /(in int left, in int2x2 right) {
        return new int2x2(left / right.v0, left / right.v1);
    }

    /// <summary>Componentwise remainder operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for remainder</param>
    /// <param name="right">Right hand side int2x2 matrix for remainder</param>
    /// <returns>Componentwise remainder result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator %(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 % right.v0, left.v1 % right.v1);
    }

    /// <summary>Componentwise remainder operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for remainder</param>
    /// <param name="right">Right hand side int value for remainder</param>
    /// <returns>Componentwise remainder result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator %(in int2x2 left, in int right) {
        return new int2x2(left.v0 % right, left.v1 % right);
    }

    /// <summary>Componentwise remainder operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for remainder</param>
    /// <param name="right">Right hand side int2x2 matrix for remainder</param>
    /// <returns>Componentwise remainder result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator %(in int left, in int2x2 right) {
        return new int2x2(left % right.v0, left % right.v1);
    }

    /// <summary>Componentwise increment operation on an int2x2 matrix</summary>
    /// <param name="value">Value for componentwise increment</param>
    /// <returns>Componentwise increment int2x2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator ++(int2x2 value) {
        return new int2x2(++value.v0, ++value.v1);
    }

    /// <summary>Componentwise decrement operation on an int2x2 matrix</summary>
    /// <param name="value">Value for componentwise decrement</param>
    /// <returns>Componentwise decrement int2x2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator --(int2x2 value) {
        return new int2x2(--value.v0, --value.v1);
    }

    /// <summary>Componentwise unary minus operation on an int2x2 matrix</summary>
    /// <param name="value">Value for componentwise unary minus</param>
    /// <returns>Componentwise unary minus int2x2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator -(int2x2 value) {
        return new int2x2(-value.v0, -value.v1);
    }

    /// <summary>Componentwise unary plus operation on an int2x2 matrix</summary>
    /// <param name="value">Value for componentwise unary plus</param>
    /// <returns>Componentwise unary plus int2x2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator +(int2x2 value) {
        return new int2x2(+value.v0, +value.v1);
    }

    /// <summary>Componentwise left shift operation on an int2x2 matrix</summary>
    /// <param name="value">Value to left shift</param>
    /// <param name="shiftAmount">Number of bits to left shift</param>
    /// <returns>CComponentwise left shift result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator <<(in int2x2 value, in int shiftAmount) {
        return new int2x2(value.v0 << shiftAmount, value.v1 << shiftAmount);
    }

    /// <summary>Componentwise right shift operation on an int2x2 matrix</summary>
    /// <param name="value">Value to right shift</param>
    /// <param name="shiftAmount">Number of bits to right shift</param>
    /// <returns>CComponentwise right shift result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator >>(in int2x2 value, in int shiftAmount) {
        return new int2x2(value.v0 >> shiftAmount, value.v1 >> shiftAmount);
    }

    /// <summary>Componentwise bitwise complement operation on an int2x2 matrix</summary>
    /// <param name="value">Value for componentwise bitwise complement</param>
    /// <returns>Componentwise bitwise complement int2x2 result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator ~(int2x2 value) {
        return new int2x2(~value.v0, ~value.v1);
    }

    /// <summary>Componentwise bitwise and operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for bitwise and</param>
    /// <param name="right">Right hand side int2x2 matrix for bitwise and</param>
    /// <returns>Componentwise bitwise and result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator &(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 & right.v0, left.v1 & right.v1);
    }

    /// <summary>Componentwise bitwise and operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for bitwise and</param>
    /// <param name="right">Right hand side int value for bitwise and</param>
    /// <returns>Componentwise bitwise and result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator &(in int2x2 left, in int right) {
        return new int2x2(left.v0 & right, left.v1 & right);
    }

    /// <summary>Componentwise bitwise and operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for bitwise and</param>
    /// <param name="right">Right hand side int2x2 matrix for bitwise and</param>
    /// <returns>Componentwise bitwise and result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator &(in int left, in int2x2 right) {
        return new int2x2(left & right.v0, left & right.v1);
    }

    /// <summary>Componentwise bitwise or operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for bitwise or</param>
    /// <param name="right">Right hand side int2x2 matrix for bitwise or</param>
    /// <returns>Componentwise bitwise or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator |(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 | right.v0, left.v1 | right.v1);
    }

    /// <summary>Componentwise bitwise or operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for bitwise or</param>
    /// <param name="right">Right hand side int value for bitwise or</param>
    /// <returns>Componentwise bitwise or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator |(in int2x2 left, in int right) {
        return new int2x2(left.v0 | right, left.v1 | right);
    }

    /// <summary>Componentwise bitwise or operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for bitwise or</param>
    /// <param name="right">Right hand side int2x2 matrix for bitwise or</param>
    /// <returns>Componentwise bitwise or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator |(in int left, in int2x2 right) {
        return new int2x2(left | right.v0, left | right.v1);
    }

    /// <summary>Componentwise bitwise exclusive or operation on two int2x2 matrices</summary>
    /// <param name="left">Left hand side int2x2 matrix for bitwise exclusive or</param>
    /// <param name="right">Right hand side int2x2 matrix for bitwise exclusive or</param>
    /// <returns>Componentwise bitwise exclusive or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator ^(in int2x2 left, in int2x2 right) {
        return new int2x2(left.v0 ^ right.v0, left.v1 ^ right.v1);
    }

    /// <summary>Componentwise bitwise exclusive or operation on an int2x2 matrix and an int value</summary>
    /// <param name="left">Left hand side int2x2 matrix for bitwise exclusive or</param>
    /// <param name="right">Right hand side int value for bitwise exclusive or</param>
    /// <returns>Componentwise bitwise exclusive or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator ^(in int2x2 left, in int right) {
        return new int2x2(left.v0 ^ right, left.v1 ^ right);
    }

    /// <summary>Componentwise bitwise exclusive or operation on an int value and an int2x2 matrix</summary>
    /// <param name="left">Left hand side int value for bitwise exclusive or</param>
    /// <param name="right">Right hand side int2x2 matrix for bitwise exclusive or</param>
    /// <returns>Componentwise bitwise exclusive or result</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 operator ^(in int left, in int2x2 right) {
        return new int2x2(left ^ right.v0, left ^ right.v1);
    }

    #endregion Operators

    #region Swizzle

    #endregion Swizzle

    #region Equals

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() {
        return HashCode.Combine(v0, v1);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(int2x2 other) {
        return v0.Equals(other.v0) && v1.Equals(other.v1);
    }

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is int2x2 value && Equals(value);

    #endregion Equals

    #region ToString

    /// <summary>Returns a string that represents the current values</summary>
    /// <returns>The values of the current instance with the specified format</returns>
    public override string ToString() {
        return string.Format("int2x2({0} {1} | {2} {3})", v0.x, v0.y, v1.x, v1.y);
    }

    /// <summary>Formats the values of the current instance using the specified format</summary>
    /// <param name="format">The format to use</param>
    /// <param name="formatProvider">The provider to use to format the values</param>
    /// <returns>The values of the current instance with the specified format</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) {
        return string.Format("int2x2({0} {1} | {2} {3})", v0.x.ToString(format, formatProvider), v0.y.ToString(format, formatProvider), v1.x.ToString(format, formatProvider), v1.y.ToString(format, formatProvider));
    }

    #endregion ToString
}

public static unsafe partial class math {
    #region Matrix Math

    /// <summary>Transposes the int2x2 matrix</summary>
    /// <param name="v">Value to transpose</param>
    /// <returns>Transposed value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int2x2 transpose(int2x2 v) {
        return new int2x2(
            v.v0.x, v.v1.x,
            v.v0.y, v.v1.y
        );
    }

    #endregion Matrix Math

}
