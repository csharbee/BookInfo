using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookInfo.Core.Models
{
    public class Book : BaseModel
    {
        public int Page { get; set; }
        public string Abstract { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
