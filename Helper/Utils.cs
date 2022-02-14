using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;

namespace MineralInventory.Helper
{
    public static class Utils
    {
        private static string ConvertFileToBase64(string link_file)
        {
            Console.WriteLine (link_file);
            try
            {
                using (
                    Stream s =
                        new FileStream(link_file,
                            FileMode.Open,
                            FileAccess.Read)
                )
                {
                    byte[] bytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        s.CopyTo (memoryStream);
                        bytes = memoryStream.ToArray();
                    }
                    return Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static void EnsureDir (string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void EnsureFile(string pathString)
        {
            if (!System.IO.File.Exists(pathString))
            {
                System.IO.File.Create(pathString);
            }
        }

        public static ByteString ConvertToByteString(byte[] arg)
        {
            using (var str = new MemoryStream(arg))
            {
                return ByteString.FromStream(str);
            }
        }

        public async static Task<FileInfo> ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (
                    var fs = new FileStream(fileName,
                            FileMode.Create,
                            FileAccess.Write)
                )
                {
                    
                    fs.Write(byteArray, 0, byteArray.Length);
                    fs.Close();
                    FileInfo fileInfo = new FileInfo(fileName);
                    return await Task.FromResult(fileInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                throw ex;
            }
        }

        public static byte[] StreamFile(string filename)
        {
            FileStream fs =
                new FileStream(filename, FileMode.Open, FileAccess.Read);
            try
            {
                // Create a byte array of file stream length
                byte[] ImageData = new byte[fs.Length];

                //Read block of bytes from stream into the byte array
                fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

                //Close the File Stream
                return ImageData; //return the byte data
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex Stream File");
                throw ex;
            }
            finally
            {
                fs.Close();
            }
        }

        /* File Function */
        public static FileInfo GetFileTemplate(string template, string output)
        {
            string filePath = "Files/" + template;
            FileInfo file = new FileInfo(filePath);
            return file;
        }

        public static void DeleteFileinFolder(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                foreach (string filename in System.IO.Directory.GetFiles(path))
                {
                    System.IO.File.Delete (filename);
                }
            }
        }
        public static bool ValidateDateTime(string date)
        {
            try
            {
                DateTime.ParseExact(date,"yyyy-MM-dd",CultureInfo.InvariantCulture,DateTimeStyles.None);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }
        public static string NullIfWhiteSpace( string value) {
            value = value.Trim();
            if (String.IsNullOrWhiteSpace(value)) { return null; }
        return value;
        }

        public static bool CheckShift(string nameShift)
        {
            List<string> nameShifts = new List<string> { "CA 1", "CA 2", "CA 3" };
            if (nameShifts.Exists(x => x == nameShift.Trim().ToUpper()))
                return true;
            return false;
        }


        /* End File Function*/
       
    }
}
