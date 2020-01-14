using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class nePerfil : neKawai
    {
        dbKawaiBanco oBanco;

        public Perfil buscaPerfil(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Perfil
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<Perfil> buscaPerfil()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Perfil
                    orderby tbl.codigo
                    select tbl).ToList<Perfil>();
        }

        public Boolean incluirPerfil(Perfil oPerfil)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Perfil.AddObject(oPerfil);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarPerfil(Perfil oPerfilAlterado)
        {
            oBanco = new dbKawaiBanco();

            Perfil oPerfil = (from tbl in oBanco.Perfil
                              where tbl.codigo.Equals(oPerfilAlterado.codigo)
                              select tbl).FirstOrDefault();

            if (oPerfil != null)
            {
                oPerfil.descricao = oPerfilAlterado.descricao;
                oPerfil.perfil = oPerfilAlterado.perfil;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        
        public Boolean excluirPerfil(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            Perfil oPerfil = (from tbl in oBanco.Perfil
                              where tbl.codigo.Equals(Codigo)
                              select tbl).FirstOrDefault();

            if (oPerfil != null)
            {
                oBanco.Perfil.DeleteObject(oPerfil);
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
