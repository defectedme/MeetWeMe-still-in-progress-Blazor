using MeetWeMe.Model;
using MeetWeMe.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetWeMe.Web.Pages
{
    public class UserListBase : ComponentBase
    {

        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Parameter]
        public Users User { get; set; }



        public IEnumerable<Users> Users { get; set; } = new List<Users>();


        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string SearchText = "";


        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }



        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadUsers);
            Users = (await UsersServices.GetUsers()).ToList();
        }



        protected async void DeleteUser(int Id)
        {
            await UsersServices.DeleteUser(Id);
            NavigationManager.NavigateTo("/", true);

        }


        public List<Users> FilteredBycity => Users.Where(
           img => img.City.ToLower().Contains(SearchText.ToLower())).ToList();

        //sleeep loader
        private void LoadUsers()
        {
            System.Threading.Thread.Sleep(300);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }

    }
}



