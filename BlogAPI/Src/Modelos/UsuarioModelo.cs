﻿using BlogAPI.Src.Utilidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogAPI.Src.Modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_usuarios no banco.</para>
    /// <para>Criado por: Jonathan</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 17/07/2022</para>
    /// </summary>
    [Table("tb_usuarios")]
    public class Usuario
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Foto { get; set; }
        [Required]
        public TipoUsuario Tipo { get; set; }

        [JsonIgnore, InverseProperty("Criador")]
        public List<Postagem> MinhasPostagens { get; set; }

        #endregion
    }


}
