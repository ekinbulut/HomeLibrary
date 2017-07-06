using System;
using Newtonsoft.Json;

namespace Library.Api.Objects
{
    [JsonObject(MemberSerialization.Fields)]
    [Serializable]
    public class AuthOutputDto
    {
        public string AppKey { get; set; }

        public string AppSecretKey { get; set; }
    }
}
