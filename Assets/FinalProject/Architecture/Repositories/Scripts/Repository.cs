namespace FinalProject.Architecture.Repositories.Scripts
{
    public abstract class Repository
    {
        public virtual void OnCreate() { } // 1 use 1
        
        public abstract void Initialize(); // 2 use only after 1
        public virtual void OnStart() { } // 3 use only after 1 and 2
        public abstract void Save();
    }
}
