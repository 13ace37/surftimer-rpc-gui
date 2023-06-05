using CSGSI;

namespace surftimer_rpc_gui
{
    internal class SurfTimerRPC_GSL
    {

        public GameStateListener GSL;

        public SurfTimerRPC_GSL(int port)
        {
             GSL = new GameStateListener(port);
        }

    }
}
