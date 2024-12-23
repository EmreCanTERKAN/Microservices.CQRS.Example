using Microservices.CQRS.Example.Manual_CQRS.Handlers.CommandHandlers;
using Microservices.CQRS.Example.Manual_CQRS.Handlers.QueryHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


#region Manuel CQRS
builder.Services.AddSingleton<CreateProductCommandHandler>()
                .AddSingleton<DeleteProductCommandHandler>()
                .AddSingleton<GetByIdProductQueryHandler>()
                .AddSingleton<GetAllProductQueryHandler>();
#endregion



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
