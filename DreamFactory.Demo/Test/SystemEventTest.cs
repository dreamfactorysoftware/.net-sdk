namespace DreamFactory.Demo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Event;
    using DreamFactory.Rest;

    public class SystemEventTest : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            string eventName = "system.get.pre_process";

            // create
            EventScriptRequest createRequest = CreateEventScript();
            EventScriptResponse createResponse = await systemApi.CreateEventScriptAsync(eventName, createRequest, new SqlQuery());
            Console.WriteLine("CreateEventScriptAsync(): Created script {0}", createResponse.Name);
            
            // delete
            EventScriptResponse deleteResponse = await systemApi.DeleteEventScriptAsync(eventName, new SqlQuery());
            Console.WriteLine("DeleteEventScriptAsync(): Deleted script {0}", deleteResponse.Name);
        }

        private EventScriptRequest CreateEventScript()
        {
            return new EventScriptRequest
            {
                Name = "my_event_script",
                Type = "v8js",
                IsActive = true,
                AffectsProcess = true,
                Content = "text",
                Config = "text"
            };
        }
    }
}