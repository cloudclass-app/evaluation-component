using System;

namespace Evaluations.Api.Data.Model
{
    public class CourseMember : IEntity
    {
        public Guid Id { get; set; }
        public Guid Organization { get; set; }
        
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public Guid UserId { get; set; }
        public CourseMemberRole Role { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
    }
}