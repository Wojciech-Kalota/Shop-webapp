using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Models;
using Server.Data.Services;
using Shared;

namespace Server.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentsService _commentsServise;

        public CommentController(CommentsService commentsService)
        {
            _commentsServise = commentsService;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] CommentEntity comment)
        {
            _commentsServise.AddComment(comment);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCommentById(Guid id, [FromBody] CommentEntity comment)
        {
            var updatedComment = _commentsServise.UpdateCommentById(id, comment);
            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCommentById(Guid id)
        {
            _commentsServise.DeleteCommentById(id);
            return Ok();
        }
    }
}
