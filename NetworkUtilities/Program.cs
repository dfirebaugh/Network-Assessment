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
using System.Text.RegularExpressions;
using System.IO;

namespace NetworkUtilities
{


    class Program
    {
        static void Main(string[] args)
        {




            if (!File.Exists("psexec.exe"))
            {
                Console.WriteLine("\r\n\r\n\r\n\r\npsexec.exe needs to be in the same directory as this executable...\r\n\r\n");
            }

            else
            {

            Console.WriteLine("Scanning Network");

                        IPScanner.Scanner();
                        //IPScanner.Scanner();
                        IPScanner.PrintNetwork();
                        Console.WriteLine("\n");



            /*   
                  System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                  //pProcess.StartInfo.Domain = "domain";
                  //pProcess.StartInfo.UserName = "user with priv";
                  //pProcess.StartInfo.Password = new System.Security.SecureString();
                  //char[] pass = textBox3.Text.ToArray();
                  //for (int x = 0; x < pass.Length; ++x)
                  //{
                  //    pProcess.StartInfo.Password.AppendChar(pass[x]);
                  //}
                  //
                  var ip = "127.0.0.1";
                  //var ip = "10.0.0.151";
                  pProcess.StartInfo.FileName = @"psexec.exe";
                  pProcess.StartInfo.Arguments = string.Format(@"\\{0} netstat -anb", ip );
                  pProcess.StartInfo.UseShellExecute = false;
                  pProcess.StartInfo.RedirectStandardInput = true;
                  pProcess.StartInfo.RedirectStandardOutput = true;
                  pProcess.StartInfo.RedirectStandardError = true;
                  pProcess.Start();
                  pProcess.WaitForExit(30000);
                  if (!pProcess.HasExited)
                  {
                      pProcess.Kill();
                  }

                  string strOutput = pProcess.StandardOutput.ReadToEnd();
                  string errOutput = pProcess.StandardError.ReadToEnd();
                  Console.WriteLine(errOutput);



                  string[] netstat = strOutput.Split('\n');
                  //Console.WriteLine(netstat[1]);
                  IDictionary<string, string> ports = new Dictionary<string, string>();
                  for(var x = 0;x<netstat.Length; x++)
                  {
                      if (netstat[x].Contains("LISTENING"))
                      {
                          if (netstat[x].Contains("]:"))
                          {
                              int startIndex = netstat[x].IndexOf(']');
                              int endIndex = netstat[x].Length;
                              int spaceIndex = netstat[x].Substring(startIndex, endIndex - startIndex - 1).IndexOf(" ");
                              var port = netstat[x].Substring(startIndex + 2, spaceIndex);
                              //Console.WriteLine("TCPv6 " + port);

                              if (netstat[x + 1].Contains("["))
                              {
                                  ports[port] = netstat[x + 1];
                                  //Console.WriteLine(netstat[x + 1]);


                              }
                              else if (netstat[x + 2].Contains("[svchost.exe"))
                              {
                                  ports[port] = netstat[x + 1];
                                  //Console.WriteLine(netstat[x + 1]);
                                  //Console.WriteLine(netstat[x+2]);
                              }

                              //Console.WriteLine(netstat[x]);
                          }
                          else
                          {
                              int startIndex = netstat[x].IndexOf(':');
                              int endIndex = netstat[x].Length;
                              int spaceIndex = netstat[x].Substring(startIndex, endIndex - startIndex - 1).IndexOf(" ");
                              var port = netstat[x].Substring(startIndex + 1, spaceIndex);
                              //Console.WriteLine("TCPv4 " + port);


                              if (netstat[x + 1].Contains("["))
                              {
                                  ports[port] = netstat[x + 1];
                                  //Console.WriteLine(netstat[x + 1]);


                              }
                              else if (netstat[x + 2].Contains("[svchost.exe"))
                              {
                                  ports[port] = netstat[x + 1];
                                  //Console.WriteLine(netstat[x + 1]);
                                  //Console.WriteLine(netstat[x+2]);
                              }
                              //Console.WriteLine(netstat[x]);
                          }





                          //Console.WriteLine(netstat[x]);




                      }

                  }
                  int count = 0;

                  Console.WriteLine(count + " LISTENING ports");

                  PortScanner.SetListeningPortList(ports);
                  PortScanner.Scan(ip, ports);




                  Console.WriteLine("\n");

                  foreach (var item in ports.Keys)
                  {
                      //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                      //Console.WriteLine(string.Format("{0} = {1}", kvp.Key, kvp.Value));
                      count++;

                  }



                  foreach (KeyValuePair<string,string> kvp in ports)
                  {

                      for (int x = 0; x< PortScanner.openPorts.Count;x++) 
                      //int port in PortScanner.openPorts)
                      {

                          string openPortValueString = PortScanner.openPorts[x].ToString();
                          string processKey = kvp.Key.Trim();

                          //ports.TryGetValue(port.ToString(), out value);


                          if(processKey.Equals(openPortValueString))
                          {
                              Console.WriteLine("PORT " + PortScanner.openPorts[x] + " is open, listening, and running " + kvp.Value);
                          }





                          //Console.WriteLine(port + " Open");
                      }

                  }


                  //List<int> openPorts = new List<int>();

                  PortScanner.openPorts.Clear();











                  //Console.ReadLine();
                  */

            //foreach(KeyValuePair<string, string> ip in IPScanner.strings)
            foreach (string ip in IPScanner.comp)
            {

                Console.WriteLine("\n\n\n\n");
                //Console.WriteLine("Hello");
                //Console.WriteLine(ip.Key);

                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                //pProcess.StartInfo.Domain = "domain";
                //pProcess.StartInfo.UserName = "user with priv";
                //pProcess.StartInfo.Password = new System.Security.SecureString();
                //char[] pass = textBox3.Text.ToArray();
                //for (int x = 0; x < pass.Length; ++x)
                //{
                //    pProcess.StartInfo.Password.AppendChar(pass[x]);
                //}
                //
                //var ip = "127.0.0.1";
                //var ip = "10.0.0.151";
                pProcess.StartInfo.FileName = @"psexec.exe";
                pProcess.StartInfo.Arguments = string.Format(@"\\{0} netstat -anb", ip);
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardInput = true;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.RedirectStandardError = true;
                pProcess.Start();
                pProcess.WaitForExit(30000);
                if (!pProcess.HasExited)
                {
                    pProcess.Kill();
                }

                string strOutput = pProcess.StandardOutput.ReadToEnd();
                string errOutput = pProcess.StandardError.ReadToEnd();
                Console.WriteLine(errOutput);








                Console.WriteLine("\n");
                    /*
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
                    Console.WriteLine(name);
                    */







                    if (strOutput != "")
                    {

                    

                string[] netstat = strOutput.Split('\n');
                //Console.WriteLine(netstat[1]);
                IDictionary<string, string> ports = new Dictionary<string, string>();
                for (var x = 0; x < netstat.Length; x++)
                {
                    if (netstat[x].Contains("LISTENING"))
                    {
                        if (netstat[x].Contains("]:"))
                        {
                            int startIndex = netstat[x].IndexOf(']');
                            int endIndex = netstat[x].Length;
                            int spaceIndex = netstat[x].Substring(startIndex, endIndex - startIndex - 1).IndexOf(" ");
                            var port = netstat[x].Substring(startIndex + 2, spaceIndex);
                            //Console.WriteLine("TCPv6 " + port);

                            if (netstat[x + 1].Contains("["))
                            {
                                ports[port] = netstat[x + 1];
                                //Console.WriteLine(netstat[x + 1]);


                            }
                            else if (netstat[x + 2].Contains("[svchost.exe"))
                            {
                                ports[port] = netstat[x + 1];
                                //Console.WriteLine(netstat[x + 1]);
                                //Console.WriteLine(netstat[x+2]);
                            }

                            //Console.WriteLine(netstat[x]);
                        }
                        else
                        {
                            int startIndex = netstat[x].IndexOf(':');
                            int endIndex = netstat[x].Length;
                            int spaceIndex = netstat[x].Substring(startIndex, endIndex - startIndex - 1).IndexOf(" ");
                            var port = netstat[x].Substring(startIndex + 1, spaceIndex);
                            //Console.WriteLine("TCPv4 " + port);


                            if (netstat[x + 1].Contains("["))
                            {
                                ports[port] = netstat[x + 1];
                                //Console.WriteLine(netstat[x + 1]);


                            }
                            else if (netstat[x + 2].Contains("[svchost.exe"))
                            {
                                ports[port] = netstat[x + 1];
                                //Console.WriteLine(netstat[x + 1]);
                                //Console.WriteLine(netstat[x+2]);
                            }
                            //Console.WriteLine(netstat[x]);
                        }





                        //Console.WriteLine(netstat[x]);




                    }

                }
                int count = 0;

                //Console.WriteLine(count + " LISTENING ports");

                PortScanner.SetListeningPortList(ports);
                PortScanner.Scan(ip, ports);




                Console.WriteLine("\n");

                foreach (var item in ports.Keys)
                {
                    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    //Console.WriteLine(string.Format("{0} = {1}", kvp.Key, kvp.Value));
                    count++;

                }

                //                string[] lines = {};
                // WriteAllLines creates a file, writes a collection of strings to the file,
                // and then closes the file.  You do NOT need to call Flush() or Close().

                using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"Output.txt", true))
                {
                    file.WriteLine("\r\n\r\n" + ip);
                    file.WriteLine("The Following Ports are open and listening \r\n");
                    file.WriteLine("Port           Process/Service \r\n==============================");
                }


                Console.WriteLine("\r\n\r\n" + ip);
                Console.WriteLine("The Following Ports are open and listening \r\n");
                Console.WriteLine("Port           Process/Service \r\n==============================");


                foreach (KeyValuePair<string, string> kvp in ports)
                {

                    for (int x = 0; x < PortScanner.openPorts.Count; x++)
                    //int port in PortScanner.openPorts)
                    {

                        string openPortValueString = PortScanner.openPorts[x].ToString();
                        string processKey = kvp.Key.Trim();

                        //ports.TryGetValue(port.ToString(), out value);

                        var line = "";


                        if (processKey.Equals(openPortValueString))
                        {
                            Console.WriteLine(PortScanner.openPorts[x] + "          " + kvp.Value);
                            line = PortScanner.openPorts[x] + "          " + kvp.Value;
                            using (System.IO.StreamWriter file =
                                new System.IO.StreamWriter(@"Output.txt", true))
                            { 
                                file.WriteLine(line);
                            }
                        }
                        }





                        //Console.WriteLine(port + " Open");
                    }

                }
//                System.IO.File.WriteAllLines(@"WriteLines.txt", lines);


                //List<int> openPorts = new List<int>();

                PortScanner.openPorts.Clear();

            }
            
            Console.ReadLine();
        }
        }

    }
}
