using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using BLC;
[Route("api/[controller]")]
[ApiController]
public partial class DataController : ControllerBase
{
    #region Members
    #endregion
    #region Extract_Ticket
    private string Extract_Ticket()
    {
        #region Declaration And Initialization Section.
        string str_Ticket = string.Empty;
        #endregion
        if (HttpContext.Request.Query["Ticket"].FirstOrDefault() != null)
        {
            str_Ticket = HttpContext.Request.Query["Ticket"].ToString();
        }
        #region Return Section.
        return str_Ticket;
        #endregion
    }
    #endregion
    #region IsValidWebTicket
    private bool IsValidWebTicket(string i_Input)
    {
        #region Declaration And Initialization Section.
        bool Is_Valid = false;
        BLCInitializer oBLCInitializer = new BLCInitializer();
        #endregion
        #region Body Section.
        BLC.BLC oBLC_Default = new BLC.BLC();
        oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
        using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
        {
            Is_Valid = oBLC.IsValidTicket(i_Input);
        }
        #endregion
        #region Return Section.
        return Is_Valid;
        #endregion
    }
    #endregion
    #region Authenticate
    [HttpPost]
    [Route("Authenticate")]
    public Result_Authenticate Authenticate(Params_Authenticate i_Params_Authenticate)
    {
        #region Declaration And Initialization Section.
        UserInfo oReturnValue = new UserInfo();
        string i_Ticket = string.Empty;
        Result_Authenticate oResult_Authenticate = new Result_Authenticate();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = new BLCInitializer();
            oBLCInitializer.UserID = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
            oBLCInitializer.OwnerID = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
            oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
            oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Authenticate(i_Params_Authenticate);
                oResult_Authenticate.My_Result = oReturnValue;
                oResult_Authenticate.My_Params_Authenticate = i_Params_Authenticate;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Authenticate.ExceptionMsg = string.Format("Authenticate : {0}", ex.Message);
            }
            else
            {
                oResult_Authenticate.ExceptionMsg = ex.Message;
                oResult_Authenticate.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Authenticate;
        #endregion
    }
    #endregion
    #region Delete_Category
    [HttpPost]
    [Route("Delete_Category")]
    public Result_Delete_Category Delete_Category(Params_Delete_Category i_Params_Delete_Category)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Delete_Category oResult_Delete_Category = new Result_Delete_Category();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Delete_Category);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Delete_Category(i_Params_Delete_Category);
                oResult_Delete_Category.My_Params_Delete_Category = i_Params_Delete_Category;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Delete_Category.ExceptionMsg = string.Format("Delete_Category : {0}", ex.Message);
            }
            else
            {
                oResult_Delete_Category.ExceptionMsg = ex.Message;
                oResult_Delete_Category.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Delete_Category;
        #endregion
    }
    #endregion
    #region Delete_Forgot_password
    [HttpPost]
    [Route("Delete_Forgot_password")]
    public Result_Delete_Forgot_password Delete_Forgot_password(Params_Delete_Forgot_password i_Params_Delete_Forgot_password)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Delete_Forgot_password oResult_Delete_Forgot_password = new Result_Delete_Forgot_password();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Delete_Forgot_password);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Delete_Forgot_password(i_Params_Delete_Forgot_password);
                oResult_Delete_Forgot_password.My_Params_Delete_Forgot_password = i_Params_Delete_Forgot_password;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Delete_Forgot_password.ExceptionMsg = string.Format("Delete_Forgot_password : {0}", ex.Message);
            }
            else
            {
                oResult_Delete_Forgot_password.ExceptionMsg = ex.Message;
                oResult_Delete_Forgot_password.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Delete_Forgot_password;
        #endregion
    }
    #endregion
    #region Delete_Product
    [HttpPost]
    [Route("Delete_Product")]
    public Result_Delete_Product Delete_Product(Params_Delete_Product i_Params_Delete_Product)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Delete_Product oResult_Delete_Product = new Result_Delete_Product();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Delete_Product);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Delete_Product(i_Params_Delete_Product);
                oResult_Delete_Product.My_Params_Delete_Product = i_Params_Delete_Product;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Delete_Product.ExceptionMsg = string.Format("Delete_Product : {0}", ex.Message);
            }
            else
            {
                oResult_Delete_Product.ExceptionMsg = ex.Message;
                oResult_Delete_Product.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Delete_Product;
        #endregion
    }
    #endregion
    #region Delete_User
    [HttpPost]
    [Route("Delete_User")]
    public Result_Delete_User Delete_User(Params_Delete_User i_Params_Delete_User)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Delete_User oResult_Delete_User = new Result_Delete_User();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Delete_User);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Delete_User(i_Params_Delete_User);
                oResult_Delete_User.My_Params_Delete_User = i_Params_Delete_User;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Delete_User.ExceptionMsg = string.Format("Delete_User : {0}", ex.Message);
            }
            else
            {
                oResult_Delete_User.ExceptionMsg = ex.Message;
                oResult_Delete_User.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Delete_User;
        #endregion
    }
    #endregion
    #region Edit_Category
    [HttpPost]
    [Route("Edit_Category")]
    public Result_Edit_Category Edit_Category(Category i_Category)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Category oResult_Edit_Category = new Result_Edit_Category();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Category);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Category(i_Category);
                oResult_Edit_Category.My_Category = i_Category;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Category.ExceptionMsg = string.Format("Edit_Category : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Category.ExceptionMsg = ex.Message;
                oResult_Edit_Category.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Category;
        #endregion
    }
    #endregion
    #region Edit_Forgot_password
    [HttpPost]
    [Route("Edit_Forgot_password")]
    public Result_Edit_Forgot_password Edit_Forgot_password(Forgot_password i_Forgot_password)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Forgot_password oResult_Edit_Forgot_password = new Result_Edit_Forgot_password();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Forgot_password);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Forgot_password(i_Forgot_password);
                oResult_Edit_Forgot_password.My_Forgot_password = i_Forgot_password;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Forgot_password.ExceptionMsg = string.Format("Edit_Forgot_password : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Forgot_password.ExceptionMsg = ex.Message;
                oResult_Edit_Forgot_password.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Forgot_password;
        #endregion
    }
    #endregion
    #region Edit_Menu_customization
    [HttpPost]
    [Route("Edit_Menu_customization")]
    public Result_Edit_Menu_customization Edit_Menu_customization(Menu_customization i_Menu_customization)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Menu_customization oResult_Edit_Menu_customization = new Result_Edit_Menu_customization();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Menu_customization);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Menu_customization(i_Menu_customization);
                oResult_Edit_Menu_customization.My_Menu_customization = i_Menu_customization;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Menu_customization.ExceptionMsg = string.Format("Edit_Menu_customization : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Menu_customization.ExceptionMsg = ex.Message;
                oResult_Edit_Menu_customization.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Menu_customization;
        #endregion
    }
    #endregion
    #region Edit_Order
    [HttpPost]
    [Route("Edit_Order")]
    public Result_Edit_Order Edit_Order(Order i_Order)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Order oResult_Edit_Order = new Result_Edit_Order();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Order);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Order(i_Order);
                oResult_Edit_Order.My_Order = i_Order;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Order.ExceptionMsg = string.Format("Edit_Order : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Order.ExceptionMsg = ex.Message;
                oResult_Edit_Order.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Order;
        #endregion
    }
    #endregion
    #region Edit_Order_details
    [HttpPost]
    [Route("Edit_Order_details")]
    public Result_Edit_Order_details Edit_Order_details(Order_details i_Order_details)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Order_details oResult_Edit_Order_details = new Result_Edit_Order_details();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Order_details);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Order_details(i_Order_details);
                oResult_Edit_Order_details.My_Order_details = i_Order_details;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Order_details.ExceptionMsg = string.Format("Edit_Order_details : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Order_details.ExceptionMsg = ex.Message;
                oResult_Edit_Order_details.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Order_details;
        #endregion
    }
    #endregion
    #region Edit_Order_details_items
    [HttpPost]
    [Route("Edit_Order_details_items")]
    public Result_Edit_Order_details_items Edit_Order_details_items(Order_details_items i_Order_details_items)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Order_details_items oResult_Edit_Order_details_items = new Result_Edit_Order_details_items();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Order_details_items);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Order_details_items(i_Order_details_items);
                oResult_Edit_Order_details_items.My_Order_details_items = i_Order_details_items;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Order_details_items.ExceptionMsg = string.Format("Edit_Order_details_items : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Order_details_items.ExceptionMsg = ex.Message;
                oResult_Edit_Order_details_items.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Order_details_items;
        #endregion
    }
    #endregion
    #region Edit_Owner
    [HttpPost]
    [Route("Edit_Owner")]
    public Result_Edit_Owner Edit_Owner(Owner i_Owner)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Owner oResult_Edit_Owner = new Result_Edit_Owner();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Owner);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Owner(i_Owner);
                oResult_Edit_Owner.My_Owner = i_Owner;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Owner.ExceptionMsg = string.Format("Edit_Owner : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Owner.ExceptionMsg = ex.Message;
                oResult_Edit_Owner.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Owner;
        #endregion
    }
    #endregion
    #region Edit_Payment
    [HttpPost]
    [Route("Edit_Payment")]
    public Result_Edit_Payment Edit_Payment(Payment i_Payment)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Payment oResult_Edit_Payment = new Result_Edit_Payment();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Payment);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Payment(i_Payment);
                oResult_Edit_Payment.My_Payment = i_Payment;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Payment.ExceptionMsg = string.Format("Edit_Payment : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Payment.ExceptionMsg = ex.Message;
                oResult_Edit_Payment.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Payment;
        #endregion
    }
    #endregion
    #region Edit_Product
    [HttpPost]
    [Route("Edit_Product")]
    public Result_Edit_Product Edit_Product(Product i_Product)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Product oResult_Edit_Product = new Result_Edit_Product();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Product);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Product(i_Product);
                oResult_Edit_Product.My_Product = i_Product;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Product.ExceptionMsg = string.Format("Edit_Product : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Product.ExceptionMsg = ex.Message;
                oResult_Edit_Product.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Product;
        #endregion
    }
    #endregion
    #region Edit_Restaurant_details
    [HttpPost]
    [Route("Edit_Restaurant_details")]
    public Result_Edit_Restaurant_details Edit_Restaurant_details(Restaurant_details i_Restaurant_details)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Restaurant_details oResult_Edit_Restaurant_details = new Result_Edit_Restaurant_details();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Restaurant_details);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Restaurant_details(i_Restaurant_details);
                oResult_Edit_Restaurant_details.My_Restaurant_details = i_Restaurant_details;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Restaurant_details.ExceptionMsg = string.Format("Edit_Restaurant_details : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Restaurant_details.ExceptionMsg = ex.Message;
                oResult_Edit_Restaurant_details.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Restaurant_details;
        #endregion
    }
    #endregion
    #region Edit_Restaurant_views
    [HttpPost]
    [Route("Edit_Restaurant_views")]
    public Result_Edit_Restaurant_views Edit_Restaurant_views(Restaurant_views i_Restaurant_views)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Restaurant_views oResult_Edit_Restaurant_views = new Result_Edit_Restaurant_views();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Restaurant_views);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Restaurant_views(i_Restaurant_views);
                oResult_Edit_Restaurant_views.My_Restaurant_views = i_Restaurant_views;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Restaurant_views.ExceptionMsg = string.Format("Edit_Restaurant_views : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Restaurant_views.ExceptionMsg = ex.Message;
                oResult_Edit_Restaurant_views.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Restaurant_views;
        #endregion
    }
    #endregion
    #region Edit_Timing
    [HttpPost]
    [Route("Edit_Timing")]
    public Result_Edit_Timing Edit_Timing(Timing i_Timing)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_Timing oResult_Edit_Timing = new Result_Edit_Timing();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_Timing);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_Timing(i_Timing);
                oResult_Edit_Timing.My_Timing = i_Timing;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_Timing.ExceptionMsg = string.Format("Edit_Timing : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_Timing.ExceptionMsg = ex.Message;
                oResult_Edit_Timing.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_Timing;
        #endregion
    }
    #endregion
    #region Edit_User
    [HttpPost]
    [Route("Edit_User")]
    public Result_Edit_User Edit_User(User i_User)
    {
        #region Declaration And Initialization Section.
        string i_Ticket = string.Empty;
        Result_Edit_User oResult_Edit_User = new Result_Edit_User();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Edit_User);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oBLC.Edit_User(i_User);
                oResult_Edit_User.My_User = i_User;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Edit_User.ExceptionMsg = string.Format("Edit_User : {0}", ex.Message);
            }
            else
            {
                oResult_Edit_User.ExceptionMsg = ex.Message;
                oResult_Edit_User.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Edit_User;
        #endregion
    }
    #endregion
    #region Get_Category_By_CATEGORY_ID
    [HttpPost]
    [Route("Get_Category_By_CATEGORY_ID")]
    public Result_Get_Category_By_CATEGORY_ID Get_Category_By_CATEGORY_ID(Params_Get_Category_By_CATEGORY_ID i_Params_Get_Category_By_CATEGORY_ID)
    {
        #region Declaration And Initialization Section.
        Category oReturnValue = new Category();
        string i_Ticket = string.Empty;
        Result_Get_Category_By_CATEGORY_ID oResult_Get_Category_By_CATEGORY_ID = new Result_Get_Category_By_CATEGORY_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Category_By_CATEGORY_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Category_By_CATEGORY_ID(i_Params_Get_Category_By_CATEGORY_ID);
                oResult_Get_Category_By_CATEGORY_ID.My_Result = oReturnValue;
                oResult_Get_Category_By_CATEGORY_ID.My_Params_Get_Category_By_CATEGORY_ID = i_Params_Get_Category_By_CATEGORY_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Category_By_CATEGORY_ID.ExceptionMsg = string.Format("Get_Category_By_CATEGORY_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Category_By_CATEGORY_ID.ExceptionMsg = ex.Message;
                oResult_Get_Category_By_CATEGORY_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Category_By_CATEGORY_ID;
        #endregion
    }
    #endregion
    #region Get_Category_By_OWNER_ID
    [HttpPost]
    [Route("Get_Category_By_OWNER_ID")]
    public Result_Get_Category_By_OWNER_ID Get_Category_By_OWNER_ID(Params_Get_Category_By_OWNER_ID i_Params_Get_Category_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Category> oReturnValue = new List<Category>();
        string i_Ticket = string.Empty;
        Result_Get_Category_By_OWNER_ID oResult_Get_Category_By_OWNER_ID = new Result_Get_Category_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Category_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Category_By_OWNER_ID(i_Params_Get_Category_By_OWNER_ID);
                oResult_Get_Category_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Category_By_OWNER_ID.My_Params_Get_Category_By_OWNER_ID = i_Params_Get_Category_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Category_By_OWNER_ID.ExceptionMsg = string.Format("Get_Category_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Category_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Category_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Category_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Forgot_password_By_FORGOT_PASSWORD_ID
    [HttpPost]
    [Route("Get_Forgot_password_By_FORGOT_PASSWORD_ID")]
    public Result_Get_Forgot_password_By_FORGOT_PASSWORD_ID Get_Forgot_password_By_FORGOT_PASSWORD_ID(Params_Get_Forgot_password_By_FORGOT_PASSWORD_ID i_Params_Get_Forgot_password_By_FORGOT_PASSWORD_ID)
    {
        #region Declaration And Initialization Section.
        Forgot_password oReturnValue = new Forgot_password();
        string i_Ticket = string.Empty;
        Result_Get_Forgot_password_By_FORGOT_PASSWORD_ID oResult_Get_Forgot_password_By_FORGOT_PASSWORD_ID = new Result_Get_Forgot_password_By_FORGOT_PASSWORD_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Forgot_password_By_FORGOT_PASSWORD_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Forgot_password_By_FORGOT_PASSWORD_ID(i_Params_Get_Forgot_password_By_FORGOT_PASSWORD_ID);
                oResult_Get_Forgot_password_By_FORGOT_PASSWORD_ID.My_Result = oReturnValue;
                oResult_Get_Forgot_password_By_FORGOT_PASSWORD_ID.My_Params_Get_Forgot_password_By_FORGOT_PASSWORD_ID = i_Params_Get_Forgot_password_By_FORGOT_PASSWORD_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Forgot_password_By_FORGOT_PASSWORD_ID.ExceptionMsg = string.Format("Get_Forgot_password_By_FORGOT_PASSWORD_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Forgot_password_By_FORGOT_PASSWORD_ID.ExceptionMsg = ex.Message;
                oResult_Get_Forgot_password_By_FORGOT_PASSWORD_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Forgot_password_By_FORGOT_PASSWORD_ID;
        #endregion
    }
    #endregion
    #region Get_Forgot_password_By_OWNER_ID
    [HttpPost]
    [Route("Get_Forgot_password_By_OWNER_ID")]
    public Result_Get_Forgot_password_By_OWNER_ID Get_Forgot_password_By_OWNER_ID(Params_Get_Forgot_password_By_OWNER_ID i_Params_Get_Forgot_password_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Forgot_password> oReturnValue = new List<Forgot_password>();
        string i_Ticket = string.Empty;
        Result_Get_Forgot_password_By_OWNER_ID oResult_Get_Forgot_password_By_OWNER_ID = new Result_Get_Forgot_password_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Forgot_password_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Forgot_password_By_OWNER_ID(i_Params_Get_Forgot_password_By_OWNER_ID);
                oResult_Get_Forgot_password_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Forgot_password_By_OWNER_ID.My_Params_Get_Forgot_password_By_OWNER_ID = i_Params_Get_Forgot_password_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Forgot_password_By_OWNER_ID.ExceptionMsg = string.Format("Get_Forgot_password_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Forgot_password_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Forgot_password_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Forgot_password_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Menu_customization_By_OWNER_ID
    [HttpPost]
    [Route("Get_Menu_customization_By_OWNER_ID")]
    public Result_Get_Menu_customization_By_OWNER_ID Get_Menu_customization_By_OWNER_ID(Params_Get_Menu_customization_By_OWNER_ID i_Params_Get_Menu_customization_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Menu_customization> oReturnValue = new List<Menu_customization>();
        string i_Ticket = string.Empty;
        Result_Get_Menu_customization_By_OWNER_ID oResult_Get_Menu_customization_By_OWNER_ID = new Result_Get_Menu_customization_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Menu_customization_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Menu_customization_By_OWNER_ID(i_Params_Get_Menu_customization_By_OWNER_ID);
                oResult_Get_Menu_customization_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Menu_customization_By_OWNER_ID.My_Params_Get_Menu_customization_By_OWNER_ID = i_Params_Get_Menu_customization_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Menu_customization_By_OWNER_ID.ExceptionMsg = string.Format("Get_Menu_customization_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Menu_customization_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Menu_customization_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Menu_customization_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Menu_customization_By_OWNER_ID_Adv
    [HttpPost]
    [Route("Get_Menu_customization_By_OWNER_ID_Adv")]
    public Result_Get_Menu_customization_By_OWNER_ID_Adv Get_Menu_customization_By_OWNER_ID_Adv(Params_Get_Menu_customization_By_OWNER_ID i_Params_Get_Menu_customization_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Menu_customization> oReturnValue = new List<Menu_customization>();
        string i_Ticket = string.Empty;
        Result_Get_Menu_customization_By_OWNER_ID_Adv oResult_Get_Menu_customization_By_OWNER_ID_Adv = new Result_Get_Menu_customization_By_OWNER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Menu_customization_By_OWNER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Menu_customization_By_OWNER_ID_Adv(i_Params_Get_Menu_customization_By_OWNER_ID);
                oResult_Get_Menu_customization_By_OWNER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Menu_customization_By_OWNER_ID_Adv.My_Params_Get_Menu_customization_By_OWNER_ID = i_Params_Get_Menu_customization_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Menu_customization_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Menu_customization_By_OWNER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Menu_customization_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Menu_customization_By_OWNER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Menu_customization_By_OWNER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_By_ORDER_ID
    [HttpPost]
    [Route("Get_Order_By_ORDER_ID")]
    public Result_Get_Order_By_ORDER_ID Get_Order_By_ORDER_ID(Params_Get_Order_By_ORDER_ID i_Params_Get_Order_By_ORDER_ID)
    {
        #region Declaration And Initialization Section.
        Order oReturnValue = new Order();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_ORDER_ID oResult_Get_Order_By_ORDER_ID = new Result_Get_Order_By_ORDER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_ORDER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_ORDER_ID(i_Params_Get_Order_By_ORDER_ID);
                oResult_Get_Order_By_ORDER_ID.My_Result = oReturnValue;
                oResult_Get_Order_By_ORDER_ID.My_Params_Get_Order_By_ORDER_ID = i_Params_Get_Order_By_ORDER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_ORDER_ID.ExceptionMsg = string.Format("Get_Order_By_ORDER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_ORDER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_ORDER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_ORDER_ID;
        #endregion
    }
    #endregion
    #region Get_Order_By_ORDER_ID_Adv
    [HttpPost]
    [Route("Get_Order_By_ORDER_ID_Adv")]
    public Result_Get_Order_By_ORDER_ID_Adv Get_Order_By_ORDER_ID_Adv(Params_Get_Order_By_ORDER_ID i_Params_Get_Order_By_ORDER_ID)
    {
        #region Declaration And Initialization Section.
        Order oReturnValue = new Order();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_ORDER_ID_Adv oResult_Get_Order_By_ORDER_ID_Adv = new Result_Get_Order_By_ORDER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_ORDER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_ORDER_ID_Adv(i_Params_Get_Order_By_ORDER_ID);
                oResult_Get_Order_By_ORDER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_By_ORDER_ID_Adv.My_Params_Get_Order_By_ORDER_ID = i_Params_Get_Order_By_ORDER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_ORDER_ID_Adv.ExceptionMsg = string.Format("Get_Order_By_ORDER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_ORDER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_ORDER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_ORDER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_By_ORDER_ID_COUNT
    [HttpPost]
    [Route("Get_Order_By_ORDER_ID_COUNT")]
    public Result_Get_Order_By_ORDER_ID_COUNT Get_Order_By_ORDER_ID_COUNT(Params_Get_Order_By_ORDER_ID_COUNT i_Params_Get_Order_By_ORDER_ID_COUNT)
    {
        #region Declaration And Initialization Section.
        List<Order> oReturnValue = new List<Order>();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_ORDER_ID_COUNT oResult_Get_Order_By_ORDER_ID_COUNT = new Result_Get_Order_By_ORDER_ID_COUNT();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_ORDER_ID_COUNT);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_ORDER_ID_COUNT(i_Params_Get_Order_By_ORDER_ID_COUNT);
                oResult_Get_Order_By_ORDER_ID_COUNT.My_Result = oReturnValue;
                oResult_Get_Order_By_ORDER_ID_COUNT.My_Params_Get_Order_By_ORDER_ID_COUNT = i_Params_Get_Order_By_ORDER_ID_COUNT;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_ORDER_ID_COUNT.ExceptionMsg = string.Format("Get_Order_By_ORDER_ID_COUNT : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_ORDER_ID_COUNT.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_ORDER_ID_COUNT.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_ORDER_ID_COUNT;
        #endregion
    }
    #endregion
    #region Get_Order_By_ORDER_ID_COUNT_Adv
    [HttpPost]
    [Route("Get_Order_By_ORDER_ID_COUNT_Adv")]
    public Result_Get_Order_By_ORDER_ID_COUNT_Adv Get_Order_By_ORDER_ID_COUNT_Adv(Params_Get_Order_By_ORDER_ID_COUNT i_Params_Get_Order_By_ORDER_ID_COUNT)
    {
        #region Declaration And Initialization Section.
        List<Order> oReturnValue = new List<Order>();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_ORDER_ID_COUNT_Adv oResult_Get_Order_By_ORDER_ID_COUNT_Adv = new Result_Get_Order_By_ORDER_ID_COUNT_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_ORDER_ID_COUNT_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_ORDER_ID_COUNT_Adv(i_Params_Get_Order_By_ORDER_ID_COUNT);
                oResult_Get_Order_By_ORDER_ID_COUNT_Adv.My_Result = oReturnValue;
                oResult_Get_Order_By_ORDER_ID_COUNT_Adv.My_Params_Get_Order_By_ORDER_ID_COUNT = i_Params_Get_Order_By_ORDER_ID_COUNT;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_ORDER_ID_COUNT_Adv.ExceptionMsg = string.Format("Get_Order_By_ORDER_ID_COUNT_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_ORDER_ID_COUNT_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_ORDER_ID_COUNT_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_ORDER_ID_COUNT_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_By_OWNER_ID
    [HttpPost]
    [Route("Get_Order_By_OWNER_ID")]
    public Result_Get_Order_By_OWNER_ID Get_Order_By_OWNER_ID(Params_Get_Order_By_OWNER_ID i_Params_Get_Order_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order> oReturnValue = new List<Order>();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_OWNER_ID oResult_Get_Order_By_OWNER_ID = new Result_Get_Order_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_OWNER_ID(i_Params_Get_Order_By_OWNER_ID);
                oResult_Get_Order_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Order_By_OWNER_ID.My_Params_Get_Order_By_OWNER_ID = i_Params_Get_Order_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_OWNER_ID.ExceptionMsg = string.Format("Get_Order_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Order_By_OWNER_ID_Adv
    [HttpPost]
    [Route("Get_Order_By_OWNER_ID_Adv")]
    public Result_Get_Order_By_OWNER_ID_Adv Get_Order_By_OWNER_ID_Adv(Params_Get_Order_By_OWNER_ID i_Params_Get_Order_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order> oReturnValue = new List<Order>();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_OWNER_ID_Adv oResult_Get_Order_By_OWNER_ID_Adv = new Result_Get_Order_By_OWNER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_OWNER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_OWNER_ID_Adv(i_Params_Get_Order_By_OWNER_ID);
                oResult_Get_Order_By_OWNER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_By_OWNER_ID_Adv.My_Params_Get_Order_By_OWNER_ID = i_Params_Get_Order_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Order_By_OWNER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_OWNER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_OWNER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_By_Where
    [HttpPost]
    [Route("Get_Order_By_Where")]
    public Result_Get_Order_By_Where Get_Order_By_Where(Params_Get_Order_By_Where i_Params_Get_Order_By_Where)
    {
        #region Declaration And Initialization Section.
        List<Order> oReturnValue = new List<Order>();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_Where oResult_Get_Order_By_Where = new Result_Get_Order_By_Where();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_Where);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_Where(i_Params_Get_Order_By_Where);
                oResult_Get_Order_By_Where.My_Result = oReturnValue;
                oResult_Get_Order_By_Where.My_Params_Get_Order_By_Where = i_Params_Get_Order_By_Where;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_Where.ExceptionMsg = string.Format("Get_Order_By_Where : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_Where.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_Where.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_Where;
        #endregion
    }
    #endregion
    #region Get_Order_By_Where_V2
    [HttpPost]
    [Route("Get_Order_By_Where_V2")]
    public Result_Get_Order_By_Where_V2 Get_Order_By_Where_V2(Params_Get_Order_By_Where_V2 i_Params_Get_Order_By_Where_V2)
    {
        #region Declaration And Initialization Section.
        List<Order> oReturnValue = new List<Order>();
        string i_Ticket = string.Empty;
        Result_Get_Order_By_Where_V2 oResult_Get_Order_By_Where_V2 = new Result_Get_Order_By_Where_V2();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_By_Where_V2);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_By_Where_V2(i_Params_Get_Order_By_Where_V2);
                oResult_Get_Order_By_Where_V2.My_Result = oReturnValue;
                oResult_Get_Order_By_Where_V2.My_Params_Get_Order_By_Where_V2 = i_Params_Get_Order_By_Where_V2;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_By_Where_V2.ExceptionMsg = string.Format("Get_Order_By_Where_V2 : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_By_Where_V2.ExceptionMsg = ex.Message;
                oResult_Get_Order_By_Where_V2.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_By_Where_V2;
        #endregion
    }
    #endregion
    #region Get_Order_details_By_ORDER_DETAILS_ID
    [HttpPost]
    [Route("Get_Order_details_By_ORDER_DETAILS_ID")]
    public Result_Get_Order_details_By_ORDER_DETAILS_ID Get_Order_details_By_ORDER_DETAILS_ID(Params_Get_Order_details_By_ORDER_DETAILS_ID i_Params_Get_Order_details_By_ORDER_DETAILS_ID)
    {
        #region Declaration And Initialization Section.
        Order_details oReturnValue = new Order_details();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_By_ORDER_DETAILS_ID oResult_Get_Order_details_By_ORDER_DETAILS_ID = new Result_Get_Order_details_By_ORDER_DETAILS_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_By_ORDER_DETAILS_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_By_ORDER_DETAILS_ID(i_Params_Get_Order_details_By_ORDER_DETAILS_ID);
                oResult_Get_Order_details_By_ORDER_DETAILS_ID.My_Result = oReturnValue;
                oResult_Get_Order_details_By_ORDER_DETAILS_ID.My_Params_Get_Order_details_By_ORDER_DETAILS_ID = i_Params_Get_Order_details_By_ORDER_DETAILS_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_By_ORDER_DETAILS_ID.ExceptionMsg = string.Format("Get_Order_details_By_ORDER_DETAILS_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_By_ORDER_DETAILS_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_By_ORDER_DETAILS_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_By_ORDER_DETAILS_ID;
        #endregion
    }
    #endregion
    #region Get_Order_details_By_ORDER_DETAILS_ID_Adv
    [HttpPost]
    [Route("Get_Order_details_By_ORDER_DETAILS_ID_Adv")]
    public Result_Get_Order_details_By_ORDER_DETAILS_ID_Adv Get_Order_details_By_ORDER_DETAILS_ID_Adv(Params_Get_Order_details_By_ORDER_DETAILS_ID i_Params_Get_Order_details_By_ORDER_DETAILS_ID)
    {
        #region Declaration And Initialization Section.
        Order_details oReturnValue = new Order_details();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_By_ORDER_DETAILS_ID_Adv oResult_Get_Order_details_By_ORDER_DETAILS_ID_Adv = new Result_Get_Order_details_By_ORDER_DETAILS_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_By_ORDER_DETAILS_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_By_ORDER_DETAILS_ID_Adv(i_Params_Get_Order_details_By_ORDER_DETAILS_ID);
                oResult_Get_Order_details_By_ORDER_DETAILS_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_details_By_ORDER_DETAILS_ID_Adv.My_Params_Get_Order_details_By_ORDER_DETAILS_ID = i_Params_Get_Order_details_By_ORDER_DETAILS_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_By_ORDER_DETAILS_ID_Adv.ExceptionMsg = string.Format("Get_Order_details_By_ORDER_DETAILS_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_By_ORDER_DETAILS_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_By_ORDER_DETAILS_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_By_ORDER_DETAILS_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_details_By_ORDER_ID
    [HttpPost]
    [Route("Get_Order_details_By_ORDER_ID")]
    public Result_Get_Order_details_By_ORDER_ID Get_Order_details_By_ORDER_ID(Params_Get_Order_details_By_ORDER_ID i_Params_Get_Order_details_By_ORDER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details> oReturnValue = new List<Order_details>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_By_ORDER_ID oResult_Get_Order_details_By_ORDER_ID = new Result_Get_Order_details_By_ORDER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_By_ORDER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_By_ORDER_ID(i_Params_Get_Order_details_By_ORDER_ID);
                oResult_Get_Order_details_By_ORDER_ID.My_Result = oReturnValue;
                oResult_Get_Order_details_By_ORDER_ID.My_Params_Get_Order_details_By_ORDER_ID = i_Params_Get_Order_details_By_ORDER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_By_ORDER_ID.ExceptionMsg = string.Format("Get_Order_details_By_ORDER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_By_ORDER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_By_ORDER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_By_ORDER_ID;
        #endregion
    }
    #endregion
    #region Get_Order_details_By_ORDER_ID_Adv
    [HttpPost]
    [Route("Get_Order_details_By_ORDER_ID_Adv")]
    public Result_Get_Order_details_By_ORDER_ID_Adv Get_Order_details_By_ORDER_ID_Adv(Params_Get_Order_details_By_ORDER_ID i_Params_Get_Order_details_By_ORDER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details> oReturnValue = new List<Order_details>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_By_ORDER_ID_Adv oResult_Get_Order_details_By_ORDER_ID_Adv = new Result_Get_Order_details_By_ORDER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_By_ORDER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_By_ORDER_ID_Adv(i_Params_Get_Order_details_By_ORDER_ID);
                oResult_Get_Order_details_By_ORDER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_details_By_ORDER_ID_Adv.My_Params_Get_Order_details_By_ORDER_ID = i_Params_Get_Order_details_By_ORDER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_By_ORDER_ID_Adv.ExceptionMsg = string.Format("Get_Order_details_By_ORDER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_By_ORDER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_By_ORDER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_By_ORDER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_details_By_OWNER_ID
    [HttpPost]
    [Route("Get_Order_details_By_OWNER_ID")]
    public Result_Get_Order_details_By_OWNER_ID Get_Order_details_By_OWNER_ID(Params_Get_Order_details_By_OWNER_ID i_Params_Get_Order_details_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details> oReturnValue = new List<Order_details>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_By_OWNER_ID oResult_Get_Order_details_By_OWNER_ID = new Result_Get_Order_details_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_By_OWNER_ID(i_Params_Get_Order_details_By_OWNER_ID);
                oResult_Get_Order_details_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Order_details_By_OWNER_ID.My_Params_Get_Order_details_By_OWNER_ID = i_Params_Get_Order_details_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_By_OWNER_ID.ExceptionMsg = string.Format("Get_Order_details_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Order_details_By_OWNER_ID_Adv
    [HttpPost]
    [Route("Get_Order_details_By_OWNER_ID_Adv")]
    public Result_Get_Order_details_By_OWNER_ID_Adv Get_Order_details_By_OWNER_ID_Adv(Params_Get_Order_details_By_OWNER_ID i_Params_Get_Order_details_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details> oReturnValue = new List<Order_details>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_By_OWNER_ID_Adv oResult_Get_Order_details_By_OWNER_ID_Adv = new Result_Get_Order_details_By_OWNER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_By_OWNER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_By_OWNER_ID_Adv(i_Params_Get_Order_details_By_OWNER_ID);
                oResult_Get_Order_details_By_OWNER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_details_By_OWNER_ID_Adv.My_Params_Get_Order_details_By_OWNER_ID = i_Params_Get_Order_details_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Order_details_By_OWNER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_By_OWNER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_By_OWNER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_details_items_By_ORDER_DETAILS_ID
    [HttpPost]
    [Route("Get_Order_details_items_By_ORDER_DETAILS_ID")]
    public Result_Get_Order_details_items_By_ORDER_DETAILS_ID Get_Order_details_items_By_ORDER_DETAILS_ID(Params_Get_Order_details_items_By_ORDER_DETAILS_ID i_Params_Get_Order_details_items_By_ORDER_DETAILS_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details_items> oReturnValue = new List<Order_details_items>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_items_By_ORDER_DETAILS_ID oResult_Get_Order_details_items_By_ORDER_DETAILS_ID = new Result_Get_Order_details_items_By_ORDER_DETAILS_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_items_By_ORDER_DETAILS_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_items_By_ORDER_DETAILS_ID(i_Params_Get_Order_details_items_By_ORDER_DETAILS_ID);
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID.My_Result = oReturnValue;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID.My_Params_Get_Order_details_items_By_ORDER_DETAILS_ID = i_Params_Get_Order_details_items_By_ORDER_DETAILS_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID.ExceptionMsg = string.Format("Get_Order_details_items_By_ORDER_DETAILS_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_items_By_ORDER_DETAILS_ID;
        #endregion
    }
    #endregion
    #region Get_Order_details_items_By_ORDER_DETAILS_ID_Adv
    [HttpPost]
    [Route("Get_Order_details_items_By_ORDER_DETAILS_ID_Adv")]
    public Result_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv Get_Order_details_items_By_ORDER_DETAILS_ID_Adv(Params_Get_Order_details_items_By_ORDER_DETAILS_ID i_Params_Get_Order_details_items_By_ORDER_DETAILS_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details_items> oReturnValue = new List<Order_details_items>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv oResult_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv = new Result_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_items_By_ORDER_DETAILS_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_items_By_ORDER_DETAILS_ID_Adv(i_Params_Get_Order_details_items_By_ORDER_DETAILS_ID);
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv.My_Params_Get_Order_details_items_By_ORDER_DETAILS_ID = i_Params_Get_Order_details_items_By_ORDER_DETAILS_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv.ExceptionMsg = string.Format("Get_Order_details_items_By_ORDER_DETAILS_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID
    [HttpPost]
    [Route("Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID")]
    public Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID(Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID i_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID)
    {
        #region Declaration And Initialization Section.
        Order_details_items oReturnValue = new Order_details_items();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID = new Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID(i_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID);
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID.My_Result = oReturnValue;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID.My_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID = i_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID.ExceptionMsg = string.Format("Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID;
        #endregion
    }
    #endregion
    #region Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv
    [HttpPost]
    [Route("Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv")]
    public Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv(Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID i_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID)
    {
        #region Declaration And Initialization Section.
        Order_details_items oReturnValue = new Order_details_items();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv = new Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv(i_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID);
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv.My_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID = i_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv.ExceptionMsg = string.Format("Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Order_details_items_By_OWNER_ID
    [HttpPost]
    [Route("Get_Order_details_items_By_OWNER_ID")]
    public Result_Get_Order_details_items_By_OWNER_ID Get_Order_details_items_By_OWNER_ID(Params_Get_Order_details_items_By_OWNER_ID i_Params_Get_Order_details_items_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details_items> oReturnValue = new List<Order_details_items>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_items_By_OWNER_ID oResult_Get_Order_details_items_By_OWNER_ID = new Result_Get_Order_details_items_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_items_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_items_By_OWNER_ID(i_Params_Get_Order_details_items_By_OWNER_ID);
                oResult_Get_Order_details_items_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Order_details_items_By_OWNER_ID.My_Params_Get_Order_details_items_By_OWNER_ID = i_Params_Get_Order_details_items_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_items_By_OWNER_ID.ExceptionMsg = string.Format("Get_Order_details_items_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_items_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_items_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_items_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Order_details_items_By_OWNER_ID_Adv
    [HttpPost]
    [Route("Get_Order_details_items_By_OWNER_ID_Adv")]
    public Result_Get_Order_details_items_By_OWNER_ID_Adv Get_Order_details_items_By_OWNER_ID_Adv(Params_Get_Order_details_items_By_OWNER_ID i_Params_Get_Order_details_items_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Order_details_items> oReturnValue = new List<Order_details_items>();
        string i_Ticket = string.Empty;
        Result_Get_Order_details_items_By_OWNER_ID_Adv oResult_Get_Order_details_items_By_OWNER_ID_Adv = new Result_Get_Order_details_items_By_OWNER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Order_details_items_By_OWNER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Order_details_items_By_OWNER_ID_Adv(i_Params_Get_Order_details_items_By_OWNER_ID);
                oResult_Get_Order_details_items_By_OWNER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Order_details_items_By_OWNER_ID_Adv.My_Params_Get_Order_details_items_By_OWNER_ID = i_Params_Get_Order_details_items_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Order_details_items_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Order_details_items_By_OWNER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Order_details_items_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Order_details_items_By_OWNER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Order_details_items_By_OWNER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Owner_By_OWNER_ID
    [HttpPost]
    [Route("Get_Owner_By_OWNER_ID")]
    public Result_Get_Owner_By_OWNER_ID Get_Owner_By_OWNER_ID(Params_Get_Owner_By_OWNER_ID i_Params_Get_Owner_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        Owner oReturnValue = new Owner();
        string i_Ticket = string.Empty;
        Result_Get_Owner_By_OWNER_ID oResult_Get_Owner_By_OWNER_ID = new Result_Get_Owner_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Owner_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Owner_By_OWNER_ID(i_Params_Get_Owner_By_OWNER_ID);
                oResult_Get_Owner_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Owner_By_OWNER_ID.My_Params_Get_Owner_By_OWNER_ID = i_Params_Get_Owner_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Owner_By_OWNER_ID.ExceptionMsg = string.Format("Get_Owner_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Owner_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Owner_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Owner_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Owner_By_OWNER_NAME
    [HttpPost]
    [Route("Get_Owner_By_OWNER_NAME")]
    public Result_Get_Owner_By_OWNER_NAME Get_Owner_By_OWNER_NAME(Params_Get_Owner_By_OWNER_NAME i_Params_Get_Owner_By_OWNER_NAME)
    {
        #region Declaration And Initialization Section.
        Owner oReturnValue = new Owner();
        string i_Ticket = string.Empty;
        Result_Get_Owner_By_OWNER_NAME oResult_Get_Owner_By_OWNER_NAME = new Result_Get_Owner_By_OWNER_NAME();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Owner_By_OWNER_NAME);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Owner_By_OWNER_NAME(i_Params_Get_Owner_By_OWNER_NAME);
                oResult_Get_Owner_By_OWNER_NAME.My_Result = oReturnValue;
                oResult_Get_Owner_By_OWNER_NAME.My_Params_Get_Owner_By_OWNER_NAME = i_Params_Get_Owner_By_OWNER_NAME;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Owner_By_OWNER_NAME.ExceptionMsg = string.Format("Get_Owner_By_OWNER_NAME : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Owner_By_OWNER_NAME.ExceptionMsg = ex.Message;
                oResult_Get_Owner_By_OWNER_NAME.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Owner_By_OWNER_NAME;
        #endregion
    }
    #endregion
    #region Get_Owner_By_Where
    [HttpPost]
    [Route("Get_Owner_By_Where")]
    public Result_Get_Owner_By_Where Get_Owner_By_Where(Params_Get_Owner_By_Where i_Params_Get_Owner_By_Where)
    {
        #region Declaration And Initialization Section.
        List<Owner> oReturnValue = new List<Owner>();
        string i_Ticket = string.Empty;
        Result_Get_Owner_By_Where oResult_Get_Owner_By_Where = new Result_Get_Owner_By_Where();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Owner_By_Where);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Owner_By_Where(i_Params_Get_Owner_By_Where);
                oResult_Get_Owner_By_Where.My_Result = oReturnValue;
                oResult_Get_Owner_By_Where.My_Params_Get_Owner_By_Where = i_Params_Get_Owner_By_Where;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Owner_By_Where.ExceptionMsg = string.Format("Get_Owner_By_Where : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Owner_By_Where.ExceptionMsg = ex.Message;
                oResult_Get_Owner_By_Where.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Owner_By_Where;
        #endregion
    }
    #endregion
    #region Get_Payment_By_OWNER_ID
    [HttpPost]
    [Route("Get_Payment_By_OWNER_ID")]
    public Result_Get_Payment_By_OWNER_ID Get_Payment_By_OWNER_ID(Params_Get_Payment_By_OWNER_ID i_Params_Get_Payment_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Payment> oReturnValue = new List<Payment>();
        string i_Ticket = string.Empty;
        Result_Get_Payment_By_OWNER_ID oResult_Get_Payment_By_OWNER_ID = new Result_Get_Payment_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Payment_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Payment_By_OWNER_ID(i_Params_Get_Payment_By_OWNER_ID);
                oResult_Get_Payment_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Payment_By_OWNER_ID.My_Params_Get_Payment_By_OWNER_ID = i_Params_Get_Payment_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Payment_By_OWNER_ID.ExceptionMsg = string.Format("Get_Payment_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Payment_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Payment_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Payment_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Payment_By_PAYMENT_ID
    [HttpPost]
    [Route("Get_Payment_By_PAYMENT_ID")]
    public Result_Get_Payment_By_PAYMENT_ID Get_Payment_By_PAYMENT_ID(Params_Get_Payment_By_PAYMENT_ID i_Params_Get_Payment_By_PAYMENT_ID)
    {
        #region Declaration And Initialization Section.
        Payment oReturnValue = new Payment();
        string i_Ticket = string.Empty;
        Result_Get_Payment_By_PAYMENT_ID oResult_Get_Payment_By_PAYMENT_ID = new Result_Get_Payment_By_PAYMENT_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Payment_By_PAYMENT_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Payment_By_PAYMENT_ID(i_Params_Get_Payment_By_PAYMENT_ID);
                oResult_Get_Payment_By_PAYMENT_ID.My_Result = oReturnValue;
                oResult_Get_Payment_By_PAYMENT_ID.My_Params_Get_Payment_By_PAYMENT_ID = i_Params_Get_Payment_By_PAYMENT_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Payment_By_PAYMENT_ID.ExceptionMsg = string.Format("Get_Payment_By_PAYMENT_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Payment_By_PAYMENT_ID.ExceptionMsg = ex.Message;
                oResult_Get_Payment_By_PAYMENT_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Payment_By_PAYMENT_ID;
        #endregion
    }
    #endregion
    #region Get_Payment_By_PAYMENT_ID_List
    [HttpPost]
    [Route("Get_Payment_By_PAYMENT_ID_List")]
    public Result_Get_Payment_By_PAYMENT_ID_List Get_Payment_By_PAYMENT_ID_List(Params_Get_Payment_By_PAYMENT_ID_List i_Params_Get_Payment_By_PAYMENT_ID_List)
    {
        #region Declaration And Initialization Section.
        List<Payment> oReturnValue = new List<Payment>();
        string i_Ticket = string.Empty;
        Result_Get_Payment_By_PAYMENT_ID_List oResult_Get_Payment_By_PAYMENT_ID_List = new Result_Get_Payment_By_PAYMENT_ID_List();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Payment_By_PAYMENT_ID_List);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Payment_By_PAYMENT_ID_List(i_Params_Get_Payment_By_PAYMENT_ID_List);
                oResult_Get_Payment_By_PAYMENT_ID_List.My_Result = oReturnValue;
                oResult_Get_Payment_By_PAYMENT_ID_List.My_Params_Get_Payment_By_PAYMENT_ID_List = i_Params_Get_Payment_By_PAYMENT_ID_List;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Payment_By_PAYMENT_ID_List.ExceptionMsg = string.Format("Get_Payment_By_PAYMENT_ID_List : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Payment_By_PAYMENT_ID_List.ExceptionMsg = ex.Message;
                oResult_Get_Payment_By_PAYMENT_ID_List.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Payment_By_PAYMENT_ID_List;
        #endregion
    }
    #endregion
    #region Get_Product_By_CATEGORY_ID
    [HttpPost]
    [Route("Get_Product_By_CATEGORY_ID")]
    public Result_Get_Product_By_CATEGORY_ID Get_Product_By_CATEGORY_ID(Params_Get_Product_By_CATEGORY_ID i_Params_Get_Product_By_CATEGORY_ID)
    {
        #region Declaration And Initialization Section.
        List<Product> oReturnValue = new List<Product>();
        string i_Ticket = string.Empty;
        Result_Get_Product_By_CATEGORY_ID oResult_Get_Product_By_CATEGORY_ID = new Result_Get_Product_By_CATEGORY_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Product_By_CATEGORY_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Product_By_CATEGORY_ID(i_Params_Get_Product_By_CATEGORY_ID);
                oResult_Get_Product_By_CATEGORY_ID.My_Result = oReturnValue;
                oResult_Get_Product_By_CATEGORY_ID.My_Params_Get_Product_By_CATEGORY_ID = i_Params_Get_Product_By_CATEGORY_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Product_By_CATEGORY_ID.ExceptionMsg = string.Format("Get_Product_By_CATEGORY_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Product_By_CATEGORY_ID.ExceptionMsg = ex.Message;
                oResult_Get_Product_By_CATEGORY_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Product_By_CATEGORY_ID;
        #endregion
    }
    #endregion
    #region Get_Product_By_OWNER_ID
    [HttpPost]
    [Route("Get_Product_By_OWNER_ID")]
    public Result_Get_Product_By_OWNER_ID Get_Product_By_OWNER_ID(Params_Get_Product_By_OWNER_ID i_Params_Get_Product_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Product> oReturnValue = new List<Product>();
        string i_Ticket = string.Empty;
        Result_Get_Product_By_OWNER_ID oResult_Get_Product_By_OWNER_ID = new Result_Get_Product_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Product_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Product_By_OWNER_ID(i_Params_Get_Product_By_OWNER_ID);
                oResult_Get_Product_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Product_By_OWNER_ID.My_Params_Get_Product_By_OWNER_ID = i_Params_Get_Product_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Product_By_OWNER_ID.ExceptionMsg = string.Format("Get_Product_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Product_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Product_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Product_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Product_By_OWNER_ID_Adv
    [HttpPost]
    [Route("Get_Product_By_OWNER_ID_Adv")]
    public Result_Get_Product_By_OWNER_ID_Adv Get_Product_By_OWNER_ID_Adv(Params_Get_Product_By_OWNER_ID i_Params_Get_Product_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Product> oReturnValue = new List<Product>();
        string i_Ticket = string.Empty;
        Result_Get_Product_By_OWNER_ID_Adv oResult_Get_Product_By_OWNER_ID_Adv = new Result_Get_Product_By_OWNER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Product_By_OWNER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Product_By_OWNER_ID_Adv(i_Params_Get_Product_By_OWNER_ID);
                oResult_Get_Product_By_OWNER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Product_By_OWNER_ID_Adv.My_Params_Get_Product_By_OWNER_ID = i_Params_Get_Product_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Product_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Product_By_OWNER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Product_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Product_By_OWNER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Product_By_OWNER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Product_By_PRODUCT_ID
    [HttpPost]
    [Route("Get_Product_By_PRODUCT_ID")]
    public Result_Get_Product_By_PRODUCT_ID Get_Product_By_PRODUCT_ID(Params_Get_Product_By_PRODUCT_ID i_Params_Get_Product_By_PRODUCT_ID)
    {
        #region Declaration And Initialization Section.
        Product oReturnValue = new Product();
        string i_Ticket = string.Empty;
        Result_Get_Product_By_PRODUCT_ID oResult_Get_Product_By_PRODUCT_ID = new Result_Get_Product_By_PRODUCT_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Product_By_PRODUCT_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Product_By_PRODUCT_ID(i_Params_Get_Product_By_PRODUCT_ID);
                oResult_Get_Product_By_PRODUCT_ID.My_Result = oReturnValue;
                oResult_Get_Product_By_PRODUCT_ID.My_Params_Get_Product_By_PRODUCT_ID = i_Params_Get_Product_By_PRODUCT_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Product_By_PRODUCT_ID.ExceptionMsg = string.Format("Get_Product_By_PRODUCT_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Product_By_PRODUCT_ID.ExceptionMsg = ex.Message;
                oResult_Get_Product_By_PRODUCT_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Product_By_PRODUCT_ID;
        #endregion
    }
    #endregion
    #region Get_Restaurant_details_By_OWNER_ID
    [HttpPost]
    [Route("Get_Restaurant_details_By_OWNER_ID")]
    public Result_Get_Restaurant_details_By_OWNER_ID Get_Restaurant_details_By_OWNER_ID(Params_Get_Restaurant_details_By_OWNER_ID i_Params_Get_Restaurant_details_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Restaurant_details> oReturnValue = new List<Restaurant_details>();
        string i_Ticket = string.Empty;
        Result_Get_Restaurant_details_By_OWNER_ID oResult_Get_Restaurant_details_By_OWNER_ID = new Result_Get_Restaurant_details_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Restaurant_details_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Restaurant_details_By_OWNER_ID(i_Params_Get_Restaurant_details_By_OWNER_ID);
                oResult_Get_Restaurant_details_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Restaurant_details_By_OWNER_ID.My_Params_Get_Restaurant_details_By_OWNER_ID = i_Params_Get_Restaurant_details_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Restaurant_details_By_OWNER_ID.ExceptionMsg = string.Format("Get_Restaurant_details_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Restaurant_details_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Restaurant_details_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Restaurant_details_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Restaurant_details_By_OWNER_ID_Adv
    [HttpPost]
    [Route("Get_Restaurant_details_By_OWNER_ID_Adv")]
    public Result_Get_Restaurant_details_By_OWNER_ID_Adv Get_Restaurant_details_By_OWNER_ID_Adv(Params_Get_Restaurant_details_By_OWNER_ID i_Params_Get_Restaurant_details_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Restaurant_details> oReturnValue = new List<Restaurant_details>();
        string i_Ticket = string.Empty;
        Result_Get_Restaurant_details_By_OWNER_ID_Adv oResult_Get_Restaurant_details_By_OWNER_ID_Adv = new Result_Get_Restaurant_details_By_OWNER_ID_Adv();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Restaurant_details_By_OWNER_ID_Adv);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Restaurant_details_By_OWNER_ID_Adv(i_Params_Get_Restaurant_details_By_OWNER_ID);
                oResult_Get_Restaurant_details_By_OWNER_ID_Adv.My_Result = oReturnValue;
                oResult_Get_Restaurant_details_By_OWNER_ID_Adv.My_Params_Get_Restaurant_details_By_OWNER_ID = i_Params_Get_Restaurant_details_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Restaurant_details_By_OWNER_ID_Adv.ExceptionMsg = string.Format("Get_Restaurant_details_By_OWNER_ID_Adv : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Restaurant_details_By_OWNER_ID_Adv.ExceptionMsg = ex.Message;
                oResult_Get_Restaurant_details_By_OWNER_ID_Adv.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Restaurant_details_By_OWNER_ID_Adv;
        #endregion
    }
    #endregion
    #region Get_Restaurant_details_By_Where
    [HttpPost]
    [Route("Get_Restaurant_details_By_Where")]
    public Result_Get_Restaurant_details_By_Where Get_Restaurant_details_By_Where(Params_Get_Restaurant_details_By_Where i_Params_Get_Restaurant_details_By_Where)
    {
        #region Declaration And Initialization Section.
        List<Restaurant_details> oReturnValue = new List<Restaurant_details>();
        string i_Ticket = string.Empty;
        Result_Get_Restaurant_details_By_Where oResult_Get_Restaurant_details_By_Where = new Result_Get_Restaurant_details_By_Where();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Restaurant_details_By_Where);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Restaurant_details_By_Where(i_Params_Get_Restaurant_details_By_Where);
                oResult_Get_Restaurant_details_By_Where.My_Result = oReturnValue;
                oResult_Get_Restaurant_details_By_Where.My_Params_Get_Restaurant_details_By_Where = i_Params_Get_Restaurant_details_By_Where;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Restaurant_details_By_Where.ExceptionMsg = string.Format("Get_Restaurant_details_By_Where : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Restaurant_details_By_Where.ExceptionMsg = ex.Message;
                oResult_Get_Restaurant_details_By_Where.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Restaurant_details_By_Where;
        #endregion
    }
    #endregion
    #region Get_Restaurant_views_By_OWNER_ID
    [HttpPost]
    [Route("Get_Restaurant_views_By_OWNER_ID")]
    public Result_Get_Restaurant_views_By_OWNER_ID Get_Restaurant_views_By_OWNER_ID(Params_Get_Restaurant_views_By_OWNER_ID i_Params_Get_Restaurant_views_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Restaurant_views> oReturnValue = new List<Restaurant_views>();
        string i_Ticket = string.Empty;
        Result_Get_Restaurant_views_By_OWNER_ID oResult_Get_Restaurant_views_By_OWNER_ID = new Result_Get_Restaurant_views_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Restaurant_views_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Restaurant_views_By_OWNER_ID(i_Params_Get_Restaurant_views_By_OWNER_ID);
                oResult_Get_Restaurant_views_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Restaurant_views_By_OWNER_ID.My_Params_Get_Restaurant_views_By_OWNER_ID = i_Params_Get_Restaurant_views_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Restaurant_views_By_OWNER_ID.ExceptionMsg = string.Format("Get_Restaurant_views_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Restaurant_views_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Restaurant_views_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Restaurant_views_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Timing_By_OWNER_ID
    [HttpPost]
    [Route("Get_Timing_By_OWNER_ID")]
    public Result_Get_Timing_By_OWNER_ID Get_Timing_By_OWNER_ID(Params_Get_Timing_By_OWNER_ID i_Params_Get_Timing_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<Timing> oReturnValue = new List<Timing>();
        string i_Ticket = string.Empty;
        Result_Get_Timing_By_OWNER_ID oResult_Get_Timing_By_OWNER_ID = new Result_Get_Timing_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Timing_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Timing_By_OWNER_ID(i_Params_Get_Timing_By_OWNER_ID);
                oResult_Get_Timing_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_Timing_By_OWNER_ID.My_Params_Get_Timing_By_OWNER_ID = i_Params_Get_Timing_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Timing_By_OWNER_ID.ExceptionMsg = string.Format("Get_Timing_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Timing_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_Timing_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Timing_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_Timing_By_TIMING_ID
    [HttpPost]
    [Route("Get_Timing_By_TIMING_ID")]
    public Result_Get_Timing_By_TIMING_ID Get_Timing_By_TIMING_ID(Params_Get_Timing_By_TIMING_ID i_Params_Get_Timing_By_TIMING_ID)
    {
        #region Declaration And Initialization Section.
        Timing oReturnValue = new Timing();
        string i_Ticket = string.Empty;
        Result_Get_Timing_By_TIMING_ID oResult_Get_Timing_By_TIMING_ID = new Result_Get_Timing_By_TIMING_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Timing_By_TIMING_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Timing_By_TIMING_ID(i_Params_Get_Timing_By_TIMING_ID);
                oResult_Get_Timing_By_TIMING_ID.My_Result = oReturnValue;
                oResult_Get_Timing_By_TIMING_ID.My_Params_Get_Timing_By_TIMING_ID = i_Params_Get_Timing_By_TIMING_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Timing_By_TIMING_ID.ExceptionMsg = string.Format("Get_Timing_By_TIMING_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Timing_By_TIMING_ID.ExceptionMsg = ex.Message;
                oResult_Get_Timing_By_TIMING_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Timing_By_TIMING_ID;
        #endregion
    }
    #endregion
    #region Get_Timing_By_TIMING_ID_List
    [HttpPost]
    [Route("Get_Timing_By_TIMING_ID_List")]
    public Result_Get_Timing_By_TIMING_ID_List Get_Timing_By_TIMING_ID_List(Params_Get_Timing_By_TIMING_ID_List i_Params_Get_Timing_By_TIMING_ID_List)
    {
        #region Declaration And Initialization Section.
        List<Timing> oReturnValue = new List<Timing>();
        string i_Ticket = string.Empty;
        Result_Get_Timing_By_TIMING_ID_List oResult_Get_Timing_By_TIMING_ID_List = new Result_Get_Timing_By_TIMING_ID_List();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_Timing_By_TIMING_ID_List);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_Timing_By_TIMING_ID_List(i_Params_Get_Timing_By_TIMING_ID_List);
                oResult_Get_Timing_By_TIMING_ID_List.My_Result = oReturnValue;
                oResult_Get_Timing_By_TIMING_ID_List.My_Params_Get_Timing_By_TIMING_ID_List = i_Params_Get_Timing_By_TIMING_ID_List;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_Timing_By_TIMING_ID_List.ExceptionMsg = string.Format("Get_Timing_By_TIMING_ID_List : {0}", ex.Message);
            }
            else
            {
                oResult_Get_Timing_By_TIMING_ID_List.ExceptionMsg = ex.Message;
                oResult_Get_Timing_By_TIMING_ID_List.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_Timing_By_TIMING_ID_List;
        #endregion
    }
    #endregion
    #region Get_User_By_OWNER_ID
    [HttpPost]
    [Route("Get_User_By_OWNER_ID")]
    public Result_Get_User_By_OWNER_ID Get_User_By_OWNER_ID(Params_Get_User_By_OWNER_ID i_Params_Get_User_By_OWNER_ID)
    {
        #region Declaration And Initialization Section.
        List<User> oReturnValue = new List<User>();
        string i_Ticket = string.Empty;
        Result_Get_User_By_OWNER_ID oResult_Get_User_By_OWNER_ID = new Result_Get_User_By_OWNER_ID();
        #endregion
        #region Body Section.
        try
        {

            // Ticket Checking
            //-------------------
            if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
            {
                if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
                {
                    if
                    (
                    (
                    (HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
                    (HttpContext.Request.Query["Ticket"].ToString() != "")
                    )
                    ||
                    (
                    (HttpContext.Request.Headers["Ticket"].FirstOrDefault() != null) &&
                    (HttpContext.Request.Headers["Ticket"].ToString() != "")
                    )
                    )
                    {
                        i_Ticket = string.IsNullOrEmpty(HttpContext.Request.Query["Ticket"]) ? "" : HttpContext.Request.Query["Ticket"].ToString();
                        if (string.IsNullOrEmpty(i_Ticket))
                        {
                            i_Ticket = HttpContext.Request.Headers["Ticket"].ToString();
                            if (string.IsNullOrEmpty(i_Ticket))
                            {
                                throw new Exception("Missing Ticket");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid Ticket");
                    }
                }
            }
            //-------------------

            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_User_By_OWNER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_User_By_OWNER_ID(i_Params_Get_User_By_OWNER_ID);
                oResult_Get_User_By_OWNER_ID.My_Result = oReturnValue;
                oResult_Get_User_By_OWNER_ID.My_Params_Get_User_By_OWNER_ID = i_Params_Get_User_By_OWNER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_User_By_OWNER_ID.ExceptionMsg = string.Format("Get_User_By_OWNER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_User_By_OWNER_ID.ExceptionMsg = ex.Message;
                oResult_Get_User_By_OWNER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_User_By_OWNER_ID;
        #endregion
    }
    #endregion
    #region Get_User_By_USER_ID
    [HttpPost]
    [Route("Get_User_By_USER_ID")]
    public Result_Get_User_By_USER_ID Get_User_By_USER_ID(Params_Get_User_By_USER_ID i_Params_Get_User_By_USER_ID)
    {
        #region Declaration And Initialization Section.
        User oReturnValue = new User();
        string i_Ticket = string.Empty;
        Result_Get_User_By_USER_ID oResult_Get_User_By_USER_ID = new Result_Get_User_By_USER_ID();
        #endregion
        #region Body Section.
        try
        {


            BLC.BLC oBLC_Default = new BLC.BLC();
            BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket, BLC.BLC.Enum_API_Method.Get_User_By_USER_ID);
            using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
            {
                oBLC.Monitor_API_Calls();
                oReturnValue = oBLC.Get_User_By_USER_ID(i_Params_Get_User_By_USER_ID);
                oResult_Get_User_By_USER_ID.My_Result = oReturnValue;
                oResult_Get_User_By_USER_ID.My_Params_Get_User_By_USER_ID = i_Params_Get_User_By_USER_ID;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType().FullName != "BLC.BLCException")
            {
                oResult_Get_User_By_USER_ID.ExceptionMsg = string.Format("Get_User_By_USER_ID : {0}", ex.Message);
            }
            else
            {
                oResult_Get_User_By_USER_ID.ExceptionMsg = ex.Message;
                oResult_Get_User_By_USER_ID.ExceptionCode = ((BLCException)ex).Code;
            }
        }
        #endregion
        #region Return Section
        return oResult_Get_User_By_USER_ID;
        #endregion
    }
    #endregion
}

#region Action_Result
public partial class Action_Result
{
    #region Properties.
    public string ExceptionCode { get; set; }
    public string ExceptionMsg { get; set; }
    #endregion
    #region Constructor
    public Action_Result()
    {
        #region Declaration And Initialization Section.
        #endregion
        #region Body Section.
        this.ExceptionMsg = string.Empty;
        #endregion
    }
    #endregion
}
#endregion
#region Result_Authenticate
public partial class Result_Authenticate : Action_Result
{
    #region Properties.
    public UserInfo My_Result { get; set; }
    public Params_Authenticate My_Params_Authenticate { get; set; }
    #endregion
}
#endregion
#region Result_Delete_Category
public partial class Result_Delete_Category : Action_Result
{
    #region Properties.
    public Params_Delete_Category My_Params_Delete_Category { get; set; }
    #endregion
}
#endregion
#region Result_Delete_Forgot_password
public partial class Result_Delete_Forgot_password : Action_Result
{
    #region Properties.
    public Params_Delete_Forgot_password My_Params_Delete_Forgot_password { get; set; }
    #endregion
}
#endregion
#region Result_Delete_Product
public partial class Result_Delete_Product : Action_Result
{
    #region Properties.
    public Params_Delete_Product My_Params_Delete_Product { get; set; }
    #endregion
}
#endregion
#region Result_Delete_User
public partial class Result_Delete_User : Action_Result
{
    #region Properties.
    public Params_Delete_User My_Params_Delete_User { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Category
public partial class Result_Edit_Category : Action_Result
{
    #region Properties.
    public Category My_Category { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Forgot_password
public partial class Result_Edit_Forgot_password : Action_Result
{
    #region Properties.
    public Forgot_password My_Forgot_password { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Menu_customization
public partial class Result_Edit_Menu_customization : Action_Result
{
    #region Properties.
    public Menu_customization My_Menu_customization { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Order
public partial class Result_Edit_Order : Action_Result
{
    #region Properties.
    public Order My_Order { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Order_details
public partial class Result_Edit_Order_details : Action_Result
{
    #region Properties.
    public Order_details My_Order_details { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Order_details_items
public partial class Result_Edit_Order_details_items : Action_Result
{
    #region Properties.
    public Order_details_items My_Order_details_items { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Owner
public partial class Result_Edit_Owner : Action_Result
{
    #region Properties.
    public Owner My_Owner { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Payment
public partial class Result_Edit_Payment : Action_Result
{
    #region Properties.
    public Payment My_Payment { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Product
public partial class Result_Edit_Product : Action_Result
{
    #region Properties.
    public Product My_Product { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Restaurant_details
public partial class Result_Edit_Restaurant_details : Action_Result
{
    #region Properties.
    public Restaurant_details My_Restaurant_details { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Restaurant_views
public partial class Result_Edit_Restaurant_views : Action_Result
{
    #region Properties.
    public Restaurant_views My_Restaurant_views { get; set; }
    #endregion
}
#endregion
#region Result_Edit_Timing
public partial class Result_Edit_Timing : Action_Result
{
    #region Properties.
    public Timing My_Timing { get; set; }
    #endregion
}
#endregion
#region Result_Edit_User
public partial class Result_Edit_User : Action_Result
{
    #region Properties.
    public User My_User { get; set; }
    #endregion
}
#endregion
#region Result_Get_Category_By_CATEGORY_ID
public partial class Result_Get_Category_By_CATEGORY_ID : Action_Result
{
    #region Properties.
    public Category My_Result { get; set; }
    public Params_Get_Category_By_CATEGORY_ID My_Params_Get_Category_By_CATEGORY_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Category_By_OWNER_ID
public partial class Result_Get_Category_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Category> My_Result { get; set; }
    public Params_Get_Category_By_OWNER_ID My_Params_Get_Category_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Forgot_password_By_FORGOT_PASSWORD_ID
public partial class Result_Get_Forgot_password_By_FORGOT_PASSWORD_ID : Action_Result
{
    #region Properties.
    public Forgot_password My_Result { get; set; }
    public Params_Get_Forgot_password_By_FORGOT_PASSWORD_ID My_Params_Get_Forgot_password_By_FORGOT_PASSWORD_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Forgot_password_By_OWNER_ID
public partial class Result_Get_Forgot_password_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Forgot_password> My_Result { get; set; }
    public Params_Get_Forgot_password_By_OWNER_ID My_Params_Get_Forgot_password_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Menu_customization_By_OWNER_ID
public partial class Result_Get_Menu_customization_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Menu_customization> My_Result { get; set; }
    public Params_Get_Menu_customization_By_OWNER_ID My_Params_Get_Menu_customization_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Menu_customization_By_OWNER_ID_Adv
public partial class Result_Get_Menu_customization_By_OWNER_ID_Adv : Action_Result
{
    #region Properties.
    public List<Menu_customization> My_Result { get; set; }
    public Params_Get_Menu_customization_By_OWNER_ID My_Params_Get_Menu_customization_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_ORDER_ID
public partial class Result_Get_Order_By_ORDER_ID : Action_Result
{
    #region Properties.
    public Order My_Result { get; set; }
    public Params_Get_Order_By_ORDER_ID My_Params_Get_Order_By_ORDER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_ORDER_ID_Adv
public partial class Result_Get_Order_By_ORDER_ID_Adv : Action_Result
{
    #region Properties.
    public Order My_Result { get; set; }
    public Params_Get_Order_By_ORDER_ID My_Params_Get_Order_By_ORDER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_ORDER_ID_COUNT
public partial class Result_Get_Order_By_ORDER_ID_COUNT : Action_Result
{
    #region Properties.
    public List<Order> My_Result { get; set; }
    public Params_Get_Order_By_ORDER_ID_COUNT My_Params_Get_Order_By_ORDER_ID_COUNT { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_ORDER_ID_COUNT_Adv
public partial class Result_Get_Order_By_ORDER_ID_COUNT_Adv : Action_Result
{
    #region Properties.
    public List<Order> My_Result { get; set; }
    public Params_Get_Order_By_ORDER_ID_COUNT My_Params_Get_Order_By_ORDER_ID_COUNT { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_OWNER_ID
public partial class Result_Get_Order_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Order> My_Result { get; set; }
    public Params_Get_Order_By_OWNER_ID My_Params_Get_Order_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_OWNER_ID_Adv
public partial class Result_Get_Order_By_OWNER_ID_Adv : Action_Result
{
    #region Properties.
    public List<Order> My_Result { get; set; }
    public Params_Get_Order_By_OWNER_ID My_Params_Get_Order_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_Where
public partial class Result_Get_Order_By_Where : Action_Result
{
    #region Properties.
    public List<Order> My_Result { get; set; }
    public Params_Get_Order_By_Where My_Params_Get_Order_By_Where { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_By_Where_V2
public partial class Result_Get_Order_By_Where_V2 : Action_Result
{
    #region Properties.
    public List<Order> My_Result { get; set; }
    public Params_Get_Order_By_Where_V2 My_Params_Get_Order_By_Where_V2 { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_By_ORDER_DETAILS_ID
public partial class Result_Get_Order_details_By_ORDER_DETAILS_ID : Action_Result
{
    #region Properties.
    public Order_details My_Result { get; set; }
    public Params_Get_Order_details_By_ORDER_DETAILS_ID My_Params_Get_Order_details_By_ORDER_DETAILS_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_By_ORDER_DETAILS_ID_Adv
public partial class Result_Get_Order_details_By_ORDER_DETAILS_ID_Adv : Action_Result
{
    #region Properties.
    public Order_details My_Result { get; set; }
    public Params_Get_Order_details_By_ORDER_DETAILS_ID My_Params_Get_Order_details_By_ORDER_DETAILS_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_By_ORDER_ID
public partial class Result_Get_Order_details_By_ORDER_ID : Action_Result
{
    #region Properties.
    public List<Order_details> My_Result { get; set; }
    public Params_Get_Order_details_By_ORDER_ID My_Params_Get_Order_details_By_ORDER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_By_ORDER_ID_Adv
public partial class Result_Get_Order_details_By_ORDER_ID_Adv : Action_Result
{
    #region Properties.
    public List<Order_details> My_Result { get; set; }
    public Params_Get_Order_details_By_ORDER_ID My_Params_Get_Order_details_By_ORDER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_By_OWNER_ID
public partial class Result_Get_Order_details_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Order_details> My_Result { get; set; }
    public Params_Get_Order_details_By_OWNER_ID My_Params_Get_Order_details_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_By_OWNER_ID_Adv
public partial class Result_Get_Order_details_By_OWNER_ID_Adv : Action_Result
{
    #region Properties.
    public List<Order_details> My_Result { get; set; }
    public Params_Get_Order_details_By_OWNER_ID My_Params_Get_Order_details_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_items_By_ORDER_DETAILS_ID
public partial class Result_Get_Order_details_items_By_ORDER_DETAILS_ID : Action_Result
{
    #region Properties.
    public List<Order_details_items> My_Result { get; set; }
    public Params_Get_Order_details_items_By_ORDER_DETAILS_ID My_Params_Get_Order_details_items_By_ORDER_DETAILS_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv
public partial class Result_Get_Order_details_items_By_ORDER_DETAILS_ID_Adv : Action_Result
{
    #region Properties.
    public List<Order_details_items> My_Result { get; set; }
    public Params_Get_Order_details_items_By_ORDER_DETAILS_ID My_Params_Get_Order_details_items_By_ORDER_DETAILS_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID
public partial class Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID : Action_Result
{
    #region Properties.
    public Order_details_items My_Result { get; set; }
    public Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID My_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv
public partial class Result_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID_Adv : Action_Result
{
    #region Properties.
    public Order_details_items My_Result { get; set; }
    public Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID My_Params_Get_Order_details_items_By_ORDER_DETAILS_ITEMS_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_items_By_OWNER_ID
public partial class Result_Get_Order_details_items_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Order_details_items> My_Result { get; set; }
    public Params_Get_Order_details_items_By_OWNER_ID My_Params_Get_Order_details_items_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Order_details_items_By_OWNER_ID_Adv
public partial class Result_Get_Order_details_items_By_OWNER_ID_Adv : Action_Result
{
    #region Properties.
    public List<Order_details_items> My_Result { get; set; }
    public Params_Get_Order_details_items_By_OWNER_ID My_Params_Get_Order_details_items_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Owner_By_OWNER_ID
public partial class Result_Get_Owner_By_OWNER_ID : Action_Result
{
    #region Properties.
    public Owner My_Result { get; set; }
    public Params_Get_Owner_By_OWNER_ID My_Params_Get_Owner_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Owner_By_OWNER_NAME
public partial class Result_Get_Owner_By_OWNER_NAME : Action_Result
{
    #region Properties.
    public Owner My_Result { get; set; }
    public Params_Get_Owner_By_OWNER_NAME My_Params_Get_Owner_By_OWNER_NAME { get; set; }
    #endregion
}
#endregion
#region Result_Get_Owner_By_Where
public partial class Result_Get_Owner_By_Where : Action_Result
{
    #region Properties.
    public List<Owner> My_Result { get; set; }
    public Params_Get_Owner_By_Where My_Params_Get_Owner_By_Where { get; set; }
    #endregion
}
#endregion
#region Result_Get_Payment_By_OWNER_ID
public partial class Result_Get_Payment_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Payment> My_Result { get; set; }
    public Params_Get_Payment_By_OWNER_ID My_Params_Get_Payment_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Payment_By_PAYMENT_ID
public partial class Result_Get_Payment_By_PAYMENT_ID : Action_Result
{
    #region Properties.
    public Payment My_Result { get; set; }
    public Params_Get_Payment_By_PAYMENT_ID My_Params_Get_Payment_By_PAYMENT_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Payment_By_PAYMENT_ID_List
public partial class Result_Get_Payment_By_PAYMENT_ID_List : Action_Result
{
    #region Properties.
    public List<Payment> My_Result { get; set; }
    public Params_Get_Payment_By_PAYMENT_ID_List My_Params_Get_Payment_By_PAYMENT_ID_List { get; set; }
    #endregion
}
#endregion
#region Result_Get_Product_By_CATEGORY_ID
public partial class Result_Get_Product_By_CATEGORY_ID : Action_Result
{
    #region Properties.
    public List<Product> My_Result { get; set; }
    public Params_Get_Product_By_CATEGORY_ID My_Params_Get_Product_By_CATEGORY_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Product_By_OWNER_ID
public partial class Result_Get_Product_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Product> My_Result { get; set; }
    public Params_Get_Product_By_OWNER_ID My_Params_Get_Product_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Product_By_OWNER_ID_Adv
public partial class Result_Get_Product_By_OWNER_ID_Adv : Action_Result
{
    #region Properties.
    public List<Product> My_Result { get; set; }
    public Params_Get_Product_By_OWNER_ID My_Params_Get_Product_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Product_By_PRODUCT_ID
public partial class Result_Get_Product_By_PRODUCT_ID : Action_Result
{
    #region Properties.
    public Product My_Result { get; set; }
    public Params_Get_Product_By_PRODUCT_ID My_Params_Get_Product_By_PRODUCT_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Restaurant_details_By_OWNER_ID
public partial class Result_Get_Restaurant_details_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Restaurant_details> My_Result { get; set; }
    public Params_Get_Restaurant_details_By_OWNER_ID My_Params_Get_Restaurant_details_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Restaurant_details_By_OWNER_ID_Adv
public partial class Result_Get_Restaurant_details_By_OWNER_ID_Adv : Action_Result
{
    #region Properties.
    public List<Restaurant_details> My_Result { get; set; }
    public Params_Get_Restaurant_details_By_OWNER_ID My_Params_Get_Restaurant_details_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Restaurant_details_By_Where
public partial class Result_Get_Restaurant_details_By_Where : Action_Result
{
    #region Properties.
    public List<Restaurant_details> My_Result { get; set; }
    public Params_Get_Restaurant_details_By_Where My_Params_Get_Restaurant_details_By_Where { get; set; }
    #endregion
}
#endregion
#region Result_Get_Restaurant_views_By_OWNER_ID
public partial class Result_Get_Restaurant_views_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Restaurant_views> My_Result { get; set; }
    public Params_Get_Restaurant_views_By_OWNER_ID My_Params_Get_Restaurant_views_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Timing_By_OWNER_ID
public partial class Result_Get_Timing_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<Timing> My_Result { get; set; }
    public Params_Get_Timing_By_OWNER_ID My_Params_Get_Timing_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Timing_By_TIMING_ID
public partial class Result_Get_Timing_By_TIMING_ID : Action_Result
{
    #region Properties.
    public Timing My_Result { get; set; }
    public Params_Get_Timing_By_TIMING_ID My_Params_Get_Timing_By_TIMING_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_Timing_By_TIMING_ID_List
public partial class Result_Get_Timing_By_TIMING_ID_List : Action_Result
{
    #region Properties.
    public List<Timing> My_Result { get; set; }
    public Params_Get_Timing_By_TIMING_ID_List My_Params_Get_Timing_By_TIMING_ID_List { get; set; }
    #endregion
}
#endregion
#region Result_Get_User_By_OWNER_ID
public partial class Result_Get_User_By_OWNER_ID : Action_Result
{
    #region Properties.
    public List<User> My_Result { get; set; }
    public Params_Get_User_By_OWNER_ID My_Params_Get_User_By_OWNER_ID { get; set; }
    #endregion
}
#endregion
#region Result_Get_User_By_USER_ID
public partial class Result_Get_User_By_USER_ID : Action_Result
{
    #region Properties.
    public User My_Result { get; set; }
    public Params_Get_User_By_USER_ID My_Params_Get_User_By_USER_ID { get; set; }
    #endregion
}
#endregion
