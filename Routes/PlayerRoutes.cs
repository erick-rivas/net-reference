#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_reference.Seed.Data;
using net_reference.Seed.Models;

namespace net_reference.Routes
{
    [Route("api/Players")]
    [ApiController]
    public class PlayerRoutes : ControllerBase
    {
        private readonly DataContext _context;

        public PlayerRoutes(DataContext context)
        {
            _context = context;
        }

        // GET: api/PlayerPositions/5
        [HttpGet("{id}/is_vinicius")]
        public ActionResult<bool> IsVinicius(int id)
        {
            Player player = _context.Players.FirstOrDefault(t => t.Id == id);

            if (player == null) {
                return NotFound();
            
            } else if(player.Name.Equals("Vinicius JR")) 
            {
                return true;
            
            } else
            {
                return false;
            }


        }

    }
}
