﻿using System;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Web.Session.Contract
{
    public interface ISessionBase<TModel>
    {
        Tuple<TModel, bool> GetModelFromSession(string sessionName);
        Tuple<List<TModel>, bool> GetListFromSession(string sessionName);
        void AddModelToSession(TModel model, string sessionName);
        void AddListToSession(List<TModel> list, string sessionName);
        void RemoveFromSession(string sessionName);        
    }
}
