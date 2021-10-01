//
// Box3.cs
//
// Copyright (C) 2019 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;

namespace OpenTK.Mathematics
{
    /// <summary>
    /// Defines an axis-aligned 2d box (rectangle).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Box3 : IEquatable<Box3>
    {
        private Vector3 _min;

        /// <summary>
        /// Gets or sets the minimum boundary of the structure.
        /// </summary>
        public Vector3 Min
        {
            get => _min;
            set
            {
                if (value.X > _max.X)
                {
                    _max.X = value.X;
                }
                if (value.Y > _max.Y)
                {
                    _max.Y = value.Y;
                }
                if (value.Z > _max.Z)
                {
                    _max.Z = value.Z;
                }

                _min = value;
            }
        }

        private Vector3 _max;

        /// <summary>
        /// Gets or sets the maximum boundary of the structure.
        /// </summary>
        public Vector3 Max
        {
            get => _max;
            set
            {
                if (value.X < _min.X)
                {
                    _min.X = value.X;
                }
                if (value.Y < _min.Y)
                {
                    _min.Y = value.Y;
                }
                if (value.Z < _min.Z)
                {
                    _min.Z = value.Z;
                }

                _max = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box3"/> struct.
        /// </summary>
        /// <param name="min">The minimum point on the XY plane this box encloses.</param>
        /// <param name="max">The maximum point on the XY plane this box encloses.</param>
        public Box3(Vector3 min, Vector3 max)
        {
            _min = Vector3.ComponentMin(min, max);
            _max = Vector3.ComponentMax(min, max);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box3"/> struct.
        /// </summary>
        /// <param name="minX">The minimum X value to be enclosed.</param>
        /// <param name="minY">The minimum Y value to be enclosed.</param>
        /// <param name="minZ">The minimum Z value to be enclosed.</param>
        /// <param name="maxX">The maximum X value to be enclosed.</param>
        /// <param name="maxY">The maximum Y value to be enclosed.</param>
        /// <param name="maxZ">The maximum Z value to be enclosed.</param>
        public Box3(float minX, float minY, float minZ, float maxX, float maxY, float maxZ)
            : this(new Vector3(minX, minY, minZ), new Vector3(maxX, maxY, maxZ))
        {
        }

        /// <summary>
        /// Gets or sets a vector describing the size of the Box3 structure.
        /// </summary>
        public Vector3 CenteredSize
        {
            get => Max - Min;
            set
            {
                Vector3 center = Center;
                _min = center - (value * 0.5f);
                _max = center + (value * 0.5f);
            }
        }

        /// <summary>
        /// Gets or sets a vector describing half the size of the box.
        /// </summary>
        public Vector3 HalfSize
        {
            get => CenteredSize / 2;
            set => CenteredSize = value * 2;
        }

        /// <summary>
        /// Gets or sets a vector describing the center of the box.
        /// </summary>
        public Vector3 Center
        {
            get => HalfSize + _min;
            set => Translate(value - Center);
        }

        // --

        /// <summary>
        /// Gets or sets the width of the box.
        /// </summary>
        public float Width
        {
            get => _max.X - _min.X;
            set => _max.X = _min.X + value;
        }

        /// <summary>
        /// Gets or sets the height of the box.
        /// </summary>
        public float Height
        {
            get => _max.Y - _min.Y;
            set => _max.Y = _min.Y + value;
        }

        /// <summary>
        /// Gets or sets the depth of the box.
        /// </summary>
        public float Depth
        {
            get => _max.Z - _min.Z;
            set => _max.Z = _min.Z + value;
        }

        /// <summary>
        /// Gets or sets the left location of the box.
        /// </summary>
        public float Left
        {
            get => _min.X;
            set => _min.X = value;
        }

        /// <summary>
        /// Gets or sets the top location of the box.
        /// </summary>
        public float Top
        {
            get => _min.Y;
            set => _min.Y = value;
        }

        /// <summary>
        /// Gets or sets the right location of the box.
        /// </summary>
        public float Right
        {
            get => _max.X;
            set => _max.X = value;
        }

        /// <summary>
        /// Gets or sets the bottom location of the box.
        /// </summary>
        public float Bottom
        {
            get => _max.Y;
            set => _max.Y = value;
        }

        /// <summary>
        /// Gets or sets the front location of the box.
        /// </summary>
        public float Front
        {
            get => _min.Z;
            set => _min.Z = value;
        }

        /// <summary>
        /// Gets or sets the back location of the box.
        /// </summary>
        public float Back
        {
            get => _max.Z;
            set => _max.Z = value;
        }

        /// <summary>
        /// Gets or sets the X location of the box.
        /// </summary>
        public float X
        {
            get => _min.X;
            set => _min.X = value;
        }

        /// <summary>
        /// Gets or sets the Y location of the box.
        /// </summary>
        public float Y
        {
            get => _min.Y;
            set => _min.Y = value;
        }

        /// <summary>
        /// Gets or sets the Z location of the box.
        /// </summary>
        public float Z
        {
            get => _min.Z;
            set => _min.Z = value;
        }

        /// <summary>
        /// Gets or sets the horizontal size.
        /// </summary>
        public float SizeX
        {
            get => _max.X - _min.X;
            set => _max.X = _min.X + value;
        }

        /// <summary>
        /// Gets or sets the vertical size.
        /// </summary>
        public float SizeY
        {
            get => _max.Y - _min.Y;
            set => _max.Y = _min.Y + value;
        }

        /// <summary>
        /// Gets or sets the vertical size.
        /// </summary>
        public float SizeZ
        {
            get => _max.Z - _min.Z;
            set => _max.Z = _min.Z + value;
        }

        /// <summary>
        /// Gets or sets the size of the box.
        /// </summary>
        public Vector3 Size
        {
            get => new Vector3(_max.X - _min.X, _max.Y - _min.Y, _max.Z - _min.Z);
            set
            {
                _max.X = _min.X + value.X;
                _max.Y = _min.Y + value.Y;
                _max.Z = _min.Z + value.Z;
            }
        }

        /// <summary>
        /// Gets the location of the box.
        /// </summary>
        public Vector3 Location => _min;

        /// <summary>
        /// Gets a value indicating whether all values are zero.
        /// </summary>
        public bool IsEmpty => _min.X == 0 && _min.Y == 0 && _min.Z == 0
                           && _max.X == 0 && _max.Y == 0 && _max.Z == 0;

        /// <summary>
        /// Gets a box with all components zero.
        /// </summary>
        public static readonly Box3 Empty = new Box3(0, 0, 0, 0, 0, 0);

        /// <summary>
        /// Gets a box with a location 0,0,9 with the a size of 1.
        /// </summary>
        public static readonly Box3 UnitSquare = new Box3(0, 0, 0, 1, 1, 1);

        /// <summary>
        /// Creates a box.
        /// </summary>
        /// <param name="location">The location of the box.</param>
        /// <param name="size">The size of the box.</param>
        /// <returns>A box.</returns>
        public static Box3 FromSize(Vector3 location, Vector3 size)
        {
            return new Box3(location, location + size);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box3"/> struct.
        /// </summary>
        /// <param name="min">The minimum point on the XY plane this box encloses.</param>
        /// <param name="max">The maximum point on the XY plane this box encloses.</param>
        /// <returns>A box.</returns>
        public static Box3 FromPositions(Vector3 min, Vector3 max)
        {
            return new Box3(min, max);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box3"/> struct.
        /// </summary>
        /// <param name="minX">The minimum X value to be enclosed.</param>
        /// <param name="minY">The minimum Y value to be enclosed.</param>
        /// <param name="minZ">The minimum Z value to be enclosed.</param>
        /// <param name="maxX">The maximum X value to be enclosed.</param>
        /// <param name="maxY">The maximum Y value to be enclosed.</param>
        /// <param name="maxZ">The maximum Z value to be enclosed.</param>
        /// <returns>A box.</returns>
        public static Box3 FromPositions(float minX, float minY, float minZ, float maxX, float maxY, float maxZ)
        {
            return new Box3(minX, minY, minZ, maxX, maxY, maxZ);
        }

        /// <summary>
        /// Replaces this Box with the intersection of itself and the specified Box.
        /// </summary>
        /// <param name="other">The Box with which to intersect.</param>
        public void Intersect(Box3 other)
        {
            Box3 result = Intersect(other, this);

            X = result.X;
            Y = result.Y;
            Z = result.Z;
            Width = result.Width;
            Height = result.Height;
            Depth = result.Depth;
        }

        /// <summary>
        /// Returns the intersection of two Boxes.
        /// </summary>
        /// <param name="a">The first box.</param>
        /// <param name="b">The second box.</param>
        /// <returns>The intersection of two Boxes.</returns>
        public static Box3 Intersect(Box3 a, Box3 b)
        {
            float minX = a._min.X > b._min.X ? a._min.X : b._min.X;
            float minY = a._min.Y > b._min.Y ? a._min.Y : b._min.Y;
            float minZ = a._min.Z > b._min.Z ? a._min.Z : b._min.Z;
            float maxX = a._max.X < b._max.X ? a._max.X : b._max.X;
            float maxY = a._max.Y < b._max.Y ? a._max.Y : b._max.Y;
            float maxZ = a._max.Z < b._max.Z ? a._max.Z : b._max.Z;

            if (maxX >= minX && maxY >= minY && maxZ >= minZ)
            {
                return new Box3(minX, minY, minZ, maxX, maxY, maxZ);
            }

            return Empty;
        }

        /// <summary>
        /// Returns the intersection of itself and the specified Box.
        /// </summary>
        /// <param name="other">The Box with which to intersect.</param>
        /// <returns>The intersection of itself and the specified Box.</returns>
        public Box3 Intersected(Box3 other)
        {
            return Intersect(other, this);
        }

        /// <summary>
        /// Determines if this Box intersects with another Box.
        /// </summary>
        /// <param name="other">The Box to test.</param>
        /// <returns>This method returns true if there is any intersection, otherwise false.</returns>
        public bool IntersectsWith(Box3 other)
        {
            return other._min.X < _max.X
                && _min.X < other._max.X
                && other._min.Y < _max.Y
                && _min.Y < other._max.Y
                && other._min.Z < _max.Z
                && _min.Z < other._max.Z;
        }

        /// <summary>
        /// Determines if this Box intersects or touches with another Box.
        /// </summary>
        /// <param name="other">The Box to test.</param>
        /// <returns>This method returns true if there is any intersection or touches, otherwise false.</returns>
        public bool TouchWith(Box3 other)
        {
            return other._min.X <= _max.X
                && _min.X <= other._max.X
                && other._min.Y <= _max.Y
                && _min.Y <= other._max.Y
                && other._min.Z <= _max.Z
                && _min.Z <= other._max.Z;
        }

        /// <summary>
        /// Gets a Box structure that contains the union of two Box structures.
        /// </summary>
        /// <param name="a">A Box to union.</param>
        /// <param name="b">a box to union.</param>
        /// <returns>A Box structure that bounds the union of the two Box structures.</returns>
        public static Box3 Union(Box3 a, Box3 b)
        {
            float minX = a._min.X < b._min.X ? a._min.X : b._min.X;
            float minY = a._min.Y < b._min.Y ? a._min.Y : b._min.Y;
            float minZ = a._min.Z < b._min.Z ? a._min.Z : b._min.Z;
            float maxX = a._max.X > b._max.X ? a._max.X : b._max.X;
            float maxY = a._max.Y > b._max.Y ? a._max.Y : b._max.Y;
            float maxZ = a._max.Z > b._max.Z ? a._max.Z : b._max.Z;

            return new Box3(minX, minY, minZ, maxX, maxY, maxZ);
        }

        /// <summary>
        /// Gets a Box structure that contains rounded integers.
        /// </summary>
        /// <param name="value">A Box to round.</param>
        /// <returns>A Box structure that contains rounded integers.</returns>
        public static Box3i Round(Box3 value)
        {
            return new Box3i(
                (int)MathHelper.Round(value.Min.X),
                (int)MathHelper.Round(value.Min.Y),
                (int)MathHelper.Round(value.Min.Z),
                (int)MathHelper.Round(value.Max.X),
                (int)MathHelper.Round(value.Max.Y),
                (int)MathHelper.Round(value.Max.Z));
        }

        /// <summary>
        /// Gets a Box structure that contains rounded up integers.
        /// </summary>
        /// <param name="value">A Box to round.</param>
        /// <returns>A Box structure that contains rounded up integers.</returns>
        public static Box3i Ceiling(Box3 value)
        {
            int x = (int)MathHelper.Ceiling(value._min.X);
            int y = (int)MathHelper.Ceiling(value._min.Y);
            int z = (int)MathHelper.Ceiling(value._min.Z);
            int sizeX = (int)MathHelper.Ceiling(value.Width);
            int sizeY = (int)MathHelper.Ceiling(value.Height);
            int sizeZ = (int)MathHelper.Ceiling(value.Depth);

            return new Box3i(x, y, z, x + sizeX, y + sizeY, z + sizeZ);
        }

        /// <summary>
        /// Gets a Box structure that contains rounded down integers.
        /// </summary>
        /// <param name="value">A Box to round.</param>
        /// <returns>A Box structure that contains rounded down integers.</returns>
        public static Box3i Floor(Box3 value)
        {
            int x = (int)MathHelper.Floor(value._min.X);
            int y = (int)MathHelper.Floor(value._min.Y);
            int z = (int)MathHelper.Floor(value._min.Z);
            int sizeX = (int)MathHelper.Floor(value.Width);
            int sizeY = (int)MathHelper.Floor(value.Height);
            int sizeZ = (int)MathHelper.Floor(value.Depth);

            return new Box3i(x, y, z, x + sizeX, y + sizeY, z + sizeZ);
        }

        // --

        /// <summary>
        /// Returns whether the box contains the specified point (borders inclusive).
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <returns>Whether this box contains the point.</returns>
        [Pure]
        public bool Contains(Vector3 point)
        {
            return _min.X < point.X && point.X < _max.X &&
                   _min.Y < point.Y && point.Y < _max.Y &&
                   _min.Z < point.Z && point.Z < _max.Z;
        }

        /// <summary>
        /// Returns whether the box contains the specified point (borders inclusive).
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <param name="boundaryInclusive">
        /// Whether points on the box boundary should be recognised as contained as well.
        /// </param>
        /// <returns>Whether this box contains the point.</returns>
        [Pure]
        public bool Contains(Vector3 point, bool boundaryInclusive)
        {
            if (boundaryInclusive)
            {
                return _min.X <= point.X && point.X <= _max.X &&
                       _min.Y <= point.Y && point.Y <= _max.Y &&
                       _min.Z <= point.Z && point.Z <= _max.Z;
            }
            return _min.X < point.X && point.X < _max.X &&
                   _min.Y < point.Y && point.Y < _max.Y &&
                   _min.Z < point.Z && point.Z < _max.Z;
        }

        /// <summary>
        /// Returns whether the box contains the specified box (borders inclusive).
        /// </summary>
        /// <param name="other">The box to query.</param>
        /// <returns>Whether this box contains the other box.</returns>
        [Pure]
        public bool Contains(Box3 other)
        {
            return _max.X >= other._min.X && _min.X <= other._max.X &&
                   _max.Y >= other._min.Y && _min.Y <= other._max.Y &&
                   _max.Z >= other._min.Z && _min.Z <= other._max.Z;
        }

        /// <summary>
        /// Returns the distance between the nearest edge and the specified point.
        /// </summary>
        /// <param name="point">The point to find distance for.</param>
        /// <returns>The distance between the specified point and the nearest edge.</returns>
        [Pure]
        public float DistanceToNearestEdge(Vector3 point)
        {
            var distX = new Vector3(
                Math.Max(0f, Math.Max(_min.X - point.X, point.X - _max.X)),
                Math.Max(0f, Math.Max(_min.Y - point.Y, point.Y - _max.Y)),
                Math.Max(0f, Math.Max(_min.Z - point.Z, point.Z - _max.Z)));
            return distX.Length;
        }

        /// <summary>
        /// Translates this Box3 by the given amount.
        /// </summary>
        /// <param name="distance">The distance to translate the box.</param>
        public void Translate(Vector3 distance)
        {
            _min += distance;
            _max += distance;
        }

        /// <summary>
        /// Returns a Box3 translated by the given amount.
        /// </summary>
        /// <param name="distance">The distance to translate the box.</param>
        /// <returns>The translated box.</returns>
        [Pure]
        public Box3 Translated(Vector3 distance)
        {
            // create a local copy of this box
            Box3 box = this;
            box.Translate(distance);
            return box;
        }

        /// <summary>
        /// Scales this Box3 by the given amount.
        /// </summary>
        /// <param name="scale">The scale to scale the box.</param>
        /// <param name="anchor">The anchor to scale the box from.</param>
        public void Scale(Vector3 scale, Vector3 anchor)
        {
            _min = anchor + ((_min - anchor) * scale);
            _max = anchor + ((_max - anchor) * scale);
        }

        /// <summary>
        /// Returns a Box3 scaled by a given amount from an anchor point.
        /// </summary>
        /// <param name="scale">The scale to scale the box.</param>
        /// <param name="anchor">The anchor to scale the box from.</param>
        /// <returns>The scaled box.</returns>
        [Pure]
        public Box3 Scaled(Vector3 scale, Vector3 anchor)
        {
            // create a local copy of this box
            Box3 box = this;
            box.Scale(scale, anchor);
            return box;
        }

        /// <summary>
        /// Inflate this Box3 to encapsulate a given point.
        /// </summary>
        /// <param name="point">The point to query.</param>
        public void Inflate(Vector3 point)
        {
            _min = Vector3.ComponentMin(_min, point);
            _max = Vector3.ComponentMax(_max, point);
        }

        /// <summary>
        /// Inflate this Box3 to encapsulate a given point.
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <returns>The inflated box.</returns>
        [Pure]
        public Box3 Inflated(Vector3 point)
        {
            // create a local copy of this box
            Box3 box = this;
            box.Inflate(point);
            return box;
        }

        /// <summary>
        /// Equality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator ==(Box3 left, Box3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator !=(Box3 left, Box3 right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is Box3 && Equals((Box3)obj);
        }

        /// <inheritdoc/>
        public bool Equals(Box3 other)
        {
            return _min.Equals(other._min) &&
                   _max.Equals(other._max);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(_min, _max);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Min} - {Max}";
        }
    }
}
