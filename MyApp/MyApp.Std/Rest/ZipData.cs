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

    public partial class ZipData
    {
        [JsonProperty("chassisId")]
        public string ChassisId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }


    public partial class ZipData
    {
        public static ZipData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ZipData>(json, Converter.Settings);
        }
    }
}
