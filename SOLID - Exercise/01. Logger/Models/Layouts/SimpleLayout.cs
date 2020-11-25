using _01._Logger.Models.Contracts;
namespace _01._Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
