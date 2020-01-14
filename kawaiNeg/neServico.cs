using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kawaiEnt;
using kawaiBco;

namespace kawaiNeg
{
    public class neServico : neKawai
    {
        dbKawaiBanco oBanco;
        string _retorno;

        public string Retorno
        {
            get { return _retorno; }
            set { _retorno = value; }
        }

        public Item buscaServico(int codigo)
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Item
                    where tbl.codigo.Equals(codigo)
                    select tbl).FirstOrDefault();
        }

        public IList<Item> buscaServico()
        {
            oBanco = new dbKawaiBanco();

            return (from tbl in oBanco.Item
                    orderby tbl.codigo
                    select tbl).ToList<Item>();
        }

        public Boolean incluirServico(Item oServico)
        {
            oBanco = new dbKawaiBanco();

            oBanco.Item.AddObject(oServico);
            oBanco.SaveChanges();
            return true;
        }

        public Boolean alterarServico(Item oServicoAlterado)
        {
            oBanco = new dbKawaiBanco();

            Item oServico = (from tbl in oBanco.Item
                             where tbl.codigo.Equals(oServicoAlterado.codigo)
                             select tbl).FirstOrDefault();

            if (oServico != null)
            {
                oServico.descricao = oServicoAlterado.descricao;
                oServico.valor = oServicoAlterado.valor;
                oServico.codigoAluguelTipo = oServicoAlterado.codigoAluguelTipo;
                oBanco.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public Boolean excluirServico(int Codigo)
        {
            oBanco = new dbKawaiBanco();

            //Item oBuscaOS = (from tbl in oBanco.OSItem
            //                             where tbl.codigoServico.Equals(Codigo)
            //                             select tbl).FirstOrDefault();

            //if (oBuscaOS != null)
            //{
            //    _retorno = "Atenção! Não é possível excluir o Item, pois existe OS relacionada com o mesmo.";
            //    return false;

            //}

            Item oServico = (from tbl in oBanco.Item
                             where tbl.codigo.Equals(Codigo)
                             select tbl).FirstOrDefault();

            if (oServico != null)
            {
                oBanco.Item.DeleteObject(oServico);
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
