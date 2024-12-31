namespace ExpenseTrackerApi.Web.Endpoints.Auth.SignUp;

public sealed record SignUpRequest(
    string Username,
    string Password,
    bool PasswordConfirmed
);