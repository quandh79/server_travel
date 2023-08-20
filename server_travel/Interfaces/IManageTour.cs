using server_travel.Dtos.Tour;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IManageTour
    {
        public Task<int> Create(TourCreateRequest request);
        public Task<int> Update(TourUpdateRequest request);
        public Task<int> Delete(int id);
        public Task<TourViewModel> Get_By_Id(int id);
        public Task<List<TourViewModel>> GetAll();
    }
}
