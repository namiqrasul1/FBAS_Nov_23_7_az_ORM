using Lesson5CodeFirstRelationships.Data;
using Lesson5CodeFirstRelationships.Models;

using var context = new AppDbFBASContext();

//var user = new User
//{
//    Name = "Kamil",
//    Number = new PhoneNumber { Number = "0771234567" }
//};

//context.Users.Add(user);

//var category = new Category
//{
//    Name = "Nonalcohol",
//    Products = [new Product { Name = "cola" }, new Product { Name = "fanta" }]
//};
//context.Categories.Add(category);


//var product = new Product
//{
//    Name = "Sprite",
//    CategoryId = 1
//};
//context.Products.Add(product);

//var category = context.Categories.FirstOrDefault(c => c.Name.Contains("Non"));
//var product = new Product
//{
//    Name = "Pepsi",
//    Category = category!
//};
//context.Products.Add(product);

//context.SaveChanges();


var names = context.Products.Where(p => p.Name.Contains("a")).Select(p => p.Name).ToList();
names.ForEach(p => Console.WriteLine(p));