using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neTelefoneTipo : neKawai
    {
        dbKawaiBanco oBanco;

        string teste;

        public string Teste
        {
            get { return teste; }
            set { teste = value; }
        }

        public TelefoneTipo busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.TelefoneTipo
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<TelefoneTipo> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.TelefoneTipo
                    orderby tbl.codigo
                    select tbl).ToList<TelefoneTipo>();
        }

        public Boolean incluir(TelefoneTipo oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.TelefoneTipo.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(TelefoneTipo oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            TelefoneTipo oObj = (from tbl in oBanco.TelefoneTipo
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

            TelefoneTipo oObj = (from tbl in oBanco.TelefoneTipo
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.TelefoneTipo.DeleteObject(oObj);
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
