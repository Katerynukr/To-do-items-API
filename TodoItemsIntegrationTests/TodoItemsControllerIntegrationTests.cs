using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Todo;
using Todo.Dtos;
using Todo.Models;
using Xunit;

namespace TodoItemsControllerIntegrationTests
{
    public class TodoItemsContollerIntegrationTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public TodoItemsContollerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

       [Fact]
        public async Task GetAll_GivenNoParameters_ReturnsTodoItems()
        {
           var httpResult = await _client.GetAsync("/todoItems");

            httpResult.StatusCode.Should().Be(200);

            string responceBody = await httpResult.Content.ReadAsStringAsync();

            var todoItems = JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(responceBody);

            todoItems.Count().Should().Be(6);
        }

        [Fact]
        public async Task Create_GivenSingleTodoDto_ReturnsNoContent()
        {
            var todoItem = new TodoDto() 
            {
                Title = "Test" 
            };

            var data = JsonConvert.SerializeObject(todoItem);

            var buffer = System.Text.Encoding.UTF8.GetBytes(data);

            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResult = await _client.PostAsync("TodoItems", byteContent);

            httpResult.StatusCode.Should().Be(200);
        }
    }
}
