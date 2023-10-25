using Firebase.Auth;
using FirebaseAuth.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseAuth.Features.SignUp
{
    public class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpFormViewModel _viewModel;
        private readonly FirebaseAuthClient _client;

        public SignUpCommand(SignUpFormViewModel viewModel, FirebaseAuthClient client)
        {
            _viewModel = viewModel;
            _client = client;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.Password != _viewModel.ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "Password and Confirm Password do not match.", "Ok");
                return ;
            }
            try
            {
                await _client.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                await Application.Current.MainPage.DisplayAlert("Success", "You've Signed Up!", "Ok");

            } catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "SignUp Failed.", "Ok");
            }
           
        }
    }
}
