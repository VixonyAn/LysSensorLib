namespace LysSensorLib
{
    public class LogEntry
    {
        /*Data to database:
        What Time the light is turned on
        What the Light Level is outside
        Whether the curtain was opened*/

        public DateTime TimeTurnedOn { get; set; }
        public int OutsideLightLevel { get; set; } //in Lux
        public bool CurtainOpened { get; set; }

        //Constructor for LogEntry
        public LogEntry(int outsideLightLevel, bool curtainsOpened)
        {
            TimeTurnedOn = DateTime.Now;
            OutsideLightLevel = outsideLightLevel;
            CurtainOpened = curtainsOpened;
        }

        //Default constructor for LogEntry
        public LogEntry()
        {
        
        }
    }
}
