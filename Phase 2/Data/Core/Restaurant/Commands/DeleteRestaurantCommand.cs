﻿namespace Pezza.Core.Restaurant.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public partial class DeleteRestaurantCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, Result>
    {
        private readonly IDataAccess<Common.Entities.Restaurant> dataAcess;

        public DeleteRestaurantCommandHandler(IDataAccess<Common.Entities.Restaurant> dataAcess)
            => this.dataAcess = dataAcess;

        public async Task<Result> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var outcome = await this.dataAcess.DeleteAsync(request.Id);

            return (outcome) ? Result.Success() : Result.Failure("Error deleting a Restaurant");
        }
    }
}
