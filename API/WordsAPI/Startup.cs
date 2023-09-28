using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace WordsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                //opt.JsonSerializerOptions.Converters.Add(new ChatMessageJsonConverter());
                //opt.JsonSerializerOptions.Converters.Add(new ChatListMessageJsonConverter());
                //opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                //opt.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
                //opt.JsonSerializerOptions.Converters.Add(new IsoDateTimeConverter());
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<IDatabaseContext, WordsDatabaseContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("WordsDatabaseConnectionString")));
            DependenciesRegistration.RegisterDependencies(services, Configuration);

            services.AddAuthorization();

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseExceptionHandler("/error");

            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseStaticFiles();

            app.UseHttpLogging();
            app.UseForwardedHeaders();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}