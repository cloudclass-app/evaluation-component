using System.Collections.Generic;
using System;

namespace Evaluations.Api.Data.Model
{
    public class Course : IEntity
    {
        public Guid Id { get; set; }
        public Guid Organization { get; set; }

        public string Name { get; set; } = "";
        public Guid[] Members { get; set; } = new Guid[] { };

        public IList<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}