using FinalProject.Architecture.Helpers.Scripts;

namespace FinalProject.Architecture.Interactors.Scripts
{
    public abstract class Interactor: ArchitectureComponent, IInteractor
    {
        protected Interactor(Coroutines coroutines) : base(coroutines)
        {
        }
    }
}
