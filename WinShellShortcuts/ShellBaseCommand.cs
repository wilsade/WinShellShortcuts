using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WinShellShortcuts
{
  public abstract class ShellBaseCommand
  {
    #region Construtor
    /// <summary>
    /// Cria uma instância da classe <seealso cref="ShellBaseCommand"/>
    /// </summary>
    /// <param name="shellPath">(Gets or sets) Caminho para a chave 'Shell' no RegEdit</param>
    public ShellBaseCommand(string shellPath)
    {
      ShellPath = shellPath;
    }
    #endregion

    protected RegistryKey FindInRegedit(string captionName)
    {
      var registro = Registry.ClassesRoot.OpenSubKey(ShellPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
      if (registro != null)
      {
        try
        {
          var chaves = registro.GetSubKeyNames();
          foreach (var esteChave in chaves)
          {
            var subChave = Registry.ClassesRoot.OpenSubKey(System.IO.Path.Combine(ShellPath, esteChave), RegistryKeyPermissionCheck.ReadWriteSubTree);
            var achei = subChave.GetValueNames().FirstOrDefault(x => x.Equals(typeof(ShellBaseCommand).Name));
            if (achei != null)
            {
              var valor = subChave.GetValue(achei);
              if (valor != null && valor.Equals(this.GetType().Name))
              {
                // Achou chave. Vamos mudar o nome
                throw new NotImplementedException();
                return subChave;
              }
            }
          }
          return null;
        }
        finally
        {
          registro.Close();
        }
      }
      else
        throw new Exception("Nâo foi possível ler o registro do Windos: " + ShellPath);
    }

    /// <summary>
    /// (Gets or sets) Caminho para a chave 'Shell' no RegEdit
    /// </summary>
    public string ShellPath { get; protected set; }

    /// <summary>
    /// (Gets or sets) Nome para identificar este comando
    /// </summary>
    public string UniqueName { get; protected set; }

    /// <summary>
    /// (Gets or sets) Rótulo do comando. É o que vai aparecer no menu de contexto
    /// </summary>
    public string Caption { get; protected set; }

    /// <summary>
    /// (Gets or sets) Instrução que executa o comando. Ex: cmd.exe /k
    /// </summary>
    public string Value { get; protected set; }

    /// <summary>
    /// Adiciona ou atualiza o comando
    /// </summary>
    /// <param name="caption">Rótulo do comando.</param>
    public abstract void AddOrUpdate(string caption);

    /// <summary>
    /// Excluir o comando
    /// </summary>
    public abstract void Delete();
  }
}
