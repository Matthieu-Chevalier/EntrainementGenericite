using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace EntityModel.Models

{
    public class Training : AbstractEntity
    {


        [Required]
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MinValue;

        //One to Many (une entreprise peut avoir plusieur Jobs->Evolution interne par exemple)
        public Enterprise? Enterprise { get; set; }
        public int EnterpriseId { get; set; }




        public bool Graduation { get; set; } = false;
        private DateTime _graduationDate;

        public Training()
        {
             
        }

        public DateTime GraduationDate
        {
            get { return _graduationDate; }
            set
            {
                if (Graduation == true)
                {
                    _graduationDate = value;
                }
                else
                {
                    _graduationDate = DateTime.MinValue;
                }
            }

        }
       
    }
}
