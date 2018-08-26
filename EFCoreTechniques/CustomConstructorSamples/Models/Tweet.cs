using System;
using System.Collections.Generic;
using System.Text;

namespace CustomConstructorSamples.Models
{
    public class Tweet
    {
        private int _id;

        public int UserId { get; }

        public string Content { get; }

        public Tweet(int userId, string content)
        {
            if (userId < 0) throw new ArgumentException("User Id must be greater than 0", nameof(userId));
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));

            this.UserId = userId;
            this.Content = content;
        }
    }
}
