class Product
{
    public int productId;
    public string name;
    public string category;
    public string description;
    public double price;
    public int quantity;
    public string brand;
    public double discount;
    public double rating;

    public Product(int id, string n, string cat, string desc, double p, int q, string b, double dis, double rat)
    {
        productId = id;
        name = n;
        category = cat;
        description = desc;
        price = p;
        quantity = q;
        brand = b;
        discount = dis;
        rating = rat;
    }
}
