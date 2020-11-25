namespace _01._Logger.IOManagement
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
