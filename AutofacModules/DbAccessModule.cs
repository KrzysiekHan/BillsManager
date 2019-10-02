using Autofac;
using DbAccess.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacModules
{
    public class DbAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            DbAccessAutofacContainerBuilder dbAccessAutofacContainer = new DbAccessAutofacContainerBuilder();
            dbAccessAutofacContainer.AddDependenciesToContainer(builder);
        }
    }
}
