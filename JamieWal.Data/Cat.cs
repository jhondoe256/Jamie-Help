
public class Cat
{
    public Cat()
    {

    }
    public Cat(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        var str = $"Id: {Id}\nName: {Name}\nPrice: ${Price}";
        return str;
    }
}
