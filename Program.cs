using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

if (!dbContext.Questions.Any())
{
    var question1Answer = Guid.NewGuid();
    var question1 = new Question()
    {
        Text = "Which of these devices is used to point at things on the monitor?",
        Options = new List<Option>
        {
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "CPU"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Keyboard"
            },
            new ()
            {
                Id = question1Answer,
                Text = "Mouse"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Speakers"
            }
        }, 
        CorrectOption = question1Answer
    };

    var question2Answer = Guid.NewGuid();
    var question2 = new Question()
    {
        Text = "What does GB stand for in the world of computers? ",
        Options = new List<Option>
        {
            new ()
            {
                Id = question2Answer,
                Text = "Gigabyte"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Game boy"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "General Business"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "None of the above"
            }
        },
        CorrectOption = question2Answer
    };

    var question3Answer = Guid.NewGuid();
    var question3 = new Question()
    {
        Text = "Which one of these is the smallest computer?",
        Options = new List<Option>
        {
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Mainframe computer"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Laptop"
            },
            new ()
            {
                Id = question2Answer,
                Text = "Tablet"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Desktop computer"
            }
        },
        CorrectOption = question3Answer
    };

    var question4Answer = Guid.NewGuid();
    var question4 = new Question()
    {
        Text = "What do you need in a computer to connect to the internet?",
        Options = new List<Option>
        {
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Mouse"
            },
            new ()
            {
                Id = question2Answer,
                Text = "Modem"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "CPU"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "Keyboard"
            }
        },
        CorrectOption = question4Answer
    };

    var question5Answer = Guid.NewGuid();
    var question5 = new Question()
    {
        Text = "What does WWW stand for in the virtual world of computers?",
        Options = new List<Option>
        {
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "World Without Windows"
            },
            new ()
            {
                Id = question2Answer,
                Text = "World Wide Web"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "World Wide Web Applications"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                Text = "World Wide Warehouse"
            }
        },
        CorrectOption = question5Answer
    };

    dbContext.Questions.AddRange([question1, question2]);
    dbContext.SaveChanges();
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
