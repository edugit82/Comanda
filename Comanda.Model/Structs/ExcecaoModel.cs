using System;

namespace Comanda.Model.Structs
{
    public struct ExcecaoModel
    {
        public DateTime DataHora { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Parametros { get; set; }
    }
}
