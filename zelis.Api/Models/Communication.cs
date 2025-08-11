namespace zelis.Api.Models;

// public class Communication
// {

//     public Guid Id { get; set; } = Guid.NewGuid(); //pk
//     public string Title { get; set; } = string.Empty;

//     //public int CommunicationTypeId { get; set; }          // explicit FK
//     //public CommunicationType Type { get; set; } = null!;   // required nav

//     public string TypeCode { get; set; } = string.Empty;   
//     public string CurrentStatus { get; set; } = string.Empty; //fk
//     public DateTime LastUpdatedUtc { get; set; }

//     // public ICollection<CommunicationStatusHistory> StatusHistory { get; set; } 
//     //     = new List<CommunicationStatusHistory>();
// }


//     // public Guid Id { get; set; } = Guid.NewGuid();
//     // public string Title { get; set; } = string.Empty;

//     // //explicit fk

//     // datetime

    public class Communication
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string TypeCode { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public DateTime LastUpdatedUtc { get; set; }
    }
