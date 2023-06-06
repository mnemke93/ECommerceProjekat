using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases
{
    public abstract class EfUseCase
    {
        public EfUseCase(ECommerceContext context) 
        {
            Context = context;
        }

        protected ECommerceContext Context { get; }
    }
}
