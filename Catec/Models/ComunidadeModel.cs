using Catec.Uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catec.Models
{
    public class ComunidadeModel
    {
        public string IdComunidade { get; set; }

        [Required(ErrorMessage = "Informe a comunidade!")]
        public string Comunidade { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        public string Bairro { get; set; }

        //Metodo recupera todas as comunidades cadastradas no banco.
        public List<ComunidadeModel> ListarTodasComunidades()
        {
            List<ComunidadeModel> listaComunidade = new List<ComunidadeModel>();
            ComunidadeModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT idcomunidade, comunidade, bairro FROM comunidade order by comunidade asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComunidadeModel
                {
                    IdComunidade = dt.Rows[i]["idcomunidade"].ToString(),
                    Comunidade = dt.Rows[i]["comunidade"].ToString(),
                    Bairro = dt.Rows[i]["bairro"].ToString()
                };

                listaComunidade.Add(item);
            }

            return listaComunidade;
        }


    }
}
