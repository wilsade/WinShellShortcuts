using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using WinShellShortcuts.RegistryItens;

namespace WinShellShortcuts
{
  static class Program
  {
    static readonly StringBuilder strOutput = new StringBuilder();

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Mutex m = new Mutex(true, "WinShellShortcuts", out bool createdNew);
      if (!createdNew)
      {
        // myApp is already running...
        Trace.WriteLine("Aplicativo já sendo executado");
        return;
      }

      if (Application.ExecutablePath.StartsWith(@"\\tecnologiabh", StringComparison.CurrentCultureIgnoreCase))
      {
        MessageBox.Show(string.Format("Para abrir o {0}, é necessário executá-lo em sua estação de trabalho." + Environment.NewLine + Environment.NewLine +
          "Não é permitido acessá-lo a partir da pasta: {1}." + Environment.NewLine + Environment.NewLine +
        "Se você tentou atualizá-lo, favor copiar todos os arquivos para sua máquina.", Application.ProductName, @"\\tecnologiabh"),
          "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (args == null || args.Length == 0)
        AbrirFormConfiguracao();

      else
      {
        ArgsItem argsItem = ArgsItem.Parse(args);
        try
        {
          Trace.WriteLine(argsItem.Print());
          ProcessarComando(argsItem);
        }
        catch (Exception ex)
        {
          MessageBox.Show("Erro ao setar Clipboard: " + ex.ToString(),
            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      GC.KeepAlive(m);
    }

    private static void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
      string msg = e.Data;
      Console.WriteLine(msg);
      strOutput.AppendLine(msg);
    }

    private static void ProcessHandle(ArgsItem argsItem)
    {
      try
      {
        List<HandleProcessItem> lstProcessos = HandleObj.Instance.GetHandles(argsItem.Parametro);
        if (lstProcessos.Count > 0)
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);

          using (var form = new ExibirProcessosUsoForm(argsItem.Parametro, lstProcessos))
          {
            form.ShowDialog();
          }
        }
        else
          MessageBox.Show($"{argsItem.Parametro}\r\n\r\nNão está em uso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception handleEx)
      {
        MessageBox.Show("Erro(s) ao verificar uso." + Environment.NewLine + handleEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      /*
      string output, outputError;
      try
      {
        int exitCode = CommandClass.ExecuteCommand(fileName, "-a -u -accepteula -nobanner \"" + parametro + "\"",
            out output, out outputError, workingDir);
        if (exitCode == 0)
        {
          const string NaoEstaSendoUsado = "No matching handles found";
          if (output.IndexOf(NaoEstaSendoUsado, StringComparison.CurrentCultureIgnoreCase) >= 0)
            MessageBox.Show($"{parametro}\r\n\r\nNão está em uso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

          else
          {
            List<HandleProcessItem> lstProcessos = HandleProcessItem.ParseOutput(output);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var form = new ExibirProcessosUsoForm(parametro, lstProcessos))
            {
              form.ShowDialog();
            }
          }
        }
        else
          MessageBox.Show("Erro(s) ao verificar uso." + Environment.NewLine + outputError, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Erro desconhecido: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      */
      //var info = new ProcessStartInfo(@"cmd")
      //{
      //  RedirectStandardInput = true,
      //  RedirectStandardError = true,
      //  RedirectStandardOutput = true,
      //  UseShellExecute = false,
      //  CreateNoWindow = true,
      //  WorkingDirectory = workingDir,
      //};
      //Process p = Process.Start(info);
      //p.StandardInput.AutoFlush = true;
      //p.OutputDataReceived += OnOutputDataReceived;
      //p.BeginOutputReadLine();
      //strOutput = new StringBuilder();

      //p.StandardInput.WriteLine("handle.exe -a -u -accepteula -nobanner \"" + parametro + "\"");
      //p.StandardInput.WriteLine(@"exit");
      //bool exited = p.WaitForExit(1000 * 60 * 15);
      //if (exited)
      //{
      //  p.StandardInput.Close();
      //  p.CancelOutputRead();
      //}
      //else
      //  p.Kill();


      //ProcessStartInfo handleParams = new ProcessStartInfo()
      //{
      //  FileName = fileName,
      //  WorkingDirectory = workingDir,
      //  Arguments = "-a -u -accepteula -nobanner \"" + parametro + "\"",
      //  UseShellExecute = false,
      //  RedirectStandardOutput = true,
      //  CreateNoWindow = false
      //};

      //Process handleProcess = Process.Start(handleParams);
      //handleProcess.WaitForExit();
      //string output = handleProcess.StandardOutput.ReadToEnd();
      //string output = strOutput.ToString();
    }

    static IEnumerable<string> GetItensSelecionadosExplorer(TipoComandoEnum tipoComando)
    {
      // get the active window
      IntPtr handle = NativeMethods.GetForegroundWindow();

      string filename;
      List<string> lstItens = new List<string>();
      foreach (SHDocVw.InternetExplorer window in new SHDocVw.ShellWindows())
      {
        // match active window
        if (window.HWND != (int)handle)
          continue;

        filename = Path.GetFileNameWithoutExtension(window.FullName).ToLower();
        if (filename.ToLowerInvariant() == "explorer")
        {
          Shell32.FolderItems items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
          foreach (Shell32.FolderItem item in items)
          {
            bool isArquivo = File.Exists(item.Path);

            Trace.WriteLine("Este item: " + item.Path + " é um arquivo? R: " + isArquivo);

            if (tipoComando == TipoComandoEnum.ArquivoCopiarNomeArquivo)
            {
              if (isArquivo)
                lstItens.Add(item.Path);
            }
            else if (item.IsFolder)
              lstItens.Add(item.Path);
          }
        }
        else
          Trace.WriteLine("Não achei janela do explorer");
      }
      return lstItens.OrderBy(x => x);
    }

    private static void ProcessarComando(ArgsItem item)
    {
      RegistryBaseMenuItem instance = (RegistryBaseMenuItem)Activator.CreateInstance(item.ClassType);
      instance.Execute(item.Parametro);
    }

    private static void AbrirFormConfiguracao()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      using (ConfigForm form = new ConfigForm())
      {
        form.ShowDialog();
      }
    }
  }
}
