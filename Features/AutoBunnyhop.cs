using RoyaleCS.Core.Handlers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RoyaleCS.Core.Functions
{
    internal class AutoBunnyhop : InitializeHandler
    {
        private bool enabled;



        internal AutoBunnyhop(bool enabled)
        {
            this.enabled = enabled;
        }



        protected override void OnEnable()
        {
            Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() + onKeyDown);



            enable();
        }

       

        protected override void OnDisable() => Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() - onKeyDown);



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
                            if (InputHandler.GetKeyDown(Keys.Space) && Player.IsGround)
                            {
                                Player.Jump();
                                Thread.Sleep(1);
                            }
                        }
                    }

                    Thread.Sleep(1);
                }
            });

            task.Start();
        }



        private void onKeyDown(Key key)
        {
            if (WindowHandler.TryGetCSGOWindow())
            {
                if (key == Key.F3) enabled = !enabled;
            }
        }
    }
}
