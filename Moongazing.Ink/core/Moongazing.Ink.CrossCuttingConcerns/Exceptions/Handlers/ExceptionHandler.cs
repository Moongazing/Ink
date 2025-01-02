using Moongazing.Ink.Kernel.CrossCuttingConcerns.Exceptions.Types;
using ValidationException = Moongazing.Ink.Kernel.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Moongazing.Ink.Kernel.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public abstract Task HandleException(BusinessException businessException);
    public abstract Task HandleException(ValidationException validationException);
    public abstract Task HandleException(AuthorizationException authorizationException);
    public abstract Task HandleException(NotFoundException notFoundException);
    public abstract Task HandleException(Exception exception);
}
