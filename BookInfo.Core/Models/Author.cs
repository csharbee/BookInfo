﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BookInfo.Core.Models
{
    public class Author
    {
        public Author()
        {
            Books = new Collection<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
