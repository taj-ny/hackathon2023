namespace dobra3.Shared.Extensions
{
    public static class FileExtensions
    {
        public static Stream? TryOpenRead(string filePath)
        {
            try
            {
                return File.OpenRead(filePath);
            }
            catch (Exception ex)
            {
                _ = ex;
                return null;
            }
        }
    }
}
