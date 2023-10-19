using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dobra3.Sdk.DataModels
{
    [Serializable]
    public sealed record QuestionSetDataModel(string? Name, List<QuestionDataModel>? Questions)
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("questions")]
        public List<QuestionDataModel>? Questions { get; set; }
    }
}
