using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda.Model.Classes
{
    /// <summary>
    /// Tabela Pedidos
    /// </summary>
    public class PedidosModel
    {       
        /// <summary>
        /// Chave primária da tabela pedidos
        /// </summary>
        [Key]
        public DateTime DataHora { get; set; }
        /// <summary>
        /// Quantide do produto do pedido
        /// </summary>
        public int Qtd { get; set; }
        
    }
}
