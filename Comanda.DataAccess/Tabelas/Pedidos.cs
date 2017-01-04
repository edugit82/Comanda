using System;
using System.Collections.Generic;
using System.Linq;
using Comanda.Model.Classes;
using Comanda.DataAccess.Contexts;
using Comanda.Excecao;

namespace Comanda.DataAccess.Tabelas
{
    public static class Pedidos
    {
        public static void Add(PedidosModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {
                    context.Pedidos.Add(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw ex;
            }
        }
        public static void Update(PedidosModel model)
        {
            using (var context = new PedidosContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();        

                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        new Excecao.Excecao().GravaExcecao(ex, "{}");
                        throw ex;
                    }
                }
            }
        }
        public static void Remove(PedidosModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {
                    context.Pedidos.Remove(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw ex;
            }
        }
        public static List<PedidosModel> ListaTotal
        {
            get
            {
                var retorno = new List<PedidosModel>();

                try
                {
                    using (var context = new PedidosContext())
                    {
                        retorno = context.Pedidos.OrderBy(x => x.DataHora).ToList();
                    }
                }
                catch (Exception ex)
                {
                    new Excecao.Excecao().GravaExcecao(ex, "{}");
                    throw ex;
                }

                return retorno;
            }
        }        
    }
}
