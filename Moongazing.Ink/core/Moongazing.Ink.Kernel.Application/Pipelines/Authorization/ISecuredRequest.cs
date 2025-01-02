namespace Moongazing.Ink.Kernel.Application.Pipelines.Authorization;

public interface ISecuredRequest
{
    public string[] Roles { get; }
}