using System;
using myDojo.Domain.Events;
using myDojo.Domain.Events.MartialArtists;
using myDojo.Domain.Users;
using NUnit.Framework;

namespace myDojo.Domain.UnitTests.MartialArtists
{
    [TestFixture]
    public class when_a_student_is_promoted
    {
        
        [Test]
        public void the_rank_of_the_student_changes_to_what_the_instructor_promoted_him_to()
        {
            var rank = new Rank {Belt = "White", Stripes = 0};
            because_the_instructor_promoted_him_to(rank);
            _student.Rank.ShouldEqual(rank);
        }
        [Test]
        public void the_students_promotion_is_recorded()
        {
            var rank = new Rank {Belt = "Blue"};
            because_the_instructor_promoted_him_to(rank);
            _student.Promotions.ShouldHave(p => p.Instructor == _instructor && p.Rank.Equals(rank));
        }
        [Test]
        public void the_student_promoted_event_is_raised()
        {
             var rank = new Rank {Belt = "Blue"};
            Action promoting_the_student = () => because_the_instructor_promoted_him_to(rank);
            promoting_the_student.ShouldHaveRaised<StudentPromoted>(e =>
                                                                        {
                                                                            e.StudentId = _student.Id;
                                                                            e.Rank = rank;
                                                                            e.InstructorId = _instructor.Id;
                                                                        });
        }
        private Instructor _instructor;
        private MartialArtist _student;

        public void because_the_instructor_promoted_him_to(Rank rank)
        {
            _instructor.Promote(_student,rank);
        }
        [SetUp]
        public void Establish_context()
        {
            _instructor = new Instructor(null);
            _student = new MartialArtist(null);
        }
    }

  
}