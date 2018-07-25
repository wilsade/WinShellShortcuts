using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinShellShortcuts
{
  /// <summary>
  /// Representa um processo que está utilzando alguma pasta/arquivo
  /// </summary>
  [DebuggerDisplay("{ProcessName}-{HandlePath}")]
  public class HandleProcessItem
  {
    const string patternOutput = "^([^ ]*)\\s*pid: ([0-9]*)\\s*type: ([^ ]*)\\s*([^ ]*)\\s*(.*?): (.*)";
    static readonly Regex _regexOutput = new Regex(patternOutput, RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// Cria uma instância da classe <see cref="HandleProcessItem"/>
    /// </summary>
    private HandleProcessItem()
    {

    }

    /// <summary>
    /// Nome do processo. Ex: explorer.exe
    /// </summary>
    public string ProcessName { get; private set; }

    /// <summary>
    /// Identificador do processo na lista de processos do Windows. Ex: 4041
    /// </summary>
    public int Pid { get; private set; }

    /// <summary>
    /// Tipo. Ex: File
    /// </summary>
    public string HandleType { get; private set; }

    /// <summary>
    /// Usuário que está utilizando o handle. Ex: Dominio\User
    /// </summary>
    public string User { get; set; }

    /// <summary>
    /// Endereço Hexadecimal do handle. Ex: 2A7C
    /// </summary>
    public string Address { get; private set; }

    /// <summary>
    /// Caminho completo do Handle. Ex: C:\Pasta\subpasta ou C:\Pasta\Subpasta\arquivos.extensao
    /// </summary>
    public string HandlePath { get; private set; }

    /// <summary>
    /// Retornar uma <see cref="System.string" /> que representa esta instância
    /// </summary>
    /// <returns>Uma <see cref="System.string" /> representando esta instância</returns>
    public override string ToString()
    {
      return $"{ProcessName} | {Address} | {HandlePath}";
    }

    /// <summary>
    /// Lê o output do handle e devolve uma lista de objetos representando o uso
    /// </summary>
    /// <param name="output">Output</param>
    /// <returns>lista de objetos representando o uso</returns>
    public static List<HandleProcessItem> ParseOutput(string output)
    {
      string[] splited = output.Split(new string[] { "\r\r", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

      var lst = new List<HandleProcessItem>();
      foreach (string estaLinha in splited)
      {
        HandleProcessItem item = Parse(estaLinha);
        lst.Add(item);
      }
      return lst;
    }

    /// <summary>
    /// Criar uma instância da classe <see cref="HandleProcessItem"/>
    /// </summary>
    /// <param name="outputLine">Representa uma linha do output contendo as informações a serem extraídas</param>
    /// <returns>Instância da classe <see cref="HandleProcessItem"/></returns>
    public static HandleProcessItem Parse(string outputLine)
    {
      if (string.IsNullOrWhiteSpace(outputLine))
        throw new ArgumentNullException(nameof(outputLine));

      HandleProcessItem item = new HandleProcessItem()
      {
        ProcessName = outputLine
      };
      if (outputLine.Contains("pid"))
      {
        MatchCollection matches = _regexOutput.Matches(outputLine);
        if (matches.Count > 0)
        {
          int pid;
          if (int.TryParse(matches[0].Groups[2].Value, out pid))
            item.Pid = pid;

          item.ProcessName = matches[0].Groups[1].Value;
          item.HandleType = matches[0].Groups[3].Value;
          item.User = matches[0].Groups[4].Value;
          item.Address = matches[0].Groups[5].Value;
          item.HandlePath = matches[0].Groups[6].Value;
        }
      }

      return item;
    }
  }
}
