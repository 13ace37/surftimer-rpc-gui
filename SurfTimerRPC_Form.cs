using CSGSI;
using DiscordRPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace surftimer_rpc_gui
{
    public partial class SurfTimerRPC_Form : Form
    {

        private SurfTimerRPC_Client surfTimerRPC_Client;
        private SurfTimerRPC_GSL surfTimerRPC_GSL;

        private DateTime surfTimerRPC_GSL_lastPackage = new DateTime(1970, 1 ,1);

        public SurfTimerRPC_Form()
        {
            InitializeComponent();

            this.initializeForm()
                .initializeRPCClient()
                .initializeRPCEvents()
                .initializeGSLServer()
                .initializeGSLEvents()
                ;


        }

        private SurfTimerRPC_Form initializeGSLServer()
        {
            surfTimerRPC_GSL = new SurfTimerRPC_GSL(23251);
            surfTimerRPC_GSL.GSL.Start();

            return this;
        }
        private SurfTimerRPC_Form initializeGSLEvents()
        {
            surfTimerRPC_GSL.GSL.NewGameState += (GameState gameState) =>
            {
                surfTimerRPC_GSL_lastPackage = DateTime.Now;

                if (gameState.Map.Name.StartsWith("surf_")) handleGSLSurfMap(gameState);
                else if (gameState.Map.Name.Length > 0) handleGSLNonSurfMap(gameState);
                else handleGSLNoMap(gameState);
            };

            System.Timers.Timer t = new System.Timers.Timer(500);
            t.AutoReset = true;
            t.Elapsed += (Object source, ElapsedEventArgs e) =>
            {
                this.updateCGITime();
            };
            t.Start();

            return this;
        }

        private void handleGSLSurfMap(GameState gameState)
        {
            
            // Timer - Kills
            TimeSpan timerSeconds = TimeSpan.FromSeconds(gameState.Player.MatchStats.Kills);
            string timerText = gameState.Player.MatchStats.Kills >= 3600 ? timerSeconds.ToString(@"h\:mm\:ss") : timerSeconds.ToString(@"mm\:ss");

            // Rank - Score (-1)
            int score = gameState.Player.MatchStats.Score * -1;
            string scoreText = score >= 99999 ? "Unranked" : score.ToString();

            // Map Progress - Assists (%)
            int mapProgress = gameState.Player.MatchStats.Assists;
            string mapProgressText = mapProgress.ToString() + "%";

            // Server Progress - MVPs (%)
            int serverProgress = gameState.Player.MatchStats.MVPs;
            string serverProgressText = serverProgress.ToString() + "%";

            // Title - Clantag
            string clantag = gameState.Player.Clan;
            string clantagText = clantag.Trim();

            // Map
            string map = gameState.Map.Name;
            string mapText = map.Trim();

            // State
            string state = gameState.Provider.SteamID == gameState.Player.SteamID ? "surfing" : "spectating";

            // User
            string userName = gameState.Player.Name;

            label1.Text = "User: " + userName + "\nTimer: " + timerText + "\nRank: " + scoreText + "\nMap Progress: " + mapProgressText + "\nServer Progress: " + serverProgressText + "\nTitle: " + clantagText + "\nMap: " + mapText + "\nState: " + state;
        }
        private void handleGSLNonSurfMap(GameState gameState)
        {
            label1.Text = "not surfing";
            
            surfTimerRPC_Client.Client.SetPresence(
                formatRichPresence($"on {gameState.Map.Name}", "not surfing", "icon", null, $"{gameState.Player.Clan} {gameState.Player.Name}", null)
            );
        }

        private void handleGSLNoMap(GameState gameState)
        {
            label1.Text = "in main menu";

            surfTimerRPC_Client.Client.SetPresence(
                formatRichPresence("in main menu", null, "icon", null, $"{gameState.Player.Clan} {gameState.Player.Name}", null)
            );
        }



#nullable enable
        private RichPresence formatRichPresence(string details, string? state, string? largeImage, string? smallImage, string? largeImageText, string? smallImageText)
        {
            return (new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = largeImage,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImage,
                    SmallImageText = smallImageText,
                }
            });
        }
#nullable disable

        private SurfTimerRPC_Form initializeRPC()
        {
            surfTimerRPC_Client.Client.SetPresence(formatRichPresence($"SurfTimer RPC v{GetAssemblyVersion()}", "just started", "icon", null, null, null));

            return this;
        }

        private SurfTimerRPC_Form initializeRPCEvents()
        {
            surfTimerRPC_Client.Client.OnReady += (sender, e) =>
            {
                this.updateRPCStatus(true)
                    .initializeRPC()
                    ;

            };

            return this;
        }

        private SurfTimerRPC_Form initializeRPCClient()
        {

            surfTimerRPC_Client = new SurfTimerRPC_Client("559388357654872064");
            surfTimerRPC_Client.Client.Initialize();

            return this;
        }

        private SurfTimerRPC_Form initializeForm()
        {
            this.initializeFormTitle()
                .initializeFormElements()
                ;

            return this;
        }

        private string GetAssemblyVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }

        private SurfTimerRPC_Form initializeFormTitle()
        {
            this.Text = $"SurfTimer RPC v{GetAssemblyVersion()}";
            return this;
        }

        private SurfTimerRPC_Form updateRPCStatus(bool status)
        {
            pn_rpcStatus.BackColor = status ? Color.FromArgb(255, 163, 190, 140) : Color.FromArgb(255, 191, 97, 106);
            return this;
        }

        private SurfTimerRPC_Form updateCGITime()
        {
            double diffInSeconds = (DateTime.Now - surfTimerRPC_GSL_lastPackage).TotalSeconds;
            string diffInSecondsString = diffInSeconds.ToString("0.0s");

            if (lb_cgiLastInfo.InvokeRequired)
                lb_cgiLastInfo.Invoke(new MethodInvoker(delegate { lb_cgiLastInfo.Text = "CGI Last Info: " + diffInSecondsString; }));
            else
                lb_cgiLastInfo.Text = "CGI Last Info: " + diffInSecondsString;

            this.updateCGIStatus(diffInSeconds < 1);

            return this;
        }

        private SurfTimerRPC_Form updateCGIStatus(bool status)
        {
            pn_cgiStatus.BackColor = status ? Color.FromArgb(255, 163, 190, 140) : Color.FromArgb(255, 191, 97, 106);
            return this;
        }

        private SurfTimerRPC_Form initializeFormElements()
        {
            this.updateRPCStatus(false)
                .updateCGIStatus(false)
                .updateCGITime()
                ;
            return this;
        }

    }
}
