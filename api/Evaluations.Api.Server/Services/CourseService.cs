using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Evaluations.Api.Data;

namespace Evaluations.Api.Server
{
    public class CourseServiceImpl : CourseService.CourseServiceBase
    {
        private readonly ILogger<CourseServiceImpl> _logger;

        public CourseServiceImpl(
            EvaluationContext dbContext,
            ILogger<CourseServiceImpl> logger)
        {
            _logger = logger;
        }

        public override Task<Course> Create(CourseNew request, ServerCallContext context)
        {
            return base.Create(request, context);
        }
    }
}