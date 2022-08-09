using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Src.Contextos;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
namespace BlogAPI.Src.Repositorios.Implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar ITema</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>

    public class TemaRepositorio : ITema
    {
        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion Atributos

        #region Construtores

        public TemaRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion Construtores

        #region Métodos

        public async Task<List<Tema>> PegarTodosTemasAsync()
        {
            return await _contexto.Temas.ToListAsync();
        }

        public async Task<Tema> PegarTemaPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("Id do Tema não encontrado");

            return await _contexto.Temas.FirstOrDefaultAsync(t => t.Id == id);

            //Funções auxiliares
            bool ExisteId(int id)
            {
                var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Id == id);

                return auxiliar != null;
            }
        }

        public async Task NovoTemaAsync(Tema tema)
        {
            if (ExisteDescricao(tema.Descricao)) throw new Exception("Descrição já existe no sistema!");

            await _contexto.Temas.AddAsync(
                new Tema
                {
                    Descricao = tema.Descricao
                });
            await _contexto.SaveChangesAsync();

            //Função Auxiliar
            bool ExisteDescricao(string descricao)
            {
                var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Descricao == descricao);
                return auxiliar != null;
            }
        }

        public async Task AtualizarTemaAsync(Tema tema)
        {
            var temaExistente = await PegarTemaPeloIdAsync(tema.Id);
            temaExistente.Descricao = tema.Descricao;
            _contexto.Temas.Update(temaExistente);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarTemaAsync(int id)
        {
            _contexto.Temas.Remove(await PegarTemaPeloIdAsync(id));
            await _contexto.SaveChangesAsync();

        }

        #endregion Métodos
    }
}