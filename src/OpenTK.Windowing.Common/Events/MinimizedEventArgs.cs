//
// MinimizedEventArgs.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

namespace OpenTK.Windowing.Common
{
    /// <summary>
    /// Defines the event data for the window minimizing event.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MinimizedEventArgs"/> struct.
    /// </remarks>
    /// <param name="isMinimized">
    /// A value indicating whether the window is minimized.
    /// </param>
    public readonly struct MinimizedEventArgs(bool isMinimized)
    {

        /// <summary>
        /// Gets a value indicating whether the window is minimized.
        /// </summary>
        public bool IsMinimized { get; } = isMinimized;
    }
}
