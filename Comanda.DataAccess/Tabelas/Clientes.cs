﻿using System;
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
                throw ex;
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
                        var entity = context.Clientes.Find(model.ClienteId);

                        context.Clientes.Remove(entity);
                        context.SaveChanges();

                        context.Clientes.Add(model);
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
                throw ex;
            }
        }
        public static List<ClienteModel> ListaTotal()
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
                throw ex;
            }
            
            return retorno;
        }
        
    }
}
