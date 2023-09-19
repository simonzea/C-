using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Models;

async Task<List<Person>> GetPerson(HttpClient client, string email) {
      var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/users?email={email}");
      var responseString = await response.Content.ReadAsStringAsync();

    return JsonSerializer.Deserialize<List<Person>>(responseString,
    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

}

async Task<List<Todo>> GetTodo(HttpClient client, Person person) {
            var response2 = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos?userId={person.Id}");
        var responseString2 = await response2.Content.ReadAsStringAsync();
        return  JsonSerializer.Deserialize<List<Todo>>(responseString2,
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
}

Person JoinGetRequest(List<Person> persons, List<Todo> todos) {
    persons[0].Todos = todos;
        return persons[0];
}

void WriteJson(Person person) {
    string json = JsonSerializer.Serialize(person);
    File.WriteAllText(@"person.json", json);
};

 async Task SearchUser(string email) {
    var client = new HttpClient();
    var personHttp = await GetPerson(client, email);
    var todos = await GetTodo(client, personHttp[0]);
    var person = JoinGetRequest(personHttp, todos);
    WriteJson(person);
}


 await SearchUser("Shanna@melissa.tv");
