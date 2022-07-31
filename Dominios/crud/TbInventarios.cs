using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios.crud
{
    [Table("Inventarios")]
    public class TbInventarios
    {
        [Display(Name = "Código")]
        public Int64 Id { get; set; }

        [Display(Name = "Status do Dispositivo")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int64 StatusId { get; set; }

        [Display(Name = "Tipo da Licença")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int64 LincencaId { get; set; }


        [Display(Name = "Tipo do Dispositivo")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int64 TipoDispositivoId { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int64 FornecedorId { get; set; }

        [Display(Name = "Responsável")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int64 Responsavel { get; set; }

        [Display(Name = "Data do Cadastro")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Ativação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataAtivacao { get; set; }


        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Fabricante { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Modelo { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Display(Name = "Data de Garantia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataGarantia { get; set; }

        [Display(Name = "Tempo Para Depreciação (Meses)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int64 Depreciacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public Int64 Quantidade { get; set; }


    }
}
