using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;

namespace ExpenseTrackerApi.Web.Endpoints.Auth.SignUp;

public sealed class SignUpEndpoint : Endpoint<SignUpRequest, SignUpResponse>
{
    private const string Route = "/auth/sign-up";

    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(SignUpRequest req, CancellationToken ct)
    {
        
    }
}