using System;
using System.ComponentModel.DataAnnotations;

namespace API_LOGS.Model
{
    public class LogEmail
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = "O compo {0} é obrigatório")]
        public int CodAnamnese { get; set; }

        [Required(ErrorMessage = "O compo {0} é obrigatório")]
        public int CodEmpresa { get; set; }

        [Required(ErrorMessage = "O compo {0} é obrigatório")]
        public DateTime DataLeitura { get; set; }

    }
}