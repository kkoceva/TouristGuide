using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Infrastructure.Data.Common;

namespace TouristGuide.Core.Services
{
    public class CommentService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public CommentService(
            IRepository _repo,
            ILogger<CommentService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }


    }
}
