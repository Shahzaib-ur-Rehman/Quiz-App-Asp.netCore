using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(option=> option.UseSqlServer(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        if (!context.Questions.Any())
        {

            var correctOption1 =Guid.NewGuid();
            var question1 = new Question()
            {
                Id= Guid.NewGuid(),
                Text= "What is the chemical symbol for gold?",
                Options= new List<Option>()
                {
                    new Option()
                    {
                        Id = Guid.NewGuid(),
                        Text="Ag",

                    },
                     new Option()
                    {
                        Id = correctOption1,
                        Text="Au",

                    },
                      new Option()
                    {
                        Id = Guid.NewGuid(),
                        Text="Fe",

                    },
                       new Option()
                    {
                        Id = Guid.NewGuid(),
                        Text="Hg",

                    }
                },
                CorrectOption= correctOption1,
            };
            var correctOption2 = Guid.NewGuid();
            var question2 = new Question()
            {
                Id = Guid.NewGuid(),
                Text = "Which planet is known as the \"Red Planet\"?",
                Options = new List<Option>()
                {
                    new Option()
                    {
                        Id = Guid.NewGuid(),
                        Text="Jupiter",

                    },
                     new Option()
                    {
                        Id = Guid.NewGuid(),
                        Text="Venus",

                    },
                      new Option()
                    {
                        Id = correctOption2,
                        Text="Mars",

                    },
                       new Option()
                    {
                        Id = Guid.NewGuid(),
                        Text="Mercury",

                    }
                },
                CorrectOption = correctOption2,
            };

            context.Questions.AddRange(question1, question2);
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {

        throw;
    }
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quiz}/{action=Index}/{id?}");

app.Run();
