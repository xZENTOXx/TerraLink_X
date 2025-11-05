using asp_servicios.Controllers;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection
       services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IFincasAplicacion, FincasAplicacion>();//1
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();//2
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();//3
            services.AddScoped<IClientesAplicacion, ClientesAplicacion>();//4
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();//5
            services.AddScoped<IInventariosAplicacion, InventariosAplicacion>();//6
            services.AddScoped<IMantenimientosAplicacion, MantenimientosAplicacion>();//7
            services.AddScoped<IPagosAplicacion, PagosAplicacion>();//8
            services.AddScoped<IPromocionesAplicacion, PromocionesAplicacion>();//9
            services.AddScoped<IReseñasAplicacion, ReseñasAplicacion>();//10
            services.AddScoped<IReservasAplicacion, ReservasAplicacion>();//11
            services.AddScoped<IReservaPromocionesAplicacion, ReservaPromocionesAplicacion>();//12
            services.AddScoped<IReservaServiciosAplicacion, ReservaServiciosAplicacion>();//13
            services.AddScoped<IServiciosExtrasAplicacion, ServiciosExtrasAplicacion>();//14
            services.AddScoped<ITareasAplicacion, TareasAplicacion>();//15
            services.AddScoped<TokenAplicacion>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}
