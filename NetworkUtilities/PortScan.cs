using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NetworkUtilities;

namespace NetworkUtilities
{
    public class PortScanner
    {
        public static List<int> openPorts = new List<int>();
        public static IEnumerable<int> Scan(string ip, IDictionary<string, string> ports)
        {
            openPorts.Clear();

            //for (int port = startPort; port <= endPort; port++)
            foreach(KeyValuePair<string, string> kvp in ports)
            {
               // Console.WriteLine(string.Format("Scanning port {0}", kvp.Key));
                //Socket scanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                //IPAddress ipaddress = IPAddress.Parse(ip);
               
                try
                {
                    if (PingHost(ip, int.Parse(kvp.Key)))
                    {
                        //Console.WriteLine(string.Format("ping successful: {0}", kvp.Key));
                        openPorts.Add(int.Parse(kvp.Key));
                    }


                    //scanSocket.BeginConnect(new IPEndPoint(ipaddress, int.Parse(kvp.Key)), ScanCallBack, new ArrayList() { scanSocket, kvp.Key });
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    //bury exception since it means we could not connect to the port
                }

                //Console.WriteLine(string.Format("END Scanning port {0}", kvp.Key));
            }
            return openPorts;
        }

        public static bool PingHost(string _HostURI, int _PortNumber)
        {
            //Console.WriteLine(string.Format("pinging port {0}", _PortNumber));
            try
            {
                TcpClient client = new TcpClient(_HostURI, _PortNumber);
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error pinging host:'" + _HostURI + ":" + _PortNumber.ToString() + "'");
                return false;
            }
        }


        /*public static void ScanCallBack(IAsyncResult result)
        {
            //List<int> openPorts = new List<int>();
            //Console.WriteLine("inside scan callback");

            /*IDictionary<int, bool> PortStatus = new Dictionary<int, bool>();


            ArrayList arrList = (ArrayList)result.AsyncState;
            Socket scanSocket = (Socket)arrList[0];

            int port = (int.Parse((string)arrList[1]));
            //  

            if (result.IsCompleted && scanSocket.Connected)
            {
                //Console.WriteLine("{0,5}\t", port);
                openPorts.Add(port);
                PortStatus[port] = true;
                //Console.WriteLine(port + " open" );


            }
            else
            {
                PortStatus[port] = false;
                // Console.WriteLine(port + " Closed");
            }


            
            scanSocket.Close();

            DiffPortList(PortStatus,ListeningPortList);

        }*/
        
        private static IDictionary<string, string> ListeningPortList = null;

        public static void SetListeningPortList(IDictionary<string, string> list)
        {
            ListeningPortList = list;
        }
        
        private static void DiffPortList(IDictionary<int,bool> status,IDictionary<string,string> listening)
        {
            //Console.WriteLine("listen.count " + listening.Count);
           // Console.WriteLine("===================");
            //if (status.Count == listening.Count)
            //{
                foreach (int port in openPorts)
                {
    
                    
                    
                        Console.WriteLine("PORT " + port+" is open, listening, and running " + listening[port.ToString()]);
                    
                    

                   //Console.WriteLine(port + " Open");
                }
            //}
        }
    }
}