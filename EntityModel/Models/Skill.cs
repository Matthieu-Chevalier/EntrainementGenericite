using System.ComponentModel.DataAnnotations;

namespace EntityModel.Models

{
    public class Skill : AbstractEntity
    {

        [Range(1, 5)]
        public int Level { get; set; } = 1;

        public bool IsHard { get; set; } = false;

        public Category Category { get; set; }

        public int? CategoryId { get; set; } = 1;





    }
}
