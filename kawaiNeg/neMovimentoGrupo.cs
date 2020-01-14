using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neMovimentoGrupo : neKawai
    {
        dbKawaiBanco oBanco;

        public MovimentoGrupo buscaGrupo(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupo
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<MovimentoGrupo> buscaGrupo()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupo
                    orderby tbl.Grupo
                    select tbl).ToList<MovimentoGrupo>();
        }


        public IQueryable FiltrarGrupo(string procura)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoGrupo
                    where tbl.Grupo.Contains(procura)
                    orderby tbl.Grupo
                    select new
                    {
                        tbl.codigo,
                        tbl.Grupo
                    });
        }

        public Boolean incluirGrupo(MovimentoGrupo oMovimentoGrupo)
        {
            oBanco = new dbKawaiBanco();

            oBanco.MovimentoGrupo.AddObject(oMovimentoGrupo);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarGrupo(MovimentoGrupo oMovimentoGrupoAlterado)
        {
            oBanco = new dbKawaiBanco();

            MovimentoGrupo oMovimentoGrupo = (from tbl in oBanco.MovimentoGrupo
                              where tbl.codigo.Equals(oMovimentoGrupoAlterado.codigo)
                              select tbl).FirstOrDefault();

            if (oMovimentoGrupo != null)
            {
                oMovimentoGrupo.Grupo = oMovimentoGrupoAlterado.Grupo;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        
        public Boolean excluirGrupo(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            MovimentoGrupo oMovimentoGrupo = (from tbl in oBanco.MovimentoGrupo
                              where tbl.codigo.Equals(Codigo)
                              select tbl).FirstOrDefault();

            if (oMovimentoGrupo != null)
            {
                oBanco.MovimentoGrupo.DeleteObject(oMovimentoGrupo);
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
