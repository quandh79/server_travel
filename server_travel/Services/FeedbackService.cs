using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Feedback;
using server_travel.Entities;
using server_travel.Interfaces;

namespace server_travel.ViewModels
{
    public class FeedbackService : IFeedbackService
    {
        private readonly TravelApiContext _context;
        public FeedbackService(TravelApiContext context)
        {
            _context = context;
        }

        public async Task<int> Create(FeedbackCreateRequest request)
        {
           var feedback = new Feedback()
           {
               Name= request.Name,
               Email= request.Email,
               Content= request.Content,
               CreatedAt= DateTime.UtcNow,
               Status = Enums.Status.Active
           };
             _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback.Id;
        }

        public async Task<List<Feedback>> GetAll()
        {
            var feedback = _context.Feedbacks.Where(s=>s.Status==Enums.Status.Active)
            .Select(f=>new Feedback{
                Name = f.Name,
                Email = f.Email,
                Content = f.Content,
                CreatedAt = f.CreatedAt
            });

            return await feedback.ToListAsync();
        }
    }
}
