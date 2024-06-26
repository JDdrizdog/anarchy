using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Anarchy.StreamLibrary.src;

namespace Anarchy.StreamLibrary
{
    public abstract class IUnsafeCodec
    {
        protected JpgCompression jpgCompression;

        protected LzwCompression lzwCompression;

        private int _imageQuality;

        public abstract ulong CachedSize { get; internal set; }

        protected object ImageProcessLock { get; private set; }

        public int ImageQuality
        {
            get
            {
                return this._imageQuality;
            }
            set
            {
                this._imageQuality = value;
                this.jpgCompression = new JpgCompression(value);
                this.lzwCompression = new LzwCompression(value);
            }
        }

        public abstract int BufferCount { get; }

        public abstract CodecOption CodecOptions { get; }

        public abstract event IVideoCodec.VideoDebugScanningDelegate onCodeDebugScan;

        public abstract event IVideoCodec.VideoDebugScanningDelegate onDecodeDebugScan;

        public IUnsafeCodec(int ImageQuality = 100)
        {
            this.ImageQuality = ImageQuality;
            this.ImageProcessLock = new object();
        }

        public abstract void CodeImage(IntPtr Scan0, Rectangle ScanArea, Size ImageSize, PixelFormat Format, Stream outStream);

        public abstract Bitmap DecodeData(Stream inStream);

        public abstract Bitmap DecodeData(IntPtr CodecBuffer, uint Length);
    }
}
