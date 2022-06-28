using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Decoration.Commands
{
    /// <summary>
    /// Class handling AddDecoration Request
    /// </summary>
    public class AddDecorationCommandHandler : IRequestHandler<AddDecorationCommand>
    {
        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public Task<Unit> Handle(AddDecorationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
