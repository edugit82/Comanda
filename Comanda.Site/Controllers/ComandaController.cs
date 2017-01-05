using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Comanda.Business;
using Comanda.Model.Classes;
using Comanda.Excecao;
using Comanda.Site.ViewModels;

namespace Comanda.Site.Controllers
{
    public class ComandaController : Controller
    {
        //
        // GET: /Comanda/
                
        public ActionResult Pedidos()
        {
            var viewmodel = new Site.ViewModels.PedidosViewModel();

            try
            {
                using (var business = new Business.Business())
                {
                    viewmodel.ListaSituacao = DataAccess.Tabelas.Situacao.ListaTotal;
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw; 
            }           

            return View(viewmodel);
        }
        public ActionResult Clientes()
        {
            return View();
        }
        public ActionResult Produtos()
        {
            return View();
        }
        public ActionResult ListaPedidos()
        {
            var situacao = DataAccess.Tabelas.Situacao.ListaTotal.ToList();
            return View(situacao);
        }
        public ActionResult Teste()
        {            
            return View();
        }
        [HttpPost]
        public PartialViewResult CadastraPedidos(ViewModels.PedidosViewModel form)
        {
            
            try 
            {
                var model = new PedidosModel() { 
                 DataHora = DateTime.Now,
                 Qtd = form.Qtd,
                 Preco = form.Preco,
                 ClienteId = form.ClienteId,
                 ProdutoId = form.ProdutoId,
                 SituacaoId = form.SituacaoId
                };

                DataAccess.Tabelas.Pedidos.Add(model);                
                
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            
            return PartialView("~/Views/PartialViews/Sucesso.cshtml");
        }
        [HttpPost]
        public PartialViewResult ClienteCadastro(ViewModels.PedidosViewModel form)
        {
            return PartialView("~/Views/PartialViews/CadastraCliente.cshtml", form);
        }
        [HttpPost]
        public PartialViewResult ProdutoCadastro(ViewModels.PedidosViewModel form)
        {
            return PartialView("~/Views/PartialViews/CadastraProduto.cshtml", form);
        }
        [HttpPost]
        public JsonResult SalvaCliente(ViewModels.PedidosViewModel form)
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);
            try
            {

                var cliente = new ClienteModel() { Nome = form.Nome.Trim(), Comentario = form.Comentario.Trim() };

                using (var business = new Business.Business())
                {
                    if (business.ClienteExiste(cliente))
                    {
                        cliente = DataAccess.Tabelas.Clientes.ListaTotal.Find(x => x.Nome.Trim() == cliente.Nome && x.Comentario.Trim() == cliente.Comentario);
                    }
                    else
                    {
                        DataAccess.Tabelas.Clientes.Add(cliente);
                        cliente = DataAccess.Tabelas.Clientes.ListaTotal.Last();
                    }
                }

                retorno = Json(new { cliente.ClienteId, cliente.Nome, cliente.Comentario }, JsonRequestBehavior.AllowGet);                
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }

            return retorno;
        }
        [HttpPost]
        public JsonResult SalvaProduto(ViewModels.PedidosViewModel form)
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            try
            {
                var produto = new ProdutoModel() { Descricao = form.Produto.Trim(), Preco = form.Preco };

                using (var business = new Business.Business())
                {
                    if (business.ProdutoExiste(produto))
                    {
                        produto = DataAccess.Tabelas.Produtos.ListaTotal.Find(x => x.Descricao.Trim() == produto.Descricao && x.Preco == produto.Preco);
                    }
                    else
                    {
                        DataAccess.Tabelas.Produtos.Add(produto);
                        produto = DataAccess.Tabelas.Produtos.ListaTotal.Last();
                    }
                }

                retorno = Json(new { produto.ProdutoId, produto.Descricao, produto.Preco }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }

            return retorno;
        }
        [HttpPost]
        public JsonResult ListaClientes() 
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            try
            {
                var lista = DataAccess.Tabelas.Clientes.ListaTotal
                           .Select(x => x.ClienteId.ToString("00") + " - " + 
                                        x.Nome + (x.Comentario.Trim().Length > 0 ? " - " + 
                                        x.Comentario : ""))
                                        .ToList<string>();
                retorno = Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            
            return retorno; 
        }
        [HttpPost]
        public JsonResult ListaProdutos()
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            try
            {
                var lista = DataAccess.Tabelas.Produtos.ListaTotal.Select(x => x.ProdutoId.ToString("00") + " - "  + x.Descricao + " - " + x.Preco.ToString("0.00")).ToList<string>();
                retorno = Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }

