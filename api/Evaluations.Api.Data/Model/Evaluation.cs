using System;
using System.Collections.Generic;

namespace Evaluations.Api.Data.Model
{
    public class Evaluation : IEntity
    {
        public Guid Id { get; set; }
        public Guid Organization { get; set; }

        public DateTime Date { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public EvaluationKind Kind { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
        public IList<EvaluationPart> Parts { get; set; } = new List<EvaluationPart>();
    }
}