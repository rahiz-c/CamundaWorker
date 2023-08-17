using CamundaWorker.DataAccess.SQL.Context;
using CamundaWorker.DataAccess.SQL.Models;

namespace CamundaWorker.DataAccess.SQL.Repository
{
    public class RechargeRepository
    {
        private readonly Recharge_DBContext _dbContext;
        public RechargeRepository(Recharge_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertItem(string item, int amount) {
            Recharge recharge = new Recharge()
            {
                Item = item,
                Amount = amount
            };

            _dbContext.Add(recharge);
            await _dbContext.SaveChangesAsync();
        }
    }
}
