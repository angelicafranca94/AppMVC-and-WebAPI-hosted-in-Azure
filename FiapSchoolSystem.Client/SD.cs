namespace FiapSchoolSystem.Client;

public static class SD
{
    public static string FiapSystemAPIBase { get; set; }

    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}