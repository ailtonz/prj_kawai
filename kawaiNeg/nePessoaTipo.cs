using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class nePessoaTipo : neKawai
    {
        dbKawaiBanco oBanco;

        string teste;

        public string Teste
        {
            get { return teste; }
            set { teste = value; }
        }

        public PessoaTipo busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.PessoaTipo
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<PessoaTipo> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.PessoaTipo
                    orderby tbl.codigo
                    select tbl).ToList<PessoaTipo>();
        }

        public Boolean incluir(PessoaTipo oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.PessoaTipo.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(PessoaTipo oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            PessoaTipo oObj = (from tbl in oBanco.PessoaTipo
                                 where tbl.codigo.Equals(oObjAlt.codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oObj.descricao = oObjAlt.descricao;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public Boolean excluir(int codigo)
        {
            oBanco = new dbKawaiBanco();

            PessoaTipo oObj = (from tbl in oBanco.PessoaTipo
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.PessoaTipo.DeleteObject(oObj);
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
