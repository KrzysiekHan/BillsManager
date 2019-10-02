using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ViewModelLayer;
using ViewModelLayer.Factory;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Interfaces.Recipient;
using ViewModelLayer.Services;

namespace ViewModelLayer.Autofac
{
    public class VmlAutofacContainerBuilder 
    {
        public void AddDependenciesToContainer(ContainerBuilder builder)
        {
            builder.RegisterType<BillService>().As<IBillService>().InstancePerDependency();
            builder.RegisterType<BillFactory>().As<IBillFactory>().InstancePerDependency();

            builder.RegisterType<RecipientService>().As<IRecipientService>().InstancePerDependency();
            builder.RegisterType<RecipientFactory>().As<IRecipientFactory>().InstancePerDependency();
        }
    }
}
