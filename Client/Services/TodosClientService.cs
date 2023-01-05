using Newtonsoft.Json;
using OttokeBlazor.Shared;
using System.Net.Http.Json;

namespace OttokeBlazor.Client.Services
{
    public class TodosClientService
    {
        private readonly HttpClient _httpClient;

        public TodosClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TodoDto>> GetAllTodos()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Todos");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<TodoDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<List<TodoDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }

        public async Task<TodoDto> CreateTodo(TodoCreateDto todoCreateDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/Todos", todoCreateDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null;
                    }

                    return await response.Content.ReadFromJsonAsync<TodoDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }

        public async Task DeleteTodo(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Todos/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }

        public async Task UpdateTodo(TodoUpdateDto todoUpdateDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(todoUpdateDto);

                var response = await _httpClient.PutAsJsonAsync($"api/Todos/{todoUpdateDto.Id}", todoUpdateDto);

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }
    }
}
