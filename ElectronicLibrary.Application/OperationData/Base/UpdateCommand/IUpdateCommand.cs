using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ElectronicLibrary.Application.OperationData.Base.UpdateCommand
{
    public interface IUpdateCommand<TKey> : IRequest where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
