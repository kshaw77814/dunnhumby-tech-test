using Potter_Kata.Models;
using Potter_Kata.Services;

namespace Potter_Kata.Tests;

public class ServiceTests 
{

    private readonly List<Book> _books =
    [
        new Book
        {
            Title = "Harry Potter and the Philosopher's Stone",
            ISBN = "978-0747532743",
            Price = 8.00
        },
        new Book
        {
            Title = "Harry Potter and the Chamber of Secrets",
            ISBN = "978-0747538493",
            Price = 8.00
        },
        new Book
        {
            Title = "Harry Potter and the Prisoner of Azkaban",
            ISBN = "978-0747546290",
            Price = 8.00
        },
        new Book
        {
            Title = "Harry Potter and the Goblet of Fire",
            ISBN = "978-0747546245",
            Price = 8.00
        },
        new Book
        {
            Title = "Harry Potter and the Order of the Phoenix",
            ISBN = "978-0747551003",
            Price = 8.00
        }
    ];

    [Fact]
    public void BuyBook_SingleBook_NoDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(8.00, basket.Total);
    }
    
    [Fact]
    public void BuyBook_TwoSameBooks_NoDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 2
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(16.00, basket.Total);
        Assert.Single(basket.Lines);
    }
    
    [Fact]
    public void BuyBook_ThreeSameBooks_NoDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 3
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(24.00, basket.Total);
    }
    
    [Fact]
    public void BuyBook_TwoDifferentBooks_5PercentDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(16.00, basket.SubTotal);
        Assert.Equal(0.8, basket.Discount);
        Assert.Equal(15.20, basket.Total);
        Assert.Equal(5, basket.Lines[0].DiscountPercentage);
    }
    
    [Fact]
    public void BuyBook_ThreeDifferentBooks_10PercentDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[2],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(24.00, basket.SubTotal);
        Assert.Equal(2.40, basket.Discount);
        Assert.Equal(21.60, basket.Total);
        Assert.Equal(10, basket.Lines[0].DiscountPercentage);
    }
    
    [Fact]
    public void BuyBook_FourDifferentBooks_20PercentDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[2],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[3],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(32.00, basket.SubTotal);
        Assert.Equal(6.40, basket.Discount);
        Assert.Equal(25.60, basket.Total);
        Assert.Equal(20, basket.Lines[0].DiscountPercentage);
    }
    
    
    
    [Fact]
    public void BuyBook_FiveDifferentBooks_25PercentDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[2],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[3],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[4],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(40.00, basket.SubTotal);
        Assert.Equal(10, basket.Discount);
        Assert.Equal(30, basket.Total);
        Assert.Equal(25, basket.Lines[0].DiscountPercentage);
    }
    
    [Fact]
    public void BuyBook_FourBooks_ThreeDifferentBooks_10PercentDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 2
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[2],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(32.00, basket.SubTotal);
        Assert.Equal(2.40, basket.Discount);
        Assert.Equal(29.60, basket.Total);
        Assert.Collection(basket.Lines,
            line => Assert.Equal(0, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage));
    }
    
    [Fact]
    public void BuyBook_FiveBooks_ThreeDifferentBooks_10PercentDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 3
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[2],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(40.00, basket.SubTotal);
        Assert.Equal(2.40, basket.Discount);
        Assert.Equal(37.60, basket.Total);
        Assert.Equal(2, basket.Lines[0].Quantity);
        Assert.Collection(basket.Lines,
            line => Assert.Equal(0, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage));
    }
    
    [Fact]
    public void BuyBook_FullSet_AndThreeDifferentBooks_25PercentAnd10PercentDiscountRespectively()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 2
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 2
                },
                new()
                {
                    Book = _books[2],
                    Quantity = 2
                },
                new()
                {
                    Book = _books[3],
                    Quantity = 1
                },
                new()
                {
                    Book = _books[4],
                    Quantity = 1
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(64.00, basket.SubTotal);
        Assert.Equal(12.40, basket.Discount);
        Assert.Equal(51.60, basket.Total);
        Assert.Collection(basket.Lines, 
            line => Assert.Equal(25, line.DiscountPercentage),
            line => Assert.Equal(25, line.DiscountPercentage),
            line => Assert.Equal(25, line.DiscountPercentage),
            line => Assert.Equal(25, line.DiscountPercentage),
            line => Assert.Equal(25, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage));
    }

    [Fact]
    public void BuyBook_SixBooks_ThreeDifferentBooks_10PercentDiscount()
    {
        // Arrange
        var basket = new Basket()
        {
            Lines = new List<BasketLine>()
            {
                new()
                {
                    Book = _books[0],
                    Quantity = 2
                },
                new()
                {
                    Book = _books[1],
                    Quantity = 2
                },
                new()
                {
                    Book = _books[2],
                    Quantity = 2
                }
            }
        };
        var service = new BasketService();
        
        // Act
        service.CalculateDiscount(basket);
        
        // Assert
        Assert.Equal(48.00, basket.SubTotal);
        Assert.Equal(4.80, basket.Discount);
        Assert.Equal(43.20, basket.Total);
        Assert.Collection(basket.Lines,
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage),
            line => Assert.Equal(10, line.DiscountPercentage));
    }

}