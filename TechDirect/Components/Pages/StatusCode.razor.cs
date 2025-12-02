using Microsoft.AspNetCore.Components;

namespace TechDirect.Components.Pages;

public partial class StatusCode : ComponentBase
{
    [Parameter]
    public int Code { get; set; }
}
