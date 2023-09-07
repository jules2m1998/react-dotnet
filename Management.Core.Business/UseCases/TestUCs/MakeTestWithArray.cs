using AutoMapper;
using Management.Core.Business.DTOs.Test;
using Management.Core.Business.Wrappers;
using Management.Core.Domain.Entities;
using MediatR;

namespace Management.Core.Business.UseCases.TestUCs;

public static class MakeTestWithArray
{
    public record Query(TestParametersDto QueryParams): IRequest<PagedList<TestDto>>;
    public class Handler : IRequestHandler<Query, PagedList<TestDto>>
    {
        private readonly IMapper mapper;

        public Handler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<PagedList<TestDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var data = Enumerable.Range(1, 100).Select(index => new Test
            {
                Name = $"Name {index}",
                Id = index,
                Description = $"Description {index}",
                Status = 100
            }).AsQueryable();
            var mapped = mapper.Map<ICollection<TestDto>>(data);

            var result = PagedList<TestDto>.Create(mapped.AsQueryable(), request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
