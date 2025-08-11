
namespace zelis.Api.Models;

    public class CommunicationType
    {
        public string TypeCode { get; set; } = string.Empty; // PK
        public string DisplayName { get; set; } = string.Empty;
        public List<CommunicationTypeStatus> AllowedStatuses { get; set; }
    }
