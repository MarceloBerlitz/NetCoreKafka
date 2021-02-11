using Confluent.Kafka;
using System.Threading.Tasks;

namespace NetCoreKafka.Infrastructure.Messaging
{

    public interface IMyProducer
    {
        Task Send(string topic, string message);
    }

    public class MyProducer : IMyProducer
    {
        public async Task Send(string topic, string message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = "test",
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            }
        }
    }
}
