using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neEndereco : neKawai
    {
        dbKawaiBanco oBanco;

        public Endereco buscaEndereco(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Endereco
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<Endereco> buscaEndereco()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Endereco
                    orderby tbl.codigo
                    select tbl).ToList<Endereco>();
        }

        public IQueryable buscaEnderecoEmpresa(Int32 codigoEmpresa)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.EmpresaEndereco
                    join tblEnd in oBanco.Endereco on tbl.codigoEndereco equals tblEnd.codigo
                    where tbl.codigoEmpresa.Value.Equals(codigoEmpresa)
                    orderby tbl.codigo
                    select new
                    {
                        tblEnd.codigo,
                        tblEnd.logradouro,
                        tblEnd.numero
                    });
        }

        public Endereco incluir(Endereco oEndereco)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Endereco.AddObject(oEndereco);
            oBanco.SaveChanges();
            return oEndereco;
        }

        public Boolean alterar(Endereco oEnderecoAlterado)
        {
            oBanco = new dbKawaiBanco();

            Endereco oEndereco = (from tbl in oBanco.Endereco
                                  where tbl.codigo.Equals(oEnderecoAlterado.codigo)
                                  select tbl).FirstOrDefault();

            if (oEndereco != null)
            {
                oEndereco.logradouro = oEnderecoAlterado.logradouro;
                oEndereco.numero = oEnderecoAlterado.numero;
                oEndereco.complemento = oEnderecoAlterado.complemento;
                oEndereco.bairro = oEnderecoAlterado.bairro;
                oEndereco.CEP = oEnderecoAlterado.CEP;
                oEndereco.Cidade = oEnderecoAlterado.Cidade;
                oEndereco.codigoUF = oEnderecoAlterado.codigoUF;
                oEndereco.codigoTipo = oEnderecoAlterado.codigoTipo;

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

            EmpresaEndereco oEmpresaEndereco = (from tbl in oBanco.EmpresaEndereco
                                                where tbl.codigoEndereco.Value.Equals(Codigo)
                                                select tbl).FirstOrDefault();
            
            if (oEmpresaEndereco != null)
            {
                oBanco.EmpresaEndereco.DeleteObject(oEmpresaEndereco);
                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }

            Endereco oEndereco = (from tbl in oBanco.Endereco
                                  where tbl.codigo.Equals(Codigo)
                                  select tbl).FirstOrDefault();

            if (oEndereco != null)
            {
                oBanco.Endereco.DeleteObject(oEndereco);
                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public EmpresaEndereco incluirEmpresaEndereco(Int32 codigoEmpresa, Int32 codigoEndereco)
        {
            oBanco = new dbKawaiBanco();
            EmpresaEndereco oEmpresaEndereco = new EmpresaEndereco();

            oEmpresaEndereco.codigoEmpresa = codigoEmpresa;
            oEmpresaEndereco.codigoEndereco = codigoEndereco;

            oBanco.AddToEmpresaEndereco(oEmpresaEndereco);

            oBanco.SaveChanges();

            return oEmpresaEndereco;
        }
    }
}
