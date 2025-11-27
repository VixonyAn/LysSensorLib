namespace LysSensorLib
{
    public class LogEntry
    {
		#region Properties
		public DateTime TimeTurnedOn { get; set; }
        public int OutsideLightLevel { get; set; } 
        public bool CurtainOpened { get; set; }
        public bool LightOn { get; set; }
        #endregion

        #region Constructors
        //Constructor for LogEntry
        public LogEntry(int outsideLightLevel, bool curtainsOpened, bool lightOn)
        {
            TimeTurnedOn = DateTime.Now;
            OutsideLightLevel = outsideLightLevel;
            CurtainOpened = curtainsOpened;
            LightOn = lightOn;
        }

        //Default constructor for LogEntry
        public LogEntry()
        {
        
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return "LogEntry [TimeTurnedOn = " + TimeTurnedOn + ", OutsideLightLevel = " + OutsideLightLevel
                    + "lux, CurtainOpened = " + CurtainOpened + "]";
        }
        #endregion
    }
}
