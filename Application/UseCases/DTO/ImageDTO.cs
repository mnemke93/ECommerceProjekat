using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class ImageDTO : BaseDTO
    {
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int? UserID { get; set; }
        public int? ProductID { get; set; }
    }

    public class CreateImageDTO : BaseDTO
    {
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int? UserID { get; set; }
        public int? ProductID { get; set; }
    }

    public class UpdateImageDTO : BaseDTO
    {
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int? UserID { get; set; }
        public int? ProductID { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteImageDTO : BaseDTO
    {
    }
}
