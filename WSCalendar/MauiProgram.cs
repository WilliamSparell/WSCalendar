using WSCalendar.Services;
using CommunityToolkit.Maui;

namespace WSCalendar;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton<ICalendarService, CalendarService>();

        builder.Services.AddSingleton<TaskListPage>();
        builder.Services.AddSingleton<AddUpdateTaskDetails>();
        builder.Services.AddSingleton<TaskDetailsPage>();
        //builder.Services.AddSingleton<CalendarPage>();

        builder.Services.AddSingleton<TaskListPageViewModel>();
        builder.Services.AddSingleton<AddUpdateTaskDetailsViewModel>();
        builder.Services.AddSingleton<TaskDetailsPageViewModel>();
        //builder.Services.AddSingleton<CalendarPageViewModel>();

        return builder.Build();
    }
}