using LobbyAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace LobbyAPP.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<LobbyModel> Lobbys { get; set; }

    }
}
