using Microsoft.EntityFrameworkCore;
using net_reference.Data;
using net_reference.Seed.Models;

namespace net_reference.Seed.Graphql
{
    public class Query
    {
#pragma warning disable CS8604, CS8602 // Possible null reference argument.

        // PLAYERS GraphQL
        public IEnumerable<Player>? GetPlayers([Service] DataContext _context) => _context.Players.Include(p => p.Team).ThenInclude(p => p.Rival).Include(p => p.PlayerPosition);

        public Player? GetPlayerById([Service] DataContext _context, int id) =>  _context.Players.Include(p => p.Team).Include(p => p.PlayerPosition).FirstOrDefault(t => t.Id == id);

        // TEAMS GraphQL
        public IEnumerable<Team>? GetTeams([Service] DataContext _context) => _context.Teams.Include(t => t.Rival);

        public Team? GetTeamById([Service] DataContext _context, int id) => _context.Teams.Include(t => t.Rival).FirstOrDefault(t => t.Id == id);

        // PLAYER POSITIONS GraphQL
        public IEnumerable<PlayerPosition>? GetPlayerPositions([Service] DataContext _context) => _context.PlayerPositions;

        public PlayerPosition? GetPlayerPositionById([Service] DataContext _context, int id) => _context.PlayerPositions.FirstOrDefault(pp => pp.Id == id);



#pragma warning restore CS8604, CS8602 // Possible null reference argument.
    }
}
