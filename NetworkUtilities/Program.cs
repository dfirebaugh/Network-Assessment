using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkUtilties;

namespace NetworkUtilities
{
    class Program
    {
        //public static IDictionary<string, Computers> comp = new Dictionary<string, Computers>();

        static void Main(string[] args)
        {
            //var ipAddresses = IPScanner.ScanIPs();
            IPScanner.ScanIPs();

            foreach (string ip in Computers.comp)
            {
                Console.WriteLine(ip);
                var ports = PortScanner.Scan(ip, 0, 9999);
                
                
                foreach (var port in ports)
                {

                   //Console.WriteLine(ports);
                    
                    Console.WriteLine(string.Format("          open: {0}", port.ToString()));
                }
            }

            /*foreach (string ip in ipAddresses)
            {
                Console.WriteLine(string.Format("Responded with IP: {0}.", ip));
                //scan Ports
                var ports = PortScanner.Scan(ip, 0, 100);
                foreach (var port in ports)
                {
                    Console.WriteLine(string.Format("Found open port: {0}", port.ToString()));
                }
            }*/

            Console.WriteLine("Scan Complete.");
            Console.ReadKey();
        }
    }
}
