using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IHotelService
    {
        public Task<HotelViewModel> Get_By_Id(int id);
        public Task<HotelViewModel> Get_By_Name(string name);

        public Task<List<HotelViewModel>> GetAll();
    }
}
