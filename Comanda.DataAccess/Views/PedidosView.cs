using System;
using System.Collections.Generic;
using System.Linq;
using Comanda.Model.Classes;
using Comanda.DataAccess.Contexts;
using Comanda.Excecao;

namespace Comanda.DataAccess.Views
{
    public static class PedidosView
    {
        public static List<PedidosViewModel> ListaTotal()
        {
            var retorno = new List<PedidosViewModel>();

            try
            {
                using (var context = new PedidosContext())
                {
                    retorno = context.Database.SqlQuery<PedidosViewModel>("select * from PedidosView (nolock)").ToList();
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
