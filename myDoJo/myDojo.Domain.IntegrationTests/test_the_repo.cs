using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Internal;
using myDojo.Domain.UnitTests;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.Db4o;
using NUnit.Framework;

namespace myDojo.Domain.IntegrationTests
{
    [TestFixture]
    public class test_the_repo
    {
        [Test]
        public void store_and_retrieve_a_martialartist()
        {
            var ma = new MartialArtist(null);
            _repo.Store(ma);
            _dbContainer.Close();
            var newContainer = Db4oFactory.OpenFile(dbFile);
            var repo2 = new Db4OAggrigateRootRepository<MartialArtist>(newContainer);
            var retrieved = repo2.GetById(ma.Id);
            retrieved.ShouldEqual(ma);
            newContainer.Close();
        }
        private IObjectContainer _dbContainer;
        private Db4OAggrigateRootRepository<MartialArtist> _repo;
        private const string dbFile = "tests.db";
        [SetUp]
        public void setup()
        {
            _dbContainer = Db4oFactory.OpenFile(dbFile);
            _repo = new Db4OAggrigateRootRepository<MartialArtist>(_dbContainer);
        }
        [TearDown]
        public void teardown()
        {
            _dbContainer.Close();
           File.Delete(dbFile);
        }
    }
}