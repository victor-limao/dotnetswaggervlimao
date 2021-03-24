using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetSwaggerVictorLimao.Models
{
    public class UserData
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome"), Required(ErrorMessage = "Nome é obrigatório."), MinLength(3, ErrorMessage = "Nome deve ser no mínimo 3 caracteres")]
        public string Name { get; set; }
        [Display(Name = "CPF"), Required(ErrorMessage = "CPF é obrigatório."), MinLength(11), MaxLength(11)]
        public string CPF { get; set; }
        [Display(Name = "Sexo"), Required(ErrorMessage = "Sexo é obrigatório."), StringLength(1, ErrorMessage = "Sexo não pode ser maior que 1 caracter. Preencher com 'M' ou 'F'")]
        public string Gender { get; set; }
    }
}
