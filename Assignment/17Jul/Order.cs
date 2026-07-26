using System;
using System.Collections.Generic;

class Order
{
    public int orderId;
    public string date;
    public string customerName;
    public string address;
    public List<OrderItem> items;
    public double total;
    public double discount;
    public double gst;
    public double grandTotal;
    public string paymentMethod;
    public string paymentStatus;
    public string orderStatus;

    public Order()
    {
        items = new List<OrderItem>();
    }
}

class OrderItem
{
    public string name;
    public int qty;
    public double price;
    public double discount;

    public OrderItem(string n, int q, double p, double d)
    {
        name = n;
        qty = q;
        price = p;
        discount = d;
    }
}
