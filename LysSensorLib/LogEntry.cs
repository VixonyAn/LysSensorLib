namespace LysSensorLib
{
    public class LogEntry
    {
		#region Properties
		public DateTime TimeTurnedOn { get; set; }
        public int OutsideLightLevel { get; set; } //in Lux
        public bool CurtainOpened { get; set; }
		#endregion

		#region Constructors
		//Constructor for LogEntry
		public LogEntry(int outsideLightLevel, bool curtainsOpened)
        {
            if(outsideLightLevel < 0 || outsideLightLevel > 150000)
            {
                throw new ArgumentOutOfRangeException("outsideLightLevel", "Outside light level must be between 0 and 150000 lux.");
            }
            TimeTurnedOn = DateTime.Now;
            OutsideLightLevel = outsideLightLevel;
            CurtainOpened = curtainsOpened;
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
