using server_travel.Dtos.Hotel;
using server_travel.Dtos.Resort;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IManageResort
    {
        public Task<int> Create(ResortCreateRequest request);
        public Task<int> Update(ResortUpdateRequest request);
        public Task<int> Delete(int id);
        public Task<ResortViewModel> Get_By_Id(int id);
        public Task<List<ResortViewModel>> GetAll();
    }
}
