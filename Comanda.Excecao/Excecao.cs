﻿using System;
using System.Collections.Generic;
using System.Linq;
using Comanda.Model.Structs;

namespace Comanda.Excecao
{
    public class Excecao
    {
        private ManipulaArquivo marquivo = new ManipulaArquivo();
        private string endereco { get; set; }
        public Excecao()
        {
            var bbase = System.Environment.CurrentDirectory;
            var split = bbase.Split("\\".ToCharArray()).ToList();

            foreach (var x in split)
            {
                if (x != "Comanda")
                    this.endereco += x + @"\";
                else
                {
                    this.endereco += x + @"\" + "Comanda.Excecao" + @"\" + "LogErros" + @"\" + "LogErros.json";
                    break;
                }
            }
        }
        public void GravaExcecao(Exception ex, string parametros)
        {
            var lista = new List<ExcecaoModel>();
            var inner = ex;

            do
            {
                lista.Add(new ExcecaoModel() { DataHora = DateTime.Now, Message = inner.Message, Source = inner.Source, StackTrace = inner.StackTrace, Parametros = parametros });
                inner = inner.InnerException;
            }
            while (inner != null);

            if (lista.Any())
            {
                marquivo.SalvaArquivo(this.endereco, lista);
            }

            throw new Exception("throw", ex);
        }
    }
}
