using System.ComponentModel.DataAnnotations;

namespace net_reference.Seed.Models
{
    public class Team
    {

        public int Id { get; set; }

        [StringLength(40)]
        public string Name { get; set; } = string.Empty;

        [StringLength(60)]
        public string Description { get; set; } = string.Empty;

        public int MarketValue { get; set; }

        public int? RivalId { get; set; }

        public Team? Rival { get; set; }


    }
}
