using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub2.Models
{
    public class BooksRead
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="bookId">BookId</param>
        public BooksRead(Guid userId, Guid bookId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            BookId = bookId;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
