namespace GameEngine
{
    public interface IPortal
    {
        
         bool IsActive { get; set; }
         string FromLocation { get; set; }
         string ToLocation { get; set; }
         bool DestinationReached { get; set; }

        void Transport();
    }
}