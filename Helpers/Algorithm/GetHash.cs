using System;
using System.IO;
using System.Security.Cryptography;

namespace Anarchy.Helpers.Algorithm
{
    public static class GetHash
    {
        public static string GetChecksum(string file)
        {
            using FileStream inputStream = File.OpenRead(file);
            return BitConverter.ToString(new SHA256Managed().ComputeHash(inputStream)).Replace("-", string.Empty);
        }
    }
}
