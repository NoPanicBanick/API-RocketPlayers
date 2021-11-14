using System;

namespace API.Player.v1.Models
{
    public class BaseModel
    {
        public string ETag { get; set; }
        public DateTime CreatedOnUTCDate { get; set; }
        public DateTime LastUpdatedOnUTCDate { get; set; }
    }
}
