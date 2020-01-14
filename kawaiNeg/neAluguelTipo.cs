using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neAluguelTipo : neKawai
    {
        dbKawaiBanco oBanco;

        public AluguelTipo busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.AluguelTipo
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<AluguelTipo> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.AluguelTipo
                    orderby tbl.codigo
                    select tbl).ToList<AluguelTipo>();
        }

        public Boolean incluir(AluguelTipo oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.AluguelTipo.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(AluguelTipo oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            AluguelTipo oObj = (from tbl in oBanco.AluguelTipo
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

            AluguelTipo oObj = (from tbl in oBanco.AluguelTipo
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.AluguelTipo.DeleteObject(oObj);
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
