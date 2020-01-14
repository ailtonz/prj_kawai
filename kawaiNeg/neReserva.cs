using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neReserva : neKawai
    {
        dbKawaiBanco oBanco;

        public Reserva busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Reserva
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        //public IQueryable busca()
        //{
        //    oBanco = new dbKawaiBanco();

        //    return (from tbl in oBanco.Reserva
        //            orderby tbl.codigo
        //            select tbl);
        //}

        public IQueryable buscaEvento(List<DateTime> listDataEvento)
        {
            oBanco = new dbKawaiBanco();

            var busca = (from tbl in oBanco.Reserva
                         join tblSrv in oBanco.Item on tbl.codigoEstudio equals tblSrv.codigo
                         join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                         join tblSts in oBanco.ReservaTipo on tbl.codigoStatus equals tblSts.codigo
                         orderby tbl.codigo descending
                         select new
                         {
                             tbl.codigo,
                             tblEmp.nomeFantasia,
                             Estudio = tblSrv.descricao,
                             tbl.dataReserva,
                             tbl.horaInicio,
                             tbl.horaTerminio,
                             tblSts.Status
                         });

            foreach (var item in busca)
            {
                listDataEvento.Add(item.dataReserva);
            }

            return busca;
        }


        public IQueryable buscaDia(DateTime dia)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Reserva
                    join tblSrv in oBanco.Item on tbl.codigoEstudio equals tblSrv.codigo
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.ReservaTipo on tbl.codigoStatus equals tblSts.codigo
                    where tbl.dataReserva.Equals(dia)
                    orderby tbl.horaInicio
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        Estudio = tblSrv.descricao,
                        tbl.dataReserva,
                        tbl.horaInicio,
                        tbl.horaTerminio,
                        tblSts.Status
                    });
        }


        public IQueryable buscaClienteStatus(int codigoEmpresa, int codigoStatus)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Reserva
                    join tblSrv in oBanco.Item on tbl.codigoEstudio equals tblSrv.codigo
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.ReservaTipo on tbl.codigoStatus equals tblSts.codigo
                    where tbl.codigoEmpresa.Equals(codigoEmpresa) && tbl.codigoStatus.Equals(codigoStatus)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        Estudio = tblSrv.descricao,
                        tbl.dataReserva,
                        tbl.horaInicio,
                        tbl.horaTerminio,
                        tblSts.Status
                    });
        }

        public IQueryable buscaCliente(int codigoEmpresa)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Reserva
                    join tblSrv in oBanco.Item on tbl.codigoEstudio equals tblSrv.codigo
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.ReservaTipo on tbl.codigoStatus equals tblSts.codigo
                    where tbl.codigoEmpresa.Equals(codigoEmpresa)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        Estudio = tblSrv.descricao,
                        tbl.dataReserva,
                        tbl.horaInicio,
                        tbl.horaTerminio,
                        tblSts.Status
                    });
        }

        public IQueryable buscaStatus(int codigoStatus)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Reserva
                    join tblSrv in oBanco.Item on tbl.codigoEstudio equals tblSrv.codigo
                    join tblEmp in oBanco.Empresa on tbl.codigoEmpresa equals tblEmp.codigo
                    join tblSts in oBanco.ReservaTipo on tbl.codigoStatus equals tblSts.codigo
                    where tbl.codigoStatus.Equals(codigoStatus)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblEmp.nomeFantasia,
                        Estudio = tblSrv.descricao,
                        tbl.dataReserva,
                        tbl.horaInicio,
                        tbl.horaTerminio,
                        tblSts.Status
                    });
        }

        public Boolean incluir(Reserva oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Reserva.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(Reserva oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            Reserva oObj = (from tbl in oBanco.Reserva
                            where tbl.codigo.Equals(oObjAlt.codigo)
                            select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oObj.codigoEstudio = oObjAlt.codigoEstudio;
                oObj.codigoEmpresa = oObjAlt.codigoEmpresa;
                oObj.dataReserva = oObjAlt.dataReserva;
                oObj.horaInicio = oObjAlt.horaInicio;
                oObj.horaTerminio = oObjAlt.horaTerminio;
                oObj.nomeRequisitante = oObjAlt.nomeRequisitante;
                oObj.nomeResponsavel = oObjAlt.nomeResponsavel;
                oObj.codigoStatus = oObjAlt.codigoStatus;
                oObj.dataCadastro = oObjAlt.dataCadastro;

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

            Reserva oObj = (from tbl in oBanco.Reserva
                            where tbl.codigo.Equals(codigo)
                            select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.Reserva.DeleteObject(oObj);
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
