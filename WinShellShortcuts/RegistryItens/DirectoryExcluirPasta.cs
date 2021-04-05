using System;
using System.Diagnostics;

using Microsoft.Win32;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Exclusão de pasta via MS-DOS
  /// </summary>
  public class DirectoryExcluirPasta : RegistryBaseMenuItem
  {
    /// <summary>
    /// Inicialização da classe: <see cref="DirectoryExcluirPasta"/>.
    /// </summary>
    public DirectoryExcluirPasta() : base()
    {

    }

    /// <summary>
    /// Inicialização da classe: <see cref="DirectoryExcluirPasta"/>.
    /// </summary>
    /// <param name="path">Caminho do registro onde a chave se encontra</param>
    /// <param name="paramPattern">Padrão para recuperar o parâmetro. Ex: %1, %V</param>
    public DirectoryExcluirPasta(string path, string paramPattern)
          : base(Registry.ClassesRoot, path + "\\Shell\\06ExcluirPasta")
    {
      MUIVerb = "Excluir pasta";
      Icon = "%SystemRoot%\\system32\\shell32.dll,234";
      Command = $"\"{Constantes.WinShellShortcutsFullPath}\" /p={typeof(DirectoryExcluirPasta).FullName} \"{paramPattern}\" ";
    }

    /// <summary>
    /// Executar o comando
    /// </summary>
    /// <param name="context">Contexto de execução</param>
    public override void Execute(object context)
    {
      string parametro = Convert.ToString(context);
      if (!string.IsNullOrEmpty(parametro))
      {
        string parametroMontado = "/c rd " + "\"" + parametro + "\"" + " /s";
        Process.Start("cmd.exe", parametroMontado);
      }
    }

  }
}
