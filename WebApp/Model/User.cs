﻿using System.Text.Json.Serialization;

namespace WebApp.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public string Password { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}
