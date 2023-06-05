using DiscordRPC;

namespace surftimer_rpc_gui
{
    internal class SurfTimerRPC_Client
    {

        public DiscordRpcClient Client;

        public SurfTimerRPC_Client(string clientID)
        {
            Client = new DiscordRpcClient(clientID);
        }
    }
}
