﻿using Application.DTO;
using Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.UseCases.Commands
{
    public interface ICreateCategoryCommand : ICommand<CreateCategoryDTO>
    {
    }
}
