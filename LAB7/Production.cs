using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7;

class Production
{
    public string id { get; set; } 
    public string companyName { get; set; }

    public Production() : this("", "") { }
    public Production(string id, string name)
    {
        this.id = id;
        this.companyName = name;
    }
}
