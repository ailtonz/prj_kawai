using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neItem : neKawai
    {
        dbKawaiBanco oBanco;

        public Item busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Item
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<Item> busca()
        {
            oBanco = new dbKawaiBanco();

            //where !tbl.codigoAluguelTipo.Value.Equals(1)
            return (from tbl in oBanco.Item
                    orderby tbl.descricao
                    select tbl).ToList<Item>();
        }

        public List<Item> buscaEstudio()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Item
                    where tbl.codigoAluguelTipo.Value.Equals(1)
                    orderby tbl.codigo
                    select tbl).ToList<Item>();
        }

        //public List<Item> buscaAluguelTipo(int codigoAluguelTipo)
        //{
        //    oBanco = new dbKawaiBanco();


        //    return (from tbl in oBanco.Item
        //            where tbl.codigoAluguelTipo.Equals(codigoAluguelTipo)
        //            orderby tbl.descricao
        //            select tbl).ToList<Item>();

        //}


        public IQueryable buscaAluguelTipo(int codigoAluguelTipo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Item
                         join tblSrv in oBanco.AluguelTipo on tbl.codigoAluguelTipo equals tblSrv.codigo
                         where tbl.codigoAluguelTipo.Value.Equals(codigoAluguelTipo)
                         orderby tblSrv.descricao descending
                         select new
                         {
                             tbl.codigo,
                             tipoServico = tblSrv.descricao,
                             tbl.descricao,
                             tbl.valor
                         });
        }



        public Boolean incluir(Item oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Item.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(Item oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            Item oObj = (from tbl in oBanco.Item
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

            Item oObj = (from tbl in oBanco.Item
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.Item.DeleteObject(oObj);
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
