using CSGSI;
using DiscordRPC;
using surftimer_rpc_gui.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace surftimer_rpc_gui
{
    public partial class SurfTimerRPC_Form : Form
    {

        private SurfTimerRPC_Client surfTimerRPC_Client;
        private SurfTimerRPC_GSL surfTimerRPC_GSL;

        private DateTime surfTimerRPC_GSL_lastPackage = new DateTime(1970, 1 ,1);

        private IDictionary<string, string> modules;
        private ListBox[,] lbx_moduleSelectors;

        private int[,] lbx_moduleSelectedIndexes;

        private string cgiConfigPath;

        private bool csgoNotOpenedWarningShowed = false;

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

            bool spectatingReplayBot = (scoreText == "Unranked" && gameState.Player.Clan.Contains("Replay"));
            scoreText = spectatingReplayBot ? gameState.Player.Clan : scoreText;

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
            state = spectatingReplayBot ? "watching replay" : state;

            // User
            string userName = gameState.Player.Name;


            // Modules
            modules["State"] = $"{state} on {mapText}";
            modules["Timer"] = $"Timer: {timerText}";
            modules["Map"] = mapText;
            modules["Server Rank/Replay Bot"] = spectatingReplayBot ? gameState.Player.Clan : $"S-Rank: {scoreText}";
            modules["Map Completion"] = mapProgressText;
            modules["Server Completion"] = serverProgressText;

            string[,] presenceModules = new string[2,2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    presenceModules[i,j] = modules[lbx_moduleSelectors[i, j].GetItemText(lbx_moduleSelectors[i, j].SelectedItem)];


            string[] presenceLines = new string[2];
            presenceLines[0] = presenceModules[0,1] == "" ? $"{presenceModules[0,0]}" : $"{presenceModules[0,0]} | {presenceModules[0,1]}";
            presenceLines[1] = presenceModules[1,1] == "" ? $"{presenceModules[1,0]}" : $"{presenceModules[1,0]} | {presenceModules[1,1]}";


            surfTimerRPC_Client.Client.SetPresence(
                formatRichPresence(presenceLines[0], presenceLines[1], "logo", null, $"{gameState.Player.Clan} {gameState.Player.Name}", null)
            );

        }

        private void handleGSLNonSurfMap(GameState gameState)
        {
            surfTimerRPC_Client.Client.SetPresence(
                formatRichPresence($"on {gameState.Map.Name}", "not surfing", "logo", null, $"{gameState.Player.Clan} {gameState.Player.Name}", null)
            );
        }

        private void handleGSLNoMap(GameState gameState)
        {
            surfTimerRPC_Client.Client.SetPresence(
                formatRichPresence("in main menu", null, "logo", null, $"{gameState.Player.Clan} {gameState.Player.Name}", null)
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
            if (surfTimerRPC_Client == null) return this;

            surfTimerRPC_Client.Client.SetPresence(formatRichPresence($"SurfTimer RPC v{GetAssemblyVersion()}", "just started", "logo", null, null, null));

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

        private SurfTimerRPC_Form initializeModules()
        {
            modules = new Dictionary<string, string>();

            modules.Clear();
            modules.Add("", "");
            modules.Add("State", "");
            modules.Add("Timer", "");
            modules.Add("Map", "");
            modules.Add("Server Rank/Replay Bot", "");
            modules.Add("Map Completion", "");
            modules.Add("Server Completion", "");

            lbx_moduleSelectors = new ListBox[2, 2];
            lbx_moduleSelectors[0, 0] = lbx_modules0;
            lbx_moduleSelectors[0, 1] = lbx_modules1;
            lbx_moduleSelectors[1, 0] = lbx_modules2;
            lbx_moduleSelectors[1, 1] = lbx_modules3;

            lbx_moduleSelectedIndexes = new int[2, 2];
            lbx_moduleSelectedIndexes[0, 0] = Settings.Default.lbx_modules0;
            lbx_moduleSelectedIndexes[0, 1] = Settings.Default.lbx_modules1;
            lbx_moduleSelectedIndexes[1, 0] = Settings.Default.lbx_modules2;
            lbx_moduleSelectedIndexes[1, 1] = Settings.Default.lbx_modules3;

            for (int i = 0; i < 2; i++)
                for(int j = 0; j < 2; j++)
                {
                    lbx_moduleSelectors[i,j].Items.Clear();
                    foreach (KeyValuePair<string, string> module in modules)
                        lbx_moduleSelectors[i, j].Items.Add(module.Key);

                    lbx_moduleSelectors[i, j].SelectedIndex = lbx_moduleSelectedIndexes[i, j];
                }
            

            return this;
        }

        private SurfTimerRPC_Form initializeForm()
        {
            this.initializeFormTitle()
                .initializeFormElements()
                .initializeModules()
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
            string diffInSecondsString = diffInSeconds > 10 ? ">10.0s" : diffInSeconds.ToString("0.0s");

            if (lb_cgiLastInfo.InvokeRequired)
                lb_cgiLastInfo.Invoke(new MethodInvoker(delegate { lb_cgiLastInfo.Text = "CGI Last Info: " + diffInSecondsString; }));
            else
                lb_cgiLastInfo.Text = "CGI Last Info: " + diffInSecondsString;

            this.updateCGIStatus(diffInSeconds < 1);

            if (diffInSeconds > 10) this.initializeRPC();

            return this;
        }

        private SurfTimerRPC_Form updateCGIStatus(bool status)
        {
            pn_cgiStatus.BackColor = status ? Color.FromArgb(255, 163, 190, 140) : Color.FromArgb(255, 191, 97, 106);
            return this;
        }

        private SurfTimerRPC_Form updateCGIConfig()
        {
#nullable enable
            Process? process = Process.GetProcessesByName("csgo").FirstOrDefault();
            if (process == null)
            {
                if (!csgoNotOpenedWarningShowed) MessageBox.Show("Please start csgo!");
                csgoNotOpenedWarningShowed = true;
                System.Timers.Timer t = new System.Timers.Timer(10000);
                t.Elapsed += (Object source, ElapsedEventArgs e) =>
                {
                    this.updateCGIConfig();
                };
                t.Start();
                return this;
            }
#nullable disable
            string path = process.MainModule.FileName;

            this.checkCGIConfig(path);


            return this;
        }

        private SurfTimerRPC_Form checkCGIConfig(string path)
        {

            cgiConfigPath = Path.Combine(Path.GetDirectoryName(path), "csgo", "cfg", "gamestate_integration_surf.cfg");
            bool configExists = File.Exists(cgiConfigPath);
            updateCGIConfigStatus(configExists);

            if (!configExists) createCGIConfig(); 

            return this;
        }

        private SurfTimerRPC_Form createCGIConfig()
        {
            if (cgiConfigPath == null) return this;

            string config = "\"surf\"\n{\n \"uri\" \"http://localhost:23251/\"\n \"timeout\" \"5.0\"\n \"buffer\"  \"0.1\"\n \"throttle\" \"0.1\"\n \"heartbeat\" \"0.5\"\n \"data\"\n {\n   \"provider\"            \"1\"\n   \"map\"                 \"1\"\n   \"round\"               \"1\"\n   \"player_id\"           \"1\"\n   \"player_state\"        \"1\"\n   \"player_weapons\"      \"1\"\n   \"player_match_stats\"  \"1\"\n }\n}\n";
            File.WriteAllText(cgiConfigPath, config);

            updateCGIConfig();

            return this;
        }

        private SurfTimerRPC_Form updateCGIConfigStatus(bool status)
        {
            pn_cgiConfigStatus.BackColor = status ? Color.FromArgb(255, 163, 190, 140) : Color.FromArgb(255, 191, 97, 106);
            return this;
        }

        private SurfTimerRPC_Form initializeFormElements()
        {
            this.updateRPCStatus(false)
                .updateCGIStatus(false)
                .updateCGIConfigStatus(false)
                .updateCGITime()
                .updateCGIConfig()
                ;
            return this;
        }

        private void lbx_modulesChangeIndex(object sender, EventArgs e)
        {
            Settings.Default.lbx_modules0 = lbx_modules0.SelectedIndex;
            Settings.Default.lbx_modules1 = lbx_modules1.SelectedIndex;
            Settings.Default.lbx_modules2 = lbx_modules2.SelectedIndex;
            Settings.Default.lbx_modules3 = lbx_modules3.SelectedIndex;
            Settings.Default.Save();
        }

        private void SurfTimerRPC_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            surfTimerRPC_Client.Client.Dispose();
            surfTimerRPC_GSL.GSL.Stop();
        }
    }
}
