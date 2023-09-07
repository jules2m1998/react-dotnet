using AutoMapper;
using Management.Core.Business.DTOs.Test;
using Management.Core.Domain.Entities;
using Management.Core.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Business.UseCases.TestUCs;

public static class MakeTest
{
    public record Query(int A, int B): IRequest<TestDto>;

    public class Handler : IRequestHandler<Query, TestDto>
    {
        private readonly IMapper mapper;

        public Handler(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public Task<TestDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var test = new Test
            {
                Id = 1,
                Name = "NAME",
                Description = "test",
                Status = request.A + request.B,
            };
            var result = mapper.Map<TestDto>(test);
            return Task.FromResult(result);
        }
    }

}
