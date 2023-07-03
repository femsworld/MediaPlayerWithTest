using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayerWithTest.Controller.src;
using MediaPlayerWithTest.Service.src.ServiceInterface;

namespace MediaPlayerWithTest.Controller.src
{
    public class MediaController
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public void CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            if (IsValidFileName(fileName) && IsValidFilePath(filePath) && IsValidDuration(duration))
            {
                _mediaService.CreateNewFile(fileName, filePath, duration);
            }
        }

        public void DeleteFileById(int id)
        {
            if (IsValidId(id))
            {
                _mediaService.DeleteFileById(id);
            }
        }

        public void GetAllFiles()
        {
            _mediaService.GetAllFiles();
        }

        public void GetFileById(int id)
        {
             if (IsValidId(id))
            {
                _mediaService.GetFileById(id);
            }
        }

        private static bool IsValidFileName(string fileName)
        {
            return !string.IsNullOrEmpty(fileName);
        }

        private static bool IsValidFilePath(string filePath)
        {
            return !string.IsNullOrEmpty(filePath);
        }

        private static bool IsValidDuration(TimeSpan duration)
        {
            return duration > TimeSpan.Zero;
        }

        private static bool IsValidId(int id)
        {
            return id > 0;
        }

    }
}