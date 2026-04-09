using System.Collections.Generic;

namespace lab
{
    public class MobilePhone
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public List<string> Features { get; set; }

        public MobilePhone()
        {
            Features = new List<string>();
        }

        public MobilePhone(string model, double price, int year, List<string> features)
        {
            Model = model;
            Price = price;
            Year = year;
            Features = features;
        }

        public void MakeCall(string phoneNumber) { }
        public void SendSMS(string textMessage) { }
        public void ChargeBattery() { }
    }
}