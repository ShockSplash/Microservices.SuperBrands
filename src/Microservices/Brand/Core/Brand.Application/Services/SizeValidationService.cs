using Brand.Application.Services.Interfaces;
using Brand.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brand.Application.Services
{
    public class SizeValidationService : ISizeValidationService
    {
        public bool Validaite(List<Size> sizes)
        {
            for (int i = 0; i < sizes.Count; i++)
            {
                for (int j = i + 1; j < sizes.Count; j++)
                {
                    if(sizes[i].RussianSize == sizes[j].RussianSize)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
