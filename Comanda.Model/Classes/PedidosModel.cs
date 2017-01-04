﻿using System;
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
        /// <summary>
        /// Preço do pedido
        /// </summary>
        public double Preco { get; set; }
        /// <summary>
        /// Cliente Id
        /// </summary>
        public int ClienteId { get; set; }
        /// <summary>
        /// Lista Clientes
        /// </summary>
        public virtual ClienteModel Cliente { get; set; }
        /// <summary>
        /// Produto Id
        /// </summary>
        public int ProdutoId { get; set; } 
        /// <summary>
        /// Lista Produtos.
        /// </summary>
        public virtual ProdutoModel Produto { get; set; }
        public int SituacaoId { get; set; }
        /// <summary>
        /// Lista situação
        /// </summary>
        public virtual SituacaoModel Situacao { get; set; }
        
    }
}
