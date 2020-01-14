using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neEmailTipo : neKawai
    {
        dbKawaiBanco oBanco;

        public EmailTipo busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.EmailTipo
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<EmailTipo> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.EmailTipo
                    orderby tbl.codigo
                    select tbl).ToList<EmailTipo>();
        }

        public Boolean incluir(EmailTipo oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.EmailTipo.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(EmailTipo oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            EmailTipo oObj = (from tbl in oBanco.EmailTipo
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

            EmailTipo oObj = (from tbl in oBanco.EmailTipo
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.EmailTipo.DeleteObject(oObj);
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
