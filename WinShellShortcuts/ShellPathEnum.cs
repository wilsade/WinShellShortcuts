using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts
{
  public enum ShellPathEnum
  {
    Directory_shell = 0,
    Directory_background_shell = 1,
    Asterisco_shell = 2
  }

  public static class ShellPathClass
  {
    public static string GetPath(ShellPathEnum retorna)
    {
      switch (retorna)
      {
        case ShellPathEnum.Directory_shell:
          return "Directory\\shell";
        case ShellPathEnum.Directory_background_shell:
          return "Directory\\background\\shell";
        case ShellPathEnum.Asterisco_shell:
          return "*\\shell";
        default:
          return null;
      }
    }
  }
}
