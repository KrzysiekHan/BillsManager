using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Autofac;

namespace AutofacModules
{
    public class ViewModelLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            VmlAutofacContainerBuilder vmlAutofacContainer = new VmlAutofacContainerBuilder();
            vmlAutofacContainer.AddDependenciesToContainer(builder);
        }
    }
}
