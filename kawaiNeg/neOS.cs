using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neOS : neKawai
    {
        dbKawaiBanco oBanco;

        public OS buscaOS(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public OSItem buscaOSItem(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OSItem
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }


        public IQueryable busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.OSStatus on tbl.codigoStatus equals tblSts.codigo
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        tbl.Trabalho,
                        tbl.dataInicio,
                        tbl.dataTerminio,
                        tblSts.Status
                    });
        }

        public IQueryable buscaOSEmpresa(int codigoEmpresa)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.OSStatus on tbl.codigoStatus equals tblSts.codigo
                    where tbl.codigoEmpresa.Equals(codigoEmpresa)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        tbl.Trabalho,
                        tbl.dataInicio,
                        tbl.dataTerminio,
                        tblSts.Status
                    });
        }


        public IQueryable buscaOSStatus(int codigoStatus)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.OSStatus on tbl.codigoStatus equals tblSts.codigo
                    where tblSts.codigo.Equals(codigoStatus)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        tbl.Trabalho,
                        tbl.dataInicio,
                        tbl.dataTerminio,
                        tblSts.Status
                    });
        }

        public IQueryable buscaOSEmpresaStatus(int codigoEmpresa, int codigoStatus)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.OSStatus on tbl.codigoStatus equals tblSts.codigo
                    where tbl.codigoEmpresa.Equals(codigoEmpresa) && tblSts.codigo.Equals(codigoStatus)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        tbl.Trabalho,
                        tbl.dataInicio,
                        tbl.dataTerminio,
                        tblSts.Status
                    });


        }

        //public List<OS> buscaOSStatus(int codigoStatus)
        //{
        //    oBanco = new dbKawaiBanco();

        //    return (from tbl in oBanco.OS
        //            where tbl.codigoStatus.Equals(codigoStatus)
        //            select tbl).ToList<OS>();
        //}

        public List<OS> buscaOS()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    orderby tbl.codigo
                    select tbl).ToList<OS>();
        }

        public List<OS> buscaOS(DateTime data)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    where tbl.dataInicio.Equals(data)
                    orderby tbl.codigo
                    select tbl).ToList<OS>();
        }
        public List<OS> buscaOS(DateTime data, int codigoEmpresa)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.OS
                    where tbl.dataInicio.Equals(data) && tbl.codigoEmpresa.Equals(codigoEmpresa)
                    orderby tbl.codigo
                    select tbl).ToList<OS>();
        }


        public Boolean incluir(OS oOS)
        {
            oBanco = new dbKawaiBanco();

            oBanco.OS.AddObject(oOS);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(OS oOSAlterado)
        {
            oBanco = new dbKawaiBanco();

            OS oOS = (from tbl in oBanco.OS
                      where tbl.codigo.Equals(oOSAlterado.codigo)
                      select tbl).FirstOrDefault();

            if (oOS != null)
            {
                oOS.codigoEmpresa = oOSAlterado.codigoEmpresa;
                oOS.dataInicio = oOSAlterado.dataInicio;
                oOS.dataTerminio = oOSAlterado.dataTerminio;
                oOS.nomeRequisitante = oOSAlterado.nomeRequisitante;
                oOS.nomeResponsavel = oOSAlterado.nomeResponsavel;
                oOS.Trabalho = oOSAlterado.Trabalho;
                oOS.controleCliente = oOSAlterado.controleCliente;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public Boolean excluir(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            OS oOS = (from tbl in oBanco.OS
                      where tbl.codigo.Equals(Codigo)
                      select tbl).FirstOrDefault();

            if (oOS != null)
            {
                oBanco.OS.DeleteObject(oOS);
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
