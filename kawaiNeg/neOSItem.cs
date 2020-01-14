using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neOSItem : neKawai
    {
        dbKawaiBanco oBanco;

        public OSItem buscaOSItem(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OSItem
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<OSItem> buscaListaOSItem(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OSItem
                    where tbl.codigoOS.Equals(codigo)
                    orderby tbl.codigo
                    select tbl).ToList<OSItem>();
        }

        public Boolean incluirOSItem(OSItem oOSItem)
        {
            oBanco = new dbKawaiBanco();

            oBanco.OSItem.AddObject(oOSItem);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarOSItem(OSItem oOSItemAlterado)
        {
            oBanco = new dbKawaiBanco();

            OSItem oOSItem = (from tbl in oBanco.OSItem
                              where tbl.codigo.Equals(oOSItemAlterado.codigo)
                              select tbl).FirstOrDefault();

            if (oOSItem != null)
            {
                oOSItem.codigoServico = oOSItemAlterado.codigoServico;
                oOSItem.Observacao = oOSItemAlterado.Observacao;
                oOSItem.valorServico = oOSItemAlterado.valorServico;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        
        public Boolean excluirOSItem(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            OSItem oOSItem = (from tbl in oBanco.OSItem
                              where tbl.codigo.Equals(Codigo)
                              select tbl).FirstOrDefault();

            if (oOSItem != null)
            {
                oBanco.OSItem.DeleteObject(oOSItem);
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
