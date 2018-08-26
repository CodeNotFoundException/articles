using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConstructorSamples.Models
{
    public class Tweet
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public string Content { get; private set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="Tweet"/> class from being created.
        /// </summary>
        /// <remarks>This is used by EF materialization</remarks>
        private Tweet()
        {
        }

        public static Tweet Create(int userId, string content)
        {
            if (userId <= 0) throw new ArgumentException("User Id must be greater than 0", nameof(userId));
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));

            var tweet = new Tweet
            {
                UserId = userId,
                Content = content
            };

            return tweet;
        }
    }
}
