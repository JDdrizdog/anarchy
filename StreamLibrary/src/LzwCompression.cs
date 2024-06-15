using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Anarchy.StreamLibrary.src
{
    public class LzwCompression
    {
        private EncoderParameter parameter;

        private ImageCodecInfo encoderInfo;

        private EncoderParameters encoderParams;

        public LzwCompression(int Quality)
        {
            this.parameter = new EncoderParameter(Encoder.Quality, Quality);
            this.encoderInfo = this.GetEncoderInfo("image/jpeg");
            this.encoderParams = new EncoderParameters(2);
            this.encoderParams.Param[0] = this.parameter;
            this.encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
        }

        public byte[] Compress(Bitmap bmp, byte[] AdditionInfo = null)
        {
            using MemoryStream memoryStream = new MemoryStream();
            if (AdditionInfo != null)
            {
                memoryStream.Write(AdditionInfo, 0, AdditionInfo.Length);
            }
            bmp.Save(memoryStream, this.encoderInfo, this.encoderParams);
            return memoryStream.ToArray();
        }

        public void Compress(Bitmap bmp, Stream stream, byte[] AdditionInfo = null)
        {
            if (AdditionInfo != null)
            {
                stream.Write(AdditionInfo, 0, AdditionInfo.Length);
            }
            bmp.Save(stream, this.encoderInfo, this.encoderParams);
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders;
            imageEncoders = ImageCodecInfo.GetImageEncoders();
            int num;
            num = 0;
            while (true)
            {
                if (num < imageEncoders.Length)
                {
                    if (imageEncoders[num].MimeType == mimeType)
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                return null;
            }
            return imageEncoders[num];
        }
    }
}
