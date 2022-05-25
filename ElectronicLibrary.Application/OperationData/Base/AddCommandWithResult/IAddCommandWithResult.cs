using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;

namespace ElectronicLibrary.Application.OperationData.Base.AddCommandWithResult
{
    public interface IAddCommandWithResult<TKey> : IRequest<Response<TKey>> where TKey : struct
    {
    }
}
