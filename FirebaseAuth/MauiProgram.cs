using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAuth.Features.SignUp;
using FirebaseAuth.Pages.SignUp;
using FirebaseAuth.Features.SignIn;
using FirebaseAuth.Pages.SignIn;
using Microsoft.Extensions.Logging;

namespace FirebaseAuth
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<SignInFormViewModel>();
            builder.Services.AddTransient<SignInViewModel>();
            builder.Services.AddTransient<SignInView>(
                s => new SignInView(s.GetRequiredService<SignInViewModel>()));

            builder.Services.AddTransient<SignUpFormViewModel>();
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<SignUpView>(
                s => new SignUpView(s.GetRequiredService<SignUpViewModel>()));

            builder.Services.AddSingleton(
                services => new FirebaseAuthClient(
                    new FirebaseAuthConfig()
                    {
                        ApiKey= "AIzaSyAMz_uZZUMlWKbRSnDgt0X_z0WWWWRlmdE",
                        AuthDomain = "time-tracker-15dc4.firebaseapp.com",
                        Providers = new FirebaseAuthProvider[]
                        {
                            new EmailProvider() 
                        } 
                    }
                )
            );
            return builder.Build();
        }
    }
}