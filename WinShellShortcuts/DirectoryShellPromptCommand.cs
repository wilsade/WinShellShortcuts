using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts
{
  /// <summary>
  /// Definir um comando para abrir o prompt para: Diretório
  /// </summary>
  /// <seealso cref="WinShellShortcuts.ShellBaseCommand" />
  public class DirectoryShellPromptCommand : ShellBaseCommand
  {
    /// <summary>
    /// Cria uma instância da classe <seealso cref="DirectoryShellPromptCommand"/>
    /// </summary>
    public DirectoryShellPromptCommand()
      :base(ShellPathClass.GetPath(ShellPathEnum.Directory_shell))
    {
      UniqueName = typeof(DirectoryShellPromptCommand).Name;
      Value = "cmd.exe /k cd %1";
    }

    /// <summary>
    /// Adiciona ou atualiza o comando
    /// </summary>
    /// <param name="caption">Rótulo do comando.</param>
    public override void AddOrUpdate(string caption)
    {
      base.FindInRegedit(caption);
      throw new NotImplementedException();
    }

    /// <summary>
    /// Excluir o comando
    /// </summary>
    public override void Delete()
    {
      throw new NotImplementedException();
    }
  }
}
