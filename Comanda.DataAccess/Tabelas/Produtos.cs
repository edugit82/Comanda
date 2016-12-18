﻿using System;
using System.Collections.Generic;
using System.Linq;
using Comanda.Model.Classes;
using Comanda.DataAccess.Contexts;
using Comanda.Excecao;

namespace Comanda.DataAccess.Tabelas
{
    public static class Produtos
    {
        public static void Add(ProdutoModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {
                    context.Produtos.Add(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw ex;
            }
        }
        public static void Update(ProdutoModel model)
        {
            using (var context = new PedidosContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var entity = context.Produtos.Find(model.ProdutoId);

                        context.Produtos.Remove(entity);
                        context.SaveChanges();

                        context.Produtos.Add(model);
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
        public static void Remove(ProdutoModel model)
        {
            try
            {
                using (var context = new PedidosContext())
                {
                    context.Produtos.Remove(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Excecao.Excecao().GravaExcecao(ex, "{}");
                throw ex;
            }
        }
        public static List<ProdutoModel> ListaTotal()
        {
            var retorno = new List<ProdutoModel>();

            try
            {
                using (var context = new PedidosContext())
                {
                    retorno = context.Produtos.OrderBy(x => x.ProdutoId).ToList();
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
