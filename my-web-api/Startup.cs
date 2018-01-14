using AutoMapper;
using ExpenseItApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApi
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
			//services.AddDbContext<TodoContext>(opt => opt.UseSqlServer());
            services.AddDbContext<ExpenseItContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SeesawDB")));
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllHeaders", builder =>
				{
					builder.AllowAnyOrigin()
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				});
			});
			services.AddMvc();
            services.AddAutoMapper();
		}

		public void Configure(IApplicationBuilder app)
		{
            app.UseCors("AllowAllHeaders");
			app.UseMvc();
		}
	}
}