using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VesselTracking.Api.Data
{
    [Table("Ports")]
    public class Port
    {
        [Key]
        public int DockingPortId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; } 

        public int capacityDeadweight { get; set; }     // Max deadweight tons it can handle

        public bool IsAvailable { get; set; } // For docking availability

        //table sql connection to access related vessels becaus eit is a one to many as one port can have many vessesl docked
        public ICollection<Vessel> Vessels { get; set; }
    }
}
