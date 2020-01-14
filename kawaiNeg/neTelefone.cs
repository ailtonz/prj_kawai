using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neTelefone : neKawai
    {
        dbKawaiBanco oBanco;

        public Telefone buscaTelefone(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Telefone
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<Telefone> buscaTelefone()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Telefone
                    orderby tbl.codigo
                    select tbl).ToList<Telefone>();
        }

        public List<Telefone> buscaTelefoneEmpresa(Int32 codigoEmpresa)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.EmpresaTelefone
                    where tbl.codigoEmpresa.Value.Equals(codigoEmpresa)
                    orderby tbl.codigo
                    select tbl.Telefone).ToList<Telefone>();
        }


        public Telefone incluir(Telefone oObj)
        {
            oBanco = new dbKawaiBanco();
            Telefone oTelefone = new Telefone();

            oTelefone.codigoTipo = oObj.codigoTipo;
            oTelefone.ddd = oObj.ddd;
            oTelefone.ddi = oObj.ddi;
            oTelefone.numero = oObj.numero;
            

            oBanco.Telefone.AddObject(oTelefone);
            oBanco.SaveChanges();
            return oTelefone;
        }

        public EmpresaTelefone incluirEmpresaTelefone(Int32 codigoEmpresa, Int32 codigoTelefone)
        {
            oBanco = new dbKawaiBanco();
            EmpresaTelefone oEmpresaTelefone = new EmpresaTelefone();

            oEmpresaTelefone.codigoEmpresa = codigoEmpresa;
            oEmpresaTelefone.codigoTelefone = codigoTelefone;

            oBanco.AddToEmpresaTelefone(oEmpresaTelefone);

            oBanco.SaveChanges();

            return oEmpresaTelefone;
        }

        public Boolean alterar(Telefone oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            Telefone oObj = (from tbl in oBanco.Telefone
                             where tbl.codigo.Equals(oObjAlt.codigo)
                             select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oObj.ddi = oObjAlt.ddi;
                oObj.ddd = oObjAlt.ddd;
                oObj.numero = oObjAlt.numero;
                oObj.codigoTipo = oObjAlt.codigoTipo;

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

            Telefone oTelefone = (from tbl in oBanco.Telefone
                                  where tbl.codigo.Equals(codigo)
                                  select tbl).FirstOrDefault();

            if (oTelefone != null)
            {
                EmpresaTelefone oEmpresaTelefone = (from tbl in oBanco.EmpresaTelefone
                                                    where tbl.codigoTelefone.Value.Equals(codigo)
                                                    select tbl).FirstOrDefault();
                if (oEmpresaTelefone != null)
                    oBanco.EmpresaTelefone.DeleteObject(oEmpresaTelefone);

                oBanco.Telefone.DeleteObject(oTelefone);

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
