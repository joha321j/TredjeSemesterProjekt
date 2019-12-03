using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductAPIVitec.Models;

namespace ProductAPIVitec.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductAPIVitecContext(serviceProvider.GetRequiredService<DbContextOptions<ProductAPIVitecContext>>()))
            {
                if (context.Product.Any())
                {
                    return;
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "CD-ORD",
                        Description =
                            "Læse- og skriveværktøjet CD-ORD er kendt for at forløse ordblinde børn og voksnes potentiale for at læse, skrive og lære.",
                    });

                context.Product.AddRange(
                    new Product
                    {
                        Name = "IntoWords",
                        Description =
                            "IntoWords is a digital tool that reads texts aloud – online, from PDF files and from text programs. When you are writing, IntoWords helps you by suggesting words."
                    });

                context.Product.AddRange(
                    new Product
                    {
                        Name = "IntoWords Pro",
                        Description =
                            "IntoWords Pro is Denmark´s most acclaimed and widely used reading and writing support tool. With IntoWords Pro on your computer, you can read and write all the text in front of you online, in PDF files and Office programs. When you are writing, IntoWords Pro helps you by suggesting words."
                    });

                context.SaveChanges();

                context.Price.AddRange(
                    new Price
                    {
                        Value = 12.99,
                        Valuta = "Euro"
                    });

                context.Price.AddRange(
                    new Price
                    {
                        Value = 35.97,
                        Valuta = "Euro"
                    });

                context.Price.AddRange(
                    new Price
                    {
                        Value = 65.94,
                        Valuta = "Euro"
                    });

                context.SaveChanges();

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Monthly",
                        Price = context.Price.ToList()[0],
                        BillingFrequency = 1,
                        Product = context.Product.ToList()[0]
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Quarterly",
                        Price = context.Price.ToList()[1],
                        BillingFrequency = 3,
                        Product = context.Product.ToList()[0],
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Half-Year",
                        Price = context.Price.ToList()[2],
                        BillingFrequency = 6,
                        Product = context.Product.ToList()[0],
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Monthly",
                        Price = context.Price.ToList()[0],
                        BillingFrequency = 1,
                        Product = context.Product.ToList()[1],
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Quarterly",
                        Price = context.Price.ToList()[1],
                        BillingFrequency = 3,
                        Product = context.Product.ToList()[1],
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Half-Year",
                        Price = context.Price.ToList()[2],
                        BillingFrequency = 6,
                        Product = context.Product.ToList()[1],
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Monthly",
                        Price = context.Price.ToList()[0],
                        BillingFrequency = 1,
                        Product = context.Product.ToList()[2],
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Quarterly",
                        Price = context.Price.ToList()[1],
                        BillingFrequency = 3,
                        Product = context.Product.ToList()[2],
                    });

                context.Subscription.AddRange(
                    new Subscription
                    {
                        Name = "Half-Year",
                        Price = context.Price.ToList()[2],
                        BillingFrequency = 6,
                        Product = context.Product.ToList()[2],
                    });



                context.SaveChanges();
            }
        }
    }
}