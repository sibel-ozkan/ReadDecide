using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Comments
    {
        public int CommentId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public string BookTitle { get; set; }
        public string UserName { get; set; }

        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }

    }
}
