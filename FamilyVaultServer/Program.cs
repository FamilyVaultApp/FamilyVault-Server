using FamilyVaultServer.Services;
using FamilyVaultServer.Services.MemberJoinToken;
using FamilyVaultServer.Services.PrivMx;

namespace FamilyVaultServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add service to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<PrivMxOptions>(builder.Configuration.GetSection(PrivMxOptions.PrivMx));
            builder.Services.AddSingleton<IPrivMxService, PrivMxService>();
            builder.Services.AddSingleton<IFamilyGroupMemberJoinService, FamilyGroupMemberJoinService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
