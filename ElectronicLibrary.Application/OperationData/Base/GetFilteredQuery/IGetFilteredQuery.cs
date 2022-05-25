using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;

namespace ElectronicLibrary.Application.OperationData.Base.GetFilteredQuery
{
    public interface IGetFilteredQuery<TKey> : ISelectQueryModel,IRequest<Response<List<SelectModel<TKey>>>> where TKey : struct
    {
    }
}
