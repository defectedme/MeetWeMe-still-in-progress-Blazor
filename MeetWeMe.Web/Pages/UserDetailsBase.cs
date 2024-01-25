using MeetWeMe.Model;
using MeetWeMe.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetWeMe.Web.Pages
{
    public class UserDetailsBase : ComponentBase
    {
        [Inject]

        public IUsersServices UsersServices { get; set; }


        public Users User { get; set; } = new Users();  


        public IEnumerable<Users> Users { get; set; } = new List<Users>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Id = Id ?? "1";

            User = await UsersServices.GetUserById(int.Parse(Id));
            //Users = (await UsersServices.GetUsers()).ToList();

        }


        protected async void DeleteUser(int Id)
        {
            await UsersServices.DeleteUser(Id);
            NavigationManager.NavigateTo("/", true);

        }
    }
}
