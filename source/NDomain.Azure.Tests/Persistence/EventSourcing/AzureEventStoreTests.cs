﻿using Microsoft.WindowsAzure.Storage;
using NDomain.Azure.Model.EventSourcing;
using NDomain.Persistence.EventSourcing;
using NDomain.Tests.Common.Specs;
using NUnit.Framework;

namespace NDomain.Azure.Tests.Persistence.EventSourcing
{
    [TestFixture]
    public class AzureEventStoreTests : EventStoreSpecs
    {
        protected override IEventStoreDb CreateEventStorage()
        {
            return new AzureEventStore(CloudStorageAccount.DevelopmentStorageAccount, "ndomaintestsevents");
        }

        protected override void OnSetUp()
        {
            // reset events table between each test
            CloudStorageAccount.DevelopmentStorageAccount
                               .CreateCloudTableClient()
                               .GetTableReference("ndomaintestsevents")
                               .DeleteIfExists();
        }
    }
}