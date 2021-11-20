using FinalProject.Architecture.Helpers.Scripts;

namespace FinalProject.Architecture.Repositories.Scripts
{
    public abstract class Repository: ArchitectureComponent, IRepository
    {
        protected Repository(Coroutines coroutines) : base(coroutines)
        {
        }
    }
}
