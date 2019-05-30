using System;
using System.Collections.Generic;

namespace NewsFeed.Model.Entities
{
    public class NewsFeedItem
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}