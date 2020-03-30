using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DomainModel;
using Application.Exceptions;
using Application.Services;
using Application.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teste_Aiko.Requests.PointOfInterest;

namespace Teste_Aiko.Controllers
{
    [Route("api/v1/point-of-interest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly IPointOfInterestApplicationService _PointOfInterestApplicationService;
        private readonly IMapper _Mapper;

        public PointOfInterestController(IPointOfInterestApplicationService PointOfInterestApplicationService, IMapper Mapper)
        {
            _PointOfInterestApplicationService = PointOfInterestApplicationService;
            _Mapper = Mapper;
        }

        [HttpGet]
        public ActionResult<List<PointOfInterestViewModel>> Get()
        {
            return _PointOfInterestApplicationService.List(null);
        }

        [HttpGet("{id}")]
        public ActionResult<PointOfInterestViewModel> Get(Guid id)
        {
            try
            {
                return _PointOfInterestApplicationService.Get(id);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePointOfInterestRequest request)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            var domainModel = _Mapper.Map<CreatePointOfInterestRequest, PointOfInterestDomainModel>(request);
            return Ok(_PointOfInterestApplicationService.Register(domainModel));
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdatePointOfInterestRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var domainModel = _Mapper.Map<UpdatePointOfInterestRequest, PointOfInterestDomainModel>(request);
                domainModel.Id = id;

                return Ok(_PointOfInterestApplicationService.Update(domainModel));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try { 
                _PointOfInterestApplicationService.Remove(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
