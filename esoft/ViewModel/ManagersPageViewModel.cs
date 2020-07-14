using esoft.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace esoft.ViewModel
{
    class ManagersPageViewModel : BaseViewModel
    {
        public List<Manager> Managers { 
            get { return Database.DatabaseManager.GetUsersWithType<Manager>(); }
        }
    }
}
