using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;

namespace ElectronicLibrary.Application.OperationData.Base.GetByIdQuery
{
    public interface IGetByIdQuery<TKey, TViewModel> : IRequest<Response<TViewModel>> where TKey: struct where TViewModel : class
    {
        TKey Id { get; set; }
    }
}
