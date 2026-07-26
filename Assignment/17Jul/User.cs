using System.Collections.Generic;

class User
{
    public string username;
    public string password;
    public string email;
    public string phone;
    public string address;
    public string role; // "customer" or "admin"
    public List<CartItem> cart;

    public User(string u, string p, string r)
    {
        username = u;
        password = p;
        role = r;
        email = "";
        phone = "";
        address = "";
        cart = new List<CartItem>();
    }
}

class CartItem
{
    public int productId;
    public string name;
    public int qty;
    public double price;
    public double discount;

    public CartItem(int id, string n, int q, double p, double d)
    {
        productId = id;
        name = n;
        qty = q;
        price = p;
        discount = d;
    }
}
