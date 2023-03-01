using Bioscoop.Api.Entities;
using Bioscoop.Api.Extensions;
using Bioscoop.Api.Repositories.Contracts;
using Bioscoop.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bioscoop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IShowRepository showRepository;

        public TicketController(ITicketRepository ticketRepository, IShowRepository showRepository)
        {
            this.ticketRepository = ticketRepository;
            this.showRepository = showRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTickets()
        {
            try
            {
                var tickets = await this.ticketRepository.GetTickets();

                if (tickets == null)
                {
                    return NotFound();
                }
                else
                {
                    var ticketsDtos = tickets.ConvertToDto();
                    return Ok(ticketsDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TicketDto>> GetTicket(int id)
        {
            try
            {
                var ticket = await this.ticketRepository.GetTicket(id);

                if (ticket == null)
                {
                    return BadRequest();
                }
                else
                {
                    var ticketDto = ticket.ConvertToDto();
                    return Ok(ticketDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> PostTicket([FromBody] TicketToAddDto ticketToAddDto)
        {
            try
            {
                var newTicket = await this.ticketRepository.AddTicket(ticketToAddDto);

                if (newTicket == null)
                {
                    return NoContent();
                }

                var newTicketDto = newTicket.ConvertToDto();

                return CreatedAtAction(nameof(GetTicket), new { id = newTicketDto.Id }, newTicketDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            try
            {
                var ticket = await this.ticketRepository.DeleteTicket(id);
                if (ticket == null)
                {
                    return NotFound();
                }

                return Ok(ticket);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }
    }
}
