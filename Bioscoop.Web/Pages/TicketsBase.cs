using Bioscoop.Models.Dtos;
using Bioscoop.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Bioscoop.Web.Pages
{
    public class TicketsBase:ComponentBase
    {
        [Inject]
        public ITicketService TicketService { get; set; }
    
        public IEnumerable<TicketDto> Tickets { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Tickets = await TicketService.GetItems();
        }
    }
}
