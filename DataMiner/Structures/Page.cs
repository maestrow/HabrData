using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMiner.Domain;

namespace DataMiner.Structures
{
    internal class Page
    {
        IEnumerable<Post> Pages { get; set; }
    }
}
