using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleForumApp.Domain.DTOs.App.Group
{
    [NotMapped]
    public class WeeklyFavouriteGroup
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public int LikeNumber { get; set; }
    }
}
