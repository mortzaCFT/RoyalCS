using RoyaleCS.Core.Handlers;
using RoyaleCS.Core.Other;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyaleCS.Core.Functions
{
    internal class Trigger : InitializeHandler
    {
        protected override void OnEnable() => enable();



        protected override void OnDisable() { }



        private void enable()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    if (WindowHandler.TryGetCSGOWindow())
                    {
                        if (InputHandler.GetKeyDown(Keys.LMenu))
                        {
                            if (Player.TryGetCrosshairEnemyTrigger(out CrosshairParameters parameters) && !parameters.TriggerIsTeammate())
                            {
                                Player.Attack();
                            }
                        }
                    }

                    Thread.Sleep(1);
                }
            });

            task.Start();
        }
    }
}
