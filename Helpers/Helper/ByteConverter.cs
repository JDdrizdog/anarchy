using System;
using System.Collections.Generic;
using System.Text;

namespace Anarchy.Helpers.Helper
{
    public class ByteConverter
    {
        private static byte NULL_BYTE;

        public static byte[] GetBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(long value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(string value)
        {
            return ByteConverter.StringToBytes(value);
        }

        public static byte[] GetBytes(string[] value)
        {
            return ByteConverter.StringArrayToBytes(value);
        }

        public static int ToInt32(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }

        public static long ToInt64(byte[] bytes)
        {
            return BitConverter.ToInt64(bytes, 0);
        }

        public static uint ToUInt32(byte[] bytes)
        {
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static ulong ToUInt64(byte[] bytes)
        {
            return BitConverter.ToUInt64(bytes, 0);
        }

        public static string ToString(byte[] bytes)
        {
            return ByteConverter.BytesToString(bytes);
        }

        public static string[] ToStringArray(byte[] bytes)
        {
            return ByteConverter.BytesToStringArray(bytes);
        }

        private static byte[] GetNullBytes()
        {
            return new byte[2]
            {
                ByteConverter.NULL_BYTE,
                ByteConverter.NULL_BYTE
            };
        }

        private static byte[] StringToBytes(string value)
        {
            byte[] array;
            array = new byte[value.Length * 2];
            Buffer.BlockCopy(value.ToCharArray(), 0, array, 0, array.Length);
            return array;
        }

        private static byte[] StringArrayToBytes(string[] strings)
        {
            List<byte> list;
            list = new List<byte>();
            for (int i = 0; i < strings.Length; i++)
            {
                list.AddRange(ByteConverter.StringToBytes(strings[i]));
                list.AddRange(ByteConverter.GetNullBytes());
            }
            return list.ToArray();
        }

        private static string BytesToString(byte[] bytes)
        {
            char[] array;
            array = new char[(int)Math.Ceiling((float)bytes.Length / 2f)];
            Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
            return new string(array);
        }

        private static string[] BytesToStringArray(byte[] bytes)
        {
            List<string> list;
            list = new List<string>();
            int i;
            i = 0;
            StringBuilder stringBuilder;
            stringBuilder = new StringBuilder(bytes.Length);
            while (i < bytes.Length)
            {
                int num;
                num = 0;
                for (; i < bytes.Length; i++)
                {
                    if (num >= 3)
                    {
                        break;
                    }
                    if (bytes[i] == ByteConverter.NULL_BYTE)
                    {
                        num++;
                        continue;
                    }
                    stringBuilder.Append(Convert.ToChar(bytes[i]));
                    num = 0;
                }
                list.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            return list.ToArray();
        }
    }
}
