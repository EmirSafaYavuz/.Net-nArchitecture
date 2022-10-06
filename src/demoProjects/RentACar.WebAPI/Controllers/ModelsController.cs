using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.Create;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Models;
using RentACar.Application.Features.Brands.Queries.GetByIdBrand;
using RentACar.Application.Features.Brands.Queries.GetListBrand;
using RentACar.Application.Features.Models.Models;
using RentACar.Application.Features.Models.Queries.GetListModel;
using RentACar.Application.Features.Models.Queries.GetListModelByDynamic;
using RentACar.Domain.Entities;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery {PageRequest = pageRequest};
            ModelListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }
        
        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic @dynamic)
        {
            GetListModelByDynamicQuery getListModelByDynamicQuery = new GetListModelByDynamicQuery {PageRequest = pageRequest, Dynamic = dynamic};
            ModelListModel result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }
    }
}
