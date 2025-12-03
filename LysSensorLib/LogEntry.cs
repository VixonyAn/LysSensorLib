namespace LysSensorLib
{
    public class LogEntry
    {
		#region Properties
        public int Id { get; set; }
        public long TimeTurnedOn { get; set; }
        public double LightLevel { get; set; } 
        public bool IsDrawn { get; set; }
        public bool LightsOn { get; set; }
        public DateTime TimeinDateTime
        {
            get
            {
                // Convert Unix timestamp (seconds since epoch) to DateTime
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(TimeTurnedOn);
                return dateTimeOffset.DateTime;
            }
        }
        #endregion

        #region Constructors
        //Constructor for LogEntry
        public LogEntry(long timeTurnedOn, double outsideLightLevel, bool curtainsOpened, bool lightOn)
        {
            TimeTurnedOn = timeTurnedOn;
            LightLevel = outsideLightLevel;
            IsDrawn = curtainsOpened;
            LightsOn = lightOn;
        }

        //Default constructor for LogEntry
        public LogEntry()
        {
        
        }
        #endregion

        #region Methods

        
        public override string ToString()
        {
            return "LogEntry [TimeTurnedOn = " + TimeinDateTime + ", OutsideLightLevel = " + LightLevel
                    + "lux, CurtainOpened = " + IsDrawn + "]";
        }
        #endregion
    }
}
