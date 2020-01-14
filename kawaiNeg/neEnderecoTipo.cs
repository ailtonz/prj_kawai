using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neEnderecoTipo : neKawai
    {
        dbKawaiBanco oBanco;

        public EnderecoTipo busca(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.EnderecoTipo
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public List<EnderecoTipo> busca()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.EnderecoTipo
                    orderby tbl.codigo
                    select tbl).ToList<EnderecoTipo>();
        }

        public Boolean incluir(EnderecoTipo oObj)
        {
            oBanco = new dbKawaiBanco();

            oBanco.EnderecoTipo.AddObject(oObj);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterar(EnderecoTipo oObjAlt)
        {
            oBanco = new dbKawaiBanco();

            EnderecoTipo oObj = (from tbl in oBanco.EnderecoTipo
                                 where tbl.codigo.Equals(oObjAlt.codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oObj.descricao = oObjAlt.descricao;

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

            EnderecoTipo oObj = (from tbl in oBanco.EnderecoTipo
                                 where tbl.codigo.Equals(codigo)
                                 select tbl).FirstOrDefault();

            if (oObj != null)
            {
                oBanco.EnderecoTipo.DeleteObject(oObj);
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
