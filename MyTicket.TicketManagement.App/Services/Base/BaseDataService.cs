using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.App.Services.Base
{
    public class BaseDataService
    {
        protected readonly ILocalStorageService _localStorage;
        
        protected IClient _client;

        public BaseDataService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;

        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = "Something went wrong, please try again.", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }
    }
}
