using Catec.Uteis;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catec.Models
{
    public class LoginModel
    {
        public string IdCatequista { get; set; }
        public string Catequista { get; set; }

        [Required(ErrorMessage = "Informe o login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        public string Senha { get; set; }
        public string Perfil { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"SELECT idcatequista, catequista, login, senha, perfil FROM catequista WHERE login = @login AND senha = @senha AND perfil = @perfil";
            MySqlCommand Command = new MySqlCommand();
            Command.CommandText = sql;
            Command.Parameters.AddWithValue("@login", Login);
            Command.Parameters.AddWithValue("@senha", Senha);
            Command.Parameters.AddWithValue("@perfil", Perfil);

            DAL objDAL = new DAL();

            DataTable dt = objDAL.RetDataTable(Command);
            if (dt.Rows.Count == 1)
            {
                IdCatequista = dt.Rows[0]["idcatequista"].ToString();
                Catequista = dt.Rows[0]["catequista"].ToString();
                Perfil = dt.Rows[0]["perfil"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
