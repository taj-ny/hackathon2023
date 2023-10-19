using System.Text.Json.Serialization;

namespace dobra3.Sdk.DataModels
{
    [Serializable]
    public sealed class QuestionSetDataModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("questions")]
        public List<QuestionDataModel>? Questions { get; set; }
    }
}
