using server_travel.Dtos.Vehicle;
using server_travel.Entities;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IManageVehicle
    {
        public Task<int> Create(CreateVehicleRequest request);
        public Task<int> Update(UpdateVehicleRequest request);
        public Task<int> Delete(int id);
        public Task<VehicleViewModel> Get_By_Id(int id);
        public Task<List<VehicleViewModel>> GetAll();
    }
}
