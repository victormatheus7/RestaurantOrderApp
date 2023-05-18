using MediatR;

namespace RestaurantOrderApp.Application.CommandSide.Command
{
    internal interface ICommand : IRequest
    {
        DateTime ModifiedDate { get => DateTime.Now; }
    }

    internal interface ICommand<out TResult> : IRequest<TResult>
    {
        DateTime ModifiedDate { get => DateTime.Now; }
    }
}
