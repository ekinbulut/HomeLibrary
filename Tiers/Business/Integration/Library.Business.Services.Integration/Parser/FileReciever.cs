using System;
using System.IO;
using Castle.Core.Logging;

namespace Library.Business.Services.Integration.Parser
{
    public class FileReciever : IFileReciever
    {
        private readonly ILogger _logger;

        public FileReciever(ILogger logger)
        {
            _logger = logger;
        }

        public bool RecieveFile(string strdocPath, byte[] bytes)
        {
            try
            {
                using (FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    var byteArray = bytes;
                    objfilestream.Write(byteArray, 0, byteArray.Length);
                    objfilestream.Close();
                }

                return true;
            }
            catch (Exception error)
            {
                _logger.Error("Error occured while reading stream",error);
                return false;
            }
        }

        public void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public bool ValidatePath(string path)
        {
            if (path == null)
            {
                _logger.Error("Upload folder is not configured.");

                return false;
            }

            return true;
        }
    }
}
