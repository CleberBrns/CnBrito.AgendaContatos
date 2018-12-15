using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Contract
{
    public interface IRepositoryBase<TModel>
    {
        TModel Salvar(TModel model);
        bool Atualizar(TModel model);
        IList<TModel> SalvarLista(IList<TModel> listModel);
        bool AtualizarLista(IList<TModel> listModel);
        bool Excluir(TModel model);        
        IList<TModel> Lista();
    }
}
