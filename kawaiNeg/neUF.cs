using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neUF : neKawai
    {
        dbKawaiBanco oBanco;

        public IList<UF> buscaUF()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.UF
                    orderby tbl.codigo
                    select tbl).ToList<UF>();
        }

        public Boolean incluirUF(UF oUF)
        {
            oBanco = new dbKawaiBanco();

            oBanco.UF.AddObject(oUF);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarUF(UF oUFAlterado)
        {
            oBanco = new dbKawaiBanco();

            UF oUF = (from tbl in oBanco.UF
                              where tbl.codigo.Equals(oUFAlterado.codigo)
                              select tbl).FirstOrDefault();

            if (oUF != null)
            {
                oUF.descricao = oUFAlterado.descricao;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        
        public Boolean excluirUF(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            UF oUF = (from tbl in oBanco.UF
                              where tbl.codigo.Equals(Codigo)
                              select tbl).FirstOrDefault();

            if (oUF != null)
            {
                oBanco.UF.DeleteObject(oUF);
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
