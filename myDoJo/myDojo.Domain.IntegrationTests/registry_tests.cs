using System;
using Db4objects.Db4o;
using myDojo.Domain.Events;
using myDojo.Domain.Events.MartialArtists;
using myDojo.Domain.UnitTests;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;
using MyDojo.Query.ViewModels;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap;

namespace myDojo.Domain.IntegrationTests
{
    [TestFixture]
    public class registry_tests
    {
        private IContainer _container;
        [Test]
        public void get_a_martialartistchangedname_handler()
        {
            _container.GetAllInstances<Handles<MartialArtistChangedName>>().ShouldHave(
                h => h.GetType() == typeof (MartialArtistDetailsWriter));
        }
        [Test]
        public void container_is_valid()
        {
            _container.AssertConfigurationIsValid();
        }
        [Test]
        public void what_do_i_have()
        {
            Console.Write(
                _container.WhatDoIHave());
        }
        [SetUp]
        public void setup()
        {
            var mockedObjectFactory = MockRepository.GenerateMock<IObjectContainer>();
            ObjectFactory.Configure(c =>
            {
                c.Scan(s =>
                {
                    s.AssembliesFromApplicationBaseDirectory();
                    s.LookForRegistries();
                });
                c.For<IObjectContainer>().Use(mockedObjectFactory);
            });
            _container = ObjectFactory.Container;
        }
    }
}