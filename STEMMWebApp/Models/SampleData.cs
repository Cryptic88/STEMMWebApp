namespace STEMMWebApp.Models
{
    public record Department(int Id, string Name, double Usage, double Budget, string Status, double Trend);

    public record Meter(string Id, string Name, string Dept, string Status, string LastReading, int Battery, int Signal);

    public record AlertItem(
        string Id, string Type, string Dept, string Meter, string Msg, string Detail,
        string Time, string Date, string? Assigned, bool Resolved, List<TimelineEvent> Timeline);

    public record TimelineEvent(string Time, string Actor, string Event);

    public record NotificationItem(int Id, string Type, string Title, string Body, string Time, bool Read);

    public record DailyUsage(string Day, int Usage, int Budget);

    public record CostPoint(string Month, int Cost);

    public static class SampleData
    {
        public static readonly List<Department> Departments = new()
    {
        new(1, "HVAC Systems", 342.5, 400, "Normal", 2.1),
        new(2, "Lighting Grid", 128.3, 150, "Normal", -3.4),
        new(3, "Server Room", 198.7, 180, "Critical", 10.2),
        new(4, "Manufacturing Floor A", 512.1, 550, "Warning", 5.6),
        new(5, "Manufacturing Floor B", 489.3, 500, "Normal", -1.2),
        new(6, "Cafeteria", 67.8, 80, "Normal", 0.3),
    };

        public static readonly List<Meter> Meters = new()
    {
        new("M-001", "Main Substation", "Server Room", "Online", "198.7 kWh", 87, 4),
        new("M-002", "HVAC Primary", "HVAC Systems", "Online", "342.5 kWh", 62, 3),
        new("M-003", "Floor A Feed", "Mfg Floor A", "Warning", "512.1 kWh", 23, 2),
        new("M-004", "Lighting Panel 1", "Lighting Grid", "Online", "64.1 kWh", 91, 4),
        new("M-005", "Lighting Panel 2", "Lighting Grid", "Offline", "—", 5, 0),
        new("M-006", "Floor B Feed", "Mfg Floor B", "Online", "489.3 kWh", 78, 3),
    };

        public static readonly List<AlertItem> Alerts = new()
    {
        new("A-2048", "Critical", "Server Room", "M-001",
            "Power draw 10.4% above threshold (198.7 / 180 kWh)",
            "Meter M-001 in the Server Room has sustained a reading of 198.7 kWh, exceeding the configured threshold of 180 kWh by 10.4%. This has persisted for 3 consecutive reporting intervals (45 minutes). Immediate investigation is recommended to prevent equipment damage or unplanned shutdown.",
            "09:14", "Today", null, false, new()
            {
                new("09:14", "System", "Alert triggered — threshold exceeded for 3rd consecutive interval"),
                new("09:00", "System", "Warning issued — threshold exceeded (first interval)"),
                new("08:45", "System", "Elevated reading detected — 184.2 kWh"),
            }),
        new("A-2047", "Warning", "Mfg Floor A", "M-003",
            "Meter M-003 battery critically low (23%)",
            "The energy meter M-003 serving Manufacturing Floor A is reporting a battery level of 23%, below the 25% warning threshold. Without replacement, the meter will cease reporting within approximately 18 hours based on current drain rate.",
            "08:52", "Today", "J. Torres", false, new()
            {
                new("08:52", "System", "Battery warning triggered at 23%"),
                new("08:52", "System", "Ticket auto-assigned to J. Torres (on-shift tech)"),
            }),
        new("A-2046", "Warning", "Mfg Floor A", "M-003",
            "Usage trending +5.6% MoM — approaching budget limit",
            "Monthly energy consumption on Manufacturing Floor A is trending 5.6% above the same period last month. At the current rate, the department will exceed its 550 kWh monthly budget by approximately 31 kWh.",
            "07:30", "Today", null, false, new()
            {
                new("07:30", "System", "Trend alert generated from monthly rollup data"),
            }),
        new("A-2045", "Info", "Lighting Grid", "M-005",
            "Meter M-005 went offline — last ping 6h ago",
            "Energy meter M-005 (Lighting Panel 2) has not reported since 20:11 yesterday. The device may have lost power, exhausted its battery, or experienced a connectivity failure.",
            "02:11", "Today", "R. Kim", true, new()
            {
                new("02:11", "System", "Offline alert triggered — no heartbeat in 6 hours"),
                new("06:44", "R. Kim", "Investigated on-site — battery depleted. Replacement scheduled."),
                new("07:10", "R. Kim", "Alert resolved"),
            }),
        new("A-2044", "Critical", "HVAC Systems", "M-002",
            "Unusual load spike detected — 42 kWh in 15 min window",
            "A sudden load spike of 42 kWh was recorded within a 15-minute window on the HVAC primary circuit, far exceeding the baseline of ~14 kWh per interval. This may indicate a compressor fault or an unexpected activation of auxiliary heating equipment.",
            "23:47", "Yesterday", "P. Singh", true, new()
            {
                new("23:47", "System", "Spike alert — 42 kWh in 15-min window"),
                new("23:55", "P. Singh", "On-call technician notified"),
                new("00:18", "P. Singh", "Root cause identified: auxiliary heating relay stuck. Reset performed."),
                new("00:22", "P. Singh", "Alert resolved — monitoring for recurrence"),
            }),
        new("A-2043", "Info", "Cafeteria", "—",
            "Monthly energy report generated",
            "The automated monthly energy report for the Cafeteria department has been generated and is available in the Reports section.",
            "00:01", "Yesterday", null, true, new()
            {
                new("00:01", "System", "Monthly report generation completed successfully"),
            }),
    };

        public static readonly List<NotificationItem> Notifications = new()
    {
        new(1, "alert", "Critical alert on Server Room", "Power draw 10.4% above threshold.", "09:14", false),
        new(2, "alert", "Battery warning — Meter M-003", "Battery at 23%, replacement needed.", "08:52", false),
        new(3, "system", "Scheduled maintenance window", "System maintenance tonight 02:00–04:00 UTC.", "08:00", false),
        new(4, "report", "Weekly report ready", "Your energy usage report for W32 is available.", "Yesterday", true),
        new(5, "alert", "Meter M-005 offline", "Lighting Panel 2 has not reported in 6 hours.", "Yesterday", true),
        new(6, "system", "Firmware update available", "Meters M-001 through M-004 have a firmware update.", "Mon", true),
        new(7, "report", "Monthly cost report", "August cost report has been generated.", "Sun", true),
    };

        public static readonly List<DailyUsage> EnergyDaily = new()
    {
        new("Mon", 1280, 1400), new("Tue", 1340, 1400), new("Wed", 1190, 1400),
        new("Thu", 1520, 1400), new("Fri", 1410, 1400), new("Sat", 820, 1400), new("Sun", 760, 1400),
    };

        public static readonly List<CostPoint> CostData = new()
    {
        new("Mar", 18420), new("Apr", 19100), new("May", 17830),
        new("Jun", 20450), new("Jul", 21200), new("Aug", 19870),
    };

        public static readonly string[] Technicians = { "J. Torres", "R. Kim", "P. Singh", "D. Okafor", "M. Reyes" };
    }
}

