using MediaPlayerWithTest.Service.src.ServiceInterface;

namespace MediaPlayerWithTest.Controller.src
{
    public class PlayListController
    {
        private readonly IPlayListService _playListService;

        public PlayListController(IPlayListService playListService)
        {
            _playListService = playListService;
        }

        public void AddNewFile(int playListId, int fileId, int userId)
        {
            if (playListId <= 0 || fileId <= 0 || userId <= 0)
            {
                return;
            }
            _playListService.AddNewFile(playListId, fileId, userId);
        }

        public void EmptyList(int playListId, int userId)
        {
            if (playListId <= 0 || userId <= 0)
            {
                return;
            }
            _playListService.EmptyList(playListId, userId);
        }

        public void RemoveFile(int playListId, int fileId, int userId)
        {
            if (playListId <= 0 || fileId <= 0 || userId <= 0)
            {
                return;
            }
            _playListService.RemoveFile(playListId, fileId, userId);
        }
    }
}