using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Address.Commands;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ElectronicBookingSystem.Tests
{
    public class AddressTest
    {
        [Fact]
        public async Task UpdateOnNonExisting_ShouldThrowError()
        {
            //Arrange
            var mediator = new Mock<IMediator>();
            var repository = new Mock<IRepository<Address>>();
            var mapper = new Mock<IMapper>();
            //Act
            var command = new UpdateAddressCommand();
            var handler = new UpdateAddressCommandHandler(repository.Object, mapper.Object);
            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, System.Threading.CancellationToken.None));
        }
    }
}
