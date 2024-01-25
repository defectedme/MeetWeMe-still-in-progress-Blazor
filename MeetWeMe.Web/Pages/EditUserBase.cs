using AutoMapper;
using MeetWeMe.Model;
using MeetWeMe.Web.Models;
using MeetWeMe.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace MeetWeMe.Web.Pages
{
    public class EditUserBase : ComponentBase
    {

        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        public Users User { get; set; } = new Users();


        public EditUserModel EditUserModel { get; set; } = new EditUserModel();

        public List<Categories> Categories { get; set; } = new List<Categories>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IConfiguration config { get; set; }

        private long maxFilesize = 2024 * 2024 * 3; //is 3MB

        private int maxAllowedFile = 1;

        public List<string> errors = new();


        private IBrowserFile? file;


        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string PageHeaderText { get; set; }



        protected async override Task OnInitializedAsync()
        {

            int.TryParse(Id, out int userId);
            if (userId != 0)
            {
                PageHeaderText = "EDIT";

                User = await UsersServices.GetUserById(int.Parse(Id));

            }
            else
            {
                PageHeaderText = "CREATE";

                User = new Users
                {
                    CategoriesId = 1,
                    DateOfBirth = DateTime.Now
                    //PhotoPath = "Images/me2we.jpg",
                };

            }


            Categories = (await CategoriesServices.GetCategories()).ToList();
            Mapper.Map(User, EditUserModel);
        }

        protected async Task Delete_Click()
        {

            await UsersServices.DeleteUser(User.UserId);
            NavigationManager.NavigateTo("/", true);

        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditUserModel, User);

            Users result = null;


            if (User.UserId != 0)
            {
                result = await UsersServices.UpdateUser(User);
            }
            else
            {
                result = await UsersServices.CreateUser(User);

            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/", true);
            }


            await SubmitForm();

        }


        public void LoadFiles(InputFileChangeEventArgs e)
        {

            errors.Clear();


            if (e.FileCount > maxAllowedFile)
            {

                errors.Add($"Only {maxAllowedFile} file ALLOWED ");
            }

            else
            {
                file = e.File;

            }
        }


        public async Task<string> CaptureFile()
        {
            if (file is null)
            {
                return "no file";
            }

            try
            {


                string newFileName = Path.ChangeExtension(
                    Path.GetRandomFileName(),
                    Path.GetExtension(file.Name));

                string path = Path.Combine(config.GetValue<string>("FileStorage")!, "UserImages", newFileName);

                string relativePath = Path.Combine("UserImages", newFileName);
                Directory.CreateDirectory(Path.Combine(config.GetValue<string>("FileStorage")!, "UserImages"));


                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream(maxFilesize).CopyToAsync(fs);

                return relativePath;
            }
            catch (Exception ex)
            {
                errors.Add($"File: {file.Name} Error: {ex.Message}");
                throw;
            }
        }

        public async Task SubmitForm()
        {
            errors.Clear();

            try
            {
                string relativePath = await CaptureFile();
                User.PhotoPath = relativePath;
                //await UsersServices.SaveData("Users", "DefaultConnection", EditUserModel);

                if (User.UserId != 0)
                {
                    await UsersServices.UpdateUser(User);
                }
                await UsersServices.CreateUser(User);

                User = new();
                file = null;
                errors.Clear();
            }
            catch (Exception ex)
            {
                errors.Add($"Error: {ex.Message}");
            }

        }

    }
}
