using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Representa uma chave do Registro do Windows para criação de um item de menu
  /// </summary>
  public abstract class RegistryBaseMenuItem
  {
    #region Construtor
    /// <summary>
    /// Cria uma instância da classe <see cref="RegistryBaseMenuItem"/>
    /// </summary>
    public RegistryBaseMenuItem()
    {
      Position = RegistryPositionEnum.Default;
    }

    /// <summary>
    /// Cria uma instância da classe <seealso cref="RegistryBaseMenuItem" /></summary>
    /// <param name="registryMainKey">Chave principal do registro</param>
    /// <param name="registryPath">Caminho do registro onde a chave se encontra</param>
    public RegistryBaseMenuItem(RegistryKey registryMainKey, string registryPath)
    {
      Position = RegistryPositionEnum.Default;
      RegistryMainKey = registryMainKey;
      RegistryPath = registryPath;
      Icon = string.Empty;
      ExtendedSubCommandsKey = string.Empty;
    }
    #endregion

    /// <summary>
    /// Chave principal do registro
    /// </summary>
    public RegistryKey RegistryMainKey { get; set; }

    /// <summary>
    /// Caminho do registro onde a chave se encontra
    /// </summary>
    public string RegistryPath { get; protected set; }

    /// <summary>
    /// Caption do item
    /// </summary>
    public string MUIVerb { get; set; }

    /// <summary>
    /// Ícone a ser exibido
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// Comando a ser executado
    /// </summary>
    public string Command { get; set; }

    /// <summary>
    /// Indica se o item tem altos privilégios
    /// </summary>
    public bool HasLUAShield { get; set; }

    /// <summary>
    /// Sub-comandos do menu
    /// </summary>
    public string ExtendedSubCommandsKey { get; set; }

    /// <summary>
    /// Command flags. Ex: 0x00000020	Show a separator above this item
    /// https://blog.sverrirs.com/2014/05/creating-cascading-menu-items-in.html
    /// </summary>
    public object CommandFlags { get; set; }

    /// <summary>
    /// Modelo de seleção: Single | Document | Player
    /// https://msdn.microsoft.com/en-us/library/cc144171(VS.85).aspx
    /// </summary>
    public string MultiSelectModel { get; set; }

    /// <summary>
    /// Posição do item
    /// </summary>
    public RegistryPositionEnum Position { get; set; }

    /// <summary>
    /// Executar o comando
    /// </summary>
    /// <param name="context">Contexto de execução</param>
    public virtual void Execute(object context)
    {

    }
  }
}
