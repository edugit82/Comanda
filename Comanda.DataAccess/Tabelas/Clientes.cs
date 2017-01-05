using System;
using System.Collections.Generic;
using System.Linq;
using Comanda.Model.Classes;
using Comanda.DataAccess.Contexts;
using Comanda.Excecao;

namespace Comanda.DataAccess.Tabelas
{
    public static class Clientes
    {        
        public static void Add(ClienteModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {
                    context.Clientes.Add(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
        }
        public static void Update(ClienteModel model)
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
                        throw;
                    }
                }
            }
        }
        public static void Remove(ClienteModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {
                    context.Clientes.Remove(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw;
            }
        }
        public static List<ClienteModel> ListaTotal
        {
            get
            {
                var retorno = new List<ClienteModel>();

                try
                {
                    using (var context = new PedidosContext())
                    {
                        retorno = context.Clientes.OrderBy(x => x.ClienteId).ToList();
                    }
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
}
