using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo.Core.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EffectedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
