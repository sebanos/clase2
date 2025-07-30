using Microsoft.AspNetCore.Components;

namespace TaskFlowPro.Web.Features.Auth.Components;

public partial class AuthFlowBase : ComponentBase
{
    protected string CurrentAuthView { get; set; } = "login";

    protected void SwitchToRegister()
    {
        CurrentAuthView = "register";
    }

    protected void SwitchToLogin()
    {
        CurrentAuthView = "login";
    }
}
