using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neEmpresa : neKawai
    {
        dbKawaiBanco oBanco;

        public Empresa busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Empresa
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<Empresa> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Empresa
                    orderby tbl.nomeFantasia
                    select tbl).ToList<Empresa>();
        }


        public IList<Empresa> FiltrarNomeFantasia(string procura)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Empresa
                    where tbl.nomeFantasia.Contains(procura)
                    select tbl).ToList<Empresa>();
        }


        //public IQueryable FiltrarNomeFantasia(string procura)
        //{
        //    oBanco = new dbKawaiBanco();

        //    return (from tbl in oBanco.Empresa
        //            orderby tbl.nomeFantasia
        //            select new
        //            {
        //                tbl.codigo,
        //                tbl.nomeFantasia,
        //                tbl.CNPJ
        //            });
        //}


        //public IQueryable FiltrarNomeFantasia(string procura)
        //{
        //    oBanco = new dbKawaiBanco();

        //    return (from tbl in oBanco.Empresa
        //            where tbl.nomeFantasia.Contains(procura)
        //            orderby tbl.nomeFantasia
        //            select tbl);
        //}


        public Boolean incluir(Empresa oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Empresa.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(Empresa oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            Empresa oObj = (from tbl in oBanco.Empresa
                            where tbl.codigo.Equals(oObjAlt.codigo)
                            select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oObj.CNPJ = oObjAlt.CNPJ;
                oObj.nomeFantasia = oObjAlt.nomeFantasia;
                oObj.razaoSocial = oObjAlt.razaoSocial;
                oObj.site = oObjAlt.site;
                oObj.IE = oObjAlt.IE;
                oObj.controleCliente = oObjAlt.controleCliente;

                foreach (var item in oObjAlt.EmpresaTelefone)
                {
                    neTelefone oNegocioTelefone = new neTelefone();

                    if (item.Telefone.codigo.Equals(0))
                    {
                        oNegocioTelefone.incluirEmpresaTelefone(oObj.codigo, oNegocioTelefone.incluir(item.Telefone).codigo);
                    }
                    else
                    {
                        if (item.Telefone.numero.Equals(""))
                            oNegocioTelefone.excluir(item.Telefone.codigo);
                        else
                            oNegocioTelefone.alterar(item.Telefone);
                    }
                }

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

            Empresa oObj = (from tbl in oBanco.Empresa
                            where tbl.codigo.Equals(codigo)
                            select tbl).FirstOrDefault();

            if (oObj != null)
            {
                foreach (var item in oObj.EmpresaTelefone)
                {
                    oBanco.Telefone.DeleteObject(item.Telefone);
                }

                List<EmpresaTelefone> listaEmpresaTelefone = oObj.EmpresaTelefone.ToList<EmpresaTelefone>();

                foreach (var item in listaEmpresaTelefone)
                {
                    EmpresaTelefone oEmrpesaTelefone = oBanco.EmpresaTelefone.Where(tbl => tbl.codigo.Equals(item.codigo)).FirstOrDefault();
                    oBanco.EmpresaTelefone.DeleteObject(oEmrpesaTelefone);
                }

                oBanco.Empresa.DeleteObject(oObj);
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
