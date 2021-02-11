using Confluent.Kafka;
using System;
using System.Collections.Generic;

namespace NetCoreKafka.KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "foo",
                BrokerAddressFamily = BrokerAddressFamily.V4,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("my-topic");

                try
                {
                    while (true)
                    {
                        var consumeResult = consumer.Consume();
                        Console.WriteLine(consumeResult.Value);
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
