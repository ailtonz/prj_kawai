using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neReservaTipo : neKawai
    {
        dbKawaiBanco oBanco;

        public ReservaTipo busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.ReservaTipo
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<ReservaTipo> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.ReservaTipo
                    orderby tbl.codigo
                    select tbl).ToList<ReservaTipo>();
        }

        public Boolean incluir(ReservaTipo oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.ReservaTipo.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(ReservaTipo oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            ReservaTipo oObj = (from tbl in oBanco.ReservaTipo
                                 where tbl.codigo.Equals(oObjAlt.codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oObj.Status = oObjAlt.Status;

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

            ReservaTipo oObj = (from tbl in oBanco.ReservaTipo
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.ReservaTipo.DeleteObject(oObj);
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
