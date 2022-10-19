using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}