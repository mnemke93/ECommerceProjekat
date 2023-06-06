using Application;
using Application.DTO;
using Application.DTO.Searches;
using Application.Queries;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries
{
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        public int ID => 1;

        public string Name => "Search Categories";

        public string Description => "Search Categories Using Entity Framework";

        private ECommerceContext _context;
        public GetCategoriesQuery(ECommerceContext context)
        {
            _context = context;
        }

        
        public IEnumerable<CategoryDTO> Execute(BaseSearch search)
        {
            var query = _context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.CategoryName.Contains(search.Keyword));
            }

            return query.Select(x => new CategoryDTO
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                ID = x.ID,
            }).ToList();
        }
    }
}
