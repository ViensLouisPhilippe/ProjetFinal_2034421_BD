using ProjetFinalBD.Models;

namespace ProjetFinalBD.ViewModels
{
    public class ImageUploadVM
    {
        public IFormFile? FormFile { get; set; }

        public Image Image { get; set; } = null!;

    }
}
