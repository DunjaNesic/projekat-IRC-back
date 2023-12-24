namespace Projekat.IRC.Logging
{
    public interface ILoggger
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}