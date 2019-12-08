namespace InstagramLightWebClient.Models
{
    using System.Data.Entity;

    public class InstagramLightModel : DbContext
    {
        public InstagramLightModel()
            : base("name=InstagramLightModel")
        { }
        public DbSet<Post> Posts { get; set; }
    }
}