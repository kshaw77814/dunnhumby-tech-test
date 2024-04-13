namespace Potter_Kata.Models;

public record BasketLine
{
    /// <summary>
    /// The book in the basket
    /// </summary>
    public Book Book { get; set; }
    
    /// <summary>
    /// Quantity of the books on basket line
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Discount percentage applied to basket line
    /// </summary>
    public int DiscountPercentage { get; set; }
    
    /// <summary>
    /// Subtotal of the basket line
    /// </summary>
   public double SubTotal => Book.Price * Quantity;
    
    /// <summary>
    /// Discount amount for the basket line
    /// </summary>
    public double Discount => Math.Round(SubTotal * DiscountPercentage / 100,2);
   
    /// <summary>
    /// Total of the basket line
    /// </summary>
    public double Total  => Math.Round(SubTotal - (SubTotal * DiscountPercentage / 100),2);
}