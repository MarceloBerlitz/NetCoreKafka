using Microsoft.AspNetCore.Mvc;
using NetCoreKafka.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NetCoreKafka.Api.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessagesController
    {
        private readonly IMessagesService messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public void sendMessage([FromBody] string message)
        {
            messagesService.Send(message);
        }

    }
}
