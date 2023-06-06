using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class CategoryDTO : BaseDTO
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

    public class CreateCategoryDTO : BaseDTO
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

    public class UpdateCategoryDTO : BaseDTO
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteCategoryDTO : BaseDTO
    { 
    }
}
