using Potter_Kata.Models;

namespace Potter_Kata.Services;

/// <summary>
/// Simple service to calculate the discount for the basket
/// <remarks>Improvements could be made to make it more future-proof and flexible</remarks>
/// </summary>
public class BasketService : IBasket
{
    /// <summary>
    /// Calculate the discount for the basket
    ///2 unique books = 5% discount on those 2 books
    ///3 unique books = 10% discount on those 3 books
    ///4 unique books = 20% discount on those 4 books
    ///5 unique books = 25% discount on those 5 books
    /// </summary>
    /// <remarks>
    /// Assumptions made: the discount is per unique group of books and is not capped at a max of 25% for 5 books
    /// </remarks>
    /// <param name="basket"></param>
    public void CalculateDiscount(Basket basket)
    {
        //Group the books based on discount that they qualify for - split lines if needed
        var basketLines = basket.Lines.ToList();

        var uniqueBooks = basketLines.Select(b => b.Book).Distinct().ToList();
        
        if(uniqueBooks.Count < 2) return;
        
        //Remove the basket lines; we will add them back sorted with applicable discounts
        basket.Lines.Clear();
        
        var discountGroups = new List<List<BasketLine>>();

        var uniqueGroup =  basketLines.Select(b => b.Book).Distinct().ToList();
        
        discountGroups = SortUnique(discountGroups, ref uniqueGroup, basketLines);
        
        //Add remainder to the basket lines
        if(uniqueGroup.Count == 1)
        {
            //Add the remainder to the basket lines
            basket.Lines.Add(uniqueGroup.Select(book => new BasketLine()
            {
                Book = book,
                Quantity = basketLines[0].Quantity
            }).First());
        }
        
        ApplyDiscounts(discountGroups);

        //Add the sorted lines back to the basket
        basket.Lines.AddRange(discountGroups.SelectMany(g => g));
    }

    /// <summary>
    /// Sort the unique books into groups of more than 1
    /// </summary>
    /// <param name="discountGroups"></param>
    /// <param name="uniqueGroup"></param>
    /// <param name="basketLines"></param>
    /// <returns></returns>
    private static List<List<BasketLine>> SortUnique( List<List<BasketLine>>  discountGroups, ref List<Book> uniqueGroup, List<BasketLine> basketLines)
    {
        while (uniqueGroup.Count > 1)
        {
            discountGroups.Add(uniqueGroup.Select(book => new BasketLine()
            {
                Book = book,
                Quantity = 1
            }).ToList());
            
            //Remove one of each book from the basket lines
            foreach (var line in uniqueGroup.Select(book => basketLines.First(b => b.Book == book)))
            {
                line.Quantity--;
                if (line.Quantity == 0)
                {
                    basketLines.Remove(line);
                }
            }
            
            uniqueGroup = basketLines.Select(b => b.Book).Distinct().ToList(); 
        }

        return discountGroups;
    }

    /// <summary>
    /// Apply the applicable discount to the basket lines
    /// </summary>
    /// <param name="discountGroups"></param>
    private static void ApplyDiscounts(List<List<BasketLine>> discountGroups)
    {
        foreach (var group in discountGroups)
        {
            var discount = group.Count switch
            {
                2 => 5,
                3 => 10,
                4 => 20,
                5 => 25,
                _ => 0
            };
            
            foreach (var line in group)
            {
                line.DiscountPercentage = discount;
            }
        }
    }
}