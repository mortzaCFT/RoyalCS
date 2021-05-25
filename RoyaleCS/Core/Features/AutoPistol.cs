using RoyaleCS.Core.Handlers;
using System.Threading;

namespace RoyaleCS.Core.Features
{
    internal class AutoPistol : InitializeHandler
    {
        private readonly bool enabled;



        internal AutoPistol(bool enabled)
        {
            this.enabled = enabled;
        }



        protected override void OnEnable()
        {
            Enable();
        }

        protected override void OnDisable() { }



        private void Enable()
        {
            void start(object t)
            {
                while (true)
                {
                    if (enabled)
                    {
                        if (WindowHandler.TryGetCSGOWindow())
                        {
                            if (InputHandler.GetLeftMouseButtonDown() && Player.HasHandsPistol)
                            {
                                Player.Attack();
                                Thread.Sleep(3);
                            }
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            Thread thread = new Thread(start);

            thread.Start();
        }
    }
}
