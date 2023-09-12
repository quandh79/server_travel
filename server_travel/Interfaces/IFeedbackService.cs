using server_travel.Dtos.Feedback;
using server_travel.Entities;

namespace server_travel.Interfaces
{
    public interface IFeedbackService
    {
        public Task<int> Create(FeedbackCreateRequest request);

        public Task<List<Feedback>>GetAll();
    }
}
