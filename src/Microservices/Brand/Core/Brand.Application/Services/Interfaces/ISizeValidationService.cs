﻿using Brand.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.Services.Interfaces
{
    public interface ISizeValidationService
    {
        bool Validaite(List<Size> sizes);
    }
}
