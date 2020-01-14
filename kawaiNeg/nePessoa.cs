using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class nePessoa : neKawai
    {
        dbKawaiBanco oBanco;

        public Pessoa buscaPessoa(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Pessoa
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<Pessoa> buscaPessoa()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Pessoa
                    orderby tbl.codigo
                    select tbl).ToList<Pessoa>();
        }

        public List<Pessoa> buscaPessoaEmpresa(Int32 codigoEmpresa)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Pessoa
                    where tbl.codigoEmpresa.Value.Equals(codigoEmpresa)
                    orderby tbl.codigo
                    select tbl).ToList<Pessoa>();
        }

        public Boolean incluir(Pessoa oObj)
        {
            oBanco = new dbKawaiBanco();
            Pessoa oPessoa = new Pessoa();
            
            oPessoa.nome = oObj.nome;
            oPessoa.ddi = oObj.ddi;
            oPessoa.ddd = oObj.ddd;
            oPessoa.numero = oObj.numero;
            oPessoa.codigoEmpresa = oObj.codigoEmpresa;
            oPessoa.codigoTipo = oObj.codigoTipo;

            oBanco.Pessoa.AddObject(oPessoa);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(Pessoa oPessoaAlterado)
        {
            oBanco = new dbKawaiBanco();

            Pessoa oPessoa = (from tbl in oBanco.Pessoa
                              where tbl.codigo.Equals(oPessoaAlterado.codigo)
                              select tbl).FirstOrDefault();

            if (oPessoa != null)
            {
                oPessoa.nome = oPessoaAlterado.nome;
                oPessoa.ddi = oPessoaAlterado.ddi;
                oPessoa.ddd = oPessoaAlterado.ddd;
                oPessoa.numero = oPessoaAlterado.numero;
                oPessoa.codigoTipo = oPessoaAlterado.codigoTipo;

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

            Pessoa oPessoa = (from tbl in oBanco.Pessoa
                              where tbl.codigo.Equals(Codigo)
                              select tbl).FirstOrDefault();

            if (oPessoa != null)
            {
                oBanco.Pessoa.DeleteObject(oPessoa);
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
