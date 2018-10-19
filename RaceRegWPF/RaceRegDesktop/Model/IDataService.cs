using System.Threading.Tasks;

namespace RaceRegDesktop.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}