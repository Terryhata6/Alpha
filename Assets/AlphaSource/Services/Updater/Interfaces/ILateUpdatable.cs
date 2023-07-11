namespace AlphaSource.Services.Updater.Interfaces
{
    public interface ILateUpdatable : IExecutor
    {
        public void LateExecute();
    }
}