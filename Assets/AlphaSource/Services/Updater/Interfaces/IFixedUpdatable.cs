namespace AlphaSource.Services.Updater.Interfaces
{
    public interface IFixedUpdatable : IExecutor
    {
        public void FixedExecute();
    }
}