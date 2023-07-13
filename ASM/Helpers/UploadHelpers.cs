﻿namespace ASM.Helpers
{
    public interface IUploadHelpers
    {
        void UploadImage(IFormFile file, string rootPath, string phanLoai);
        void RemoveImage(string filePath);
    }
    public class UploadHelpers : IUploadHelpers
    {
        public void UploadImage(IFormFile file, string rootPath, string phanLoai)
        {
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            string dirPath = rootPath + @"\" + phanLoai;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string filePath = dirPath + @"\" + file.FileName;

            if (!File.Exists(filePath))
            {
                using (Stream stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
        }

        public void RemoveImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
