using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts
{
  enum CategoriaComandoEnum
  {
    /// <summary>
    /// None
    /// </summary>
    None = 0,

    /// <summary>
    /// Comando para copiar seu nome para a área de transferência
    /// </summary>
    CopiarNome = 1,

    /// <summary>
    /// Comando para verificar se o item está sendo usado
    /// </summary>
    Handle = 2,

    /// <summary>
    /// Comando para abrir o Prompt de comando
    /// </summary>
    Prompt = 3,
  }
}
