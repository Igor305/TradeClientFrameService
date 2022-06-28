using DataAccessLayer.Entities.Avrora;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IitExecutionPlanShopRepository
    {
        public Task<ItExecutionPlanShop> getInfoForStockId(int stockId);
    }
}
