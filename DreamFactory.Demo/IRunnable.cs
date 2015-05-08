namespace DreamFactory.Demo
{
    using System.Threading.Tasks;
    using DreamFactory.Rest;

    internal interface IRunnable
    {
        Task RunAsync(IRestContext context);
    }
}
