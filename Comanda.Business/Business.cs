using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comanda.Excecao;
using Comanda.DataAccess.Tabelas;
using Comanda.Model.Classes;

namespace Comanda.Business
{
    public class Business : IDisposable
    {        
        public bool ClienteExiste(ClienteModel model)
        {
            var retorno = false;
            try
            {
                retorno = Clientes.ListaTotal.Exists(x => x.Nome.Trim() == model.Nome.Trim() && x.Comentario.Trim() == model.Comentario.Trim());
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }

            return retorno;
        }
        public bool ProdutoExiste(ProdutoModel model)
        {
            var retorno = false;
            try
            {
                retorno = Produtos.ListaTotal.Exists(x => x.Descricao == model.Descricao && x.Preco == model.Preco);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }

            return retorno;
        }
        public string ListaClientes()
        {
            var retorno = "[ ";
            var i = 0;
            var last = DataAccess.Tabelas.Clientes.ListaTotal.Last();
            var lastindex = DataAccess.Tabelas.Clientes.ListaTotal.FindIndex(x => x.ClienteId == last.ClienteId);

            DataAccess.Tabelas.Clientes.ListaTotal.ForEach(x => {
                var text = x.Nome + " - " + x.Comentario;
                retorno += i < lastindex ? text+ "," : text;                
                i++;
            });
            retorno += " ]";
            return retorno;
        }
        public string ListaProdutos()
        {
            var retorno = "[ ";
            var i = 0;
            var last = DataAccess.Tabelas.Produtos.ListaTotal.Last();
            var lastindex = DataAccess.Tabelas.Produtos.ListaTotal.FindIndex(x => x.ProdutoId == last.ProdutoId);

            DataAccess.Tabelas.Produtos.ListaTotal.ForEach(x =>
            {
                var text = x.Descricao + " - " + x.Preco.ToString("0.00");
                retorno += i < lastindex ? text + "," : text;
                i++;
            });
            retorno += " ]";
            return retorno;
        }
        public List<DateTime> ListaTotalFiltro(int ClienteId, int ProdutoId, DateTime DataInicio, DateTime DataFim, int Situacao)
        {
            DataFim += TimeSpan.Parse("23:59:59");
            var retorno = new List<PedidosModel>();

            var validacliente = ClienteId > 0;
            var validaproduto = ProdutoId > 0;
            var validadata = DataInicio > new DateTime(2000, 1, 1) && DataFim > new DateTime(2000, 1, 1);
            var validasituacao = Situacao < 3;

            var listatotal = DataAccess.Tabelas.Pedidos.ListaTotal.Where(x => x.SituacaoId < 3).ToList();
            
            if (validacliente)
                retorno = !retorno.Any() ? listatotal.Where(x => x.ClienteId == ClienteId).ToList() : retorno.Where(x => x.ClienteId == ClienteId).ToList();
            
            if (validaproduto)
                retorno = !retorno.Any() ? listatotal.Where(x => x.ProdutoId == ProdutoId).ToList() : retorno.Where(x => x.ProdutoId == ProdutoId).ToList();
            
            if (validadata)
                retorno = !retorno.Any() ? listatotal.Where(x => x.DataHora >= DataInicio && x.DataHora <= DataFim).ToList() : retorno.Where(x => x.DataHora >= DataInicio && x.DataHora <= DataFim).ToList();
            
            if (validasituacao)
                retorno = !retorno.Any() ? listatotal.Where(x => x.SituacaoId == Situacao).ToList() : retorno.Where(x => x.SituacaoId == Situacao).ToList();

            if (!validacliente && !validaproduto && !validadata && !validasituacao)
                retorno = listatotal;

            return retorno.Select(x => x.DataHora).OrderByDescending(x => x).ToList();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);            
        }
        ~Business()
        {
            this.Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
