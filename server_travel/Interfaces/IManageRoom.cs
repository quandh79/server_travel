using server_travel.Dtos.Hotel;
using server_travel.Dtos.Room;
using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Interfaces
{
    public interface IManageRoom
    {
        public Task<int> Create(CreateRoomRequest request);

        public Task<int> Update(UpdateRoomRequest request);
        public Task<int> Delete(int id);
        public Task<RoomViewModel> Get_By_Id(int id);
        public Task<List<RoomViewModel>> GetRoomsByHotelId(int hotelId);
        public Task<List<RoomViewModel>> GetRoomsByResortId(int resortId);

        public Task<List<RoomViewModel>> GetAll();
    }
}
