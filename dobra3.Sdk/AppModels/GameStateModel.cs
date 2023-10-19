using dobra3.Shared.Api;

namespace dobra3.Sdk.AppModels
{
    public static class GameStateModel
    {
        public static string? OpenAiKey { get; set; } = ApiKeys.GetOpenAiKey();

        public static string? QuestionsFilePath { get; set; }
    }
}
