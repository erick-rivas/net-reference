using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_reference.Models
{
    public class Player
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }  

        public int TeamId { get; set; }

        public Team? Team { get; set; }

        public int PlayerPositionId { get; set; }

        public PlayerPosition? PlayerPosition { get; set; }
    }
}
