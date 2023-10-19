using System.Text.Json.Serialization;

namespace dobra3.Sdk.DataModels
{
    [Serializable]
    public sealed class AnswerDataModel
    {
        [JsonPropertyName("answer")]
        public string? Answer { get; set; }

        [JsonPropertyName("isCorrect")]
        public bool? IsCorrect { get; set; }
    }
}
