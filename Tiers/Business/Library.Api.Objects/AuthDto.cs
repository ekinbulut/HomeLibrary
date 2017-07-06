using System;
using Newtonsoft.Json;

namespace Library.Api.Objects
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class AuthDto
    {
        public string AppName { get; set; }
    }
}
