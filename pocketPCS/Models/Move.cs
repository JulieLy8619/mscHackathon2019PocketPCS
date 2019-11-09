using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pcsHackathon2019.Models
{
    public class Move
    {
        public string UserId { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy}")]
        public DateTime EndDate { get; set; }

        [Required]
        public Budget Budget { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Start Station")]
        public ArmyDutyStations StartStation { get; set; }

        [Required]
        [DisplayName("End Station")]
        public ArmyDutyStations EndStation { get; set; }

        public TimeSpan Duration {
            get
            {
                return EndDate - StartDate;
            }
        }
    }
}
