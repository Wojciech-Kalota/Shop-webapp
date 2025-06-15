namespace Server.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedDate { get;set; } = DateTimeOffset.Now;

        public List<Comment> ?Comments { get; set; }

    }
}
