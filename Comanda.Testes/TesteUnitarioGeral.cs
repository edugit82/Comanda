using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comanda.Model.Classes;
using Comanda.DataAccess.Contexts;

namespace Comanda.Testes
{
    [TestClass]
    public class TesteUnitarioGeral
    {
        [TestMethod]
        public void Teste01()
        {
            using (var context = new PedidosContext())
            {
                context.Clientes.ToList();
            }
        }
    }
}
