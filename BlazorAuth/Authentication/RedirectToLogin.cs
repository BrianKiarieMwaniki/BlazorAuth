using Microsoft.AspNetCore.Components;

namespace BlazorAuth.Authentication
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        private NavigationManager? _navigationManager { get; set;}

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _navigationManager?.NavigateTo("/login");
        }
    }
}
