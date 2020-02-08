﻿using SharpDX.Direct3D11;
using System;

namespace ImGuiScene.DX11
{
    /// <summary>
    /// DX11 Implementation of <see cref="TextureWrap"/>.
    /// Provides a simple wrapped view of the disposeable resource as well as the handle for ImGui.
    /// </summary>
    public class DX11TextureWrap : TextureWrap
    {
        // hold onto this directly for easier dispose etc and in case we need it later
        private ShaderResourceView _resourceView = null;

        public int Width { get; }
        public int Height { get; }
        public IntPtr ImGuiHandle => (_resourceView == null) ? IntPtr.Zero : _resourceView.NativePointer;

        public DX11TextureWrap(ShaderResourceView texView, int width, int height)
        {
            _resourceView = texView;
            Width = width;
            Height = height;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _resourceView?.Dispose();
                _resourceView = null;

                disposedValue = true;
            }
        }

        ~DX11TextureWrap()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
