using System;

namespace Evaluations.Api.Data.Model
{
    public class EvaluationPartResult : IEntity
    {
        public Guid Id { get; set; }
        public Guid Organization { get; set; }

        public Guid UserId { get; set; }
        public string? Score { get; set; }

        public Guid PartId { get; set; }
        public EvaluationPart Part { get; set; } = new EvaluationPart();
    }
}