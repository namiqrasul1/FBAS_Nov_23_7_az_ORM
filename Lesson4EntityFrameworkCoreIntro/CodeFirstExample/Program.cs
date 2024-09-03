using CodeFirstExample.Data;

using var context = new AppDbContext();

context.Products.Where(p => p.Name.Contains("a")).ToList();
//context.Products.Where(p => p.Name.Contains("a")).ToList();
