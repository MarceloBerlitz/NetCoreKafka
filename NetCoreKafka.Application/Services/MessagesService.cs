using NetCoreKafka.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreKafka.Application.Services
{

    public interface IMessagesService
    {
        Task Send(string message);
    }
    public class MessagesService : IMessagesService
    {
        private readonly IMyProducer _myProducer;

        public MessagesService(IMyProducer myProducer)
        {
            this._myProducer = myProducer;
        }

        public async Task Send(string what)
        {
            await _myProducer.Send("my-topic", what);
        }
    }
}
