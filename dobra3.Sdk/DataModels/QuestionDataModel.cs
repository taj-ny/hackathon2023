using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dobra3.Sdk.DataModels
{
    [Serializable]
    public sealed record QuestionDataModel(string? Question, int? Difficulty, List<AnswerDataModel>? Answers)
    {
        [JsonPropertyName("question")]
        public string? Question { get; set; }

        [JsonPropertyName("difficulty")]
        public int? Difficulty { get; set; }


        [JsonPropertyName("answers")]
        public List<AnswerDataModel>? Answers { get; set; }
    }
}
