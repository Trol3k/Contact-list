using AutoMapper;
using ContactService.Dtos;
using ContactService.Models;
using ContactService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        public ContactController(IContactRepository contactRepository, IMapper mapper)
        {
            _repository = contactRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contacts = await _repository.GetAllAsync();

            var contactDto = contacts.Select(s=>_mapper.Map<ContactDto>(s)).ToList();

            return Ok(contactDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contact = await _repository.GetByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ContactDetailsDto>(contact));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contactModel = _mapper.Map<Contact>(contactDto);

            await _repository.CreateAsync(contactModel);

            return CreatedAtAction(nameof(GetById), new { id = contactModel.Id }, _mapper.Map<ContactDto>(contactModel));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateContactDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contactModel = await _repository.UpdateAsync(id, updateDto);

            if (contactModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ContactDto>(contactModel));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contactModel = await _repository.DeleteAsync(id);

            if (contactModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}