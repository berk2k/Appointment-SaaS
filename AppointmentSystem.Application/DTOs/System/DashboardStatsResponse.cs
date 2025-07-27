namespace AppointmentSystem.Application.DTOs.System
{
    public class DashboardStatsResponse
    {
        public int TotalAppointments { get; set; }
        public int TodayAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int TotalCustomers { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
    }
}
