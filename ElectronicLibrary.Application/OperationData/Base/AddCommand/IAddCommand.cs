using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ElectronicLibrary.Application.OperationData.Base.AddCommand
{
    public interface IAddCommand<TKey> : IRequest where TKey : struct
    {
    }
}
