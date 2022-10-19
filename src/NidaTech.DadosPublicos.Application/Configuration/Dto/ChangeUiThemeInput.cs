using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
