using Bioscoop.Api.Data;
using Bioscoop.Api.Entities;
using Bioscoop.Api.Repositories.Contracts;
using Bioscoop.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bioscoop.Api.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly BioscoopDbContext bioscoopDbContext;

        public TicketRepository(BioscoopDbContext bioscoopDbContext)
        {
            this.bioscoopDbContext = bioscoopDbContext;
        }

        public async Task<Ticket> GetTicket(int id)
        {
            var ticket = await bioscoopDbContext.Tickets.FindAsync(id);
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            var tickets = await bioscoopDbContext.Tickets.ToListAsync();
            return tickets;
        }

        private async Task<bool> TicketExists(int showId, int rowNumber, int seatNumber)
        {
            return await this.bioscoopDbContext.Tickets.AnyAsync(c => c.ShowId == showId &&
                                                                 c.RowNumber == rowNumber &&
                                                                 c.SeatNumber == seatNumber);
        }

        private async Task<int> TicketCodeGenerator()
        {
            int code;

            while (true)
            {
                code = new Random().Next(0, 999999);
                var alreadyExists = await this.bioscoopDbContext.Tickets.AnyAsync(c => c.Code == code);
                if (!alreadyExists) break;
            }

            return code;
        }

        public async Task<Ticket> AddTicket(TicketToAddDto ticketToAddDto)
        {
            if (await TicketExists(ticketToAddDto.ShowId, ticketToAddDto.RowNumber, ticketToAddDto.SeatNumber) == false)
            {
                var code = await TicketCodeGenerator();
                var ticket = await (from show in this.bioscoopDbContext.Shows
                                    where show.Id == ticketToAddDto.ShowId
                                    select new Ticket
                                    {
                                        ShowId = show.Id,
                                        Code = code,
                                        RowNumber = ticketToAddDto.RowNumber,
                                        SeatNumber = ticketToAddDto.SeatNumber,
                                        Price = ticketToAddDto.Price,
                                    }).SingleOrDefaultAsync();
                if (ticket != null)
                {
                    var result = await this.bioscoopDbContext.Tickets.AddAsync(ticket);
                    await this.bioscoopDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<Ticket> DeleteTicket(int id)
        {
            var ticket = await this.bioscoopDbContext.Tickets.FindAsync(id);

            if (ticket != null)
            {
                this.bioscoopDbContext.Tickets.Remove(ticket);
                await this.bioscoopDbContext.SaveChangesAsync();
            }

            return ticket;
        }
    }
}
