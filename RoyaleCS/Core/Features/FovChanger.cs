using RoyaleCS.Core.Handlers;
using System.Windows.Input;

namespace RoyaleCS.Core.Functions
{
    internal class FovChanger : InitializeHandler
    {
        private bool enabled;



        internal FovChanger(bool enabled)
        {
            this.enabled = enabled;
        }



        protected override void OnEnable() => Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() + onKeyDown);



        protected override void OnDisable() => Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() - onKeyDown);



        private void onKeyDown(Key key)
        {
            if (WindowHandler.TryGetCSGOWindow())
            {
                if (key == Key.O && !Player.IsScoping)
                {
                    if (enabled = !enabled) Player.SetFov(110);

                    else Player.SetFovByDefault();
                }
            }
        }
    }
}