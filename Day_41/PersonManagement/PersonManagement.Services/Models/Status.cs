namespace PersonManagement.Services.Models
{
    public enum Status
    {
        NotFound = 404,
        AlreadyExists = 409,
        InternalServerError = 500,
        Success = 200,
        Unauth = 401,
    }
}
