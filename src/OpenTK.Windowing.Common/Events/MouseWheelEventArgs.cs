//
// MouseWheelEventArgs.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using OpenTK.Mathematics;

namespace OpenTK.Windowing.Common
{
    /// <summary>
    /// Defines the event data for <see cref="NativeWindow.MouseWheel" /> events.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MouseWheelEventArgs"/> struct.
    /// </remarks>
    /// <param name="offset">The offset the mouse wheel was moved.</param>
    public readonly struct MouseWheelEventArgs(Vector2 offset)
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseWheelEventArgs"/> struct.
        /// </summary>
        /// <param name="offsetX">The offset on the X axis.</param>
        /// <param name="offsetY">The offset on the Y axis.</param>
        public MouseWheelEventArgs(float offsetX, float offsetY)
            : this(new Vector2(offsetX, offsetY))
        {
        }

        /// <summary>
        /// Gets the offset the mouse wheel was moved.
        /// </summary>
        public Vector2 Offset { get; } = offset;

        /// <summary>
        /// Gets the offset on the X axis.
        /// </summary>
        public float OffsetX => Offset.X;

        /// <summary>
        /// Gets the offset on the Y axis.
        /// </summary>
        public float OffsetY => Offset.Y;
    }
}
