using Firebase.Auth;
using FirebaseAuth.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseAuth.Features.SignIn
{
    public class SignInCommand : AsyncCommandBase
    {
        private readonly SignInFormViewModel _viewModel;
        private readonly FirebaseAuthClient _client;

        public SignInCommand(SignInFormViewModel viewModel, FirebaseAuthClient client)
        {
            _viewModel = viewModel;
            _client = client;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _client.SignInWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                await Application.Current.MainPage.DisplayAlert("Success", "You've Signed In!", "Ok");

            } catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "SignIn Failed.", "Ok");
            }
        }
    }
}
