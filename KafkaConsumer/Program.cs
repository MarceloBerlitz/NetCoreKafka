using Confluent.Kafka;
using System;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "foo",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe("test");

            while (true)
            {
                var consumeResult = consumer.Consume();

                Console.WriteLine(consumeResult.ToString());

                consumer.Commit();
            }

        }
    }
}
