using Microsoft.EntityFrameworkCore;
using UserWeb.Data;

namespace CoinWeb.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CoinContext(
            serviceProvider.GetRequiredService<DbContextOptions<CoinContext>>()))
        {
            if (context.Coin.Any())   return;           // DB has been seeded

            context.Coin.AddRange(
        new Coin { Id=1, Country="Italy", Year=1973, Metal="Aluminum", 
            Face="/images/img1.jpg", Denomination="5 lire" },
        new Coin { Id=2, Country="Italy", Year=1980, Metal="Aluminum", 
            Face="/images/img2.jpg", Denomination="10 lire" },
        new Coin { Id=3, Country="Italy", Year=1967, Metal="Steel",    
            Face="/images/img3.jpg", Denomination="50 lire" },
        new Coin { Id=4, Country="Italy", Year=1975, Metal="Steel",    
            Face="/images/img4.jpg", Denomination="100 lire" },
        new Coin { Id=5, Country="Italy", Year=1978, Metal="Bronze", 
            Face="/images/img5.jpg", Denomination="200 lire" },
        new Coin { Id=6, Country="Italy", Year=1965, Metal="Silver", 
            Face="/images/img6.jpg", Denomination="500 lire" }
            );
            context.SaveChanges();
        }
    }
}