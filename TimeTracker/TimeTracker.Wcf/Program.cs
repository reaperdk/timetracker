using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceModel;
using TimeTracker.WcfContract;
using System.ServiceModel.Description;

namespace TimeTracker.Wcf
{
    class Program
    {
        static void Main(string[] args)
        {

            Program obj = new Program();
            obj.RunServer();
        }

        private void RunServer()
        {
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(WcfService)))
                {
                    try
                    {
                        ServiceDescription serviceDesciption = host.Description;
                        foreach (ServiceEndpoint endpoint in serviceDesciption.Endpoints)
                        {
                            string properties = "";
                            ConsoleColor oldColour = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            properties = "Endpoint - address:  " + endpoint.Address + "\n";
                            properties += "         - binding name:\t\t" + endpoint.Binding.Name + "\n";
                            properties += "         - contract name:\t\t" + endpoint.Contract.Name + "\n";
                            Console.WriteLine("\n" + properties);
                            Console.WriteLine();
                            Console.ForegroundColor = oldColour;
                        }
                        host.Open();
                        Console.WriteLine("Server is running at " + DateTime.Now.ToString());
                        Console.ReadLine();
                        host.Close();
                        Console.WriteLine("Host is closed. Server is shutting down.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Fatal error: \n" + e.Message);
                        try
                        {
                            if (host != null)
                                host.Close();
                        }
                        catch
                        {
                            Console.WriteLine("Fatal error while closing host: \n" + e.Message);
                        }
                        Console.WriteLine("Press Enter to close application");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal error while creating new ServiceHost: \n" + e.Message);
                Console.WriteLine("Press Enter to close application");
                Console.ReadLine();
            }
        }
    }
} 