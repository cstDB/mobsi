// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = GettingStarted.FromJson(jsonString);
//
// For POCOs visit quicktype.io?poco
//
namespace Rest
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class TrainData
    {
        [JsonProperty("triebzugnummer")]
        public Triebzugnummer Triebzugnummer { get; set; }

        [JsonProperty("uic-wagennummer")]
        public UicWagennummer UicWagennummer { get; set; }

        [JsonProperty("baureihe")]
        public object Baureihe { get; set; }

        [JsonProperty("uic-triebzugnummer")]
        public object UicTriebzugnummer { get; set; }

        [JsonProperty("vzn")]
        public Vzn Vzn { get; set; }

        [JsonProperty("wagenImZugteil")]
        public object WagenImZugteil { get; set; }
    }

    public partial class Triebzugnummer
    {
        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("tzn")]
        public string Tzn { get; set; }
    }

    public partial class UicWagennummer
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("uic")]
        public string Uic { get; set; }
    }

    public partial class Vzn
    {
        [JsonProperty("taufdatum")]
        public string Taufdatum { get; set; }

        [JsonProperty("vzn")]
        public long OtherVzn { get; set; }
    }


    public partial class TrainData
    {
        public static TrainData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<TrainData>(json, Converter.Settings);
        }
    }
}
