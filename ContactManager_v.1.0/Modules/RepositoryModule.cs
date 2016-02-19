﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using Autofac;
using System.Reflection;

namespace ContactManager_v._1._0.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("ContactManager_v.1.0.Repository"))
                  .Where(t => t.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();
        }
    }
}