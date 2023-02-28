using Dapper;
using FishFinder.Models;
using System.Data;

namespace FishFinder
{
    public class FishRepository : IFishRepository
    {

        private readonly IDbConnection _conn;

        public FishRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Fish> GetAllFish()
        {
            return _conn.Query<Fish>("SELECT * FROM allfish;");
        }

        public Fish GetFish(int id)
        {
            return _conn.QuerySingle<Fish>("SELECT * FROM allfish WHERE FishId = @id", new { id = id });
        }

        public void UpdateFish(Fish fish)
        {
            _conn.Execute("UPDATE allfish SET Name = @name, Season = @season, Minimum_Length = @minimum_length, Maximum_Length = @maximum_length, Bag_Limit = @bag_limit, Description = @description, WHERE FishId = @Id",
             new { name = fish.Name, season = fish.Season, minimum_length = fish.Minimum_Length, maximum_length = fish.Maximum_Length, bag_limit = fish.Bag_Limit, description = fish.Description, id = fish.FishId }); //added pic code here
        }

        public void InsertFish(Fish fishToInsert)
        {
            _conn.Execute("INSERT INTO allfish (NAME, SEASON, MINIMUM_LENGTH, MAXIMUM_LENGTH, BAG_LIMIT, DESCRIPTION, FISHID) VALUES (@name, @season, @minimum_length, @maximum_length, @bag_limit, @description, @fishid);",
                new { name = fishToInsert.Name, season = fishToInsert.Season, minimum_length = fishToInsert.Minimum_Length, maximum_length = fishToInsert.Maximum_Length, bag_limit = fishToInsert.Bag_Limit, description = fishToInsert.Description, fishid = fishToInsert.FishId}); //added pic code here
        }

        public IEnumerable<CreateFish> FishCreate()
        {
            return _conn.Query<CreateFish>("SELECT * FROM createfish");
        }

        public Fish AssignFish()
        {
            var fishList = FishCreate();
            var fish = new Fish();
            fish.Fishes = fishList;
            return fish;
        }

        public void DeleteFish(Fish fish)
        {
            _conn.Execute("DELETE FROM createfish WHERE FishId = @id;", new { id = fish.FishId });
            _conn.Execute("DELETE FROM allfish WHERE FishId = @id;", new { id = fish.FishId });
        }


    }
}
