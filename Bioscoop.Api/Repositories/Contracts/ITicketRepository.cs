using Bioscoop.Api.Entities;
using Bioscoop.Models.Dtos;

namespace Bioscoop.Api.Repositories.Contracts
{
    public interface ITicketRepository
    {
        Task<Ticket> AddTicket(TicketToAddDto ticketToAddDto);
        Task<Ticket> DeleteTicket(int id);
        Task<IEnumerable<Ticket>> GetTickets();
        Task<Ticket> GetTicket(int id);
    }
}
