using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neMovimento : neKawai
    {
        dbKawaiBanco oBanco;

        public Movimento busca(int codigo, int codigoMovimento)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Movimento
                    where tbl.codigo.Equals(codigo) && tbl.codigoMovimento.Equals(codigoMovimento)
                    select tbl).FirstOrDefault();
        }

        public IList<Movimento> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Movimento
                    orderby tbl.codigo
                    select tbl).ToList<Movimento>();
        }

        public IQueryable buscaMovimento(int codigoMovimento)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Movimento
                    join tblCta in oBanco.MovimentoGrupoConta on tbl.codigoConta equals tblCta.codigo
                    where tbl.codigoMovimento.Equals(codigoMovimento)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblCta.Conta,
                        tbl.Documento,
                        tbl.Observacao,
                        tbl.dataVencimento,
                        tbl.ValorOriginal,
                        tbl.dataPagamento,
                        tbl.ValorFinal
                    });
        }


        public IQueryable buscaConta(int codigoMovimento, int codigoConta)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Movimento
                    join tblCta in oBanco.MovimentoGrupoConta on tbl.codigoConta equals tblCta.codigo
                    where tbl.codigoMovimento.Equals(codigoMovimento) && tbl.codigoConta.Equals(codigoConta)
                    orderby tbl.codigo descending
                    select new
                    {
                        tbl.codigo,
                        tblCta.Conta,
                        tbl.Documento,
                        tbl.Observacao,
                        tbl.dataVencimento,
                        tbl.ValorOriginal,
                        tbl.dataPagamento,
                        tbl.ValorFinal
                    });
        }

        public Boolean incluir(Movimento oMovimento)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Movimento.AddObject(oMovimento);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(Movimento oMovimentoAlterado)
        {
            oBanco = new dbKawaiBanco();

            Movimento oMovimento = (from tbl in oBanco.Movimento
                                    where tbl.codigo.Equals(oMovimentoAlterado.codigo)
                                    select tbl).FirstOrDefault();

            if (oMovimento != null)
            {
                oMovimento.dataVencimento = oMovimentoAlterado.dataVencimento;
                oMovimento.ValorOriginal = oMovimentoAlterado.ValorOriginal;
                oMovimento.dataPagamento = oMovimentoAlterado.dataPagamento;
                oMovimento.ValorFinal = oMovimentoAlterado.ValorFinal;
                oMovimento.codigoConta = oMovimentoAlterado.codigoConta;
                oMovimento.codigoPagamento = oMovimentoAlterado.codigoPagamento;
                oMovimento.Documento = oMovimentoAlterado.Documento;
                oMovimento.Observacao = oMovimentoAlterado.Observacao;

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

            Movimento oMovimento = (from tbl in oBanco.Movimento
                                    where tbl.codigo.Equals(Codigo)
                                    select tbl).FirstOrDefault();

            if (oMovimento != null)
            {
                oBanco.Movimento.DeleteObject(oMovimento);
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
