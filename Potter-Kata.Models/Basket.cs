namespace Potter_Kata.Models;

/// <summary>
/// Basket model
/// </summary>
public record Basket
{
    /// <summary>
    /// Id of the basket
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();
    
    /// <summary>
    /// List of  basket lines
    /// </summary>
    public List<BasketLine> Lines { get; set; } = new();
    
    /// <summary>
    /// Subtotal of the basket
    /// </summary>
    public double SubTotal  => Lines.Sum(b => b.SubTotal);
    
    /// <summary>
    /// Total discount of the basket
    /// </summary>
    public double Discount =>  Math.Round(Lines.Sum(b => b.Discount),2);
    
    /// <summary>
    /// Total of the basket
    /// </summary>
    public double Total  => Math.Round(Lines.Sum(b => b.Total),2);
    
}