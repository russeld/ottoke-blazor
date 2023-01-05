using System.ComponentModel.DataAnnotations;

namespace OttokeBlazor.Shared
{
    public class TodoCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;
    }
}
