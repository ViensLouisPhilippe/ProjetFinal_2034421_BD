using ProjetFinalBD.Models;

namespace ProjetFinalBD.ViewModels
{
    public class PlayerImageViewModel
    {
        public Player Player{ get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
