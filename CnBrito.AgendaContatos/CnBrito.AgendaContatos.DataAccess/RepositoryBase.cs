using AutoMapper;
using CnBrito.AgendaContatos.Data.Contract;
using CnBrito.AgendaContatos.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CnBrito.AgendaContatos.DataAccess
{
    public abstract class RepositoryBase<TModel, TRespository> : IRepositoryBase<TModel>
        where TModel : class, new() where TRespository : class, new()
    {
        #region Construtor e propriedade

        protected readonly IMapper Mapper;

        public RepositoryBase(IMapper mapper)
        {
            Mapper = mapper;
        }

        #endregion

        public TModel Salvar(TModel model)
        {
            using (var context = new AgdCtContext())
            {
                var modelBD = Mapper.Map<TModel, TRespository>(model);
                context.Set<TRespository>().Add(modelBD);
                context.SaveChanges();

                return Mapper.Map<TRespository, TModel>(modelBD);
            }
        }

        public bool Atualizar(TModel model)
        {
            using (var context = new AgdCtContext())
            {
                var modeloBD = Mapper.Map<TModel, TRespository>(model);
                Attach(context, modeloBD, EntityState.Modified);

                return context.SaveChanges() != 0;
            }
        }

        public IList<TModel> SalvarLista(IList<TModel> listModel)
        {
            using (var context = new AgdCtContext())
            {
                var listaModelBD = Mapper.Map<IList<TModel>, IList<TRespository>>(listModel);
                context.Set<TRespository>().AddRange(listaModelBD);
                context.SaveChanges();

                return Mapper.Map<IList<TRespository>, IList<TModel>>(listaModelBD);
            }
        }

        public bool AtualizarLista(IList<TModel> listModel)
        {
            using (var context = new AgdCtContext())
            {
                foreach (var model in listModel)
                {
                    var modeloBD = Mapper.Map<TModel, TRespository>(model);
                    Attach(context, modeloBD, EntityState.Modified);
                }

                return context.SaveChanges() != 0;
            }
        }

        public bool Excluir(Expression<Func<TModel, bool>> expression)
        {
            using (var context = new AgdCtContext())
            {
                var modelo = context.Set<TRespository>().FirstOrDefault(GetMappedSelector(expression));
                if (modelo == null)
                    return false;
                Attach(context, modelo, EntityState.Deleted);
                return context.SaveChanges() != 0;
            }
        }

        public bool Excluir(TModel model)
        {
            using (var context = new AgdCtContext())
            {
                var modelo = Mapper.Map<TModel, TRespository>(model);
                Attach(context, modelo, EntityState.Deleted);
                return context.SaveChanges() != 0;
            }
        }

        public IList<TModel> Lista()
        {
            using (var context = new AgdCtContext())
            {
                var modelo = context.Set<TRespository>().ToList();
                return Mapper.Map<IList<TRespository>, IList<TModel>>(modelo);
            }
        }

        #region Métodos Privados

        private void Attach(AgdCtContext context, TRespository entity, EntityState state)
        {
            var entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
                context.Set<TRespository>().Attach(entity);

            context.ChangeObjectState(entity, state);
        }

        private Expression<Func<TRespository, bool>> GetMappedSelector(Expression<Func<TModel, bool>> selector)
        {
            var modelo = Mapper.Map<Expression<Func<TModel, bool>>, Expression<Func<TRespository, bool>>>(selector);
            return modelo;
        }

        #endregion
    }
}
