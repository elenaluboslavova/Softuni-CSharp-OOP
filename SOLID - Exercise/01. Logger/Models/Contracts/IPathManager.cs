namespace _01._Logger.Models.Contracts
{
    public interface IPathManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentPath();

        void EnsureDirectoryAndFileExists();
    }
}
