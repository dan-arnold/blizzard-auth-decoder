/* Author: Dan Arnold
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetAuthCode
{
    class Program
    {
        static void Main(string[] args)
        {
            String mask = "398e27fc50276a656065b0e525f4c06c04c61075286b8e7aeda59da9813b5dd6c80d2fb38068773fa59ba47c17ca6c6479015c1d5b8b8f6b9a";
            String hash = "5dbd459e6811525d500083dd1496a45d60a572131f5ee81bdb92fbc8e35f3fe2aa3c1f82b209470df0c8894d27fa5e494830682b76bebc5ead";

            byte[] secretKey = StringToByteArray(hash.Substring(0, 80));
            byte[] serial = StringToByteArray(hash.Substring(80));
            byte[] maskBytes = StringToByteArray(mask);

            byte[] decodedSerial = new byte[serial.Length];
            byte[] decodedSecretKey = new byte[secretKey.Length];

            int offset = 40;

            for (int i = 0; i < serial.Length; ++i )
            {
                decodedSerial[i] = (byte) (serial[i] ^ maskBytes[40 + i]);
            }

            for (int i = 0; i < secretKey.Length; ++i)
            {
                decodedSecretKey[i] = (byte)(secretKey[i] ^ maskBytes[i]);
            }

            String decodedSerialString = ASCIIEncoding.UTF8.GetString(decodedSerial);
            String decodedSecretKeyString = ASCIIEncoding.ASCII.GetString(decodedSecretKey);

            Console.WriteLine("Serial: {0}", decodedSerialString);
            Console.WriteLine("Secret Key: {0}", decodedSecretKeyString);
        }

        /// <summary>
        /// Convert a hex string into a byte array. E.g. "001f406a" -> byte[] {0x00, 0x1f, 0x40, 0x6a}
        /// </summary>
        /// <param name="hex">hex string to convert</param>
        /// <returns>byte[] of hex string</returns>
        public static byte[] StringToByteArray(string hex)
        {
            int len = hex.Length;
            byte[] bytes = new byte[len / 2];
            for (int i = 0; i < len; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        /// <summary>
        /// Convert a byte array into a ascii hex string, e.g. byte[]{0x00,0x1f,0x40,ox6a} -> "001f406a"
        /// </summary>
        /// <param name="bytes">byte array to convert</param>
        /// <returns>string version of byte array</returns>
        public static string ByteArrayToString(byte[] bytes)
        {
            // Use BitConverter, but it sticks dashes in the string
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}
