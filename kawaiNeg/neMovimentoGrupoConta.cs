using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neMovimentoGrupoConta : neKawai
    {
        dbKawaiBanco oBanco;

        public MovimentoGrupoConta buscaConta(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupoConta
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<MovimentoGrupoConta> buscaConta()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupoConta
                    orderby tbl.Conta
                    select tbl).ToList<MovimentoGrupoConta>();
        }

        public IQueryable buscaContaGrupo(Int32 codigoGrupo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupoConta
                    where tbl.codigoGrupo.Value.Equals(codigoGrupo)
                    orderby tbl.codigo
                    select tbl);
        }


        public IQueryable busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupoConta
                    join tblGrp in oBanco.MovimentoGrupo on tbl.codigoGrupo equals tblGrp.codigo
                    orderby tblGrp.Grupo
                    select new
                    {
                        tbl.codigo,
                        tblGrp.Grupo,
                        tbl.Conta
                    });
        }

        public IQueryable FiltrarPlanosContas(string procura)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupoConta
                    join tblGrp in oBanco.MovimentoGrupo on tbl.codigoGrupo equals tblGrp.codigo
                    where tbl.Conta.Contains(procura)
                    orderby tblGrp.Grupo
                    select new
                    {
                        tbl.codigo,
                        tblGrp.Grupo,
                        tbl.Conta
                    });
        }





        public Boolean incluirConta(MovimentoGrupoConta oMovimentoGrupoConta)
        {
            oBanco = new dbKawaiBanco();

            oBanco.MovimentoGrupoConta.AddObject(oMovimentoGrupoConta);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarConta(MovimentoGrupoConta oMovimentoGrupoContaAlterado)
        {
            oBanco = new dbKawaiBanco();

            MovimentoGrupoConta oMovimentoGrupoConta = (from tbl in oBanco.MovimentoGrupoConta
                                                        where tbl.codigo.Equals(oMovimentoGrupoContaAlterado.codigo)
                                                        select tbl).FirstOrDefault();

            if (oMovimentoGrupoConta != null)
            {
                oMovimentoGrupoConta.Conta = oMovimentoGrupoContaAlterado.Conta;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public Boolean excluirConta(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            MovimentoGrupoConta oMovimentoGrupoConta = (from tbl in oBanco.MovimentoGrupoConta
                                                        where tbl.codigo.Equals(Codigo)
                                                        select tbl).FirstOrDefault();

            if (oMovimentoGrupoConta != null)
            {
                oBanco.MovimentoGrupoConta.DeleteObject(oMovimentoGrupoConta);
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
