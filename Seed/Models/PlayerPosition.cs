using System.ComponentModel.DataAnnotations;

namespace net_reference.Seed.Models
{
    public class PlayerPosition
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string Name { get; set; } = string.Empty;


        [StringLength(200)]
        public string Details { get; set; } = string.Empty;




    }
}
