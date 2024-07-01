using HNG.StageOneTask.BackendC_.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace HNGTask1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddHttpClient();
			builder.Services.AddTransient<GreetingService>();

			// Add Swagger services
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "HNG Task API",
					Version = "v1"
				});
			});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				// Enable middleware to serve generated Swagger as a JSON endpoint.
				app.UseSwagger();

				// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
				// specifying the Swagger JSON endpoint.
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "HNG Task API V1");
				});
			}

			// Configure the HTTP request pipeline.
			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
