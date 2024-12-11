using JasperFx.CodeGeneration;
using JasperFx.CodeGeneration.Commands;
using JasperFx.CodeGeneration.Model;
using JasperFx.RuntimeCompiler;
using Oakton;

namespace Capacitaciones.Api.Tools.Migrations;

[Description("Marten Setup", Name = "marten-setup")]
public class MartenSetupCommand:OaktonAsyncCommand<GenerateCodeInput>
{
    public MartenSetupCommand()
    {
        Usage("action").NoArguments();
        Usage("action").Arguments(x => x.Action);
    }

    public async override Task<bool> Execute(GenerateCodeInput input)
    {
        using (IHost host = input.BuildHost())
        {
            var defaultColor = Console.ForegroundColor;
            var services = host.Services;
            ICodeFileCollection[] array = host.Services.GetServices<ICodeFileCollection>()
                .ToArray<ICodeFileCollection>();
            if (!((IEnumerable<ICodeFileCollection>) array).Any<ICodeFileCollection>())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[red]No registered ICodeFileCollection services were detected, aborting.[/]");
                return false;
            }
            DynamicCodeBuilder dynamicCodeBuilder = new DynamicCodeBuilder(services, array)
            {
                ServiceVariableSource = services.GetService<IServiceVariableSource>()
            };
            System.Console.WriteLine("Deleting Generated code");
            dynamicCodeBuilder.DeleteAllGeneratedCode();
            System.Console.WriteLine("Writing code");
            dynamicCodeBuilder.WriteGeneratedCode((Action<string>) (file => System.Console.WriteLine("Wrote generated code file to " + file)));
            System.Console.WriteLine("Run Test..");
            System.Console.WriteLine("Trying to generate all code and compile, this might take a bit.");
            dynamicCodeBuilder.TryBuildAndCompileAll((Action<GeneratedAssembly, IServiceVariableSource>) ((a, s) => new AssemblyGenerator().Compile(a, s)));
            Console.ForegroundColor= ConsoleColor.Green;
            Console.Write("SUCCESS!");
            Console.ForegroundColor=defaultColor;
            return true;
        }
    }
}
