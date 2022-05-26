using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;

namespace ElectronicLibrary.Application.OperationData.Base.GetPageableQuery
{
    public interface IGetPageableQuery<TViewModel> : IPageableQueryModel, IRequest<Response<PageableModel<TViewModel>>> where TViewModel : class
    {
    }
}
