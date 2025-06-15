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

        public Comment UpdateCommentById(Guid commentId, CommentEntity comment)
        {
            var _comment = _context.Comments.Where(n => !n.IsDeleted).FirstOrDefault(n => n.Id == commentId);
            if (_comment != null)
            {
                _comment.Text = comment.Text;

                _context.SaveChanges();
            }
            return _comment;
        }

        public void DeleteCommentById(Guid commentId)
        {
            var _comment = _context.Comments.Where(n => !n.IsDeleted).FirstOrDefault(n => n.Id == commentId);
            if (_comment != null)
            {
                _comment.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}
