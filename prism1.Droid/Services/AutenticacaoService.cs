using System;
using System.Threading.Tasks;
using Firebase.Auth;
using prism1.Services;

namespace prism1.Droid.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private const string API_KEY = "AIzaSyAig85XRqXPFq7Kl1vJOnrcqq63zecS5co";

        public async Task<bool> Autentica(string email, string senha)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
             
            try 
            {
                // Autenticando
				var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, senha);

                // Obtém o Token do Firebase
				Token = auth.FirebaseToken;
                // Obtém o UserId
                UserId = auth.User.LocalId;

                return true;
			}
            catch (FirebaseAuthException)
            {
                return false;
            }
		}

        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
