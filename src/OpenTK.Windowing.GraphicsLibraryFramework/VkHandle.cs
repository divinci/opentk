using System;
using System.Runtime.InteropServices;

namespace OpenTK.Windowing.GraphicsLibraryFramework
{
    /// <summary>
    ///     A handle to a Vulkan object.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="VkHandle"/> struct.
    /// </remarks>
    /// <param name="handle">
    /// The native Vulkan handle.
    /// This is NOT a pointer to a field containing the handle, this is the actual handle itself.
    /// </param>
    [StructLayout(LayoutKind.Sequential)]
    public struct VkHandle(IntPtr handle)
    {
        /// <summary>
        /// The actual value of the Vulkan handle.
        /// </summary>
        public IntPtr Handle = handle;
    }
}
