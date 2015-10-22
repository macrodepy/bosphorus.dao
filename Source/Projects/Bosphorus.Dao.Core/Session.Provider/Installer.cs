﻿using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Fluent.Decoration;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Core.Session.Provider.Decoration.NullSafe;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ISessionProvider>()
                    .ImplementedBy<TransientSessionProvider>(),

                Decorator
                    .Of<ISessionProvider>()
                    .Is<NullSafeDecorator>(),

                Component
                    .For<ExtensionConfiguration>()
            );
        }
    }
}