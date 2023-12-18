namespace DOAN.Utilities
{
    public class Functions
    {
        public static string TitleSlugGeneration(string type, string title, int id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }
    }
}
