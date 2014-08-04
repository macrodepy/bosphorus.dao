﻿using System;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Common
{
    public class BankBuilder : AbstractBuilder<Bank, BankBuilder>
    {
        public static BankBuilder Default
        {
            get { return Empty.WithNo("0092").WithName("City Bank"); }
        }

        public BankBuilder WithId(int id)
        {
            model.Id = id;
            return this;
        }

        public BankBuilder WithNo(string no)
        {
            model.No = no;
            return this;
        }

        public BankBuilder WithName(string name)
        {
            model.Name = name;
            return this;
        }
    }
}