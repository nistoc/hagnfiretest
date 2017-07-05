using System;
using System.IO;
using System.Text;
using System.Web.Hosting;

namespace HangfireService.Services
{
    public static class FilesService
    {
        public static void CreateFile(string prefix)
        {
            try
            {
                var pathToFile = $@"{HostingEnvironment.ApplicationPhysicalPath}" + @"jobs\" + $@" {prefix} - {DateTime.Now.ToUniversalTime().ToLongTimeString()}.txt".Replace(":", "-");

                // Create the file.
                using (FileStream fs = File.Create(pathToFile))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}