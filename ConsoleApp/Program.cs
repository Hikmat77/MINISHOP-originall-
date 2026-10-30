using Domain.Models;
using Infrastructure.Repositories;

var categoryRepo = new CategoryRepository();
var productRepo = new ProductRepository();

while (true)
{
    System.Console.WriteLine("===============================");
    System.Console.WriteLine(@"1 - Show all categories.
2 - Show category.
3 - Add new category.
4 - Update category.
5 - Delete category.
6 - Show all products.
7 - Show product.
8 - Add new product.
9 - Update product.
10 - Delete product.
11 - Show products by category.
12 - Amount of products.
13 - Amount of categories.
14 - Amount of products by category.
15 - Min price of product by category.
16 - Max price of product by category.
17 - Average price of product by category.
18 - Total price of products.
0 - Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("===============================");
    switch (a)
    {
        case "1":
            var allCategories = await categoryRepo.GetCategoriesAsync();
            foreach(var item in allCategories)
            {
                System.Console.WriteLine(item.Id+" "+item.Name);
            }
            break;
        case "2":
            System.Console.Write("Enter id of category: ");
            var categoryIdToShow = Convert.ToInt32(Console.ReadLine());
            var categoryToShow = await categoryRepo.GetCategoryAsync(categoryIdToShow);
            System.Console.WriteLine(categoryToShow.Id+" "+categoryToShow.Name);
            break;
        case "3":
            System.Console.Write("Enter name: ");
            var categoryName = Console.ReadLine()!;
            var newCategory = new Category()
            {
                Name = categoryName
            };
            await categoryRepo.AddCategoryAsync(newCategory);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var categoryIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newCategoryName = Console.ReadLine()!;
            var categoryToUpdate = new Category()
            {
                Id = categoryIdToUpdate,
                Name = newCategoryName
            };
            await categoryRepo.UpdateCategoryAsync(categoryToUpdate);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            var categoryIdToDelete = Convert.ToInt32(Console.ReadLine());
            await categoryRepo.DeleteCategoryAsync(categoryIdToDelete);
            break;
        case "6":
            var allProducts = await productRepo.GetProductsAsync();
            foreach(var item in allProducts)
            {
                System.Console.WriteLine(item.Id+" "+item.Name+" "+item.Price+" "+item.CategoryId);
            }
            break;
        case "7":
            System.Console.Write("Enter id of product: ");
            var productIdToShow = Convert.ToInt32(Console.ReadLine());
            var productToShow = await productRepo.GetProductAsync(productIdToShow);
            System.Console.WriteLine(productToShow.Id+" "+productToShow.Name+" "+productToShow.Price+" "+productToShow.CategoryId);
            break;
        case "8":
            System.Console.Write("Enter name: ");
            var productName = Console.ReadLine()!;
            System.Console.Write("Enter price: ");
            var productPrice = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("Enter category id: ");
            var productCategoryId = Convert.ToInt32(Console.ReadLine());
            var newProduct = new Product()
            {
                Name = productName,
                Price = productPrice,
                CategoryId = productCategoryId
            };
            await productRepo.AddProductAsync(newProduct);
            break;
        case "9":
            System.Console.Write("Enter id: ");
            var productIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newProductName = Console.ReadLine()!;
            System.Console.Write("Enter new price: ");
            var newProductPrice = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("Enter new category id: ");
            var newProductCategoryId = Convert.ToInt32(Console.ReadLine());
            var productToUpdate = new Product()
            {
                Id = productIdToUpdate,
                Name = newProductName,
                Price = newProductPrice,
                CategoryId = newProductCategoryId
            };
            await productRepo.UpdateProductAsync(productToUpdate);
            break;
        case "10":
            System.Console.Write("Enter id: ");
            var productIdToDelete = Convert.ToInt32(Console.ReadLine());
            await productRepo.DeleteProductAsync(productIdToDelete);
            break;
        case "11":
            System.Console.Write("Enter id of category: ");
            var categoryIdToFilter = Convert.ToInt32(Console.ReadLine());
            var productsByCategory = await productRepo.GetProductsByCategoryAsync(categoryIdToFilter);
            foreach(var item in productsByCategory)
            {
                System.Console.WriteLine(item.Id+" "+item.Name+" "+item.Price+" "+item.CategoryId);
            }
            break;
        case "12":
            var amountOfProducts = await productRepo.GetAmountOfProductsAsync();
            System.Console.WriteLine("Amount of products: "+amountOfProducts);
            break;
        case "13":
            var amountOfCategories = await categoryRepo.GetAmountOfCategoriesAsync();
            System.Console.WriteLine("Amount of categories: "+amountOfCategories);
            break;
        case "14":
            System.Console.Write("Enter id of category: ");
            var categoryIdForAmount = Convert.ToInt32(Console.ReadLine());
            var amountByCategory = await productRepo.GetAmountOfProductsByCategoryAsync(categoryIdForAmount);
            System.Console.WriteLine("Amount of products: "+amountByCategory);
            break;
        case "15":
            System.Console.Write("Enter id of category: ");
            var categoryIdForMin = Convert.ToInt32(Console.ReadLine());
            var minPrice = await productRepo.GetMinPriceOfProductByCategoryAsync(categoryIdForMin);
            System.Console.WriteLine("Min price: "+minPrice);
            break;
        case "16":
            System.Console.Write("Enter id of category: ");
            var categoryIdForMax = Convert.ToInt32(Console.ReadLine());
            var maxPrice = await productRepo.GetMaxPriceOfProductByCategoryAsync(categoryIdForMax);
            System.Console.WriteLine("Max price: "+maxPrice);
            break;
        case "17":
            System.Console.Write("Enter id of category: ");
            var categoryIdForAvg = Convert.ToInt32(Console.ReadLine());
            var avgPrice = await productRepo.GetAveragePriceOfProductByCategoryAsync(categoryIdForAvg);
            System.Console.WriteLine("Average price: "+avgPrice);
            break;
        case "18":
            var totalPrice = await productRepo.GetTotalPriceOfProductsAsync();
            System.Console.WriteLine("Total price of products: "+totalPrice);
            break;
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}