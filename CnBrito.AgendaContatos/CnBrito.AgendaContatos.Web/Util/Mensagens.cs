using CnBrito.AgendaContatos.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Util
{
    public class Mensagens
    {
        public MensagensDeRetorno ConfiguraMensagemRetorno(string msgExibicao, string msgAnalise)
        {
            return new MensagensDeRetorno
            {
                MensagemExibicao = msgExibicao,
                MensagemAnalise = msgAnalise,
                Status = string.IsNullOrEmpty(msgAnalise)
            };
        }

        public string MensagensInvalidModelState(ModelStateDictionary dictionary)
        {
            string retornos = string.Empty;
            List<string> str = new List<string>();

            if (dictionary.IsValid == false)
            {
                foreach (var dic in dictionary.Values)
                {
                    foreach (var erro in dic.Errors)
                    {
                        //str.Add(erro.ErrorMessage);
                        retornos += erro.ErrorMessage + ", ";
                    }
                }
            }            

            return retornos;
        }
    }
}