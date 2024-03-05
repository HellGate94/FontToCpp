using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellEngine.Mathematics;

public partial struct int2 {
    public static implicit operator int2(Point v) => new(v.X, v.Y);
    public static implicit operator Point(int2 v) => new(v.x, v.y);

    public static implicit operator int2(Size v) => new(v.Width, v.Height);
    public static implicit operator Size(int2 v) => new(v.x, v.y);
}

public partial struct float2 {
    public static implicit operator float2(PointF v) => new(v.X, v.Y);
    public static implicit operator PointF(float2 v) => new(v.x, v.y);

    public static implicit operator float2(SizeF v) => new(v.Width, v.Height);
    public static implicit operator SizeF(float2 v) => new(v.x, v.y);
}