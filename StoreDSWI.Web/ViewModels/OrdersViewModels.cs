using StoreDSWI.Entities;
using StoreDSWI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreDSWI.Web.ViewModels
{
    public class OrdersViewModels
    {
        public List<Order> Orders { get; set; }
        public string UserID { get; set; }
        public Pager Pager { get; set; }
        public string Status { get; set; }
    }

    public class OrderDetailsViewModels
    {
        public Order Order { get; set; }
        public StoreDSWIUser OrderBy { get; set; }
        public List<string> AvailableStatuses { get; set; }
    }
}