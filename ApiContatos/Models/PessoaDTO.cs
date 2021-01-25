using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiContatos.Models
{
    public class PessoaDTO
    {

        public int PessoaId { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(30)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(30)]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(9)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(30)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo {0} é de preenchimento obrigatório")]
        [MaxLength(16)]
        public string Telefone { get; set; }

        //public int PessoaId { get; set; }

        //public string Nome { get; set; }

        //public string Sobrenome { get; set; }

        //public string Nacionalidade { get; set; }

        //public string CEP { get; set; }

        //public string CPF { get; set; }

        //public string Estado { get; set; }

        //public string Cidade { get; set; }

        //public string Logradouro { get; set; }

        //public string Email { get; set; }

        //public string Telefone { get; set; }
    }
}