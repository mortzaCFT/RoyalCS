namespace RoyaleCS.Core.Handlers
{
    internal abstract class InitializeHandler
    {
        protected InitializeHandler()
        {
            ApplicationHandler.Load += onEnable;

            ApplicationHandler.Unload += onDisable;
        }



        protected abstract void OnEnable();

        protected abstract void OnDisable();



        private void onEnable()
        {
            ApplicationHandler.Load -= onEnable;

            OnEnable();
        }

        private void onDisable()
        {
            ApplicationHandler.Load -= onDisable;

            OnDisable();
        }



        private void DrawEnemy(int index, int red, int green, int blue, int alpha)
        {
            int num = Cheat.Memory.Read<int>(Cheat.ModuleAddress + Offsets.dwGlowObjectManager);

            Cheat.Memory.Write(num + (index * 56) + 4, red / 100f);
            Cheat.Memory.Write(num + (index * 56) + 8, green / 100f);
            Cheat.Memory.Write(num + (index * 56) + 12, blue / 100f);
            Cheat.Memory.Write(num + (index * 56) + 16, alpha / 100f);

            Cheat.Memory.Write(num + (index * 56) + 36, true);
            Cheat.Memory.Write(num + (index * 56) + 37, false);
        }
    }
}
