namespace HangfireService.Services
{
    interface IFileBackgroundJob
    {
        /// <summary>
        /// Вызываем отложенное создание файла
        /// </summary>
        /// <returns>время создания файла</returns>
        string DelayedCreation();
    }
}