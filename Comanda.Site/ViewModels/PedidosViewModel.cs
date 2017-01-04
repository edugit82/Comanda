using Comanda.Model.Classes;
using System.Collections.Generic;

namespace Comanda.Site.ViewModels
{
    public class PedidosViewModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Comentario { get; set; }
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public double Preco { get; set; }
        public int Qtd { get; set; }
        public int SituacaoId { get; set; }        
        public List<SituacaoModel> ListaSituacao { get; set; }
        public List<VPedidosModel> ListaPedidos { get; set; }      
    }
}