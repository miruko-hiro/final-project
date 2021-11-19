namespace FinalProject.Architecture.Interactors.Scripts
{
    public abstract class Interactor
    {
        public virtual void OnCreate() { } // 1 use 1

        public virtual void Initialize() { } // 2 use only after 1

        public virtual void OnStart() { } // 3 use only after 1 and 2
    }
}
