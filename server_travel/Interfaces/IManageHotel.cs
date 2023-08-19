using server_travel.Dtos.Hotel;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IManageHotel
    {
        public Task<int> Create(HotelCreateRequest spot);
        public Task<int> Update(HotelUpdateRequest spot);
        public Task<int> Delete(int id);
        public Task<TourestSpotViewModel> Get_By_Id(int id);
        public Task<List<TourestSpotViewModel>> GetAll();
    }
}
