//
// MouseButtonEventArgs.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTK.Windowing.Common
{
    /// <summary>
    /// Defines the event data for <see cref="NativeWindow.MouseDown" />
    /// and <see cref="NativeWindow.MouseUp" /> events.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MouseButtonEventArgs"/> struct.
    /// </remarks>
    /// <param name="button">The mouse button for the event.</param>
    /// <param name="action">The action of the mouse button.</param>
    /// <param name="modifiers">The key modifiers held during the mouse button's action.</param>
    public readonly struct MouseButtonEventArgs(MouseButton button, InputAction action, KeyModifiers modifiers)
    {

        /// <summary>
        /// Gets the <see cref="MouseButton" /> that triggered this event.
        /// </summary>
        public MouseButton Button { get; } = button;

        /// <summary>
        /// Gets the <see cref="InputAction"/> of the pressed button.
        /// </summary>
        public InputAction Action { get; } = action;

        /// <summary>
        /// Gets the active <see cref="KeyModifiers"/> of the pressed button.
        /// </summary>
        public KeyModifiers Modifiers { get; } = modifiers;

        /// <summary>
        /// Gets a value indicating whether the <see cref="Button"/> which triggered this event was pressed or released.
        /// </summary>
        public bool IsPressed => Action != InputAction.Release;
    }
}
