using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using WinShellShortcuts.RegistryItens;

namespace WinShellShortcuts
{
  /// <summary>
  /// Representa parâmetros de linha de comando
  /// </summary>
  class ArgsItem
  {
    /// <summary>
    /// Cria uma instância da classe <see cref="ArgsItem"/>
    /// </summary>
    private ArgsItem()
    {
      Parametro = null;
      CategoriaComando = CategoriaComandoEnum.None;
      TipoComando = TipoComandoEnum.None;
    }

    /// <summary>
    /// Parametro
    /// </summary>
    public string Parametro { get; private set; }

    internal string Print()
    {
      return $"Parâmetro: {Parametro} - Categoria: {CategoriaComando} - Tipo: {TipoComando}";
    }

    /// <summary>
    /// Definir a Categoria de um comando
    /// </summary>
    public CategoriaComandoEnum CategoriaComando { get; private set; }

    /// <summary>
    /// FullClassName da classe
    /// </summary>
    public Type ClassType { get; set; }

    /// <summary>
    /// Tipo de comando
    /// </summary>
    public TipoComandoEnum TipoComando { get; set; }

    /// <summary>
    /// Criar uma instância da classe <see cref="ArgsItem"/>
    /// </summary>
    /// <param name="args">Argumentos de linha de comando</param>
    /// <returns>Instância da classe</returns>
    public static ArgsItem Parse(string[] args)
    {
      ArgsItem item = new ArgsItem();

      Func<string, string> lerParametroComDefinicao = modificador =>
      {
        string nomeComando = (from str in args
                              where str.StartsWith(modificador, StringComparison.CurrentCultureIgnoreCase)
                              let start = str.IndexOf("=")
                              select str.Substring(start + 1)).FirstOrDefault();
        return nomeComando;
      };

      string comando = lerParametroComDefinicao("/c");
      if (!string.IsNullOrEmpty(comando))
        item.CategoriaComando = CategoriaComandoEnum.CopiarNome;
      else
      {
        comando = lerParametroComDefinicao("/h");
        if (!string.IsNullOrEmpty(comando))
          item.CategoriaComando = CategoriaComandoEnum.Handle;
        else
        {
          comando = lerParametroComDefinicao("/p");
          if (!string.IsNullOrEmpty(comando))
            item.CategoriaComando = CategoriaComandoEnum.Prompt;
        }
      }

      if (!string.IsNullOrWhiteSpace(comando))
      {
        item.ClassType = Type.GetType(comando);

        //item.TipoComando = (TipoComandoEnum)Enum.Parse(typeof(TipoComandoEnum), comando);
        item.Parametro = args[args.Length - 1];
      }
      return item;
    }
  }
}
