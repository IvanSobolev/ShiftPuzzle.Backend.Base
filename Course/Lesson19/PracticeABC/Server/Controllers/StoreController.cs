namespace PracticeA;

using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.IO; 
using System.Net.Http;
using System.Text; 
using System.Threading.Tasks;
using System.Collections.Generic;
[ApiController]
public class StoreController : ControllerBase
{
    public class Product
    {
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Range(0.01, 10000)]
    public double Price { get; set; }

    [Range(0, 10000)]
    public int Stock { get; set; }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }

    public class UserCredentials
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string User { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Pass { get; set; }

    }


    private List<Product> Items = new List<Product>();

    private readonly string _jsonFilePath = "DataBase.json";

    privateconst AddProductMethod = "/store/add";
    const UpdPriceMethod = "/store/updateprice";
    const UpdNameMethod = "/store/updatename";
    const OutOfStockMethod ="store/outofstock";
    const AuthMethod="store/auth";
    const DeleteMethod="store/delete";
    const ShowMethod="store/show";

    
    public StoreController()
    {
        ReadDataFromFile();
    }

    [HttpPost]
    [Route(UpdPriceMethod)]
    public IActionResult UpdatePrice(string name, double newPrice)
    {
        var product = Items.FirstOrDefault(p => p.Name == name);
        if (product != null)
        {
            product.Price = newPrice;
            return Ok($"{name} обновлен с новой ценой: {newPrice}");
        }
        else
        {
            return NotFound($"Продукт {name} не найден");
        }
    }

    [HttpPost]
    [Route(UpdNameMethod)]
    public IActionResult UpdateName(string currentName, string newName)
    {
        var product = Items.FirstOrDefault(p => p.Name == currentName);
        if (product != null)
        {
            product.Name = newName;
            return Ok($"Имя продукта изменено с {currentName} на {newName}");
        }
        else
        {
            return NotFound($"Продукт {currentName} не найден");
        }
    }


    [HttpGet]
    [Route(OutOfStockMethod)]
    public IActionResult OutOfStock()
    {
        var outOfStockItems = Items.Where(p => p.Stock == 0).ToList();
        if (outOfStockItems.Any())
        {
            return Ok(outOfStockItems);
        }
        else
        {
            return Ok("Все продукты в наличии");
        }
    }



    [HttpPost]
    [Route(AuthMethod)]
    public IActionResult Auth([FromBody] UserCredentials user)
    { 
        if((user.User == "admin") && (user.Pass == "123"))
        {
            
            return Ok($"{user.User} авторизован");
        }
        else
        {
            return NotFound($"{user.User} не найден");
        }

    }



    [HttpPost]
    [Route(AddProductMethod)]
    public IActionResult Add([FromBody] Product newProduct)
    { 
        Items.Add(newProduct);
        WriteDataToFile();
        return Ok(Items);
    }


    [HttpPost]
    [Route(DeleteMethod)]
    public IActionResult Delete(string name)
    {
        var product = Items.FirstOrDefault(p => p.Name == name);
        if (product != null)
        {
            Items.Remove(product);
            return Ok($"{name} удален");
        }
        else
        {
            return NotFound($"{name} не найден");
        }
    }


    [HttpGet]
    [Route("/store/show")]
    public IActionResult Show()
    {
        return Ok(Items);
    }
     private List<Product> ConvertTextDBToList()
    {
        string json = ReadDB();
        return JsonSerializer.Deserialize<List<Product>>(json);
    }

    private string ReadDB()
    {
        return System.IO.File.ReadAllText(_jsonFilePath);
    }

    private bool DBExist()
    {
        return System.IO.File.Exists(_jsonFilePath);
    }
    private void ReadDataFromFile()
    {
        if (DBExist())
        {
            Items = ConvertTextDBToList();
        }
    }

    private string ConvertDBtoJson(){
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(Items, options);
    }
    private void WriteToDB(){
        System.IO.File.WriteAllText(_jsonFilePath, ConvertDBtoJson());
    }
    private void WriteDataToFile()
    {
        WriteToDB();
    }


}