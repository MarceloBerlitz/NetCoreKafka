using Microsoft.AspNetCore.Mvc;
using NetCoreKafka.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreKafka.Api.Controllers
{
    public class MessageContainer
    {
        public string Message { get; set; }
    }

    [ApiController]
    [Route("Messages")]
    public class MessagesController : ControllerBase
    {

        private readonly IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpPost]
        public async Task sendMessage([FromBody] MessageContainer message)
        {
            await _messagesService.Send(message.Message);
        }

    }
}
