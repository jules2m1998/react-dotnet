using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Domain.Exceptions;

public class BaseException: Exception
{
    public virtual string Title { get; set; } = string.Empty;
    public Dictionary<string, string[]>? Errors { get; }

    public BaseException(): base()
    {
        Errors = new Dictionary<string, string[]>();
    }

    public BaseException(string message) : base(message)
    {
        Errors = new Dictionary<string, string[]>
        {
            ["default"] = new[] {message}
        };
    }

    public BaseException(ValidationFailure failure)
    {
        Errors = new Dictionary<string, string[]>
        {
            [failure.PropertyName] = new[] {failure.ErrorMessage} 
        };
    }

    public BaseException(ICollection<ValidationFailure> failures, string? message = null): base(message)
    {
        Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}
