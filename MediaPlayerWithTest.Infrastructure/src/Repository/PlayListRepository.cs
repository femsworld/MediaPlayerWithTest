using MediaPlayerWithTest.Core.src.RepositoryInterface;

namespace MediaPlayerWithTest.Infrastructure.src.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        public void AddNewFile(int playListId, int fileId, int userId)
        {
            throw new NotImplementedException();
        }

        public void EmptyList(int playListId, int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFile(int playListId, int fileId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}