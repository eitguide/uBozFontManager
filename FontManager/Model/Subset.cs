using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharpNghia
{
    public class Subset
    {
        public string start { get; set; }
        public string end { get; set; }
        public string name { get; set; }

        public Subset()
        {

        }

        public Subset(string start, string end, string name)
        {
            this.start = start;
            this.end = end;
            this.name = name;
        }
    }

    
}
