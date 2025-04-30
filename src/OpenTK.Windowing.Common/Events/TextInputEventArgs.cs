//
// KeyPressEventArgs.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

namespace OpenTK.Windowing.Common
{
    /// <summary>
    ///     Raised when a single unicode code point is input.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="TextInputEventArgs"/> struct.
    /// </remarks>
    /// <param name="unicode">The unicode code point that was input.</param>
    public readonly struct TextInputEventArgs(int unicode)
    {

        /// <summary>
        ///     Gets the Unicode code point that was input.
        /// </summary>
        public int Unicode { get; } = unicode;

        /// <summary>
        ///     Gets the string representation of the input Unicode code point.
        /// </summary>
        public string AsString => char.ConvertFromUtf32(Unicode);
    }
}
