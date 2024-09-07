using Autofac; 
using Autofac.Extensions.DependencyInjection;
using ServiceContract;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllersWithViews();
//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Transient
//));
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
   // containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();
    //AddTransient

    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();
    //AddScoped

    //containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();
    //AddSinglton
});

var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
