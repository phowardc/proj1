using System.Collections.Generic;
using System.Linq;
using zelis.Shared.Dtos;

namespace zelis.Shared.Statuses
{
    public static class GlobalStatusCatalog
    {
        public static readonly StatusOptionDto[] All =
        {
            new StatusOptionDto { StatusCode = "Draft",            Description = "Initial work-in-progress" },
            new StatusOptionDto { StatusCode = "InReview",         Description = "Awaiting review/approval" },
            new StatusOptionDto { StatusCode = "ReadyForRelease",  Description = "Approved and queued" },
            new StatusOptionDto { StatusCode = "Released",         Description = "Published/Released" },
            new StatusOptionDto { StatusCode = "Archived",         Description = "Retired/No longer active" },
        };

        // Valid codes (case-insensitive)
        public static readonly HashSet<string> Codes =
            All.Select(s => s.StatusCode).ToHashSet(System.StringComparer.OrdinalIgnoreCase);

        // Descriptions lookup (case-insensitive)
        public static readonly Dictionary<string, string> Descriptions =
            All.ToDictionary(s => s.StatusCode, s => s.Description, System.StringComparer.OrdinalIgnoreCase);
    }
}
