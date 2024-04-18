using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The description is required!")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The price is required!")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The stock is required!")]
    [Range(1, 9999)]
    public long Stock { get; set; }

    [Required(ErrorMessage = "The ImageURL is required!")]
    [MinLength(5)]
    [MaxLength(100)]
    public string? ImageURL { get; set; }
    public string? CategoryName { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}
