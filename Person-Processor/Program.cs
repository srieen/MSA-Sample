using Person_Processor;
using Person_Processor.DataAccess;
using Microsoft.EntityFrameworkCore;
using Person_Processor.Interfaces;
using Person_Processor.Domain;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        string connectionString = hostContext.Configuration.GetConnectionString("SqlConnectionString");
        
        services.AddDbContext<PersonContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
        services.AddSingleton<IPersonRepository, PersonRepository>();
        services.AddSingleton<IPersonSocialMediaLogic, PersonSocialMediaLogic>();
        
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
