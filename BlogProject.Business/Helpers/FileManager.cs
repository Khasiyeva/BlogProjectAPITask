using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Helpers
{
    public static class FileManager
    {
        public static bool CheckType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

        public static bool CheckLength(this IFormFile file, int length)
        {
            return file.Length <= length * 1024;
        }
        public static string Upload(this IFormFile file, string envPath, string folderName)
        {
            string f_name = file.FileName;

            if (f_name.Length > 64)
            {
                f_name = f_name.Substring(f_name.Length - 64);
            }

            f_name = Guid.NewGuid().ToString() + f_name;
            string path = envPath + folderName + f_name;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return f_name;
        }
        public static void DeleteFile(this string imgUrl, string envPath, string folderName)
        {
            string path = envPath + folderName + imgUrl;

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
