using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using prism1.Models;
using prism1.Services;

namespace prism1.Droid.Services
{
    public class InfracoesService : IInfracoesService
    {
        private const string DATABASE_URL = "https://prismauth.firebaseio.com";
        private const string CHILD_NAME = "infracoes";

        private IAutenticacaoService _autenticacaoService;
        private FirebaseClient _client;

        public InfracoesService(IAutenticacaoService autenticacaoService) {
            _autenticacaoService = autenticacaoService;
        }

        public async Task<Infracao> Adiciona(Infracao infracao, System.IO.Stream photoStream)
        {
            if (photoStream != null) 
            {
				// Envia a foto para o servidor
                var task = new FirebaseStorage(
                    "prismauth.appspot.com", 
                    new FirebaseStorageOptions() {
                        AuthTokenAsyncFactory = () => Task.FromResult(_autenticacaoService.Token)
                    }
                )
            	.Child("fotografias")
            	.Child(Guid.NewGuid().ToString("N") + ".png")
            	.PutAsync(photoStream);
                
                infracao.Foto = await task;
            }

            // Define o usuário da infração para ser o user id
            // do usuário logado
            infracao.Usuario = _autenticacaoService.UserId;

            // Grava a infração no Banco de Dados
            return (await Client.Child(CHILD_NAME).PostAsync(infracao)).Object;
        }

        public async Task<IEnumerable<Infracao>> Lista()
        {
            var infracoes = await Client.Child(CHILD_NAME).OnceAsync<Infracao>();

            List<Infracao> retorno = new List<Infracao>();

            foreach (var infracao in infracoes) 
            {
                retorno.Add(infracao.Object);
            }

            return retorno;
        }

        private FirebaseClient Client {
            get {
                if (_client != null) return _client;

				_client = new FirebaseClient(
                    DATABASE_URL,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(_autenticacaoService.Token)
                    }
                );

                return _client;
            }
        }
    }
}
