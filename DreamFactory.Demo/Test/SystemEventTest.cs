namespace DreamFactory.Demo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.System.Event;
    using DreamFactory.Rest;

    public class SystemEventTest : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            IEnumerable<EventCacheResponse> events = await systemApi.GetEventsAsync(true);
            Console.WriteLine("User events:");
            var paths = events.Single(x => x.Name == "user").Paths;
            IEnumerable<string> userEvents = from p in paths
                                             from v in p.Verbs
                                             from fv in FlattenVerbs(v)
                                             select p.Path + " " + fv;
            foreach (string userEvent in userEvents)
            {
                Console.WriteLine("\t{0}", userEvent);
            }
        }

        private static IEnumerable<string> FlattenVerbs(EventVerbs verbs)
        {
            return verbs.Event.Select(@event => verbs.Type.ToUpperInvariant() + " " + @event);
        }
    }
}