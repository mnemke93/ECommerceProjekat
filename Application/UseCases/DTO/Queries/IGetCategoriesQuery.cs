using Application.DTO;
using Application.DTO.Searches;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IGetCategoriesQuery : IQuery<BaseSearch, IEnumerable<CategoryDTO>>
    {

    }
}
