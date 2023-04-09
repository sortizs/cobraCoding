using System;
using System.Text;
using System.Text.Json;
using CobraCoding_APP.Models;
using CobraCoding_APP.Services.Interface;

namespace CobraCoding_APP.Services;


public class CarService : ICarService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public CarService(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        var res = await _client.GetAsync("car");
        var resContent = await res.Content.ReadAsStringAsync();

        if (!res.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"The request failed with status code: {res.StatusCode}");
        }

        var cars = JsonSerializer.Deserialize<List<Car>>(resContent, _options);
        return cars;
    }

    public async Task<Car> GetCarAsync(int id)
    {
        var res = await _client.GetAsync($"car/{id}");
        var resContent = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"The request failed with status code: {res.StatusCode}");
        }
        var car = JsonSerializer.Deserialize<Car>(resContent, _options);
        return car;
    }

    public async Task<Car> CreateCarAsync(Car car)
    {
        var reqContent = new StringContent(
            JsonSerializer.Serialize(car, _options), Encoding.UTF8, "application/json");
        var res = await _client.PostAsync("car", reqContent);
        var resContent = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"The request failed with status code: {res.StatusCode}");
        }
        var createdCar = JsonSerializer.Deserialize<Car>(resContent, _options);
        return createdCar;
    }

    public async Task PutCarAsync(int id, Car car)
    {
        var reqContent = new StringContent(
            JsonSerializer.Serialize(car, _options), Encoding.UTF8, "application/json");
        var res = await _client.PutAsync($"car/{id}", reqContent);

        if (!res.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"The request failed with status code: {res.StatusCode}");
        }
    }

    public async Task DeleteCarAsync(int id)
    {
        var res = await _client.DeleteAsync($"car/{id}");

        if (!res.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"The request failed with status code: {res.StatusCode}");
        }
    }
}