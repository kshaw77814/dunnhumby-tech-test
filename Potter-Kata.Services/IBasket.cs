using Potter_Kata.Models;

namespace Potter_Kata.Services;

public interface IBasket
{
    /// <summary>
    /// Calculate the discount to be applied to the basket
    /// </summary>
    void CalculateDiscount(Basket basket);

}