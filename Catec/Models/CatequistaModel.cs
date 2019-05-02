using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Catec.Uteis;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;


namespace Catec.Models
{
    public class CatequistaModel
    {
        public string IdCatequista { get; set; }
        public string NomeCatequista { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Data_cadastro { get; set; }
        public string Ativo { get; set; }

        [Required(ErrorMessage = "Informe o login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public string IdComunidade { get; set; }

        //Metodo retorna todos os catequistas cadastrados
        public List<CatequistaModel> ListarTodosCatequistas()
        {
            List<CatequistaModel> listaCatequista = new List<CatequistaModel>();
            CatequistaModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT idcatequista, catequista, cpf, rua, numero, data_cadastro, " +
                "ativo, login, senha, perfil, idcomunidade FROM catequista order by catequista";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new CatequistaModel
                {
                    IdCatequista = dt.Rows[i]["idcatequista"].ToString(),
                    NomeCatequista = dt.Rows[i]["catequista"].ToString(),
                    Cpf = dt.Rows[i]["cpf"].ToString(),
                    Rua = dt.Rows[i]["rua"].ToString(),
                    Numero = dt.Rows[i]["numero"].ToString(),
                    Data_cadastro = dt.Rows[i]["data_cadastro"].ToString(),
                    Ativo = dt.Rows[i]["ativo"].ToString(),
                    Login = dt.Rows[i]["login"].ToString(),
                    Senha = dt.Rows[i]["senha"].ToString(),
                    Perfil = dt.Rows[i]["perfil"].ToString(),
                    IdComunidade = dt.Rows[i]["idcomunidade"].ToString()
                };

                listaCatequista.Add(item);
            }

            return listaCatequista;           

        }


    }
}


