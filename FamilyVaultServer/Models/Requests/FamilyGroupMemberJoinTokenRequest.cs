﻿using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class FamilyGroupMemberJoinTokenRequest
    {
        [JsonPropertyName("token")]
        public required Guid Token { get; set; }
    }
}
