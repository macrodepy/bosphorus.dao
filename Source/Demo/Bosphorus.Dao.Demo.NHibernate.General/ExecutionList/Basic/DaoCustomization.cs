﻿using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.NHibernate.Common.Business;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Basic
{
    public class DaoCustomization: AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> genericDao;
        private readonly IBankDao customizedDao;

        public DaoCustomization(IResultTransformer resultTransformer, IDao<Bank> genericDao, IBankDao customizedDao) 
            : base(resultTransformer)
        {
            this.genericDao = genericDao;
            this.customizedDao = customizedDao;
        }

        public IQueryable<Bank> StartsWith_ByExtension()
        {
            IQueryable<Bank> result = genericDao.GetStartsWithByExtension("Ci");
            return result;
        }

        public IQueryable<Bank> StartsWith_ByInheritance()
        {
            //TODO:
            //ISession session = customizedDao.SessionManager.Current;
            ISession session = null;
            IQueryable<Bank> result = customizedDao.GetStartsWithByInheritance(session, "Ci");
            return result;
        }
    }
}