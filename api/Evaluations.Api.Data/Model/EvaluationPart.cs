using System;
using System.Collections.Generic;

namespace Evaluations.Api.Data.Model
{
    public class EvaluationPart : IEntity
    {
        public Guid Id { get; set; }
        public Guid Organization { get; set; }

        public DateTime Date { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string? MaxScore { get; set; }
        public EvaluationPartKind Kind { get;set; }
        
        public Guid EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; } = new Evaluation();
        public IList<EvaluationPartResult> MyProperty { get; set; } = new List<EvaluationPartResult>();
    }
}