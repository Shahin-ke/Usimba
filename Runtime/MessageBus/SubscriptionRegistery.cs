using System.Collections.Generic;
using System.Linq;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.MessageBus
{
    public class SubscriptionRegistery : List<SubscriptionRegisteryItem>
    {
        public bool ContainsRule(MessageRouteRule routeRule)
        {
            return this.Any(item => item.Route == routeRule);
        }

        public IEnumerable<SubscriptionRegisteryItem> ItemsByRule(MessageRouteRule routeRule)
        {
            return this.Where(item => item.Route == routeRule);
        }

        public IEnumerable<SubscriptionRegisteryItem> GetRuleSubscriptions(MessageRouteRule rule)
        {
            return this.Where(item => item.Route == rule);
        }
    }
}