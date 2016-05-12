using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkUtilities;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace NetworkUtilities
{
    class IPScanner
    {


        static CountdownEvent countdown;
        static int upCount = 0;
        static object lockObj = new object();
        const bool resolveNames = false;
        public static IDictionary<string, string> strings = new Dictionary<string, string>();
        public static List<string> comp = new List<string>();

        public static void Scanner()
        {

            

            //Get's preferred outbound IP address
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("10.0.2.4", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            //Console.WriteLine(localIP);


            var bytes = IPAddress.Parse(localIP).GetAddressBytes();
            bytes[3] = 0;

            IPAddress ipAddress = new IPAddress(bytes);
            var IPaddress1 = IPAddress.Parse(localIP).GetAddressBytes()[0].ToString() + "." + IPAddress.Parse(localIP).GetAddressBytes()[1].ToString() + "." + IPAddress.Parse(localIP).GetAddressBytes()[2].ToString() + ".";

            // Console.WriteLine(bytes);
            //Console.WriteLine(ipAddress);
            //Console.WriteLine(IPaddress1);
            //Console.ReadLine();
            //Console.WriteLine("Scanning Network");








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






            var list = strings.Keys.ToList();
            list.Sort();

        }
        static void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            //Dictionary<string, int> d = new Dictionary<string, int>();
            
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                if (comp.Contains(ip))
                {
                    comp.Add(ip);
                }
                
                if (resolveNames)
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
                    //comp[ip] = name;//.Add(ip,name);
                    comp.Add(ip);

                }
                else
                {
                    //Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
                    //comp[ip] = "?";// strings.Add(ip,"?");
                    comp.Add(ip);
                }
                lock (lockObj)
                {
                    upCount++;
                }
            }
            else if (e.Reply == null)
            {
               // Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
            }
            //Console.WriteLine(d);
            
            countdown.Signal();

        }
        public static void PrintNetwork()
        {

            int count = 0 ;

            foreach (string ip in comp)
            {
                count++;
                Console.WriteLine(string.Format("{0} \n", ip));
            }
                /*
                foreach (KeyValuePair<string, string> kvp in strings)
                {
                    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    Console.WriteLine(string.Format("{0} = {1}", kvp.Key, kvp.Value));
                    count++;
                }*/
                Console.WriteLine(count + " alive");
        }

}
}
