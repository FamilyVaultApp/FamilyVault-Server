﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class RemoveMemberFromFamilyGroupRequest
    {
        [Required]
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
        [Required]
        [JsonPropertyName("userPubKey")]
        public required string UserPubKey { get; set; }
    }
}
