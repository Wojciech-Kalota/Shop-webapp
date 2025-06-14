using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Services;
using Shared;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentsService _commentsServise;

        public CommentController(CommentsService commentsService)
        {
            _commentsServise = commentsService;
        }

        [HttpPost("add-comment")]
        public IActionResult AddComment([FromBody] CommentEntity comment)
        {
            _commentsServise.AddComment(comment);
            return Ok();
        }

        public IActionResult GetAllProductComments(Guid productId)
        {
            var comments = _commentsServise.GetAllProductComments(productId);
            return Ok(comments);
        }
    }
}
