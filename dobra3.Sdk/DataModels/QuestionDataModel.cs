using System.Text.Json.Serialization;

namespace dobra3.Sdk.DataModels
{
    [Serializable]
    public sealed class QuestionDataModel
    {
        [JsonPropertyName("question")]
        public string? Question { get; set; }

        [JsonPropertyName("difficulty")]
        public int Difficulty { get; set; }
        
        [JsonPropertyName("answers")]
        public List<AnswerDataModel>? Answers { get; set; }
    }
}
