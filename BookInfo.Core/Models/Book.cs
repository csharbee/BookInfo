using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Author Author { get; set; }

    }
}
