using CamundaWorker.DataAccess.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CamundaWorker.DataAccess.SQL.Context
{
    public class Recharge_DBContext:DbContext
    {
        DbSet<Recharge> Recharges { get; set; }

        public Recharge_DBContext(DbContextOptions<Recharge_DBContext> options):base(options) 
        {
            
        }
    }
}
