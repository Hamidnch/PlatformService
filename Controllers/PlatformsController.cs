using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : Controller
    {
        private readonly ILogger<PlatformsController> _logger;
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ILogger<PlatformsController> logger,
            IPlatformRepo repository, IMapper mapper)
        {
            _logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> getting Platforms...");
            var platforms = _repository.GetAllPlatforms();
            var platformsDto = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
            return Ok(platformsDto);
        }        
    }
}