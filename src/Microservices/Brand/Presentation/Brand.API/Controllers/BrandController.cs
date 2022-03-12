using Brand.Application.Common;
using Brand.Application.CQRS.Commands.CreateBrand;
using Brand.Application.CQRS.Commands.DeleteBrand;
using Brand.Application.CQRS.Commands.PatchBrand;
using Brand.Application.CQRS.Commands.UpdateBrand;
using Brand.Application.CQRS.Queries.GetAllBrands;
using Brand.Application.CQRS.Queries.GetBrandById;
using Brand.Application.Services.Interfaces;
using Brand.Domain.Models;
using Brand.Persistance.Data.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace Brand.API.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class BrandsController : ControllerBase
    {
        private IMediator _mediatr;

        private IBrandsDbContext _context;

        private ISizeValidationService _sizeValidationService;

        public BrandsController(IBrandsDbContext contxet, ISizeValidationService service, IMediator mediator)
        {
            _context = contxet;
            _sizeValidationService = service;
            _mediatr = mediator;
        }

        [HttpPost("brand")]
        public async Task<ActionResult<ResultResponse<BrandDto>>> CreateBrand(CreateBrandCommand command, CancellationToken token)
        {
            return await _mediatr.Send(command, token) ;
        }

        [HttpGet("brand")]
        public async Task<ActionResult<ResultResponse<GetBrandsVm>>> GetAllBrands(CancellationToken token)
        {
            return await _mediatr.Send(new GetBrandsQuery(), token);
        }

        [HttpGet("brand/{id}")]
        public async Task<ActionResult<ResultResponse<BrandModel>>> GetBrandById(int id, CancellationToken token)
        {
            var query = new GetBrandQuery()
            {
                Id = id
            };

            return await _mediatr.Send(query, token);
        }

        [HttpPatch("brand")]
        public async Task<ActionResult<ResultResponse<BrandDto>>> PatchBrand(PatchBrandCommand command, CancellationToken token)
        {
            return await _mediatr.Send(command, token);
        }

        [HttpPut("brand")]
        public async Task<ActionResult<ResultResponse<BrandDto>>> UpdateBrand(UpdateBrandCommand command, CancellationToken token)
        {
            return await _mediatr.Send(command, token);
        }

        [HttpDelete]
        public async Task<ActionResult<ResultResponse<Unit>>> DeleteBrand(DeleteBrandCommand command, CancellationToken token)
        {
            return await _mediatr.Send(command, token);
        }
    }
}
