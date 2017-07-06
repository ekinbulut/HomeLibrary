using System;
using Newtonsoft.Json;

namespace Library.Api.Objects
{
    [JsonObject(MemberSerialization.Fields)]
    [Serializable]
    public class AuthInputDto
    {
        public AuthDto AuthDto { get; set; }
    }
}
