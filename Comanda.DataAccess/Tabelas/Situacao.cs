using System;
using System.Collections.Generic;
using System.Linq;
using Comanda.Model.Classes;
using Comanda.DataAccess.Contexts;
using Comanda.Excecao;

namespace Comanda.DataAccess.Tabelas
{
    public static class Situacao
    {
        public static void Add(SituacaoModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {                    
                    context.Situacao.Add(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw ex;
            }
        }
        public static void Update(SituacaoModel model)
        {
            using (var context = new PedidosContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var entity = context.Situacao.Find(model.SituacaoId);

                        context.Situacao.Remove(entity);
                        context.SaveChanges();

                        context.Situacao.Add(model);
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
        public static void Remove(SituacaoModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {
                    context.Situacao.Remove(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw ex;
            }
        }
        public static List<SituacaoModel> ListaTotal()
        {
            var retorno = new List<SituacaoModel>();

            try
            {
                using (var context = new PedidosContext())
                {
                    retorno = context.Situacao.OrderBy(x => x.SituacaoId).ToList();
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
