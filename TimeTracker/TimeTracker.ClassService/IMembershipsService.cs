namespace TimeTracker.ClassService
{
    public interface IMembershipsService
    {
        void SetSalt(int userId, string salt);
        void Remove(int id);
    }
}