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
                    + ", CurtainOpened = " + CurtainOpened + "]";
        }
        #endregion
    }
}
