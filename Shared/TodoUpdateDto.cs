using System.ComponentModel.DataAnnotations;

namespace OttokeBlazor.Shared
{
    public class TodoUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
