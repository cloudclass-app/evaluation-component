using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluations.Api.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
        Guid Organization { get; set; }
    }
}