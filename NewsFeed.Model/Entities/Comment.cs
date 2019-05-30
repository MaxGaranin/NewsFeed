﻿namespace NewsFeed.Model.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }
    }
}