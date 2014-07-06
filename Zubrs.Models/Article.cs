using System.ComponentModel.DataAnnotations.Schema;

namespace Zubrs.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        [Column(TypeName = "ntext")]
        public string PreText { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        public ArticleType Type { get; set; }

        public bool HasImage
        {
            get { return !string.IsNullOrEmpty(ImageUrl); }
        }
    }
}
