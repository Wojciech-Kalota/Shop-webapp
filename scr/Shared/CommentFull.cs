namespace Shared
{
    public class CommentFull
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.Now;

        public Guid ProductId { get; set; }
        public ProductFull Product { get; set; }    
    }
}
