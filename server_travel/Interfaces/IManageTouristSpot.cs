using server_travel.Dtos.touristSpot;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IManageTouristSpot
    {
        public Task<int> Create(SpotCreateRequest spot);
        public Task<int> Update(SpotUpdateRequest spot);
        public Task<int> Delete(int id);
        public Task<TourestSpotViewModel> Get_By_Id(int id);  
        public Task<List<TourestSpotViewModel>> GetAll();
    }
}
