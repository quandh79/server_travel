using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IResortService
    {
        public Task<ResortViewModel> Get_By_Id(int id);
        public Task<ResortViewModel> SearchByName(string name);
        public Task<List<ResortViewModel>> GetAll();
    }
}
