using Microsoft.Azure.Cosmos.Table;
using PoorMan;
using System;

namespace DataAccess.Player.v1.DataEntities
{
    public class PlayerTableEntity : TableEntity, IAudit
    {
        public string ExternalID { get; set; }
        public string Name { get; set; }
        public int MMR { get; set; }
        public DateTime CreatedOnUTCDate { get; set; }
        public DateTime LastModifiedOnUTCDate { get; set; }
    }
}
