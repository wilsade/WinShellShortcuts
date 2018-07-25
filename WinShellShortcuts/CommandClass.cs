using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShellShortcuts
{
  /// <summary>
  /// Classe para execução de comandos
  /// </summary>
  static class CommandClass
  {
    static string AjustaAspas(string str)
    {
      int indiceAspas = str.IndexOf("\"");
      if (indiceAspas >= 0)
        str = str.Substring(0, indiceAspas);
      return str;
    }

    public static int ExecuteCommand(string filename, string arguments, out string outputString, out string outputError, string defaultPath = "", int timeout = 980000)
    {
      outputString = outputError = string.Empty;
      using (var process = new Process())
      {
        process.StartInfo.FileName = filename;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = false;

        if (!string.IsNullOrEmpty(defaultPath))
          process.StartInfo.WorkingDirectory = defaultPath;

        var output = new StringBuilder();
        var error = new StringBuilder();
        var outputWaitHandle = new AutoResetEvent(false);
        var errorWaitHandle = new AutoResetEvent(false);
        DataReceivedEventHandler onOutput = (sender, e) =>
        {
          if (e.Data == null)
          {
            if (!outputWaitHandle.SafeWaitHandle.IsClosed)
              outputWaitHandle.Set();
          }
          else
          {
            output.AppendLine(e.Data);
          }
        };
        DataReceivedEventHandler onError = (sender, e) =>
        {
          if (e.Data == null)
          {
            if (!errorWaitHandle.SafeWaitHandle.IsClosed)
              errorWaitHandle.Set();
          }
          else
          {
            error.AppendLine(e.Data);
          }
        };
        process.OutputDataReceived += onOutput;
        process.ErrorDataReceived += onError;
        try
        {
          process.Start();
          process.BeginOutputReadLine();
          process.BeginErrorReadLine();
          if (process.WaitForExit(timeout) && outputWaitHandle.WaitOne(timeout) && errorWaitHandle.WaitOne(timeout))
          {
            outputString += output.ToString();
            outputError += error.ToString();
            return process.ExitCode;
          }
          return -1;
        }
        catch (Exception ex)
        {
          var sb = new StringBuilder("Erro ao executar o comando!");
          sb.AppendFormat("Comando: {0}\n", process.StartInfo.FileName);
          sb.AppendFormat("Argumentos: {0}\n", process.StartInfo.Arguments);
          sb.AppendFormat("Usuário: {0}\n", process.StartInfo.UserName);
          sb.AppendLine(ex.ToString());
          throw new ApplicationException(sb.ToString(), ex);
        }
        finally
        {
          process.CancelOutputRead();
          process.CancelErrorRead();
          process.OutputDataReceived -= onOutput;
          process.ErrorDataReceived -= onError;
          outputWaitHandle.Dispose();
          errorWaitHandle.Dispose();
          process.Close();
        }
      }
    }

    public static void SetTextInClipboard(string strToClipboard, Action<string> onError = null)
    {
      try
      {
        strToClipboard = AjustaAspas(strToClipboard);

        //Clipboard.SetText(strToClipboard, TextDataFormat.Text);
        Clipboard.SetDataObject(strToClipboard, true);
      }
      catch (Exception ex)
      {
        Trace.WriteLine(ex.ToString());
        onError?.Invoke(ex.ToString());
      }
    }

    public static void ProcessHandle(string parametro)
    {
      try
      {
        parametro = AjustaAspas(parametro);

        List<HandleProcessItem> lstProcessos = HandleObj.Instance.GetHandles(parametro);
        if (lstProcessos.Count > 0)
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);

          using (var form = new ExibirProcessosUsoForm(parametro, lstProcessos))
          {
            form.ShowDialog();
          }
        }
        else
          MessageBox.Show($"{parametro}\r\n\r\nNão está em uso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception handleEx)
      {
        MessageBox.Show("Erro(s) ao verificar uso." + Environment.NewLine + handleEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }
  }
}
