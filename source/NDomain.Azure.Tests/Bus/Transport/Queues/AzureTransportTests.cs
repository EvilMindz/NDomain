﻿using Microsoft.WindowsAzure.Storage;
using NDomain.Bus.Transport;
using NDomain.Bus.Transport.Azure.Queues;
using NUnit.Framework;
using NDomain.Tests.Common.Specs;

namespace NDomain.Azure.Tests.Bus.Transport.Queues
{
    [TestFixture]
    public class AzureTransportTests : TransportSpecs
    {
        public override ITransportFactory CreateFactory()
        {
            return new QueueTransportFactory(CloudStorageAccount.DevelopmentStorageAccount, "ndomain-azure-tests");
        }

        private void Clear()
        {
            var queues = CloudStorageAccount.DevelopmentStorageAccount
                                            .CreateCloudQueueClient().ListQueues("ndomain-azure-tests");

            foreach (var queue in queues)
            {
                queue.Clear();
            }
        }

        protected override void OnSetUp()
        {
            Clear();
        }

        protected override void OnTearDown()
        {
            Clear();
        }
    }
}
