using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub2.Models
{
    public class Book
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="title">Название</param>
        public Book(string author, string title)
        {
            Id = Guid.NewGuid();
            Author = author;
            Title = title;
        }

        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

    }
}
