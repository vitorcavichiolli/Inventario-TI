using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios.crud
{
    [Table("Usuarios")]

    public class TbUsuarios
    {
        [Display(Name = "Código")]
        public Int64 Id { get; set; }


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }


        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Matricula { get; set; }

        [Display(Name = "Data do Cadastro")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataCadastro { get; set; }
    }
}
