using System.ComponentModel.DataAnnotations;

namespace SwashbuckleIssue
{
    public sealed class Article
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
    }
}