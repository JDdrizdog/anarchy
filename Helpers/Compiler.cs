using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using Anarchy.Properties;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace Anarchy.Helpers;

internal class Compiler
{
    public static bool Compilation(string source_code, string output_name, bool obfuscateMe, string icon_path = null, bool stExe = false, bool ndExe = false, bool rdExe = false, bool thExe = false, bool fthExe = false, string stringExe1 = null, string stringExe2 = null, string stringExe3 = null, string stringExe4 = null, string stringExe5 = null)
    {
        string text;
        text = Environment.CurrentDirectory + "\\icon.ico";
        Dictionary<string, string> providerOptions;
        providerOptions = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };
        string text2;
        text2 = "/target:winexe /platform:anycpu /optimize";
        if (icon_path != null)
        {
            File.Copy(icon_path, text, overwrite: true);
            text2 = text2 + " /win32icon:\"" + text + "\"";
        }
        using CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider(providerOptions);
        CompilerParameters compilerParameters;
        compilerParameters = new CompilerParameters
        {
            GenerateExecutable = true,
            GenerateInMemory = false,
            OutputAssembly = output_name,
            CompilerOptions = text2,
            TreatWarningsAsErrors = false,
            IncludeDebugInformation = false
        };
        compilerParameters.ReferencedAssemblies.Add("System.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Net.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
        compilerParameters.ReferencedAssemblies.Add("System.IO.dll");
        compilerParameters.ReferencedAssemblies.Add("System.IO.compression.dll");
        compilerParameters.ReferencedAssemblies.Add("System.IO.compression.filesystem.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Security.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Net.Http.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
        if (cSharpCodeProvider.Supports(GeneratorSupport.Resources))
        {
            if (stExe)
            {
                compilerParameters.EmbeddedResources.Add(stringExe1);
            }
            if (ndExe)
            {
                compilerParameters.EmbeddedResources.Add(stringExe2);
            }
            if (rdExe)
            {
                compilerParameters.EmbeddedResources.Add(stringExe3);
            }
            if (thExe)
            {
                compilerParameters.EmbeddedResources.Add(stringExe4);
            }
            if (fthExe)
            {
                compilerParameters.EmbeddedResources.Add(stringExe5);
            }
        }
        CompilerResults compilerResults;
        compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, source_code);
        if (compilerResults.Errors.HasErrors)
        {
            MessageBox.Show($"The compiler has encountered {compilerResults.Errors.Count} errors", "Errors while compiling", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            foreach (CompilerError error in compilerResults.Errors)
            {
                MessageBox.Show($"{error.ErrorText}\nLine: {error.Line} - Column: {error.Column}\nFile: {error.FileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        else if (obfuscateMe)
        {
            Compiler.Confuser(output_name);
        }
        File.Delete(text);
        return compilerResults.Errors.Count == 0;
    }

    private static void Confuser(string file)
    {
        File.WriteAllBytes(Path.GetTempPath() + "confuser.zip", Resources.ConfuserEx);
        if (Directory.Exists(Path.GetTempPath() + "Confuser"))
        {
            Directory.Delete(Path.GetTempPath() + "Confuser", recursive: true);
            Directory.CreateDirectory(Path.GetTempPath() + "Confuser");
        }
        ZipFile.ExtractToDirectory(Path.GetTempPath() + "confuser.zip", Path.GetTempPath() + "Confuser");
        Interaction.Shell(string.Concat(str2: Path.GetFullPath(file), str0: Path.GetTempPath(), str1: "Confuser\\Confuser.CLI.exe -n "), AppWinStyle.Hide, Wait: true);
        File.Delete(Path.GetTempPath() + "confuser.zip");
    }
}