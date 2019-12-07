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
            Uri baseAddress = new Uri("http://localhost:8000/UTC/");

            ServiceHost selfHost = new ServiceHost(typeof(CarService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ICarService), new WSHttpBinding(), "CarService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}