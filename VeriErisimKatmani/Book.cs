using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Slug { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
