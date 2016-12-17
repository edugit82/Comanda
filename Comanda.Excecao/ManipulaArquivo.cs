using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Comanda.Model.Structs;

namespace Comanda.Excecao
{
    public class ManipulaArquivo
    {
        public List<ExcecaoModel> AbreArquivo(string endereco)
        {
            var retorno = new List<ExcecaoModel>();
            if (File.Exists(endereco))
            {
                using (var file = File.OpenText(endereco))
                {
                    retorno = JsonConvert.DeserializeObject<List<ExcecaoModel>>(file.ReadToEnd());
                }
            }
            return retorno;
        }
        public void SalvaArquivo(string endereco, ExcecaoModel dado)
        {
            var arquivo = this.AbreArquivo(endereco);
            arquivo.Add(dado);
            arquivo = arquivo.GroupBy(x => x)
                             .Select(x => new ExcecaoModel() { DataHora = x.Key.DataHora, Message = x.Key.Message, Source = x.Key.Source, StackTrace = x.Key.StackTrace, Parametros = x.Key.Parametros })
                             .OrderByDescending(x => x.DataHora)
                             .ToList();

            var json = JsonConvert.SerializeObject(arquivo);

            if (File.Exists(endereco))
                File.Delete(endereco);

            File.AppendAllText(endereco, json);
        }
        public void SalvaArquivo(string endereco, List<ExcecaoModel> lista)
        {
            lista.ForEach(x =>
            {
                this.SalvaArquivo(endereco, x);
            });
        }
    }
}
