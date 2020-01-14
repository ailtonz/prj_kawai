using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neEmail : neKawai
    {
        dbKawaiBanco oBanco;

        public Email busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Email
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<Email> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Email
                    orderby tbl.codigo
                    select tbl).ToList<Email>();
        }

        public Boolean incluir(Email oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Email.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(Email oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            Email oObj = (from tbl in oBanco.Email
                                 where tbl.codigo.Equals(oObjAlt.codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                //oObj.descricao = oObjAlt.descricao;

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

            Email oObj = (from tbl in oBanco.Email
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.Email.DeleteObject(oObj);
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
