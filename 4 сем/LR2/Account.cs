using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2;

[Serializable]
public class Account
{
    public int Number { get; set; }
    public string DepositeType { get; set; }
    public double Balance { get; set; }
    public DateTime FoundationDate { get; set; }
    public Owner _Owner { get; set; }
    public bool InternetBanking { get; set; }
    public bool SMSNotify { get; set; }

    public Account(int number, string depositeType, double balance, DateTime foundationDate, Owner owner, bool internetBanking, bool smsNotify)
    {
        Number = number;
        DepositeType = depositeType;
        Balance = balance;
        FoundationDate = foundationDate;
        _Owner = owner;
        InternetBanking = internetBanking;
        SMSNotify = smsNotify;
    }

    public Account()
    {
        Number = 0;
        DepositeType = "unknown";
        Balance = 0;
        FoundationDate = new DateTime(1, 1, 1);
        _Owner = new Owner();
        InternetBanking = false;
        SMSNotify = false;
    }
}
