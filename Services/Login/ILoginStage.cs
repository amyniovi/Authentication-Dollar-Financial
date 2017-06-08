namespace Dollar.Authentication.Services.Login
{
    public interface ILoginStage
    {
        bool Validate(LoginContext context);
    }
}