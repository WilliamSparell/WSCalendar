namespace WSCalendar.Views;

public partial class TaskListPage : ContentPage
{
	private TaskListPageViewModel _viewModel;
	public TaskListPage(TaskListPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;

		this.BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetTaskListCommand.Execute(null);
	}
}