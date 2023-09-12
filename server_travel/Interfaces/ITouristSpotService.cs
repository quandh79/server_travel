using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Interfaces
{
    public interface ITouristSpotService
    {
        public Task<TourestSpotViewModel> Get_By_Id(int id);
        public Task<List<TourestSpotViewModel>> GetAll();
        public Task<List<TourestSpotViewModel>> SearchByName(string name);

    }
}
