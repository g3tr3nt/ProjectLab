using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

public class TouristAgency
{
    public List<Service> Services { get; set; }
    public List<Tourist> Tourists { get; set; }

    public List<SpecialTourist> SpecialTourists { get; set; }

    public TouristAgency()
    {
        Services = new List<Service>();
        Tourists = new List<Tourist>();
        SpecialTourists = new List<SpecialTourist>();
    }

    public TouristAgency(List<Service> services, List<Tourist> tourists)
    {
        Services = services;
        Tourists = tourists;
    }

    public void AddService(Service service)
    {
        Services.Add(service);
    }

    public void RemoveService(Service service)
    {
        Services.Remove(service);
    }

    public void AddTourist(Tourist tourist)
    {
        Tourists.Add(tourist);
    }

    public void RemoveTourist(Tourist tourist)
    {
        Tourists.Remove(tourist);
    }

    public void AddSpecialTourist(SpecialTourist tourist)
    {
        SpecialTourists.Add(tourist);
    }

    public void RemoveSpecialTourist(SpecialTourist tourist)
    {
        SpecialTourists.Remove(tourist);
    }
}

public class Service
{

  



    public string Name { get; set; }
    public double Price { get; set; }

    public Service()
    {
        Name = "Default Service";
        Price = 0.0;
    }

    public Service(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }
}

public class SpecialService : Service
{
    public SpecialService() : base()
    {
        Name = "Special Service";
    }

    public SpecialService(string name, double price) : base(name, price)
    {
    }

    public override void UpdatePrice(double newPrice)
    {
        if (newPrice >= 0)
        {
            Price = newPrice;
        }
        else
        {
            Console.WriteLine("Price cannot be negative.");
        }
    }
}

public class Tourist
{


    public string Name { get; set; }
    public List<Service> ChosenServices { get; set; }
    public Country Destination { get; set; }
    public static List<Tourist> Tourists = new List<Tourist>();

    public static void DisplayTourists(RichTextBox textBox)
    {
        foreach (var tourist in Tourists)
        {
            textBox.AppendText("Tourist Name: " + tourist.Name + "\n");
            textBox.AppendText("Chosen Services:\n");
            foreach (var service in tourist.ChosenServices)
            {
                textBox.AppendText("- " + service.Name + "\n");
            }
            textBox.AppendText("Destination: " + tourist.Destination.Name + "\n\n");
        }
    }

    public static void WriteToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (var tourist in Tourists)
            {
                writer.WriteLine("Tourist Name: " + tourist.Name);
                writer.WriteLine("Chosen Services:");
                foreach (var service in tourist.ChosenServices)
                {
                    writer.WriteLine("- " + service.Name);
                }
                writer.WriteLine("Destination: " + tourist.Destination.Name);
                writer.WriteLine();
            }
        }
    }
    public static void WriteToFile1(string filePath, Tourist[] tourists)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (var tourist in tourists)
            {
                writer.WriteLine("Tourist Name: " + tourist.Name);
                writer.WriteLine("Chosen Services:");
                foreach (var service in tourist.ChosenServices)
                {
                    writer.WriteLine("- " + service.Name);
                }
                writer.WriteLine("Destination: " + tourist.Destination.Name);
                writer.WriteLine();
            }
        }
    }
    public static string ReadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            return reader.ReadToEnd();
        }
    }
    public Tourist()
    {
        Name = "Default Tourist";
        ChosenServices = new List<Service>();
        Destination = new Country();
    }

    public Tourist(string name, List<Service> chosenServices, Country destination)
    {
        Name = name;
        ChosenServices = chosenServices;
        Destination = destination;
    }

    public virtual void ChooseService(Service service)
    {
        ChosenServices.Add(service);
    }

    public void UnchooseService(Service service)
    {
        ChosenServices.Remove(service);
    }

    public void ChooseDestination(Country country)
    {
        Destination = country;
    }
}

public class Country
{
    public string Name { get; set; }

    public Country()
    {
        Name = "Default Country";
    }

    public Country(string name)
    {
        Name = name;
    }

    public void UpdateName(string newName)
    {
        Name = newName;
    }
}
public class SpecialTourist : Tourist
{
    public Service SpecialService { get; set; }

    public SpecialTourist() : base()
    {
        SpecialService = new Service();
    }

    public SpecialTourist(string name, List<Service> chosenServices, Country destination, Service specialService)
        : base(name, chosenServices, destination)
    {
        SpecialService = specialService;
    }

    public override void ChooseService(Service service)
    {
        base.ChooseService(service);
        Console.WriteLine("Special tourist has chosen a service.");
    }

    public void ShowSpecialService()
    {
        Console.WriteLine("Сервіс: безкоштовний" );
    }

    public static void WriteToFile(string filePath, SpecialTourist[] tourists)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (var tourist in tourists)
            {
                writer.WriteLine("Tourist Name: " + tourist.Name);
                writer.WriteLine("Chosen Services:");
                foreach (var service in tourist.ChosenServices)
                {
                    writer.WriteLine("- " + service.Name);
                }
                writer.WriteLine("Special Service: " + tourist.SpecialService.Name);
                writer.WriteLine("Destination: " + tourist.Destination.Name);
                writer.WriteLine();
            }
        }
    }
}

//public class BaseClass
//{
//    public virtual void ShowMessage()
//    {
//        Console.WriteLine("Hello from BaseClass");
//    }
//}

//public class DerivedClass : BaseClass
//{
//    public sealed override void ShowMessage()
//    {
//        Console.WriteLine("Hello from DerivedClass");
//    }
//}

//public sealed class SealedClass
//{
//    public void ShowMessage()
//    {
//        Console.WriteLine("Hello from SealedClass");
//    }
//}


