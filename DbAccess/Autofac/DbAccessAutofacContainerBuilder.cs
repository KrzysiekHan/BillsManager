using Autofac;
using DbAccess.Repository;
using DbAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Autofac
{
    public class DbAccessAutofacContainerBuilder
    {
        public void AddDependenciesToContainer(ContainerBuilder builder)
        {
            builder.RegisterType<BillRepository>().As<IBillRepository>().InstancePerDependency();
            builder.RegisterType<BillTypeDictRepository>().As<IBillTypeDictRepository>().InstancePerDependency();
            builder.RegisterType<RecipientRepository>().As<IRecipientRepository>().InstancePerDependency();

        }
    }
}
