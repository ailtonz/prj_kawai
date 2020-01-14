using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neKawai
    {
        private Exception _erro = null;

        public Exception erro
        {
            get { return _erro; }
            set { _erro = value; }
        }

        public etUsuario Logar(string txtLogin, string txtSenha)
        {
            etUsuario oUsuario;

            neLogin oLogin = new neLogin();

            Login oBuscaLogin = oLogin.buscaLogin(txtLogin, txtSenha);
            if (oBuscaLogin != null)
            {
                oUsuario = new etUsuario();
                oUsuario.login = oBuscaLogin.login;
                oUsuario.perfil = oBuscaLogin.Perfil.perfil;
                oUsuario.nome = oBuscaLogin.Pessoa.First().nome;
                if (oBuscaLogin.Pessoa.First().codigoEmpresa != null)
                    oUsuario.codigoEmpresa = oBuscaLogin.Pessoa.First().codigoEmpresa.Value;

            }
            else
            {
                oUsuario = null;
            }

            return oUsuario;
        }
    }
}
