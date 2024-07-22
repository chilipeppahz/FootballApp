using Microsoft.Extensions.Logging;

namespace FootballApp.Services
{
    public class FileServices
    {
        private readonly ILogger<FileServices> _logger;

        public FileServices(ILogger<FileServices> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool FileExists(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                _logger.LogWarning("File path is null or empty.");
                return false;
            }

            bool exists = File.Exists(filePath);
            _logger.LogInformation($"Checking file existence for: {filePath}. Exists: {exists}");
            return exists;
        }

        public bool IsFileEmpty(string filePath)
        {
            if (!FileExists(filePath))
            {
                _logger.LogWarning($"File does not exist: {filePath}");
                return true; 
            }

            FileInfo fileInfo = new FileInfo(filePath);
            bool isEmpty = fileInfo.Length == 0;
            _logger.LogInformation($"Checking if file is empty for: {filePath}. Is empty: {isEmpty}");
            return isEmpty;
        }
    }
}
