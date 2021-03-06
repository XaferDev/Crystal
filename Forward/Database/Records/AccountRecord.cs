﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Castle.ActiveRecord;
using NHibernate.Criterion;
using NHibernate.Engine;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.RealmServer.Database.Records
{
    [Serializable]
    [ActiveRecord("accounts")]
    public class AccountRecord : ActiveRecordBase<AccountRecord>
    {
        [PrimaryKey("Id")]
        public int ID
        {
            get;
            set;
        }

        [Property("Username", NotNull = true)]
        public string Username
        {
            get;
            set;
        }

        [Property("Password", NotNull = true)]
        public string Password
        {
            get;
            set;
        }

        [Property("Pseudo")]
        public string Pseudo
        {
            get;
            set;
        }

        [Property("SecretQuestion")]
        public string SecretQuestion
        {
            get;
            set;
        }

        [Property("SecretAnswer")]
        public string SecretAnswer
        {
            get;
            set;
        }

        [Property("AdminLevel")]
        public int AdminLevel
        {
            get;
            set;
        }

        [Property("SubscriptionEndDate")]
        public double SubscriptionEndDate
        {
            get;
            set;
        }

        [Property("Points")]
        public int Points
        {
            get;
            set;
        }

        [Property("Logged")]
        public int Logged
        {
            get;
            set;
        }

        public static AccountRecord FindByUsername(string username)
        {
            return FindFirst(Restrictions.Eq("Username", username));
        }

        public double SubscriptionRemainingTime
        {
            get
            {
                return SubscriptionEndDate - Environment.TickCount;
            }
        }
    }
}
