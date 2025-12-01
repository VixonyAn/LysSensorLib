namespace LysSensorLib
{
    public class LogEntry
    {
		#region Properties
        public int Id { get; set; }
        public DateTime TimeTurnedOn { get; set; }
        public double LightLevel { get; set; } 
        public bool IsDrawn { get; set; }
        public bool LightsOn { get; set; }
        #endregion

        #region Constructors
        //Constructor for LogEntry
        public LogEntry(double outsideLightLevel, bool curtainsOpened, bool lightOn)
        {
            TimeTurnedOn = DateTime.Now;
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
            return "LogEntry [TimeTurnedOn = " + TimeTurnedOn + ", OutsideLightLevel = " + LightLevel
                    + "lux, CurtainOpened = " + IsDrawn + "]";
        }
        #endregion
    }
}
