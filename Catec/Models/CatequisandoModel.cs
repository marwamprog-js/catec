using Catec.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catec.Models
{
    public class CatequisandoModel
    {
        public string IdCatequisando { get; set; }
        public string NomeCatequisando { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Data_cadastro { get; set; }
        public string Ativo { get; set; }
        public string IdComunidade { get; set; }

        //Recupera todos os catequisando do banco
        public List<CatequisandoModel> ListarTodosCatequisando()
        {
            List<CatequisandoModel> listaCatequisando = new List<CatequisandoModel>();
            CatequisandoModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT idcatequisando, catequisando, mae, pai, rua, numero, data_cadastro, " +
                "ativo, idcomunidade FROM catequisando order by catequisando";
            DataTable dt = objDAL.RetDataTable(sql);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                item = new CatequisandoModel
                {
                    IdCatequisando = dt.Rows[i]["idcatequisando"].ToString(),
                    NomeCatequisando = dt.Rows[i]["catequisando"].ToString(),
                    Mae = dt.Rows[i]["mae"].ToString(),
                    Pai = dt.Rows[i]["pai"].ToString(),
                    Rua = dt.Rows[i]["rua"].ToString(),
                    Numero = dt.Rows[i]["numero"].ToString(),
                    Data_cadastro = dt.Rows[i]["data_cadastro"].ToString(),
                    Ativo = dt.Rows[i]["ativo"].ToString(),
                    IdComunidade = dt.Rows[i]["idcomunidade"].ToString()
                };

                listaCatequisando.Add(item);
            }

            return listaCatequisando;
        }
    }
}
