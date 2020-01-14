using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neContrato : neKawai
    {
        dbKawaiBanco oBanco;

        public Contrato busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Contrato
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<Contrato> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Contrato
                    orderby tbl.codigo
                    select tbl).ToList<Contrato>();
        }

        public Boolean incluir(Contrato oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Contrato.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(Contrato oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            Contrato oObj = (from tbl in oBanco.Contrato
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

            Contrato oObj = (from tbl in oBanco.Contrato
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.Contrato.DeleteObject(oObj);
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
