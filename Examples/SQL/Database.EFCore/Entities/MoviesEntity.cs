using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("Movies")]
    public class MoviesEntity
    {
        public int MoviesId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}