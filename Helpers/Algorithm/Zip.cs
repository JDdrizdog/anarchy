using System;
using System.IO;
using System.IO.Compression;

namespace Anarchy.Helpers.Algorithm
{
    public static class Zip
    {
        public static byte[] Decompress(byte[] input)
        {
            using MemoryStream memoryStream = new MemoryStream(input);
            byte[] array;
            array = new byte[4];
            memoryStream.Read(array, 0, 4);
            int num;
            num = BitConverter.ToInt32(array, 0);
            using GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
            byte[] array2;
            array2 = new byte[num];
            gZipStream.Read(array2, 0, num);
            return array2;
        }

        public static byte[] Compress(byte[] input)
        {
            using MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(BitConverter.GetBytes(input.Length), 0, 4);
            using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                gZipStream.Write(input, 0, input.Length);
                gZipStream.Flush();
            }
            return memoryStream.ToArray();
        }
    }
}
