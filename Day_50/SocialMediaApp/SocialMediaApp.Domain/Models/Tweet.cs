using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaApp.Domain.Models
{
    public class Tweet
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Created_At")]
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public string AccountId { get; set; }
        public bool IsEnabled { get; set; }
        public int Likes { get; set; }
    }
}
