namespace Core.Common
{
    public enum ServiceResponseCode : int
    {
        Success = 0,
        InvalidData = 1,
        NotFound = 2,
        Duplicate = 3,
        RequireConfirm = 4,
        ObsoleteVersion = 5,
        Forbidden = 6,
        Error = 99,
        Exception = 999
    }

    public enum ModelState : int
    {
        None = 0,
        Insert = 1,
        Update = 2,
        Delete = 3
    }

    public enum DatabaseSide : int
    {
        WriteSide = 1,
        ReadSide = 2
    }

    public enum DatabaseType : int
    {
        Todo = 1
    }
}
