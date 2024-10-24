
namespace TodoApp.MVC.Tools.Convertors
{
    public static class TextHelper
    {
        public static string RemoveWhiteSpace(this string text)
        {
            return text.Replace(" ", string.Empty);
        }
    }
}
