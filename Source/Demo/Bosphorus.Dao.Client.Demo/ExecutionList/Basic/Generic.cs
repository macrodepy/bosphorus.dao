﻿using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class Generic : MethodExecutionItemList
    {
        private readonly IDao<Bank> dao;

        public Generic(IResultTransformer resultTransformer, IDao<Bank> dao) 
            : base(resultTransformer)
        {
            this.dao = dao;
        }

        public IEnumerable<Bank> GetAll()
        {
            return dao.GetAll();
        }

        public IQueryable<Bank> GetById()
        {
            IQueryable<Bank> result = dao.GetById(1);
            return result;
        }

        public Bank GetByIdSingle()
        {
            Bank result = dao.GetByIdSingle(1);
            return result;
        }

        public IEnumerable<Bank> GetByQuery()
        {
            IEnumerable<Bank> result = dao.GetByQuery("select * from XBank");
            return result;
        }

        public IEnumerable<Bank> GetByNamedQuery()
        {
            var parameter = new {No = "0092"};
            IEnumerable<Bank> result = dao.GetByNamedQuery("BankNamedQueryPositional", parameter);
            return result;
        }

        public IEnumerable<Bank> GetByNamedQueryFromProcedure()
        {
            var parameter = new {Parameter1 = "Deneme", Parameter2 = "Deneme2"};
            IEnumerable<Bank> result = dao.GetByNamedQuery("BankNamedQueryFromProcedure", parameter);
            return result;
        }

        public Bank Insert()
        {
            Bank bank = BankBuilder.Default.Build();
            Bank result = dao.Insert(bank);
            return result;
        }

        public Bank Update()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            bank.No = Randomize.String();
            Bank result = dao.Update(bank);
            return result;
        }

        public Bank Delete()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            dao.Delete(bank);
            return bank;
        }
    }
}
