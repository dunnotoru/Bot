using System.Text;

namespace Bot
{
    internal class ScheduleCell
    {
        public string TimeSpanString { get; private set; }
        public string Body { get; private set; }
        public string ClassId { get; private set; }
        public ScheduleCell(string time, string body, string classId)
        {
            TimeSpanString = time;
            Body = body;
            ClassId = classId;
        }

        public string GetFormattedString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{TimeSpanString} {Body} {ClassId}");
            return sb.ToString();
        }
    }
}
