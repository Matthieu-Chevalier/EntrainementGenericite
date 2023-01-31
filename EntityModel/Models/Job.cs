using System.ComponentModel.DataAnnotations;

namespace EntityModel.Models

{
    public class Job : AbstractEntity
    {


        [Required]
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        //On pourra prévoir d'aller chercher le code postal via l'API du gouvernement
        public string City { get; set; } = String.Empty;


        //One to Many (une entreprise peut avoir plusieur Jobs->Evolution interne par exemple)
        public Enterprise? Enterprise { get; set; }
        public int EnterpriseId { get; set; }

        public List<Goal>? Goals { get; set; }
    }
}
