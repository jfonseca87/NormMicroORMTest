using NormMicroORMTest.Models;

namespace NormMicroORMTest.Models;

public class DashboardViewModel
{
    public IEnumerable<Proyecto> HighPriorityProjects { get; set; } = [];
    public IEnumerable<Persona> RecentPeople { get; set; } = [];
}
