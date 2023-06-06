using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class ReviewDTO : BaseDTO
    {
        public int Rating { get; set; }
        public string Body { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }

    public class CreateReviewDTO : BaseDTO
    {
        public int Rating { get; set; }
        public string Body { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }

    public class UpdateReviewDTO : BaseDTO
    {
        public int Rating { get; set; }
        public string Body { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteReviewDTO : BaseDTO
    {
    }
}
