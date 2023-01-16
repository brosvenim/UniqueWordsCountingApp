using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniqueWordsCountingApp;
using UniqueWordsCountingApp.Infrastructure;
using UniqueWordsCountingApp.Logic;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWordsCalculator, WordsCalculator>();
        services.AddTransient<IInputDataParser, TextInputDataParser>();
        services.AddTransient<IInputDataReader, TextFileInputDataReader>();
        services.AddTransient<ITextCalculationFacade, TextCalculationFacade>();
        services.AddTransient<IStreamFactory, StreamFactory>();


    }).Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider serviceProvider = serviceScope.ServiceProvider;

// var facade = serviceProvider.GetRequiredService<IFacade>();
// await facade.RunAll();

var calculationFacade = serviceProvider.GetRequiredService<ITextCalculationFacade>();
await calculationFacade.RunCalculation();

await host.RunAsync();