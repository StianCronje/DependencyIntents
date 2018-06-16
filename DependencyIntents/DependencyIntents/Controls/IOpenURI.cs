namespace DependencyIntents.Controls
{
    public interface IOpenURI
    {
        void OpenLocation(string title, double latitude, double longitude);
        void Share(string title, string message, string imageUrl = null);
    }
}