using System;

namespace Comanda.Model.Classes
{
    public class VPedidosModel
    {
        public DateTime DataHora { get; set; }
        public int Qtd { get; set; }
        public string Cliente { get; set; }
        public string Comentario { get; set; }
        public string Produto { get; set; }
        public double Preco { get; set; }
        public string Situacao { get; set; }
    }
}
