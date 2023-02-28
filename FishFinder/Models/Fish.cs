namespace FishFinder.Models
{
    public class Fish
    {
        public string Name { get; set; }
        public string Season { get; set; }
        public string Minimum_Length { get; set; }
        public string Maximum_Length { get; set; }
        public string Bag_Limit { get; set; }
        public string Description { get; set; }
        public int FishId { get; set; }
        public IEnumerable<CreateFish> Fishes { get; set; }
        public byte[] Pic { get; set; }
    }
}
