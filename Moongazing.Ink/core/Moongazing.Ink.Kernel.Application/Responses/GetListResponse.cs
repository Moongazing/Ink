using Moongazing.Ink.Kernel.Persistence.Paging;

namespace Moongazing.Ink.Kernel.Application.Responses;

public class GetListResponse<T> : BasePageableModel
{
    public IList<T> Items
    {
        get => items ??= new List<T>();
        set => items = value;
    }
    private IList<T>? items;
}