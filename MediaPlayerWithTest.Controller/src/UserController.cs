using MediaPlayerWithTest.Service.src.ServiceInterface;

namespace MediaPlayerWithTest.Controller.src
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public void AddNewList(string name, int userId)
        {
            if (string.IsNullOrEmpty(name) || userId <= 0)
            {
                return;
            }
            _userService.AddNewList(name, userId);
        }

        public void EmptyOneList(int listId, int userId)
        {
            if (listId <= 0 || userId <= 0)
            {
                return;
            }
            _userService.EmptyOneList(listId, userId);
        }

        public void GetAllList(int userId)
        {
            if (userId <= 0)
            {
                return;
            }
            _userService.GetAllList(userId);
        }

        public void GetListById(int listId)
        {
            if (listId <= 0)
            {
                return;
            }
            _userService.GetListById(listId);
        }

        public void RemoveAllLists(int userId)
        {
             if (userId <= 0)
            {
                return;
            }
            _userService.RemoveAllLists(userId);
        }

        public void RemoveOneList(int listId, int userId)
        {
            if (listId <= 0 || userId <= 0)
            {
                return;
            }

           _userService.RemoveOneList(listId, userId);
        }
    }
}