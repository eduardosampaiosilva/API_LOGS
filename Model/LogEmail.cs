using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_LOGS.Model
{
    public class LogEmail
    {
        [Required(ErrorMessage = "O compo {0} é obrigatório")]
        [Key] public string Id { get; set; }

        [Required(ErrorMessage = "O compo {0} é obrigatório")]
        public string EventType { get; set; }

        [Required(ErrorMessage = "O compo {0} é obrigatório")]
        public string IdExame { get; set; }

        [Required(ErrorMessage = "O compo {0} é obrigatório")]
        public string IdEmpresa { get; set; }

    }

    public class Recorde
    {
        public string EventSource { get; set; }
    }
}