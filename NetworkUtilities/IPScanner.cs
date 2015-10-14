using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using NetworkUtilities;
using System.Threading.Tasks;

namespace NetworkUtilities
{
    class IPScanner
    {


        static CountdownEvent countdown;
        static int upCount = 0;
        static object lockObj = new object();
        const bool resolveNames = true;

        public static void ScanIPs()
        {


            //string hostName = Dns.GetHostName(); // Retrive the Name of HOST

            //Console.WriteLine(hostName);

            // Get the IP

            //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            string myIP = "192.168.1.1";
            var bytes = IPAddress.Parse(myIP).GetAddressBytes();
            // set the value here
            bytes[3] = 0;



            IPAddress ipAddress = new IPAddress(bytes);
            var IPaddress1 = IPAddress.Parse(myIP).GetAddressBytes()[0].ToString() + "." + IPAddress.Parse(myIP).GetAddressBytes()[1].ToString() + "." + IPAddress.Parse(myIP).GetAddressBytes()[2].ToString() + ".";

            Console.WriteLine("My IP Address is :" + myIP);
            Console.WriteLine("Network :" + IPaddress1);
            //Console.ReadLine();




            countdown = new CountdownEvent(1);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //string ipBase = "10.0.0.";
            for (int i = 1; i < 255; i++)
            {
                string ip = IPaddress1 + i.ToString();

                Ping p = new Ping();
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                countdown.AddCount();
                p.SendAsync(ip, 100, ip);
            }
            countdown.Signal();
            countdown.Wait();
            sw.Stop();
            TimeSpan span = new TimeSpan(sw.ElapsedTicks);
            //Console.WriteLine("Took {0} milliseconds. {1} hosts active.", sw.ElapsedMilliseconds, upCount);
            //Console.WriteLine("\nPress any key to continue...");
            //Console.ReadKey();
        }

        static void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                if (!Computers.comp.Contains(ip))
                {
                    Computers.comp.Add(ip);
                }
                /*if (resolveNames)
                {
                    string name;
                    try
                    {
                        IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                        name = hostEntry.HostName;
                    }
                    catch (SocketException ex)
                    {
                        name = "?";
                    }
                    //Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
                }
                else
                {
                    Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
                }*/
                lock (lockObj)
                {
                    upCount++;
                }
            }
            else if (e.Reply == null)
            {
             //   Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
            }

            countdown.Signal();
        }

        public static async Task<IEnumerable<string>> ScanIPsAsync()
        {
            string baseIP = "192.168.1.";

            var tasks = Enumerable.Range(0, 255).Select(x => new Ping().SendPingAsync(baseIP + x.ToString() , 200));
            var results = await Task.WhenAll(tasks);

            return results
                .Where(x => x.Status == IPStatus.Success)
                .Select(x => x.Address.ToString()).ToList();
        }

    }
}
