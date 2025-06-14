using Server.Data.Models;
using Shared;

namespace Server.Data.Services
{
    public class CommentsService
    {
        private AppDbContext _context;

        public CommentsService(AppDbContext contexct)
        {
            _context = contexct;
        }

        public void AddComment(CommentEntity comment)
        {
            var _comment = new Comment()
            {
                Text = comment.Text,
                ProductId = comment.ProductId
            };

            _context.Comments.Add(_comment);
            _context.SaveChanges();
        }

        public List<Comment> GetAllProductComments(Guid productId)
        {
            return _context.Comments.Where(n => n.ProductId == productId && !n.IsDeleted).ToList();
        }

    }
}
