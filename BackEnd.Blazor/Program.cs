using BackEnd.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazored.Toast;

using BackEnd.Blazor.Servicios.Contrato;
using BackEnd.Blazor.Servicios.Implementacion;

using CurrieTechnologies.Razor.SweetAlert2;

using Microsoft.AspNetCore.Components.Authorization;
using BackEnd.Blazor.Extensiones;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// acá pondremos nuestra url base
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5121/api/") });


//agregamos el servicio de localstorage que se usa en el carrito
builder.Services.AddBlazoredLocalStorage();

// agregamos el toast que le da un número al carrito
builder.Services.AddBlazoredToast();

// agregamos los servicios del carrito
builder.Services.AddScoped<IUsuarioServicio,UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio,CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio,ProductoServicio>();
builder.Services.AddScoped<ICarritoServicio,CarritoServicio>();
builder.Services.AddScoped<IVentaServicio,VentaServicio>();
builder.Services.AddScoped<IDashboardServicio,DashboardServicio>();

// Agregamos sweetalert2 para mostrar mejores mensajes
builder.Services.AddSweetAlert2();

// Para la autenticación
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();

await builder.Build().RunAsync();
