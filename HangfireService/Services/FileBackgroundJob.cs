using System;
using Hangfire;

namespace HangfireService.Services
{
    public class FileBackgroundJob: IFileBackgroundJob
    {
        /// <summary>
        /// Вызываем отложенное создание файла
        /// </summary>
        /// <param name="minutesAmount">на сколько минут отложить задачу</param>
        /// <returns>Job identifier</returns>
        public string DelayedCreation(int minutesAmount)
        {
            return BackgroundJob.Schedule(() => FilesService.CreateFile(DateTime.UtcNow.ToLongTimeString()), TimeSpan.FromMinutes(minutesAmount));
        }

        /// <summary>
        /// Вызываем отложенное создание файла. В требуемое время Job вызовет метод нужного класса.
        /// </summary>
        /// <param name="minutesAmount">на сколько минут отложить задачу</param>
        /// <returns>Job identifier</returns>
        public string DelayedCreationNonStatic(int minutesAmount)
        {
            return BackgroundJob.Schedule(() => FilesService.CreateFile(DateTime.UtcNow.ToLongTimeString()), TimeSpan.FromMinutes(minutesAmount));
        }

        /// <summary>
        /// Удалить отложенную задачу
        /// </summary>
        /// <param name="jobId">идентификатор задачи</param>
        /// <returns>True on a successfull state transition, false otherwise.</returns>
        public bool RemoveDelayedJob(string jobId)
        {
            return BackgroundJob.Delete(jobId);
        }
    }
}
