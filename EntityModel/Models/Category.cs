namespace EntityModel.Models
{
    public class Category : AbstractEntity
    {
        public IEnumerable<Skill> Skills { get; set; }
        // Langage, BDD, Cadre
    }
}
