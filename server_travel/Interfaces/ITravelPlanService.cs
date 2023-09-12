using server_travel.Dtos.Tour;
using server_travel.Entities;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface ITravelPlanService
    {
        public Task<int> Create(TravelPlan request);
        public Task<int> Update(TravelPlan request);
        public Task<TravelPlan> Get_By_Id(int id);
        public Task<List<TravelPlan>> GetAll();
    }
}
