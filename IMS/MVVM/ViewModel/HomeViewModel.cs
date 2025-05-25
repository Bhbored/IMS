using IMS.MVVM.Model;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;
using System.Windows.Input;
using Microsoft.Maui.Dispatching;

namespace IMS.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class HomeViewModel : INotifyPropertyChanged
    {
        private static HomeViewModel? _instance;
        public static HomeViewModel Instance => _instance ??= new HomeViewModel();

        public HomeViewModel()
        {
            CurrentInventory = new ObservableCollection<Product>();
            foreach (var product in Electronics) CurrentInventory.Add(product);
            foreach (var product in Groceries) CurrentInventory.Add(product);
            foreach (var product in Clothings) CurrentInventory.Add(product);
            foreach (var product in Furniture) CurrentInventory.Add(product);
            foreach (var product in Books) CurrentInventory.Add(product);

            Products = new ObservableCollection<Product>(Electronics);
            Orders = new ObservableCollection<Orders>();
            Transactions = new ObservableCollection<Transaction>();
            StartTimer();
        }

        #region Date and Time
        public DateTime CurrentDateTime { get; set; }
        private void StartTimer()
        {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    CurrentDateTime = DateTime.Now;
                });
            };
            timer.Start();
        }
        #endregion

        #region Categories
        public ObservableCollection<Category>? Categories { get; set; } = [
           new(){ CategoryID = 1, Name = "Electronics" ,ImageUrl="electronics.png"},
            new() { CategoryID = 2, Name = "Groceries" ,ImageUrl= "grocery.png"},
            new() { CategoryID = 3, Name = "Clothing" ,ImageUrl="clothings.png"},
            new() { CategoryID = 4, Name = "Furniture" ,ImageUrl="furniture.png"},
            new() { CategoryID = 5, Name = "Books" ,ImageUrl="books.png"},
          ];
        #endregion

        #region Products Collections
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> CurrentInventory { get; set; }

        public ObservableCollection<Product> Electronics { get; set; } = [
            new Product { ProductID = 1, Name = "Smartphone X", Description = "Latest 5G smartphone with AI-powered camera", ImageUrl = "a1a.jpg", CategoryID = 1, SupplierID = 101, Price = 799.99m, Stock = 50 },
            new Product { ProductID = 2, Name = "Laptop Pro 15", Description = "High-performance laptop with 16GB RAM", ImageUrl = "a2a.jpg", CategoryID = 1, SupplierID = 102, Price = 1299.99m, Stock = 30 },
            new Product { ProductID = 3, Name = "Wireless Earbuds", Description = "Noise-cancelling true wireless earbuds", ImageUrl = "a3a.jpg", CategoryID = 1, SupplierID = 103, Price = 149.99m, Stock = 100 },
            new Product { ProductID = 4, Name = "Smartwatch Series 7", Description = "Water-resistant smartwatch with health tracking", ImageUrl = "a4a.jpg", CategoryID = 1, SupplierID = 104, Price = 299.99m, Stock = 40 },
            new Product { ProductID = 5, Name = "Gaming Console Z", Description = "Next-gen gaming console with 4K support", ImageUrl = "a5a.jpg", CategoryID = 1, SupplierID = 105, Price = 499.99m, Stock = 25 },
            new Product { ProductID = 6, Name = "Bluetooth Speaker Max", Description = "High-fidelity Bluetooth speaker with deep bass", ImageUrl = "a6a.jpg", CategoryID = 1, SupplierID = 106, Price = 199.99m, Stock = 80 },
            new Product { ProductID = 7, Name = "Drone Pro 4K", Description = "Advanced drone with 4K camera stabilization", ImageUrl = "a7a.jpg", CategoryID = 1, SupplierID = 107, Price = 999.99m, Stock = 15 },
            new Product { ProductID = 8, Name = "Tablet Ultra 12", Description = "Large-screen tablet with stylus support", ImageUrl = "a8a.jpg", CategoryID = 1, SupplierID = 108, Price = 899.99m, Stock = 20 },
            new Product { ProductID = 9, Name = "VR Headset Pro", Description = "Immersive virtual reality headset for gaming", ImageUrl = "a9a.jpg", CategoryID = 1, SupplierID = 109, Price = 399.99m, Stock = 35 },
            new Product { ProductID = 10, Name = "Smart TV 55-inch", Description = "4K UHD Smart TV with HDR support", ImageUrl = "a10a.jpg", CategoryID = 1, SupplierID = 110, Price = 699.99m, Stock = 60 },
        ];

        public ObservableCollection<Product> Groceries { get; set; } = [
            new Product { ProductID = 11, Name = "Organic Apples", Description = "Fresh organic apples, packed with nutrients", ImageUrl = "b1b.jpg", CategoryID = 2, SupplierID = 201, Price = 3.99m, Stock = 200 },
            new Product { ProductID = 12, Name = "Whole Wheat Bread", Description = "Soft and nutritious whole wheat bread", ImageUrl = "b2b.jpg", CategoryID = 2, SupplierID = 202, Price = 2.49m, Stock = 150 },
            new Product { ProductID = 13, Name = "Almond Milk", Description = "Plant-based milk alternative, rich in vitamins", ImageUrl = "b3b.jpg", CategoryID = 2, SupplierID = 203, Price = 4.99m, Stock = 100 },
            new Product { ProductID = 14, Name = "Brown Rice", Description = "Healthy whole grain rice, great for meals", ImageUrl = "b4b.jpg", CategoryID = 2, SupplierID = 204, Price = 5.99m, Stock = 120 },
            new Product { ProductID = 15, Name = "Extra Virgin Olive Oil", Description = "Premium cold-pressed olive oil", ImageUrl = "b5b.jpg", CategoryID = 2, SupplierID = 205, Price = 10.99m, Stock = 80 },
            new Product { ProductID = 16, Name = "Free-Range Eggs", Description = "Large eggs sourced from free-range farms", ImageUrl = "b6b.jpg", CategoryID = 2, SupplierID = 206, Price = 3.79m, Stock = 140 },
            new Product { ProductID = 17, Name = "Greek Yogurt", Description = "Creamy, high-protein yogurt with probiotics", ImageUrl = "b7b.jpg", CategoryID = 2, SupplierID = 207, Price = 6.49m, Stock = 90 },
            new Product { ProductID = 18, Name = "Fresh Salmon Fillet", Description = "High-quality, omega-rich salmon fillet", ImageUrl = "b8b.jpg", CategoryID = 2, SupplierID = 208, Price = 12.99m, Stock = 60 },
            new Product { ProductID = 19, Name = "Mixed Nuts", Description = "Healthy snack packed with protein and fiber", ImageUrl = "b9b.jpg", CategoryID = 2, SupplierID = 209, Price = 7.99m, Stock = 110 },
            new Product { ProductID = 20, Name = "Dark Chocolate Bar", Description = "Rich dark chocolate with 70% cocoa", ImageUrl = "b10b.jpg", CategoryID = 2, SupplierID = 210, Price = 3.49m, Stock = 130 },
        ];

        public ObservableCollection<Product> Clothings { get; set; } = [
            new Product { ProductID = 21, Name = "Men's Cotton T-Shirt", Description = "Soft and breathable cotton T-shirt", ImageUrl = "c1c.jpg", CategoryID = 3, SupplierID = 301, Price = 14.99m, Stock = 200 },
            new Product { ProductID = 22, Name = "Women's Casual Dress", Description = "Elegant yet casual dress, perfect for outings", ImageUrl = "c2c.jpg", CategoryID = 3, SupplierID = 302, Price = 29.99m, Stock = 150 },
            new Product { ProductID = 23, Name = "Unisex Hoodie", Description = "Warm fleece hoodie with a modern fit", ImageUrl = "c3c.jpg", CategoryID = 3, SupplierID = 303, Price = 39.99m, Stock = 100 },
            new Product { ProductID = 24, Name = "Jeans Slim Fit", Description = "Comfortable and stylish slim-fit jeans", ImageUrl = "c4c.jpg", CategoryID = 3, SupplierID = 304, Price = 49.99m, Stock = 120 },
            new Product { ProductID = 25, Name = "Running Shoes", Description = "Lightweight and supportive running shoes", ImageUrl = "c5c.jpg", CategoryID = 3, SupplierID = 305, Price = 59.99m, Stock = 80 },
            new Product { ProductID = 26, Name = "Men's Formal Shirt", Description = "Classic formal shirt for professional settings", ImageUrl = "c6c.jpg", CategoryID = 3, SupplierID = 306, Price = 34.99m, Stock = 140 },
            new Product { ProductID = 27, Name = "Women's Winter Coat", Description = "Cozy and stylish winter coat", ImageUrl = "c7c.jpg", CategoryID = 3, SupplierID = 307, Price = 89.99m, Stock = 90 },
            new Product { ProductID = 28, Name = "Sportswear Tracksuit", Description = "Breathable tracksuit for workouts and casual wear", ImageUrl = "c8c.jpg", CategoryID = 3, SupplierID = 308, Price = 69.99m, Stock = 60 },
            new Product { ProductID = 29, Name = "Baseball Cap", Description = "Adjustable and stylish baseball cap", ImageUrl = "c9c.jpg", CategoryID = 3, SupplierID = 309, Price = 19.99m, Stock = 130 },
            new Product { ProductID = 30, Name = "Leather Belt", Description = "Classic leather belt for formal and casual wear", ImageUrl = "c10c.jpg", CategoryID = 3, SupplierID = 310, Price = 24.99m, Stock = 110 },
        ];

        public ObservableCollection<Product> Furniture { get; set; } = [
            new Product { ProductID = 31, Name = "Wooden Dining Table", Description = "Elegant solid wood dining table, seats 6", ImageUrl = "d1d.jpg", CategoryID = 4, SupplierID = 401, Price = 499.99m, Stock = 20 },
            new Product { ProductID = 32, Name = "Ergonomic Office Chair", Description = "Comfortable, adjustable chair for office use", ImageUrl = "d2d.jpg", CategoryID = 4, SupplierID = 402, Price = 149.99m, Stock = 50 },
            new Product { ProductID = 33, Name = "Leather Sofa Set", Description = "Luxurious three-piece leather sofa set", ImageUrl = "d3d.jpg", CategoryID = 4, SupplierID = 403, Price = 899.99m, Stock = 10 },
            new Product { ProductID = 34, Name = "Modern Coffee Table", Description = "Stylish glass-top coffee table with storage", ImageUrl = "d4d.jpg", CategoryID = 4, SupplierID = 404, Price = 199.99m, Stock = 35 },
            new Product { ProductID = 35, Name = "Queen-Size Bed Frame", Description = "Sturdy wooden bed frame with headboard", ImageUrl = "d5d.jpg", CategoryID = 4, SupplierID = 405, Price = 699.99m, Stock = 15 },
            new Product { ProductID = 36, Name = "Bookshelf Organizer", Description = "Spacious wooden bookshelf with multiple compartments", ImageUrl = "d6d.jpg", CategoryID = 4, SupplierID = 406, Price = 129.99m, Stock = 40 },
            new Product { ProductID = 37, Name = "Dining Chairs Set", Description = "Set of 4 upholstered dining chairs", ImageUrl = "d7d.jpg", CategoryID = 4, SupplierID = 407, Price = 249.99m, Stock = 25 },
            new Product { ProductID = 38, Name = "TV Stand with Drawers", Description = "Wooden TV stand with built-in storage drawers", ImageUrl = "d8d.jpg", CategoryID = 4, SupplierID = 408, Price = 279.99m, Stock = 30 },
            new Product { ProductID = 39, Name = "Nightstand with Drawer", Description = "Compact bedside nightstand with storage", ImageUrl = "d9d.jpg", CategoryID = 4, SupplierID = 409, Price = 89.99m, Stock = 45 },
            new Product { ProductID = 40, Name = "Outdoor Patio Set", Description = "Weather-resistant outdoor furniture set", ImageUrl = "d10d.jpg", CategoryID = 4, SupplierID = 410, Price = 499.99m, Stock = 20 },
        ];

        public ObservableCollection<Product> Books { get; set; } = [
            new Product { ProductID = 41, Name = "The Art of Coding", Description = "Comprehensive guide to modern programming techniques", ImageUrl = "e1e.jpg", CategoryID = 5, SupplierID = 501, Price = 29.99m, Stock = 100 },
            new Product { ProductID = 42, Name = "Mastering Data Science", Description = "Deep dive into machine learning and AI fundamentals", ImageUrl = "e2e.jpg", CategoryID = 5, SupplierID = 502, Price = 39.99m, Stock = 80 },
            new Product { ProductID = 43, Name = "World History: A Brief Overview", Description = "Concise yet engaging account of global history", ImageUrl = "e3e.jpg", CategoryID = 5, SupplierID = 503, Price = 24.99m, Stock = 120 },
            new Product { ProductID = 44, Name = "Advanced Mathematics Handbook", Description = "Essential formulas and concepts for higher-level math", ImageUrl = "e4e.jpg", CategoryID = 5, SupplierID = 504, Price = 49.99m, Stock = 60 },
            new Product { ProductID = 45, Name = "Science Fiction Anthology", Description = "A collection of mind-bending sci-fi stories", ImageUrl = "e5e.jpg", CategoryID = 5, SupplierID = 505, Price = 19.99m, Stock = 90 },
            new Product { ProductID = 46, Name = "Personal Finance Guide", Description = "Tips and strategies for financial independence", ImageUrl = "e6e.jpg", CategoryID = 5, SupplierID = 506, Price = 34.99m, Stock = 110 },
            new Product { ProductID = 47, Name = "The Psychology of Success", Description = "Insights into mindset, habits, and personal growth", ImageUrl = "e7e.jpg", CategoryID = 5, SupplierID = 507, Price = 27.99m, Stock = 95 },
            new Product { ProductID = 48, Name = "Modern Architecture Designs", Description = "Exploration of contemporary architectural innovations", ImageUrl = "e8e.jpg", CategoryID = 5, SupplierID = 508, Price = 54.99m, Stock = 50 },
            new Product { ProductID = 49, Name = "Cooking for Beginners", Description = "Easy-to-follow recipes for new cooks", ImageUrl = "e9e.jpg", CategoryID = 5, SupplierID = 509, Price = 21.99m, Stock = 140 },
            new Product { ProductID = 50, Name = "Travel Destinations Guide", Description = "A curated list of must-visit places around the world", ImageUrl = "e10e.jpg", CategoryID = 5, SupplierID = 510, Price = 26.99m, Stock = 75 },
        ];
        #endregion

        public ObservableCollection<Transaction> Transactions { get; set; }

        #region Orders
        public ObservableCollection<Orders> Orders { get; set; }
        #endregion

        #region Calculated Properties
        public decimal Subtotal
        {
            get
            {
                return Orders?.Sum(o => o.Price * o.QuantityChanged) ?? 0;
            }
        }

        public decimal Tax => Subtotal * 0.02m;
        public decimal Total => Subtotal + Tax;
        #endregion

        #region Property Change Notification
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyCalculatedPropertiesChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }
        #endregion

        #region Commands
        public ICommand Choose => new Command<string>((categoryName) =>
        {
            if (string.IsNullOrEmpty(categoryName)) return;

            var category = Categories?.FirstOrDefault(c => c.Name == categoryName);
            if (category == null) return;

            ObservableCollection<Product> filteredProducts = category.CategoryID switch
            {
                1 => Electronics,
                2 => Groceries,
                3 => Clothings,
                4 => Furniture,
                5 => Books,
                _ => Electronics
            };

            Products.Clear();
            foreach (var product in filteredProducts)
            {
                Products.Add(product);
            }
        });

        public ICommand AddOrder => new Command<string>((productName) =>
        {
            AddOrderToCart(productName);
        });

        public ICommand Add => new Command<string>((productName) =>
        {
            AddQuantity(productName);
        });

        public ICommand Deduct => new Command<string>((productName) =>
        {
            DeductQuantity(productName);
        });

        public ICommand RemoveOrder => new Command<string>((productName) =>
        {
            RemoveOrderFromCart(productName);
        });

        public ICommand ClearOrderCommand => new Command(() =>
        {
            Orders.Clear();
            NotifyCalculatedPropertiesChanged();
        });

        public ICommand PaidCashCommand => new Command(() =>
        {
            ProcessPayment("Cash");
        });

        public ICommand PaidOnlineCommand => new Command(() =>
        {
            ProcessPayment("Online");
        });
        #endregion

        #region Methods
        public void AddOrderToCart(string productName)
        {
            if (string.IsNullOrEmpty(productName)) return;

            var product = CurrentInventory.FirstOrDefault(p => p.Name == productName);
            if (product == null) return;

            var existingOrder = Orders.FirstOrDefault(o => o.ProductID == product.ProductID);
            if (existingOrder != null)
            {
                existingOrder.QuantityChanged++;
            }
            else
            {
                Orders.Add(new Orders
                {
                    ProductID = product.ProductID,
                    ProductName = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    QuantityChanged = 1,
                    Date = DateTime.Now,
                    TransactionType = "Sale"
                });
            }
            NotifyCalculatedPropertiesChanged();
        }

        public void AddQuantity(string productName)
        {
            if (string.IsNullOrEmpty(productName)) return;

            var order = Orders.FirstOrDefault(o => o.ProductName == productName);
            if (order != null)
            {
                order.QuantityChanged++;
                NotifyCalculatedPropertiesChanged();
            }
        }

        public void DeductQuantity(string productName)
        {
            if (string.IsNullOrEmpty(productName)) return;

            var order = Orders.FirstOrDefault(o => o.ProductName == productName);
            if (order != null && order.QuantityChanged > 1)
            {
                order.QuantityChanged--;
                NotifyCalculatedPropertiesChanged();
            }
            else if (order != null && order.QuantityChanged == 1)
            {
                Orders.Remove(order);
                NotifyCalculatedPropertiesChanged();
            }
        }

        public void RemoveOrderFromCart(string productName)
        {
            if (string.IsNullOrEmpty(productName)) return;

            var order = Orders.FirstOrDefault(o => o.ProductName == productName);
            if (order != null)
            {
                Orders.Remove(order);
                NotifyCalculatedPropertiesChanged();
            }
        }

        private void ProcessPayment(string paymentMethod)
        {
            if (Orders == null || !Orders.Any()) return;

            var transaction = new Transaction
            {
                TransactionID = new Random().Next(1000, 9999),
                TransactionDate = DateTime.Now,
                PaymentMethod = paymentMethod,
                Subtotal = Subtotal,
                Tax = Tax,
                Total = Total,
                Status = "Completed",
                OrderItems = new ObservableCollection<Orders>(Orders),
                OrderCount = Orders.Count,
            };

            Transactions.Add(transaction);
            Orders.Clear();
            NotifyCalculatedPropertiesChanged();

            Application.Current?.MainPage?.DisplayAlert("Payment Complete",
                $"Transaction completed successfully!\nTransaction ID: {transaction.TransactionID}\nTotal: ${transaction.Total:F2}",
                "OK");
        }
        #endregion


    }
}