using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neOSStatus : neKawai
    {
        dbKawaiBanco oBanco;

        public OSStatus busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OSStatus
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<OSStatus> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OSStatus
                    orderby tbl.codigo
                    select tbl).ToList<OSStatus>();
        }

        public Boolean incluir(OSStatus oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.OSStatus.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(OSStatus oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            OSStatus oObj = (from tbl in oBanco.OSStatus
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

            OSStatus oObj = (from tbl in oBanco.OSStatus
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.OSStatus.DeleteObject(oObj);
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
