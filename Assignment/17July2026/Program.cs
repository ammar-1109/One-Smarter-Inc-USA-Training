using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<User> users = new List<User>();
    static List<Product> products = new List<Product>();
    static List<Category> categories = new List<Category>();
    static List<Order> orders = new List<Order>();

    static User currentUser = null;
    static int nextProductId = 1002;
    static int nextOrderId = 5001;
    static string appliedCoupon = "";
    static double gstRate = 18;

    static void Main()
    {
        // default admin
        users.Add(new User("admin", "admin123", "admin"));

        // default categories
        categories.Add(new Category(1, "Electronics"));
        categories.Add(new Category(2, "Books"));
        categories.Add(new Category(3, "Fashion"));
        categories.Add(new Category(4, "Sports"));
        categories.Add(new Category(5, "Furniture"));
        categories.Add(new Category(6, "Groceries"));

        // sample product
        products.Add(new Product(1001, "Laptop", "Electronics", "Dell Inspiron", 65000, 20, "Dell", 10, 4.6));

        int choice = 0;

        do
        {
            try
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("         SHOPEASE SYSTEM");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Customer Register");
                Console.WriteLine("2. Customer Login");
                Console.WriteLine("3. Admin Login");
                Console.WriteLine("4. Exit");
                Console.WriteLine("==================================");

                Console.Write("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        CustomerLogin();
                        break;
                    case 3:
                        AdminLogin();
                        break;
                    case 4:
                        Console.WriteLine("Thank You!");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter numbers only.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            if (choice != 4)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (choice != 4);
    }

    // -------- AUTH --------

    static void Register()
    {
        Console.WriteLine("\n--- Customer Register ---");
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        foreach (User u in users)
        {
            if (u.username == username)
            {
                Console.WriteLine("Username already exist");
                return;
            }
        }

        User newUser = new User(username, password, "customer");
        Console.Write("Enter Email: ");
        newUser.email = Console.ReadLine();
        Console.Write("Enter Phone: ");
        newUser.phone = Console.ReadLine();
        Console.Write("Enter Address: ");
        newUser.address = Console.ReadLine();

        users.Add(newUser);
        Console.WriteLine("Registration Successful!");
    }

    static void CustomerLogin()
    {
        Console.WriteLine("\n--- Customer Login ---");
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        foreach (User u in users)
        {
            if (u.username == username && u.password == password && u.role == "customer")
            {
                currentUser = u;
                Console.WriteLine("Welcome " + u.username);
                CustomerMenu();
                return;
            }
        }
        Console.WriteLine("Invalid login");
    }

    static void AdminLogin()
    {
        Console.WriteLine("\n--- Admin Login ---");
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        foreach (User u in users)
        {
            if (u.username == username && u.password == password && u.role == "admin")
            {
                currentUser = u;
                Console.WriteLine("Welcome Admin");
                AdminMenu();
                return;
            }
        }
        Console.WriteLine("Invalid admin login");
    }

    static void Logout()
    {
        currentUser = null;
        appliedCoupon = "";
        Console.WriteLine("Logged out successfully");
    }

    static void UpdateProfile()
    {
        if (currentUser == null)
        {
            Console.WriteLine("Please login first");
            return;
        }

        Console.WriteLine("\n--- Update Profile ---");
        Console.Write("Enter Email: ");
        currentUser.email = Console.ReadLine();
        Console.Write("Enter Phone: ");
        currentUser.phone = Console.ReadLine();
        Console.Write("Enter Address: ");
        currentUser.address = Console.ReadLine();
        Console.WriteLine("Profile updated");
    }

    static void ChangePassword()
    {
        if (currentUser == null)
        {
            Console.WriteLine("Please login first");
            return;
        }

        Console.Write("Enter Old Password: ");
        string oldPass = Console.ReadLine();
        if (oldPass != currentUser.password)
        {
            Console.WriteLine("Wrong old password");
            return;
        }

        Console.Write("Enter New Password: ");
        currentUser.password = Console.ReadLine();
        Console.WriteLine("Password changed");
    }

    // -------- ADMIN MENU --------

    static void AdminMenu()
    {
        int choice = 0;
        do
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("           ADMIN MENU");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Search Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Add Category");
            Console.WriteLine("7. Delete Category");
            Console.WriteLine("8. Update Category");
            Console.WriteLine("9. View Categories");
            Console.WriteLine("10. View All Orders");
            Console.WriteLine("11. Sales Report");
            Console.WriteLine("12. Inventory Report");
            Console.WriteLine("13. Logout");
            Console.WriteLine("==================================");

            Console.Write("Enter Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: AddProduct(); break;
                case 2: UpdateProduct(); break;
                case 3: DeleteProduct(); break;
                case 4: SearchProduct(); break;
                case 5: ViewAllProducts(); break;
                case 6: AddCategory(); break;
                case 7: DeleteCategory(); break;
                case 8: UpdateCategory(); break;
                case 9: ViewCategories(); break;
                case 10: ViewAllOrders(); break;
                case 11: SalesReport(); break;
                case 12: InventoryReport(); break;
                case 13: Logout(); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }

            if (choice != 13)
            {
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (choice != 13);
    }

    static void AddProduct()
    {
        Console.WriteLine("\n--- Add Product ---");
        ViewCategories();

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Category: ");
        string cat = Console.ReadLine();
        Console.Write("Enter Description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter Price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Brand: ");
        string brand = Console.ReadLine();
        Console.Write("Enter Discount %: ");
        double dis = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter Rating: ");
        double rat = Convert.ToDouble(Console.ReadLine());

        Product p = new Product(nextProductId, name, cat, desc, price, qty, brand, dis, rat);
        products.Add(p);
        nextProductId++;
        Console.WriteLine("Product added with ID: " + p.productId);
    }

    static void UpdateProduct()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Product p in products)
        {
            if (p.productId == id)
            {
                Console.Write("Enter Name: ");
                p.name = Console.ReadLine();
                Console.Write("Enter Category: ");
                p.category = Console.ReadLine();
                Console.Write("Enter Description: ");
                p.description = Console.ReadLine();
                Console.Write("Enter Price: ");
                p.price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                p.quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Brand: ");
                p.brand = Console.ReadLine();
                Console.Write("Enter Discount %: ");
                p.discount = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Rating: ");
                p.rating = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Product updated");
                return;
            }
        }
        Console.WriteLine("Product not found");
    }

    static void DeleteProduct()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].productId == id)
            {
                products.RemoveAt(i);
                Console.WriteLine("Product deleted");
                return;
            }
        }
        Console.WriteLine("Product not found");
    }

    static void SearchProduct()
    {
        Console.Write("Enter keyword: ");
        string key = Console.ReadLine();
        bool found = false;

        foreach (Product p in products)
        {
            if (p.name.Contains(key) || p.category.Contains(key) || p.brand.Contains(key))
            {
                ShowProduct(p);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No product found");
    }

    static void ViewAllProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products");
            return;
        }

        foreach (Product p in products)
            ShowProduct(p);
    }

    static void ShowProduct(Product p)
    {
        Console.WriteLine("ID: " + p.productId + " | " + p.name + " | " + p.category);
        Console.WriteLine("Price: " + p.price + " | Qty: " + p.quantity + " | Brand: " + p.brand);
        Console.WriteLine("Discount: " + p.discount + "% | Rating: " + p.rating);
        Console.WriteLine("Description: " + p.description);
        Console.WriteLine("------------------------------");
    }

    static void AddCategory()
    {
        Console.Write("Enter Category Name: ");
        string name = Console.ReadLine();
        categories.Add(new Category(categories.Count + 1, name));
        Console.WriteLine("Category added");
    }

    static void DeleteCategory()
    {
        ViewCategories();
        Console.Write("Enter Category ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < categories.Count; i++)
        {
            if (categories[i].categoryId == id)
            {
                categories.RemoveAt(i);
                Console.WriteLine("Category deleted");
                return;
            }
        }
        Console.WriteLine("Category not found");
    }

    static void UpdateCategory()
    {
        ViewCategories();
        Console.Write("Enter Category ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        foreach (Category c in categories)
        {
            if (c.categoryId == id)
            {
                c.name = name;
                Console.WriteLine("Category updated");
                return;
            }
        }
        Console.WriteLine("Category not found");
    }

    static void ViewCategories()
    {
        Console.WriteLine("\nCategories:");
        foreach (Category c in categories)
            Console.WriteLine(c.categoryId + ". " + c.name);
    }

    static void ViewAllOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No orders");
            return;
        }

        foreach (Order o in orders)
            ShowOrder(o);
    }

    static void SalesReport()
    {
        double totalSales = 0;
        foreach (Order o in orders)
        {
            if (o.orderStatus != "Cancelled")
                totalSales = totalSales + o.grandTotal;
        }
        Console.WriteLine("\n--- Sales Report ---");
        Console.WriteLine("Total Orders: " + orders.Count);
        Console.WriteLine("Total Sales: Rs. " + totalSales);
    }

    static void InventoryReport()
    {
        Console.WriteLine("\n--- Inventory Report ---");
        foreach (Product p in products)
            Console.WriteLine(p.productId + " | " + p.name + " | Qty: " + p.quantity);
    }

    // -------- CUSTOMER MENU --------

    static void CustomerMenu()
    {
        int choice = 0;
        do
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("          CUSTOMER MENU");
            Console.WriteLine("==================================");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Remove from Cart");
            Console.WriteLine("5. Update Cart Quantity");
            Console.WriteLine("6. Clear Cart");
            Console.WriteLine("7. Apply Coupon");
            Console.WriteLine("8. Checkout");
            Console.WriteLine("9. Order History");
            Console.WriteLine("10. Search Order");
            Console.WriteLine("11. Cancel Order");
            Console.WriteLine("12. Download Invoice");
            Console.WriteLine("13. Update Profile");
            Console.WriteLine("14. Change Password");
            Console.WriteLine("15. Logout");
            Console.WriteLine("==================================");

            Console.Write("Enter Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: ViewAllProducts(); break;
                case 2: AddToCart(); break;
                case 3: ViewCart(); break;
                case 4: RemoveFromCart(); break;
                case 5: UpdateCartQty(); break;
                case 6: ClearCart(); break;
                case 7: ApplyCoupon(); break;
                case 8: Checkout(); break;
                case 9: OrderHistory(); break;
                case 10: SearchOrder(); break;
                case 11: CancelOrder(); break;
                case 12: DownloadInvoice(); break;
                case 13: UpdateProfile(); break;
                case 14: ChangePassword(); break;
                case 15: Logout(); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }

            if (choice != 15)
            {
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (choice != 15);
    }

    static void AddToCart()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        foreach (Product p in products)
        {
            if (p.productId == id)
            {
                if (qty > p.quantity)
                {
                    Console.WriteLine("Not enough stock");
                    return;
                }

                // check if already in cart
                foreach (CartItem c in currentUser.cart)
                {
                    if (c.productId == id)
                    {
                        c.qty = c.qty + qty;
                        Console.WriteLine("Cart updated");
                        return;
                    }
                }

                currentUser.cart.Add(new CartItem(p.productId, p.name, qty, p.price, p.discount));
                Console.WriteLine("Added to cart");
                return;
            }
        }
        Console.WriteLine("Product not found");
    }

    static void RemoveFromCart()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < currentUser.cart.Count; i++)
        {
            if (currentUser.cart[i].productId == id)
            {
                currentUser.cart.RemoveAt(i);
                Console.WriteLine("Item removed");
                return;
            }
        }
        Console.WriteLine("Item not in cart");
    }

    static void UpdateCartQty()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter New Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        foreach (CartItem c in currentUser.cart)
        {
            if (c.productId == id)
            {
                c.qty = qty;
                Console.WriteLine("Quantity updated");
                return;
            }
        }
        Console.WriteLine("Item not found in cart");
    }

    static void ClearCart()
    {
        currentUser.cart.Clear();
        appliedCoupon = "";
        Console.WriteLine("Cart cleared");
    }

    static void ApplyCoupon()
    {
        Console.Write("Enter Coupon Code (SAVE10 / FLAT500): ");
        string code = Console.ReadLine();
        if (code == "SAVE10" || code == "FLAT500")
        {
            appliedCoupon = code;
            Console.WriteLine("Coupon applied");
        }
        else
        {
            Console.WriteLine("Invalid coupon");
        }
    }

    static void ViewCart()
    {
        if (currentUser.cart.Count == 0)
        {
            Console.WriteLine("Cart is empty");
            return;
        }

        double total = 0;
        double discount = 0;

        foreach (CartItem c in currentUser.cart)
        {
            double itemTotal = c.price * c.qty;
            double itemDiscount = itemTotal * c.discount / 100;
            total = total + itemTotal;
            discount = discount + itemDiscount;
            Console.WriteLine(c.name + " x" + c.qty + " = Rs." + (itemTotal - itemDiscount));
        }

        double afterDiscount = total - discount;
        double couponDiscount = 0;

        if (appliedCoupon == "SAVE10")
            couponDiscount = afterDiscount * 10 / 100;
        else if (appliedCoupon == "FLAT500")
            couponDiscount = 500;

        double gst = (afterDiscount - couponDiscount) * gstRate / 100;
        double grandTotal = afterDiscount - couponDiscount + gst;

        Console.WriteLine("------------------------------");
        Console.WriteLine("Total: Rs." + total);
        Console.WriteLine("Discount: Rs." + discount);
        Console.WriteLine("Coupon Discount: Rs." + couponDiscount);
        Console.WriteLine("GST: Rs." + gst);
        Console.WriteLine("Grand Total: Rs." + grandTotal);
    }

    static void Checkout()
    {
        if (currentUser.cart.Count == 0)
        {
            Console.WriteLine("Cart is empty");
            return;
        }

        Console.WriteLine("\n--- Checkout ---");
        Console.Write("Confirm Address (press enter to use saved): ");
        string addr = Console.ReadLine();
        if (addr == "")
            addr = currentUser.address;

        Console.WriteLine("Select Payment:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. Debit Card");
        Console.WriteLine("3. UPI");
        Console.WriteLine("4. Cash On Delivery");
        Console.Write("Enter Choice: ");
        int payChoice = Convert.ToInt32(Console.ReadLine());

        string payMethod = "";
        if (payChoice == 1) payMethod = "Credit Card";
        else if (payChoice == 2) payMethod = "Debit Card";
        else if (payChoice == 3) payMethod = "UPI";
        else if (payChoice == 4) payMethod = "Cash On Delivery";
        else
        {
            Console.WriteLine("Invalid payment");
            return;
        }

        // calculate totals
        double total = 0;
        double discount = 0;
        foreach (CartItem c in currentUser.cart)
        {
            total = total + (c.price * c.qty);
            discount = discount + (c.price * c.qty * c.discount / 100);
        }
        double afterDiscount = total - discount;
        double couponDiscount = 0;
        if (appliedCoupon == "SAVE10")
            couponDiscount = afterDiscount * 10 / 100;
        else if (appliedCoupon == "FLAT500")
            couponDiscount = 500;

        double gst = (afterDiscount - couponDiscount) * gstRate / 100;
        double grandTotal = afterDiscount - couponDiscount + gst;

        // payment simulation
        string payStatus = SimulatePayment(payMethod);

        Order order = new Order();
        order.orderId = nextOrderId;
        nextOrderId++;
        order.date = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        order.customerName = currentUser.username;
        order.address = addr;
        order.total = total;
        order.discount = discount + couponDiscount;
        order.gst = gst;
        order.grandTotal = grandTotal;
        order.paymentMethod = payMethod;
        order.paymentStatus = payStatus;
        order.orderStatus = "Placed";

        if (payStatus == "Success" || payMethod == "Cash On Delivery")
            order.orderStatus = "Confirmed";

        foreach (CartItem c in currentUser.cart)
        {
            order.items.Add(new OrderItem(c.name, c.qty, c.price, c.discount));

            // reduce stock
            foreach (Product p in products)
            {
                if (p.productId == c.productId)
                    p.quantity = p.quantity - c.qty;
            }
        }

        orders.Add(order);
        currentUser.cart.Clear();
        appliedCoupon = "";

        Console.WriteLine("\nOrder Placed Successfully!");
        ShowOrder(order);
        GenerateInvoice(order);
    }

    static string SimulatePayment(string method)
    {
        Console.WriteLine("\nProcessing Payment...");

        if (method == "Credit Card" || method == "Debit Card")
        {
            Console.Write("Enter Card Number: ");
            Console.ReadLine();
            Console.Write("Enter CVV: ");
            Console.ReadLine();
        }
        else if (method == "UPI")
        {
            Console.Write("Enter UPI ID: ");
            Console.ReadLine();
        }

        if (method == "Cash On Delivery")
        {
            Console.WriteLine("Payment Status: Pending");
            return "Pending";
        }

        Random r = new Random();
        int num = r.Next(1, 4);

        if (num == 1)
        {
            Console.WriteLine("Payment Status: Success");
            return "Success";
        }
        else if (num == 2)
        {
            Console.WriteLine("Payment Status: Failed");
            return "Failed";
        }
        else
        {
            Console.WriteLine("Payment Status: Pending");
            return "Pending";
        }
    }

    static void OrderHistory()
    {
        bool found = false;
        foreach (Order o in orders)
        {
            if (o.customerName == currentUser.username)
            {
                ShowOrder(o);
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("No orders found");
    }

    static void SearchOrder()
    {
        Console.Write("Enter Order ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Order o in orders)
        {
            if (o.orderId == id && o.customerName == currentUser.username)
            {
                ShowOrder(o);
                return;
            }
        }
        Console.WriteLine("Order not found");
    }

    static void CancelOrder()
    {
        Console.Write("Enter Order ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Order o in orders)
        {
            if (o.orderId == id && o.customerName == currentUser.username)
            {
                if (o.orderStatus == "Cancelled")
                {
                    Console.WriteLine("Already cancelled");
                    return;
                }

                o.orderStatus = "Cancelled";

                // add qty back to stock
                foreach (OrderItem item in o.items)
                {
                    foreach (Product p in products)
                    {
                        if (p.name == item.name)
                            p.quantity = p.quantity + item.qty;
                    }
                }

                Console.WriteLine("Order cancelled");
                return;
            }
        }
        Console.WriteLine("Order not found");
    }

    static void DownloadInvoice()
    {
        Console.Write("Enter Order ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Order o in orders)
        {
            if (o.orderId == id && o.customerName == currentUser.username)
            {
                string file = GenerateInvoice(o);
                Console.WriteLine("Invoice saved: " + file);
                return;
            }
        }
        Console.WriteLine("Order not found");
    }

    static void ShowOrder(Order o)
    {
        Console.WriteLine("\nOrder Id: " + o.orderId);
        Console.WriteLine("Date: " + o.date);
        Console.WriteLine("Customer: " + o.customerName);
        Console.WriteLine("Address: " + o.address);
        Console.WriteLine("Items:");
        foreach (OrderItem item in o.items)
            Console.WriteLine("  " + item.name + " x" + item.qty);
        Console.WriteLine("Total: Rs." + o.total);
        Console.WriteLine("Discount: Rs." + o.discount);
        Console.WriteLine("GST: Rs." + o.gst);
        Console.WriteLine("Grand Total: Rs." + o.grandTotal);
        Console.WriteLine("Payment: " + o.paymentMethod + " | Status: " + o.paymentStatus);
        Console.WriteLine("Order Status: " + o.orderStatus);
        Console.WriteLine("------------------------------");
    }

    static string GenerateInvoice(Order o)
    {
        if (!Directory.Exists("Invoices"))
            Directory.CreateDirectory("Invoices");

        string fileName = "Invoices/Invoice_" + o.orderId + ".txt";

        StreamWriter writer = new StreamWriter(fileName);
        writer.WriteLine("======== SHOPEASE INVOICE ========");
        writer.WriteLine("Order Id: " + o.orderId);
        writer.WriteLine("Date: " + o.date);
        writer.WriteLine("Customer: " + o.customerName);
        writer.WriteLine("Address: " + o.address);
        writer.WriteLine("Items:");
        foreach (OrderItem item in o.items)
            writer.WriteLine(item.name + " x" + item.qty);
        writer.WriteLine("Total: Rs." + o.total);
        writer.WriteLine("Discount: Rs." + o.discount);
        writer.WriteLine("GST: Rs." + o.gst);
        writer.WriteLine("Grand Total: Rs." + o.grandTotal);
        writer.WriteLine("Payment: " + o.paymentMethod);
        writer.WriteLine("Payment Status: " + o.paymentStatus);
        writer.WriteLine("==================================");
        writer.Close();

        return fileName;
    }
}
