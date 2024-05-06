using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Binding;

public class UserDataContext
{
    public List<User> Users { get; set; }

	public UserDataContext()
	{
		Users = new List<User>();
		Users.Add(new User("Ivan", 2));
	}
}
