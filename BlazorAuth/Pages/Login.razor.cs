using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorAuth;
using BlazorAuth.Shared;
using BlazorAuth.Authentication;
using BlazorAuth.Models;

namespace BlazorAuth.Pages
{
    public partial class Login
    {
        //[Inject]
        //private CustomAuthenticationStateProvider _customAuthenticationStateProvider { get; set; }
        [Inject]
        private AuthenticationStateProvider? _authenticationStateProvider { get; set; }

        [Inject]
        private NavigationManager? _navigationManager { get; set; }

        private User _user = new User();
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _authenticationStateProvider.AuthenticationStateChanged += HandleAuthenticatonStateChanged;
        }

        private async void HandleAuthenticatonStateChanged(Task<AuthenticationState> task)
        {
            var authState = await task;
            var user = authState.User;

            if(user.Identity.IsAuthenticated)
            {
                _navigationManager?.NavigateTo("/");
            }
        }

        private void HandleValidSubmit()
        {
            if((bool)_user?.Email?.Equals("guest@email.com", StringComparison.OrdinalIgnoreCase) &&
               (bool)_user?.Password?.Equals("guest", StringComparison.OrdinalIgnoreCase)) 
            {
                var customAuthStateProvider = _authenticationStateProvider as CustomAuthenticationStateProvider;

                customAuthStateProvider.AuthenticateUser(_user.Email);
            }
        }
    }
}