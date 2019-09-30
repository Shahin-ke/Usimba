namespace SH_SWAT.Usimba.Validation
{
    public class ResultMessage
    {
        public string Message { get; }
        public ResultMessageLevel Level { get; }

        public ResultMessage(string message, ResultMessageLevel level)
        {
            Message = message;
            Level = level;
        }
    }
}