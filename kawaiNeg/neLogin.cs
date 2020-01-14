using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neLogin : neKawai
    {
        dbKawaiBanco oBanco;

        public Login buscaLogin(string Login, string Senha)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Login
                    where tbl.login.Equals(Login) && tbl.senha.Equals(Senha)
                    select tbl).FirstOrDefault();
        }

        public Boolean incluirLogin(Login oLogin)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Login.AddObject(oLogin);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarLogin(Login oLoginAlterado)
        {
            oBanco = new dbKawaiBanco();

            Login oLogin = (from tbl in oBanco.Login
                              where tbl.codigo.Equals(oLoginAlterado.codigo)
                              select tbl).FirstOrDefault();

            if (oLogin != null)
            {
                oLogin.login = oLoginAlterado.login;
                oLogin.senha = oLoginAlterado.senha;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        
        public Boolean excluirLogin(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            Login oLogin = (from tbl in oBanco.Login
                              where tbl.codigo.Equals(Codigo)
                              select tbl).FirstOrDefault();

            if (oLogin != null)
            {
                oBanco.Login.DeleteObject(oLogin);
                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
