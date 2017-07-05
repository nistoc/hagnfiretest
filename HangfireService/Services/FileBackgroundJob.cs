using System;
using Hangfire;

namespace HangfireService.Services
{
    public class FileBackgroundJob: IFileBackgroundJob
    {
        /// <summary>
        /// Вызываем отложенное создание файла
        /// </summary>
        /// <returns></returns>
        public string DelayedCreation()
        {
            var callTime = DateTime.UtcNow.ToLongTimeString();
            BackgroundJob.Schedule(() => FilesService.CreateFile(callTime), TimeSpan.FromMinutes(1));
            return callTime;
        }
    }
}
