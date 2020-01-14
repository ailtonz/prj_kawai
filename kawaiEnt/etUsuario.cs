using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kawaiEnt
{
    public class etUsuario
    {
        private string _perfil = String.Empty;

        public string perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }

        private string _login = String.Empty;

        public string login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _nome = String.Empty;

        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private int _codigoEmpresa;

        public int codigoEmpresa
        {
            get { return _codigoEmpresa; }
            set { _codigoEmpresa = value; }
        }
    }
}
