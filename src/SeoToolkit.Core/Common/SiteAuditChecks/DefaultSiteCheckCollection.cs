using System;
using System.Collections.Generic;
using System.Linq;
using SeoToolkit.Core.Interfaces.SiteAudit;

namespace SeoToolkit.Core.Common.SiteAuditChecks
{
    public class DefaultSiteCheckCollection : ISiteCheckCollection
    {
        private readonly List<ISiteCheck> _checks;

        public DefaultSiteCheckCollection()
        {
            _checks = new List<ISiteCheck>()
            {
                new BrokenLinkCheck()
            };
        }

        public IEnumerable<ISiteCheck> GetAll()
        {
            return _checks;
        }

        public ISiteCheck GetCheckByAlias(Guid id)
        {
            return _checks.FirstOrDefault(it => id.Equals(id));
        }
    }
}
