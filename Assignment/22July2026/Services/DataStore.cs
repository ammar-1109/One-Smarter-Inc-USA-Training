using _22July2026.Models;

namespace _22July2026.Services
{
    // Simple in-memory storage for learner demo (data resets when app restarts)
    public static class DataStore
    {
        public static List<Automobile> Automobiles { get; } = new();
        public static List<Manufacturer> Manufacturers { get; } = new();
    }
}
