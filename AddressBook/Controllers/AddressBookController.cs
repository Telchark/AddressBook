using AddressBook.Data;
using AddressBook.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly ILogger<AddressBookController> _logger;
        public AddressBookController(IAddressBookRepository repository, IMapper mapper, LinkGenerator linkGenerator, ILogger<AddressBookController> logger)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpGet("all")]
        public async Task<ActionResult<AddressModel[]>> GetAll()
        {
            _logger.LogInformation("Get all addresses endpoint.");
            try
            {
                var results = await _repository.GetAllAddressesAsync();

                return _mapper.Map<AddressModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }

        }
        [HttpGet]
        public async Task<ActionResult<AddressModel>> GetLast()
        {
            _logger.LogInformation("Get last address.");
            try
            {
                var result = await _repository.GetLastAddress();

                if (result == null)
                {
                    return NotFound();
                }

                return _mapper.Map<AddressModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }

        }
        [HttpGet("{city}")]
        public async Task<ActionResult<AddressModel[]>> Get(string city)
        {
            _logger.LogInformation("Get addresses with certain city.");
            try
            {
                var results = await _repository.GetAllAddressesByCityAsync(city);

                if (!results.Any())
                {
                    return NotFound();
                }

                return _mapper.Map<AddressModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
        }
        [HttpPost]
        public async Task<ActionResult<AddressModel>> Post(AddressModel model)
        {
            _logger.LogInformation("Sending new address to the AddressBook.");
            try
            {
                var address = _mapper.Map<Address>(model);
                _repository.Add(address);
                if (await _repository.SaveChangesAsync())
                {
                    return Created(_linkGenerator.GetPathByAction("GetLast","AddressBook"), _mapper.Map<AddressModel>(address));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Error");
            }
            return BadRequest();
        }
    }
}
