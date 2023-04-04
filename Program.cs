using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Device
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Color { get; set; }

    public abstract void PrintInfo();

    public Device(string manufacturer, string model, int quantity, double price, string color)
    {
        Manufacturer = manufacturer;
        Model = model;
        Quantity = quantity;
        Price = price;
        Color = color;
    }
}

class MobilePhone : Device
{
    public string OS { get; set; }

    public MobilePhone(string manufacturer, string model, int quantity, double price, string color, string os)
        : base(manufacturer, model, quantity, price, color)
    {
        OS = os;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Manufacturer: {Manufacturer} \nModel: {Model} \nQuantity: {Quantity} \nPrice: {Price} \nColor: {Color} \nOS: {OS}");
    }
}

class Laptop : Device
{
    public string CPU { get; set; }
    public int RAM { get; set; }

    public Laptop(string manufacturer, string model, int quantity, double price, string color, string cpu, int ram)
        : base(manufacturer, model, quantity, price, color)
    {
        CPU = cpu;
        RAM = ram;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Manufacturer: {Manufacturer} \nModel: {Model} \nQuantity: {Quantity} \nPrice: {Price} \nColor: {Color} \nCPU: {CPU} \nRAM: {RAM}GB");
    }
}

class Tablet : Device
{
    public string DisplayType { get; set; }

    public Tablet(string manufacturer, string model, int quantity, double price, string color, string displayType)
        : base(manufacturer, model, quantity, price, color)
    {
        DisplayType = displayType;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Manufacturer: {Manufacturer} \nModel: {Model} \nQuantity: {Quantity} \nPrice: {Price} \nColor: {Color} \nDisplay Type: {DisplayType}");
    }
}

class Shop
{
    private List<Device> devices = new List<Device>();

    public void AddDevice(Device device)
    {
        devices.Add(device);
    }

    public void RemoveDevice(string manufacturer, string model)
    {
        devices.RemoveAll(d => d.Manufacturer == manufacturer && d.Model == model);
    }

    public void PrintDevices()
    {
        Console.WriteLine("List of devices:");
        foreach (Device device in devices)
        {
            device.PrintInfo();
            Console.WriteLine("\n");
        }
    }

    public List<Device> SearchDevicesByManufacturer(string manufacturer)
    {
        return devices.FindAll(d => d.Manufacturer == manufacturer);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();

        MobilePhone phone = new MobilePhone("Samsung", "Galaxy S21", 10, 799.99, "Black", "Android");
        Laptop laptop = new Laptop("Apple", "MacBook Pro", 5, 1999.99, "Silver", "Intel Core i7", 16);
        Tablet tablet = new Tablet("Amazon", "Fire HD 10", 20, 149.99, "Blue", "IPS LCD");

        shop.AddDevice(phone);
        shop.AddDevice(laptop);
        shop.AddDevice(tablet);

        MobilePhone phone2 = new MobilePhone("Apple", "iPhone 12 Pro", 8, 1099.99, "Gold", "iOS");
        shop.AddDevice(phone2);

        shop.RemoveDevice("Samsung", "Galaxy S21");

        shop.PrintDevices();

        List<Device> appleDevices = shop.SearchDevicesByManufacturer("Apple");
        foreach (Device device in appleDevices)
        {
            device.PrintInfo();
            Console.WriteLine('\n');
        }
    }
}
