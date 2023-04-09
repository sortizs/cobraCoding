using System;
using CobraCoding_APP.Models;

namespace CobraCoding_APP.Services.Interface;

public interface ICarService
{
    Task<List<Car>> GetCarsAsync();
    Task<Car> GetCarAsync(int id);
    Task<Car> CreateCarAsync(Car car);
    Task PutCarAsync(int id, Car car);
    Task DeleteCarAsync(int id);
}
