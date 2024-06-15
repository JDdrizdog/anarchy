using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Anarchy.StreamLibrary.src
{
    public class JpgCompression
    {
        private EncoderParameter parameter;

        private ImageCodecInfo encoderInfo;

        private EncoderParameters encoderParams;

        public JpgCompression(int Quality)
        {
            this.parameter = new EncoderParameter(Encoder.Quality, Quality);
            this.encoderInfo = this.GetEncoderInfo("image/jpeg");
            this.encoderParams = new EncoderParameters(2);
            this.encoderParams.Param[0] = this.parameter;
            this.encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
        }

        public byte[] Compress(Bitmap bmp)
        {
            using MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, this.encoderInfo, this.encoderParams);
            return memoryStream.ToArray();
        }

        public void Compress(Bitmap bmp, ref Stream TargetStream)
        {
            bmp.Save(TargetStream, this.encoderInfo, this.encoderParams);
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders;
            imageEncoders = ImageCodecInfo.GetImageEncoders();
            int num;
            num = imageEncoders.Length - 1;
            int num2;
            num2 = 0;
            while (true)
            {
                if (num2 <= num)
                {
                    if (imageEncoders[num2].MimeType == mimeType)
                    {
                        break;
                    }
                    num2++;
                    continue;
                }
                return null;
            }
            return imageEncoders[num2];
        }
    }
}
