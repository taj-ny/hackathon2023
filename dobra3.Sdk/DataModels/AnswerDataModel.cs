using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dobra3.Sdk.DataModels
{
    [Serializable]
    public sealed record AnswerDataModel(string? Answer, bool? IsCorrect)
    {
        [JsonPropertyName("answer")]
        public string? Answer { get; set; }

        [JsonPropertyName("isCorrect")]
        public bool? IsCorrect { get; set; }
    }
}
