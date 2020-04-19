using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace HostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(RatingServiceLibrary.Service1)))
            {
                host.Open();
                Console.WriteLine("Host started at " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
