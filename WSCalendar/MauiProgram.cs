

using WSCalendar.Services;

namespace WSCalendar;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<ICalendarService, CalendarService>();

        builder.Services.AddSingleton<TaskListPage>();
        builder.Services.AddSingleton<AddUpdateTaskDetails>();
        builder.Services.AddSingleton<TaskDetailsPage>();
        builder.Services.AddSingleton<CalendarView>();

        builder.Services.AddSingleton<TaskListPageViewModel>();
        builder.Services.AddSingleton<AddUpdateTaskDetailsViewModel>();
        builder.Services.AddSingleton<TaskDetailsPageViewModel>();


        return builder.Build();
	}
}
