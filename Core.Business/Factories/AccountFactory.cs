using Banking.AppCore.Common.Enums;
using Banking.AppCore.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Banking.AppCore.Business.Factories
{
    public class AccountFactory
    {
        Dictionary<string, Type> _accounts;

        public AccountFactory()
        {
            LoadAccountTypes();
        }

        public IAccount CreateInstance(AccountTypeEnum accountToCreate)
        {
            Type t = GetAccountType(accountToCreate);
            if (t == null)
            {
                return null; //TODO:  implement NULL object pattern
            }
            return Activator.CreateInstance(t) as IAccount;
        }

        private Type GetAccountType(AccountTypeEnum accountToCreate)
        {
            foreach (var acct in _accounts)
            {
                if (acct.Key.Contains(accountToCreate.ToString().ToLower()))
                {
                    return _accounts[acct.Key];
                }
            }
            return null;
        }

        private void LoadAccountTypes()
        {
            _accounts = new Dictionary<string, Type>();
            Assembly a = Assembly.Load("Banking.AppCore.Common");
            Type[] types = a.GetTypes();

            foreach(Type t in types)
            {
                if (t.GetInterface(typeof(IAccount).ToString()) != null)
                {
                    _accounts.Add(t.Name.ToLower(), t);
                }
            }
        }
    }
}
