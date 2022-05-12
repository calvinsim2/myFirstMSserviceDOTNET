using System.ComponentModel.DataAnnotations;

namespace MStest.Models
{
    public class GameModel
    {
        [Key]
        public int GameID { get; set; }
        public string GameName { get; set; }

        public double Price { get; set; }

    }
}
