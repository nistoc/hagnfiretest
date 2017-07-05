namespace HangfireService.Services
{
    interface IFileBackgroundJob
    {
        /// <summary>
        /// Вызываем отложенное создание файла
        /// </summary>
        /// <param name="minutesAmount">на сколько минут отложить задачу</param>
        /// <returns>идентификатор задачи</returns>
        string DelayedCreation(int minutesAmount);

        /// <summary>
        /// Удалить отложенную задачу
        /// </summary>
        /// <param name="jobId">идентификатор задачи</param>
        /// <returns>True on a successfull state transition, false otherwise.</returns>
        bool RemoveDelayedJob(string jobId);
    }
}