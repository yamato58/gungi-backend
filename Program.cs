
using GungiBackend.Services;

namespace GungiBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // CORSポリシーの定義
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy => policy.WithOrigins("http://localhost:4200",// AngularのデフォルトURL
                                                 "https://gungi-frontend.onrender.com")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            // DIの定義
            builder.Services.AddSingleton<IGameService, GameService>();
            builder.Services.AddSingleton<IPiecePositionService, PiecePositionService>();
            builder.Services.AddSingleton<ISelectPieceService, SelectPieceService>();
            builder.Services.AddSingleton<IReplayService, ReplayService>();
            builder.Services.AddSingleton<ITurnService, TurnService>();
            builder.Services.AddSingleton<IMovePieceService, MovePieceService>();
            builder.Services.AddSingleton<IGameJudgeService, GameJudgeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            // ─── 【追記②】CORSミドルウェアの適用 ───
            app.UseCors("AllowAngular");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
