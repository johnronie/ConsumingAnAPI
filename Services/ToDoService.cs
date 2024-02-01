using ConsumingAnAPI.Contracts;
using ConsumingAnAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumingAnAPI.Services
{
    public class ToDoService : ITodos
    {
        public List<ToDo> Get()
        {
            return (GetJsonTodos());
        }

        public ToDo GetById(int id)
        {
            ToDo todo = GetJsonTodos().FirstOrDefault(t => t.Id == id);
            return (todo);
        }

        public List<ToDo> GetJsonTodos()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            HttpResponseMessage response = client.GetAsync("/todos").Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<ToDo> todos = JsonConvert.DeserializeObject<List<ToDo>>(responseBody);
            return (todos);
        }
    }
}
