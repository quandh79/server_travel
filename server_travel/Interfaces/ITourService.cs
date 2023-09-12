using server_travel.Dtos.Tour;
using server_travel.Entities;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface ITourService
    {
        public Task<TourViewModel> Get_By_Id(int id);
        public Task<List<TourViewModel>> GetAll();
        public Task<List<Tour>> Search(TourSearchRequest request);

    }
}
