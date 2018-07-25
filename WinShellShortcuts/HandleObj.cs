using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts
{
  /// <summary>
  /// Manipular o Handle.exe
  /// </summary>
  class HandleObj
  {
    const string PatternNoMatchingFound = "No matching handles found";
    const string PatternErrorClosingHandle = "Error closing handle:";
    const string IdentificadorInvalido = "Identificador inválido";
    const string InvalidIdentifier = "Invalid identifier";
    static HandleObj _instance = null;

    /// <summary>
    /// Cria uma instância da classe <see cref="HandleObj"/>
    /// </summary>
    /// <param name="fileName">Caminho completo do Handle.exe</param>
    private HandleObj()
    {
      FileName = Constantes.HandlePath;
    }

    /// <summary>
    /// Devolve a instância da classe <see cref="HandleObj"/>
    /// </summary>
    public static HandleObj Instance => _instance == null ? new HandleObj() : _instance;

    /// <summary>
    /// Caminho completo do Handle.exe
    /// </summary>
    public string FileName { get; }

    /// <summary>
    /// Verificar se o item está sendo usado por algum processo
    /// </summary>
    /// <param name="item">Item a ser verificado. Pode ser uma pasta ou um arquivo</param>
    /// <returns>Lista de uso; lista vazia se o item não está em uso</returns>
    /// <exception cref="Exception">Erro ao verficar uso do item</exception>
    public List<HandleProcessItem> GetHandles(string item)
    {
      string output, outputError;
      int exitCode = CommandClass.ExecuteCommand(FileName, "-a -u -accepteula -nobanner \"" + item + "\"",
            out output, out outputError, Path.GetDirectoryName(FileName));
      if (exitCode == 0)
      {
        if (output.IndexOf(PatternNoMatchingFound, StringComparison.CurrentCultureIgnoreCase) >= 0)
          return new List<HandleProcessItem>();

        else
        {
          List<HandleProcessItem> lstProcessos = HandleProcessItem.ParseOutput(output);
          return lstProcessos;
        }
      }
      else
        throw new Exception(outputError);
    }

    /// <summary>
    /// Tentar fechar o ponteiro do processo que está usando o item
    /// </summary>
    /// <param name="item">Item</param>
    /// <returns>null em caso de sucesso; string de erro caso contrário</returns>
    public string CloseHandle(HandleProcessItem item)
    {
      string args = $"-c {item.Address} -p {item.Pid} -y -nobanner";
      string output, outputerror;
      int resultado = CommandClass.ExecuteCommand(Constantes.HandlePath, args, out output, out outputerror, Path.GetDirectoryName(Constantes.HandlePath));
      if (resultado == 0)
      {
        int index = output.IndexOf(PatternErrorClosingHandle, StringComparison.CurrentCultureIgnoreCase);
        if (index >= 0)
        {
          string msg = output.Substring(index + PatternErrorClosingHandle.Length).Trim();
          if ((msg.IndexOf(IdentificadorInvalido, StringComparison.CurrentCultureIgnoreCase) >= 0) ||
               (msg.IndexOf(InvalidIdentifier, StringComparison.CurrentCultureIgnoreCase) >= 0))
            msg += Environment.NewLine + "Tente executar com privilégios de administrador.";
          return msg;
        }
      }
      else
        return output + " " + outputerror;
      return null;
    }
  }
}
