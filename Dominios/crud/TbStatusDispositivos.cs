using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios.crud
{
    [Table("StatusDispositivos")]
    public class TbStatusDispositivos
    {
        [Display(Name ="Código")]
        public Int64 Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Cor da Legenda")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CorLegenda { get; set; }
    }
}
