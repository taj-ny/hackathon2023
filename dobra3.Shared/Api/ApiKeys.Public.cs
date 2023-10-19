namespace dobra3.Shared.Api
{
    public static partial class ApiKeys
    {
        public static string? GetOpenAiKey()
        {
            string? key = null;
            GetOpenAiKey(ref key);

            return key;
        }

        static partial void GetOpenAiKey(ref string? key);
    }
}
