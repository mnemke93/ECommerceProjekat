﻿using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validator
{
    public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemDTO>
    {
        private ECommerceContext _context;
        public UpdateCartItemValidator(ECommerceContext context)
        {
            _context = context;
            RuleFor(x => x.ID).NotNull().WithMessage("ID cannot be null.");
            RuleFor(x => x.ProductID).NotNull().WithMessage("Product ID cannot be null.");
            RuleFor(x => x.CartID).NotNull().WithMessage("Cart ID cannot be null.");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity cannot be null.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive cannot be null.");
        }
    }
}
