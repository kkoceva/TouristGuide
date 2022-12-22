using TouristGuide.Core.Models.Comment;

namespace TouristGuide.Models
{
    public class CommentsViewModel
    {
        public CommentModel CurrentComment { get; set; }

        public List<CommentModel> Comments { get; set; }
    }
}
