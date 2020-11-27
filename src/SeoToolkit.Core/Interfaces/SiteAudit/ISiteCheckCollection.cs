using System;
using System.Collections.Generic;

namespace SeoToolkit.Core.Interfaces.SiteAudit
{
    public interface ISiteCheckCollection
    {
        IEnumerable<ISiteCheck> GetAll();
        ISiteCheck GetCheckByAlias(Guid id);
    }
}
