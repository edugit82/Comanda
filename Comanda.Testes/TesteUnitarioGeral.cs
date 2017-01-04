using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comanda.Model.Classes;
using Comanda.DataAccess;
using System.Collections.Generic;

namespace Comanda.Testes
{
    [TestClass]
    public class TesteUnitarioGeral
    {        
        ClienteModel cliente { get; set; }
        ProdutoModel produto { get; set; }
        List<SituacaoModel> situacao { get; set; }
        PedidosModel pedido { get; set; }

        [TestInitialize]
        public void Inicia()
        {
            
        }
        [TestMethod]
        public void Teste01()
        {
            DataAccess.Tabelas.Pedidos.ListaTotal.ToList();
        }
        [TestMethod]
        public void Teste02()
        {
            var path = @"C:\Users\Eduardo\Documents\visual studio 2013\Projects\Comanda\Comanda.Excecao\LogErros\LogErros.json";
            var erros = new Excecao.ManipulaArquivo().AbreArquivo(path).ToList();
        }
        [TestCleanup]
        public void Limpa()
        {
           
        }
    }
}
