using CnBrito.AgendaContatos.Web.Models;

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
    }
}