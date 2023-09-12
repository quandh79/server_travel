using server_travel.Dtos.Hotel;
using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Interfaces
{
    public interface IManageHotel
    {
        public Task<int> Create(HotelCreateRequest request);
        public Task<int> Update(HotelUpdateRequest request);
        public Task<int> Delete(int id);
        public Task<HotelViewModel> Get_By_Id(int id);
        public Task<List<HotelViewModel>> SearchByName(string name);

        public Task<List<HotelViewModel>> GetAll();
    }
}
