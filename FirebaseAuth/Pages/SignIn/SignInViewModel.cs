using FirebaseAuth.Features.SignIn;
using FirebaseAuth.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseAuth.Pages.SignIn
{
    public class SignInViewModel : ViewModelBase
    {
        public SignInFormViewModel SignInFormViewModel { get;  }

        public SignInViewModel(SignInFormViewModel signInFormViewModel)
        {
            SignInFormViewModel = signInFormViewModel;
        }
    }
}
