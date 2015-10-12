using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtilities
{
    
    //public static IDictionary<string, Computers> comp = new Dictionary<string, Computers>();

    public class Computers
    {
        public static IDictionary<string, List<int>> comp1 = new Dictionary<string, List<int>>();
        public static List<string> comp = new List<string>();
        

        public string IP { get; set; }
        public List<int> OpenPort { get; set; }

        public Computers()
        {
            OpenPort = new List<int>();
        }
    }
}