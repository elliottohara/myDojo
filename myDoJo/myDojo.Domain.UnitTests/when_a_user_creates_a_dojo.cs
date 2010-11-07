using System;
using System.Linq;
using myDojo.Domain.Events.Dojos;
using myDojo.Domain.Users;
using NUnit.Framework;

namespace myDojo.Domain.UnitTests
{
    [TestFixture]
    public class when_a_user_creates_a_dojo
    {
       
        [Test] 
        public void the_dojo_is_added_to_his_list()
        {
            because_CreateDojo_was_called();
            _user.DojosCreated.ShouldHave(d => d.Id == _newDojoId);
        }
        [Test]
        public void the_dojo_created_event_is_raised()
        {
            Action creating_the_dojo = because_CreateDojo_was_called;
            creating_the_dojo.ShouldHaveRaised<UserCreatedDojo>(e =>
                                                                   {
                                                                       e.UserId.ShouldEqual(_user.Id);
                                                                       e.DojoId.ShouldEqual(_newDojoId);
                                                                   });
        }
        [Test]
        public virtual void the_created_dojos_creator_is_set_to_the_user()
        {
            because_CreateDojo_was_called();
            _user.DojosCreated.First().Creator.ShouldEqual(_user);
        }
        
        private User _user;
        private Guid _newDojoId;
        public void because_CreateDojo_was_called()
        {
            _user = new User();
            _newDojoId = Guid.NewGuid();
            _user.CreateDojoWithId(_newDojoId);
        }
    }
}