using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BookInfo.Core.Models
{
    public class Author : BaseModel
    {
        public Author()
        {
            Books = new Collection<Book>();
        }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
