using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using UTCService;

namespace UTCServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri carBaseAddress = new Uri("http://localhost:8000/UTC/");
            Uri truckBaseAddress = new Uri("http://localhost:8001/UTC/");

            ServiceHost carSelfHost = new ServiceHost(typeof(CarService), carBaseAddress);
            ServiceHost truckSelfHost = new ServiceHost(typeof(TruckService), truckBaseAddress);

            try
            {
                carSelfHost.AddServiceEndpoint(typeof(ICarService), new WSHttpBinding(), "CarService");
                truckSelfHost.AddServiceEndpoint(typeof(ITruckService), new WSHttpBinding(), "TruckService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                carSelfHost.Description.Behaviors.Add(smb);
                truckSelfHost.Description.Behaviors.Add(smb);

                carSelfHost.Open();
                truckSelfHost.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.ReadLine();
                carSelfHost.Close();
                truckSelfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                carSelfHost.Abort();
                truckSelfHost.Abort();
            }
        }
    }
}