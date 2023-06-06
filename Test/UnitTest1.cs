using Application.DTO;
using Application.UseCases.DTO;
using DataAccess;
using FluentAssertions;
using Implementation.Validator;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void CategoryCreateValidatorTest()
        {
            var validator = new CreateCategoryValidator(Context);
            var dto = new CreateCategoryDTO();
            var result = validator.Validate(dto);

            result.IsValid.Should().BeFalse();
            result.Errors.Where(x => x.PropertyName == "CategoryName")
                .Should().HaveCount(1);
            result.Errors.Where(x => x.PropertyName == "CategoryName")
                .First().ErrorMessage.Should().Be("Category Name cannot be null.");
            
        }

        private ECommerceContext Context
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = "Data Source=LENOVOB71\\SQLEXPRESS;Initial Catalog=WebShop;Integrated Security=True";

                optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new ECommerceContext(options);
            }
        }
    }
}
