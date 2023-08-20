using server_travel.Dtos.Restaurant;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IManageRestaurant
    {
        public Task<int> Create(RestaurantCreateRequest request);
        public Task<int> Update(RestaurantUpdateRequest request);
        public Task<int> Delete(int id);
        public Task<RestaurantViewModel> Get_By_Id(int id);
        public Task<List<RestaurantViewModel>> GetAll();
    }
}
