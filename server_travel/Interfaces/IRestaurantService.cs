using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IRestaurantService
    {
        public Task<RestaurantViewModel> Get_By_Id(int id);
         public Task<RestaurantViewModel> SearchByName(string name);
        public Task<List<RestaurantViewModel>> GetAll();
    }
}
