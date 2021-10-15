using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_LOGS.Model
{
    /*
    public class LogEmailViewModel
    {
        public string id { get; set; }

        public List<RecordeViewModel> Records { get; set; }
    }

    public class RecordeViewModel
    {
        public string EventSource { get; set; }
        public string EventVersion { get; set;  }
        public SNS Sns { get; set; }
    }

    public class SNS
    {
        public string Message { get; set; }

        public string MessageId { get; set; }
        
    }
    */
    /*
   * ModeloElton
   * https://json2csharp.com/ para mapear o json
   */
    public class Tags
    {
        public string IdExame { get; set; }

        public string IdEmpresa { get; set; }
    }

    public class Mail
    {
        public string MessageId { get; set; }
        public Tags Tags { get; set; }
    }

    public class LogEmailMessage
    {
        public string EventType { get; set; }
        public Mail Mail { get; set; }
    }

    public class Sns
    {
        public string MessageId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Record
    {
        public Sns Sns { get; set; }
    }

    public class LogEmailSentRecords
    {
        public List<Record> Records { get; set; }
    }
}