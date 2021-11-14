using System;

namespace API.Player.v1.Models
{
    /*
     * Opted to be explicit here versus using inheritance.
     * If complexity increases, consider changing this strategy.
     */

    public class PlayerModel : BaseModel
    {
        public Guid ID { get; set; }
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int MMR { get; set; }
    }

    public class PlayerAddModel
    {
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int MMR { get; set; }
        
    }

    public class PlayerUpdateModel
    {
        public Guid ID { get; set; }
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int MMR { get; set; }
        public string ETag { get; set; }
    }
}
