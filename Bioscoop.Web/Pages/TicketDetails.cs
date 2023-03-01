using Bioscoop.Models.Dtos;
using Bioscoop.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Bioscoop.Web.Pages

{
    public class TicketDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public ITicketService TicketService { get; set; }



        private async Task<TicketDto> GetProductById(int id = 2)
        {
            var ticketDtos = await GetProductById(id);

            if (ticketDtos != null)
            {
                return ticketDtos;
            }
            return null;
        }

    }
}

