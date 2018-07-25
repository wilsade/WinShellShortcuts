using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinShellShortcuts.RegistryItens;

namespace WinShellShortcuts
{
  public class RegistryUtils
  {
    static void Add(string chave, string nomeValor, object valor, RegistryValueKind regKind = RegistryValueKind.String)
    {
      Add(Registry.ClassesRoot, chave, nomeValor, valor, regKind);
    }

    static void Add(RegistryKey regKeyRoot, string chave, string nomeValor, object valor, RegistryValueKind regKind = RegistryValueKind.String)
    {
      var registro = regKeyRoot.CreateSubKey(chave, RegistryKeyPermissionCheck.ReadWriteSubTree);
      try
      {
        if (registro != null)
        {
          try
          {
            registro.SetValue(nomeValor, valor, regKind);
          }
          catch (Exception ex)
          {
            MessageBoxEx.ShowError("Não foi possível salvar o registro no Windows:" + Environment.NewLine + Environment.NewLine +
              ex.Message);
          }
          finally
          {
            registro.Close();
          }
        }
        else
          MessageBoxEx.ShowWarning("Nâo foi possível ler o registro do Windos.");
      }
      catch (Exception ex)
      {
        MessageBoxEx.ShowWarning("Nâo foi possível ler o registro do Windos:" + Environment.NewLine + Environment.NewLine +
          ex.Message);
      }

    }

    internal static void AddOrUpdate(RegistryBaseMenuItem item)
    {
      using (RegistryKey mainKey = item.RegistryMainKey.CreateSubKey(item.RegistryPath, RegistryKeyPermissionCheck.ReadWriteSubTree))
      {
        // Caption
        mainKey.SetValue(nameof(item.MUIVerb), item.MUIVerb, RegistryValueKind.String);

        // Ícone
        mainKey.SetValue(nameof(item.Icon), item.Icon, RegistryValueKind.String);

        // Ícone com privilégios
        if (item.HasLUAShield && !string.IsNullOrEmpty(item.Icon))
          mainKey.SetValue(nameof(item.HasLUAShield), string.Empty, RegistryValueKind.String);
        else
          mainKey.DeleteValue(nameof(item.HasLUAShield), false);

        // CommandFlags
        if (item.CommandFlags != null)
          mainKey.SetValue(nameof(item.CommandFlags), item.CommandFlags, RegistryValueKind.DWord);
        else
          mainKey.DeleteValue(nameof(item.CommandFlags), false);

        // MultiSelectModel
        if (!string.IsNullOrEmpty(item.MultiSelectModel))
          mainKey.SetValue(nameof(item.MultiSelectModel), item.MultiSelectModel, RegistryValueKind.String);
        else
          mainKey.DeleteValue(nameof(item.MultiSelectModel), false);

        // Sub-comandos
        mainKey.SetValue(nameof(item.ExtendedSubCommandsKey), item.ExtendedSubCommandsKey, RegistryValueKind.String);

        // Posição
        if (item.Position != RegistryPositionEnum.Default)
          mainKey.SetValue(nameof(item.Position), item.Position.ToString(), RegistryValueKind.String);
        else
          mainKey.DeleteValue(nameof(item.Position), false);

        // Comando
        if (!string.IsNullOrEmpty(item.Command))
        {
          using (var chaveComando = mainKey.CreateSubKey(nameof(item.Command), RegistryKeyPermissionCheck.ReadWriteSubTree))
          {
            chaveComando.SetValue(null, item.Command, RegistryValueKind.String);
          }
        }
        else
          mainKey.DeleteSubKey(nameof(item.Command), false);

      }
    }

    internal static void Delete(RegistryBaseMenuItem item)
    {
      using (var itemKey = item.RegistryMainKey.OpenSubKey(item.RegistryPath, false))
      {
        if (itemKey != null)
          item.RegistryMainKey.DeleteSubKeyTree(item.RegistryPath);
      }
    }

