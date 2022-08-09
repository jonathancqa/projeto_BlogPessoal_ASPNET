using BlogAPI.Src.Contextos;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogTeste.Contextos
{
    namespace BlogTeste.Contextos
    {
        /// <summary>
        /// <para>Resumo: Classe para texte unitario de contexto de usuario</para>
        /// <para>Criado por: Generation</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 17/07/2022</para>
        /// </summary>
        [TestClass]
        public class UsuarioContextoTeste
        {
            #region Atributos

            private BlogPessoalContexto _contexto;

            #endregion

            #region Métodos
            [TestMethod]

            public void InserirNovoUsuarioRetornaUsuarioInserido()
            {
                //Ambiente
                var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
                .Options;

                _contexto = new BlogPessoalContexto(opt);

                _contexto.Usuarios.Add(new Usuario
                {
                    Nome = "Jonathan",
                    Email = "jonathan@email.com",
                    Senha = "123456",
                    Foto = "URLDAFOTO"
                });
                _contexto.SaveChanges();

                var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email == "jonathan@email.com");
                Assert.IsNotNull(resultado);
                Assert.AreEqual("jonathan@email.com", resultado.Email);
            }

            #endregion
        }
    }

}