using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neMovimentoPagamento : neKawai
    {
        dbKawaiBanco oBanco;

        public MovimentoPagamento buscaPagamento(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoPagamento
                    where tbl.codigo.Equals(codigo)
                    orderby tbl.codigo
                    select tbl).FirstOrDefault();
        }

        public IList<MovimentoPagamento> buscaPagamento()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.MovimentoPagamento
                    orderby tbl.FormaPagamento
                    select tbl).ToList<MovimentoPagamento>();
        }

        public Boolean incluirPagamento(MovimentoPagamento oMovimentoPagamento)
        {
            oBanco = new dbKawaiBanco();

            oBanco.MovimentoPagamento.AddObject(oMovimentoPagamento);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarPagamento(MovimentoPagamento oMovimentoPagamentoAlterado)
        {
            oBanco = new dbKawaiBanco();

            MovimentoPagamento oMovimentoPagamento = (from tbl in oBanco.MovimentoPagamento
                              where tbl.codigo.Equals(oMovimentoPagamentoAlterado.codigo)
                              select tbl).FirstOrDefault();

            if (oMovimentoPagamento != null)
            {
                oMovimentoPagamento.FormaPagamento = oMovimentoPagamentoAlterado.FormaPagamento;

                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        
        public Boolean excluirPagamento(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            MovimentoPagamento oMovimentoPagamento = (from tbl in oBanco.MovimentoPagamento
                              where tbl.codigo.Equals(Codigo)
                              select tbl).FirstOrDefault();

            if (oMovimentoPagamento != null)
            {
                oBanco.MovimentoPagamento.DeleteObject(oMovimentoPagamento);
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
