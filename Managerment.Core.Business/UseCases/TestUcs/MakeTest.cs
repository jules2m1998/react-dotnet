using AutoMapper;
using Management.Core.Domain.Entities;
using Managerment.Core.Business.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Core.Business.UseCases.TestUcs;

public static class MakeTest
{
    public record Query(string Number): IRequest<TestDTO>;
    public class Handler : IRequestHandler<Query, TestDTO>
    {
        private readonly IMapper mapper;

        public Handler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<TestDTO> Handle(Query request, CancellationToken cancellationToken)
        {
            var model = new Test
            {
                Id = int.Parse(request.Number),
                Name = "Name",
                Description = "Description",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now.AddDays(1),
            };

            return Task.FromResult(mapper.Map<TestDTO>(model));
        }
    }
}
