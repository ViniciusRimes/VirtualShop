using System.ComponentModel.DataAnnotations;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    public ICollection<Product>? Products {get; set;}
}