    public static void AddDirectoryPrompt(string nomeMenu, string nomeMenuAdm)
    {
      //Directory: Prompt aqui
      string chave = string.Format(Constantes.DirectoryPromptAquiCommand, nomeMenu);
      Add(chave, null, DirectoryValues.PromptAqui);
      Add(string.Format(Constantes.DirectoryPromptAqui, nomeMenu), Constantes.Icon, Constantes.IconePrompt);

      //Directory Background: Prompt aqui
      chave = string.Format(Constantes.DirectoryBackPromptAquiCommand, nomeMenu);
      Add(chave, null, DirectoryBackgroundValues.PromptAqui);
      Add(string.Format(Constantes.DirectoryBackPromptAqui, nomeMenu), Constantes.Icon, Constantes.IconePrompt);

      //Directory: Prompt aqui (Adm)
      chave = Constantes.DirectoryShellRunas;
      Add(chave, null, nomeMenuAdm);
      Add(chave, Constantes.NoWorkingDirectory, "");
      Add(Constantes.DirectoryShellRunasCommand, null, DirectoryValues.RunasValues.PromptAqui);

      //Directory Background: Prompt aqui (Adm)
      chave = Constantes.DirectoryBackgroundShellRunas;
      Add(chave, null, nomeMenuAdm);
      Add(chave, Constantes.NoWorkingDirectory, "");
      Add(Constantes.DirectoryBackgroundShellRunasCommand, null, DirectoryBackgroundValues.RunasValues.PromptAqui);
    }

    public static void AddDirectoryCopiarNomePasta(string menuCopiarNomePasta, string menuVerificarUsoPasta)
    {
      // Directory: Copiar nome da pasta
      string chave = string.Format(Constantes.DirectoryCopiarNomePastaCommand, menuCopiarNomePasta);
      Add(chave, null, DirectoryValues.CopiarNomePasta);
      Add(string.Format(Constantes.DirectoryCopiarNomePasta, menuCopiarNomePasta), Constantes.Icon, Constantes.IconeCopiarPasta);

      // Directory: Verificar uso da pasta
      chave = string.Format(Constantes.DirectoryVerificarUsoPastaCommand, menuVerificarUsoPasta);
      Add(chave, null, DirectoryValues.VerificarUsoPasta);
      Add(string.Format(Constantes.DirectoryVerificarUsoPasta, menuVerificarUsoPasta), Constantes.Icon, Constantes.IconeVerificarUsoPasta);

      // Directory back: Copiar nome da pasta
      chave = string.Format(Constantes.DirectoryBackCopiarNomePastaCommand, menuCopiarNomePasta);
      Add(chave, null, DirectoryBackgroundValues.CopiarNomePasta);
      Add(string.Format(Constantes.DirectoryBackCopiarNomePasta, menuCopiarNomePasta), Constantes.Icon, Constantes.IconeCopiarPasta);
    }

    public static void AddMenusArquivo(string menuPrompt, string menuPromptAdm, string menuPasta, string nomeMenuArquivo)
    {
      // Prompt
      string chave = string.Format(Constantes.ArquivoPromptAquiCommand, menuPrompt);
      Add(chave, null, ArquivoValues.PromptAqui2);
      Add(string.Format(Constantes.ArquivoPromptAqui, menuPrompt), Constantes.Icon, Constantes.IconePrompt);

      // Copiar nome da pasta
      //chave = string.Format(Constantes.ArquivoCopiarNomePastaOuNomeArquivoCommand, menuPasta);
      //Add(chave, null, ArquivoValues.CopiarNomePasta);

      // Copiar nome do arquivo
      chave = string.Format(Constantes.ArquivoCopiarNomePastaOuNomeArquivoCommand, nomeMenuArquivo);
      Add(chave, null, ArquivoValues.CopiarNomeArquivo);
      Add(string.Format(Constantes.ArquivoCopiarNomePastaOuNomeArquivo, nomeMenuArquivo), Constantes.Icon, Constantes.IconeCopiarArquivo);

      // Prompt Adm
      chave = Constantes.ArquivoShellRunas;
      Add(chave, null, menuPromptAdm);
      Add(chave, Constantes.NoWorkingDirectory, "");
      Add(Constantes.ArquivoShellRunasCommand, null, ArquivoValues.RunasValues.PromptAqui2);
    }

    public static void ChangeExplorerMaxContextMenus()
    {
      Add(Registry.CurrentUser,
        Constantes.SoftwareMicrosoftWindowsCurrentVersionExplorer,
        Constantes.MultipleInvokePromptMinimum, 0x0000ffff, RegistryValueKind.DWord);
    }
  }
}