            return retorno; 
        }        
        [HttpPost]
        public JsonResult DeletaPedido(string datahora)
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            try
            {                
                var entity = DataAccess.Tabelas.Pedidos.ListaTotal.FirstOrDefault(x => x.DataHora.ToString("dd/MM/yyyy HH:mm:ss") == datahora);
                entity.SituacaoId = DataAccess.Tabelas.Situacao.ListaTotal.Max(x => x.SituacaoId);
                DataAccess.Tabelas.Pedidos.Update(entity);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            return retorno;
        }
        [HttpPost]
        public JsonResult CarregaClientes()
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);
            try
            {
                var lista = DataAccess.Tabelas.Clientes.ListaTotal;
                retorno = Json(lista.Select(x => new {ClienteId = x.ClienteId.ToString("00"),x.Nome,x.Comentario,Editar = x.ClienteId }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            return retorno;
        }
        [HttpPost]
        public JsonResult CarregaProdutos()
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);
            try
            {
                var lista = DataAccess.Tabelas.Produtos.ListaTotal;
                retorno = Json(lista.Select(x => new { ProdutoId = x.ProdutoId,Descricao = x.Descricao,Preco = x.Preco.ToString("0.00"),Editar = x.ProdutoId }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            return retorno;
        }
        [HttpPost]
        public PartialViewResult EditarCliente(string Id)
        {
            var retorno = new PartialViewResult();
            try
            {
                var dado = DataAccess.Tabelas.Clientes.ListaTotal.FirstOrDefault(x => x.ClienteId == int.Parse(Id));
                retorno = PartialView("~/Views/PartialViews/EditarCliente.cshtml", dado);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            return retorno;
        }
        [HttpPost]
        public PartialViewResult EditarProduto(string Id)
        {
            var retorno = new PartialViewResult();
            try
            {
                var dado = DataAccess.Tabelas.Produtos.ListaTotal.FirstOrDefault(x => x.ProdutoId == int.Parse(Id));
                retorno = PartialView("~/Views/PartialViews/EditarProduto.cshtml", dado);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            return retorno;
        }
        [HttpPost]
        public JsonResult AtualizaDadosCliente(ClienteModel model)
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            try
            {
                DataAccess.Tabelas.Clientes.Update(model);
                retorno = Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            
            return retorno;
        }
        [HttpPost]
        public JsonResult AtualizaDadosProduto(ProdutoModel model)
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            try
            {
                DataAccess.Tabelas.Produtos.Update(model);
                retorno = Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }

            return retorno;
        }
        [HttpPost]
        public JsonResult FiltroListaPedidos(int ClienteId, int ProdutoId, DateTime DataInicio, DateTime DataFim,int Situacao)
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            using (var business = new Business.Business())
            {
                var listadatahora = business.ListaTotalFiltro(ClienteId, ProdutoId, DataInicio, DataFim, Situacao);
                var listatotal = DataAccess.Views.PedidosView.ListaTotal;
                var listaretorno = new List<VPedidosModel>();

                listadatahora.ForEach(a => {
                    listaretorno.AddRange(listatotal.Where(x => x.DataHora == a).ToList());
                });

                retorno = Json(listaretorno.Select(x => new
                {
                    DataHora = x.DataHora.ToString("dd/MM/yyyy HH:mm:ss"),
                    x.Cliente,
                    x.Comentario,
                    x.Produto,
                    Preco = x.Preco.ToString("0.00"),
                    x.Qtd,
                    x.Situacao,
                    Excluir = x.DataHora.ToString("dd/MM/yyyy HH:mm:ss")
                }), JsonRequestBehavior.AllowGet);                
            }
            
            return retorno;
        }
        [HttpPost]
        public JsonResult AtualizaSituacaoPedido(DateTime DataHora, int Situacao)
        {
            var retorno = Json("{}", JsonRequestBehavior.AllowGet);

            try
            {
                var model = DataAccess.Tabelas.Pedidos.ListaTotal.FirstOrDefault(x => x.DataHora.ToString("dd/MM/yyyy HH:mm:ss") == DataHora.ToString("dd/MM/yyyy HH:mm:ss"));
                model.SituacaoId = Situacao;
                DataAccess.Tabelas.Pedidos.Update(model);
                var text = DataAccess.Tabelas.Situacao.ListaTotal.FirstOrDefault(x => x.SituacaoId == Situacao).Descricao;

                retorno = Json("{situacao : "+text+"}", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
            
            return retorno;
        }
    }
}
