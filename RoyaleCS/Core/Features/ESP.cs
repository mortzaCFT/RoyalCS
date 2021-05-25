using RoyaleCS.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoyaleCS.Core.Functions
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    internal class ESP : InitializeHandler
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private bool enabled;



        internal ESP(bool enabled)
        {
            ESP eSP1 = this;
            ESP eSP = eSP1;
            eSP.enabled = enabled;
        }

        public ESP()
        {
        }

        protected override void OnEnable()
        {
            Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() + OnKeyDown);

            Enable();
        }



        protected override void OnDisable()
        {
            Main.Instance.Listener.SetOnKeyPressed(Main.Instance.Listener.GetOnKeyPressed() - OnKeyDown);
        }

        private void Enable()
        {
            void action()
            {
                while (true)
                {
                    if (enabled)
                    {
                        if (WindowHandler.TryGetCSGOWindow())
                        {
                            int playerTeamNum = Cheat.Memory.Read<int>(Player.Local + Offsets.m_iTeamNum);

                            for (int i = 0; i < 64; i++)
                            {
                                int enemyNum = Cheat.Memory.Read<int>(Cheat.ModuleAddress + Offsets.dwEntityList + (i * 16));
                                int enemyTeamNum = Cheat.Memory.Read<int>(enemyNum + Offsets.m_iTeamNum);
                                int index = Cheat.Memory.Read<int>(enemyNum + Offsets.m_iGlowIndex);

                                if (enemyTeamNum != 0)
                                {
                                    if (enemyTeamNum != playerTeamNum)
                                    {
                                        DrawEnemy(index, 255, 0, 0, 255);
                                    }
                                    else
                                    {
                                        DrawEnemy(index, 0, 0, 255, 255);
                                    }
                                }
                            }
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            Task task = new Task(action);

            task.Start();
        }

        private void DrawEnemy(int index, int v1, int v2, int v3, int v4)
        {
            throw new NotImplementedException();
        }

        private void OnKeyDown(Key key)
        {
            if (WindowHandler.TryGetCSGOWindow())
            {
                if (key == Key.F4)
                {
                    bool v = !enabled;
                    enabled = v;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is ESP eSP &&
enabled == eSP.enabled;
        }
    }
}
