using server_travel.Dtos.District;
using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Interfaces
{
    public interface IManageDistrict
    {
        public Task<int> Create(CreateDistrictRequest spot);
        public Task<int> Update(UpdateDistrictRequest spot);
        public Task<int> Delete(int id);
        public Task<DistrictViewModel> Get_By_Id(int id);
        public Task<List<DistrictViewModel>> GetAll();
    }
}
