using System; 
 
// This is is the beginnong of the program which is the section that defines the Address class, representing  
// a physical address. It has private attributes (street, city, state, zip code) and a constructor to 
// initialize the address. It also overrides the ToString() method to provide a formatted address string.


public class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string _street, string _city, string _state, string _zipCode)
    {
        this.street = _street;
        this.city = _city;
        this.state = _state;
        this.zipCode = _zipCode;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}
// The Event class is defined to represent an event. It has private attributes (title,
// description, date, time, address) and a constructor to initialize them.It provides 
// methods to get the event details (standard details, full details, short description).
public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string _title, string _description, DateTime _date, TimeSpan _time, Address _address)
    {
        this.title = _title;
        this.description = _description;
        this.date = _date;
        this.time = _time;
        this.address = _address;
    }

    public string GetStandardDetails()
    {
        return $"Description: {description}\nDate: {date.ToShortDateString()}\nTime: {date.ToString("hh:mm")} PM\nAddress: {address.ToString()}";
    }

    public virtual string GetFullDetails()
    {
        return $"Event: {title}\n{GetStandardDetails()}";
    }

    public string GetShortDescription()
    {
        return $"Event: {title}\nDate: {date.ToShortDateString()}";
    }
}
// The Lecture class is a subclass of Event and represents a lecture event. 
// It adds extra attributes (speaker, capacity) and has a constructor to initialize
//  them. It overrides the GetFullDetails() method to include speaker and capacity.
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}
// The Reception class is another subclass of Event representing a reception event.
// It adds an extra attribute (Email) and has a constructor to initialize it.
// It overrides the GetFullDetails() method to include the RSVP email.
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\n Email: {rsvpEmail}";
    }
}
// The OutdoorGathering class is also a subclass of Event representing an outdoor gathering. 
// It adds an extra attribute (weatherForecast) and has a constructor to initialize it.
// It overrides the GetFullDetails() method to include the weather forecast.
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather Forecast: {weatherForecast}";
    }
}
// The Program class contains the Main method, which is the entry point of the program. 
// It creates instances of Address, Lecture, Reception, and OutdoorGathering classes.  
// It then prints out the details of each event by calling the respective GetFullDetails() methods.
public class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("231 Omega Main St", "Monrovia", "Montserrado County", "+231");
        Lecture lecture1 = new Lecture("Introduction to the Principle of Leadership", "Learn about leadership and its principles.", DateTime.Now.Date, new TimeSpan(1, 0, 0), address1, "Emmanuel DK Dolo", 100);

        Address address2 = new Address("Gbarnga Main St", "Bong County", "Opposite MTN Office", "+231");
        Reception reception1 = new Reception("Networking Event", "Connect with professionals in your industry.", DateTime.Now.Date.AddDays(1), new TimeSpan(1, 30, 0), address2, "emmanuel342@gmail.com");

        Address address3 = new Address("Harper City", "Maryland County, Liberia", "Maryland", "+321");
        OutdoorGathering gathering1 = new OutdoorGathering("Fun Sharing Event", "Join us for a fun-filled evening with food and games.", DateTime.Now.Date.AddDays(2), new TimeSpan(7, 0, 0), address3, "Sunny with a chance of clouds.");

        Console.WriteLine();
        Console.WriteLine("--- Lecture ---");
        string lectureDetails = lecture1.GetFullDetails();
        Console.WriteLine(lectureDetails);
        

        Console.WriteLine("\n--- Reception ---");
        string receptionDetails = reception1.GetFullDetails();
        Console.WriteLine(receptionDetails);
       

        Console.WriteLine("\n--- Outdoor Gathering ---");
        string gatheringDetails = gathering1.GetFullDetails();
        Console.WriteLine(gatheringDetails);
      

        Console.ReadLine();
    }
}
