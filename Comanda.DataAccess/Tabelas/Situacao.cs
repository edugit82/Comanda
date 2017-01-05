﻿using System;
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
                throw;
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
                throw;
            }
        }
        public static List<SituacaoModel> ListaTotal
        {
            get
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
                    throw;
                }

                return retorno;
            }
        }        
    }
}
