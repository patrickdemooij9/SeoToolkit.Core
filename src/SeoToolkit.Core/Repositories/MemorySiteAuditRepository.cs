using SeoToolkit.Core.Interfaces.SiteAudit;
using SeoToolkit.Core.Models.SiteAudit;

namespace SeoToolkit.Core.Repositories
{
    public class MemorySiteAuditRepository : BaseMemoryRepository<SiteAuditDto>, ISiteAuditRepository
    {
    }
}
