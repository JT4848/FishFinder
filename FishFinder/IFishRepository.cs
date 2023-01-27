using FishFinder.Models;

namespace FishFinder
{
    public interface IFishRepository
    {
        public IEnumerable<Fish> GetAllFish();
        public Fish GetFish(int id);
        public void UpdateFish(Fish fish);
        public void InsertFish(Fish fishToInsert);
        public IEnumerable<CreateFish> FishCreate();
        public Fish AssignFish();
        public void DeleteFish(Fish fish);

    }
}
