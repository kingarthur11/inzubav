using jvconsult.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Newtonsoft.Json;
using System.Collections.Generic;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using JsonException = System.Text.Json.JsonException;


namespace jvconsult.Models
{
    public class MovieRepository : IMovieRepository
    {
        private MainContext _mainContex;
        //static string _address = "http://api.worldbank.org/countries?format=json";
        //static string _address = "https://sep-backend.afchub.org/api/diagnostic-tool";
        public MovieRepository(MainContext mainContex)
        {
            _mainContex = mainContex;

        }
        public async Task<List<Movie>> GetAll() => await _mainContex.Movie.ToListAsync();
        public async Task<Movie?> GetById(int id)
        {
            var result = await _mainContex.Movie.FindAsync(id);
            return result == null ? null : result;
        }
        public async Task CreateMovie(Movie movie)
        {
            await _mainContex.Movie.AddAsync(movie);
            await _mainContex.SaveChangesAsync();
            //return result.Entity;
        }
        public async Task UpdateMovie (int? id, Movie movie)
        {
            await _mainContex.Movie.AddAsync (movie);
            await _mainContex.SaveChangesAsync();
        }
        public async Task DeleteMovie(int? id)
        {
            var result = await _mainContex.Movie.FirstOrDefaultAsync(m => m.MovieId  == id);
            if (result != null)
            {
                _mainContex.Movie.Remove(result);
                await _mainContex.SaveChangesAsync();
            }
        }
        public async Task SearchMovie(string Poster, string IMDBScrore)
        {
            try
            {
                string json = @"{
                    ""name"": ""John Doe"",
                    ""roles"": [""admin"", ""user"", ""editor""],
                    ""emails"": [""john@example.com"", ""john.doe@example.com""]
                }";

                MyObject obj = JsonSerializer.Deserialize<MyObject>(json);

                if (obj != null)
                {
                    Console.WriteLine($"Name: {obj.Name}");

                    Console.WriteLine("Roles:");
                    foreach (var role in obj.Roles)
                    {
                        Console.WriteLine($"- {role}");
                    }

                    Console.WriteLine("Emails:");
                    foreach (var email in obj.Emails)
                    {
                        Console.WriteLine($"- {email}");
                    }
                }
                else
                {
                    Console.WriteLine("Deserialization failed. Object is null.");
                }

                //using HttpClient client = new();
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.BaseAddress = new Uri("https://sep-backend.afchub.org/api/diagnostic-tool");
                //HttpResponseMessage response = await client.GetAsync(_address);
                //client.BaseAddress = new Uri("http://localhost:64195/");
                //string endpoint = "/diagnostic-tool";

                //HttpResponseMessage response = await client.GetAsync(endpoint);

                //if (response.IsSuccessStatusCode)
                //{

                //string responseBody = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseBody);
                //DiagnostiTool responseObject = JsonSerializer.Deserialize<DiagnostiTool>(responseBody);

                //if (responseObject != null)
                //{
                // Use the returned object
                //Console.WriteLine($"Received object: {responseObject}");
                // }
                //else
                //{
                //Console.WriteLine("Failed to deserialize the response into an object.");
                //}
                // }
                //else
                //{
                //Console.WriteLine($"Failed to request API: {response.StatusCode}");
                //}
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}


public class DiagnostiTool
{
    public int? Id { get; set; }
    public string? QuestionFormate { get; set; }
    public string? Question { get; set; }
    public List<string?> Options { get; set; }
    public string? InputText { get; set; }
    public bool? IsCondition { get; set; }
    public bool? IsCountry { get; set; }
    public string? Condition { get; set; }
    public string? ConditionValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class MyObject
{
    public string? Name { get; set; }
    public List<string> Roles { get; set; }
    public List<string> Emails { get; set; }
}