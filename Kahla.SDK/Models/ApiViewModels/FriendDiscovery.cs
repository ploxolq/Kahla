namespace Kahla.SDK.Models.ApiViewModels
{
    public class FriendDiscovery
    {
        public int CommonFriends { get; set; }
        public int CommonGroups { get; set; }
        public bool SentRequest { get; set; }
        public KahlaUser TargetUser { get; set; }
    }
}
