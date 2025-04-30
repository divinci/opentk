//
// FocusChangedEventArgs.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using System;

namespace OpenTK.Windowing.Common
{
    /// <summary>
    /// Defines the event data for the window focus changing.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FocusedChangedEventArgs"/> struct.
    /// </remarks>
    /// <param name="isFocused">A value indicating whether the window is focused.</param>
    public readonly struct FocusedChangedEventArgs(bool isFocused)
    {

        /// <summary>
        /// Gets a value indicating whether the window is focused.
        /// </summary>
        public bool IsFocused { get; } = isFocused;
    }
}
