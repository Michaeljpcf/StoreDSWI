using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StoreDSWI.Services;
using StoreDSWI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreDSWI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class OrderController : Controller
    {
        private StoreDSWISignInManager _signInManager;
        private StoreDSWIUserManager _userManager;

        public StoreDSWISignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<StoreDSWISignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public StoreDSWIUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<StoreDSWIUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        // GET: Order
        public ActionResult Index(string userID, string status, int? pageNo)
        {
            OrdersViewModels model = new OrdersViewModels();
            model.UserID = userID;
            model.Status = status;

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            var pageSize = ConfigurationsService.Instance.PageSize();

            model.Orders = OrdersService.Instance.SearchOrders(userID, status, pageNo.Value, pageSize);
            var totalRecords = OrdersService.Instance.SearchOrdersCount(userID, status);

            model.Pager = new Pager(totalRecords, pageNo, pageSize);

            return View(model);
        }

        public ActionResult Details(int ID)
        {
            OrderDetailsViewModels model = new OrderDetailsViewModels();

            model.Order = OrdersService.Instance.GetOrderByID(ID);

            if (model.Order != null)
            {
                model.OrderBy = UserManager.FindById(model.Order.UserID);
            }

            model.AvailableStatuses = new List<string>() { "Pendiente", "Enviado", "Entregado" };

            return View(model);
        }

        public JsonResult ChangeStatus(string status, int ID)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            result.Data = new { Success = OrdersService.Instance.UpdateOrderStatus(ID, status) };

            return result;
        }
    }
}