using MediatR;

namespace RestaurantOrderApp.Application.QuerySide.Queries
{
    internal interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    { }
}