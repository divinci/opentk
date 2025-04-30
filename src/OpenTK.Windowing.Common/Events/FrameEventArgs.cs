//
// FrameEventArgs.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

namespace OpenTK.Windowing.Common
{
    /// <summary>
    /// Defines the arguments for frame events.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FrameEventArgs"/> struct.
    /// </remarks>
    /// <param name="elapsed">The amount of time that has elapsed since the previous event, in seconds.</param>
    public readonly struct FrameEventArgs(double elapsed)
    {

        /// <summary>
        /// Gets how many seconds of time elapsed since the previous event.
        /// </summary>
        public double Time { get; } = elapsed;
    }
}
