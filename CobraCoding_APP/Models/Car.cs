using System;
using System.ComponentModel.DataAnnotations;

namespace CobraCoding_APP.Models;

public class Car
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Make { get; set; }
    [Required]
    public string? Model { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int Doors { get; set; }
    [Required]
    public string? Color { get; set; }
    [Required]
    public int Price { get; set; }

}

