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
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hub;
using WebAPI.Models;
using DALC;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class DataController : ControllerBase
    {


        //var hubContext = _messageHub.Clients.All;
        //await hubContext.SendProductsToUserAfterAddingIt(i_Product);

        private IHubContext<MessageHub, IMessageHubClient> _messageHub;

        public DataController(IHubContext<MessageHub, IMessageHubClient> messageHub)
        {
            try
            {
                _messageHub = messageHub;
                Console.WriteLine("1", _messageHub);
                Console.WriteLine("2", messageHub);

                Console.WriteLine("MessageHub initialized: " + (_messageHub != null));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during BLC initialization: " + ex.Message);
                throw;
            }
        }

    }
    public partial class Params_Get_Owner_By_OWNER_NAME
    {
        #region Properties
        public string NAME { get; set; }

        #endregion
    }
}
