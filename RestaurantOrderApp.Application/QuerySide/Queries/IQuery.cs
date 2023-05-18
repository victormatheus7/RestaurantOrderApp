using MediatR;

namespace RestaurantOrderApp.Application.QuerySide.Queries
{
    internal interface IQuery<out TResult> : IRequest<TResult>
    { }
}
