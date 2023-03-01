using Bioscoop.Web.Services.Contracts;
using Bioscoop.Models.Dtos;
using System.Net.Http.Json;

namespace Bioscoop.Web.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient httpClient;

        public TicketService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TicketDto> GetTicket(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Ticket/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(TicketDto);
                    }

                    return await response.Content.ReadFromJsonAsync<TicketDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<TicketDto>> GetTickets()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Movie");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<TicketDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<TicketDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}