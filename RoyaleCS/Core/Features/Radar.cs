using RoyaleCS.Core.Handlers;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoyaleCS.Core.Features
{
    internal class Radar : InitializeHandler
    {
        private bool enabled;



        internal Radar(bool enabled)
        {
            this.enabled = enabled;
        }


            
        protected override void OnEnable()
        {
            Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() + onKeyDown);



            enable();
        }

        

        protected override void OnDisable() 
        {
            Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() - onKeyDown);
        }



        private void enable()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    if (enabled)
                    {
                        if (WindowHandler.TryGetCSGOWindow())
                        {
                            for (int i = 0; i < 64; i++)
                            {
                                int enemy = Cheat.Memory.Read<int>(Cheat.ModuleAddress + Offsets.dwEntityList + (i * 0x10));

                                if (Cheat.Memory.Read<bool>(enemy + Offsets.m_bDormant)) continue;

                                Cheat.Memory.Write<bool>(enemy + Offsets.m_bSpotted, true);
                            }
                        }
                    }
                }
            });

            task.Start();
        }



        private void onKeyDown(Key key)
        {
            if (WindowHandler.TryGetCSGOWindow())
            {
                if (key == Key.N) enabled = !enabled;
            }
        }
    }
}
