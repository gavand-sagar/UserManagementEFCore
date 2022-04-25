
namespace UserManagementSystem.ViewModels
{
    public class IndexViewModel
    {
        // not so good way
        //public List<User> users = new List<User>();
        // not so good way

        // good way
        public List<UserViewModel> users = new List<UserViewModel>();
        // good way



        //This is for add userform edit data
        public UserViewModel user = new UserViewModel();
        //

        public string CurrentUser { get; set; }

    }
}
