using System.ComponentModel.DataAnnotations;

namespace Potter_Kata.Models;

/// <summary>
/// Book model
/// </summary>
public record Book
{
    /// <summary>
    /// Title of the book
    /// </summary>
    [StringLength(128)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Book's ISBN
    /// </summary>
    [Required(ErrorMessage = "ISBN is required")]
    [StringLength(14, MinimumLength = 10)]
    public string ISBN { get; set; } = string.Empty;

    /// <summary>
    /// Price of the book
    /// </summary>
    [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Price must at least 1.00 EUR")]
    public double Price { get; set; }
}