namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ITokenJWT
    {
        string Generate(string key, string awg);
    }
}
