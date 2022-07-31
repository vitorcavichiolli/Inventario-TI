using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios.crud
{
    [Table("Fornecedores")]

    public class TbFornecedores
    {
        [Display(Name = "Código")]
        public Int64 Id { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Razao { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }


        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CNPJ { get; set; }

        [Display(Name = "Data do Cadastro")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataCadastro { get; set; }
    }
}
