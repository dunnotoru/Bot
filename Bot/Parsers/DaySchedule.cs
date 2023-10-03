using System.Text;

namespace Bot
{
    internal class DaySchedule
    {
        private string DayName { get; set; }
        private List<ScheduleCell> Cells { get; set; }

        public DaySchedule(List<ScheduleCell> cells, string dayName)
        {
            Cells = cells;
            DayName = dayName;
        }

        public string GetFormattedString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DayName);
            foreach (ScheduleCell cell in Cells)
                sb.AppendLine(cell.GetFormattedString());

            return sb.ToString();
        }
    }
}
