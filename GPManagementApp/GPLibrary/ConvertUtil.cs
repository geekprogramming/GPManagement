using System;
using System.IO;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace GPLibrary
{
    public class ConvertUtil
    {
        public static string upperFirstLetter(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string upperFirstLetterString(string str)
        {
            if (string.IsNullOrWhiteSpace(str)){
                return null;
            }
            else
            {
                char[] a = str.ToCharArray();
                a[0] = char.ToUpper(a[0]);
                return new string(a);
            }
        }

        public static bool convertStringToDateTime(string str,string pattern,DateTime parsedDate)
        {
            if(DateTime.TryParseExact(str, pattern, null, DateTimeStyles.None, out parsedDate))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static byte[] convertBlobToBufferData(String column,MySqlDataReader rdr)
        {
            int bufferSize = 1024; // Number of bytes to read at a time
            byte[] ImageData = new byte[bufferSize];
            long nBytesReturned, startIndex = 0;
            int ordinal = rdr.GetOrdinal(column);
            string image = rdr.IsDBNull(ordinal) ? null : rdr.GetString(column);
            if (image != null)
            {
                startIndex = 0;

                nBytesReturned = rdr.GetBytes(
                ordinal, // Column index of BLOB column
                startIndex, // Start position of the byte to read
                ImageData, // Byte array to recieve BLOB data
                0, // Start index of the array
                bufferSize // Size of buffer
                );
                while (nBytesReturned == bufferSize)
                {
                    startIndex += bufferSize;
                    nBytesReturned = rdr.GetBytes(ordinal, startIndex, ImageData, 0, bufferSize); // Number of bytes returned is assigned to nBytesReturned
                }
                return ImageData;
            }
            else
            {
                return null;
            }
        }
        public static byte[] convertFileToBufferData(string path)
        {
            FileStream fs = new FileStream(path,FileMode.Open);
            BufferedStream bf = new BufferedStream(fs);
            byte[] buffer = new byte[bf.Length];
            bf.Read(buffer, 0, buffer.Length);
            byte[] buffer_new = buffer;
            return buffer_new;
        }
    }
}
