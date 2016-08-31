using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//These imports are non-default and added
using SpeechLib;
using System.Reflection;

namespace Minerva
{
    public partial class FullScreenButWhy : Form
    {
        Dictionary<string, string> responses = new Dictionary<string, string>(); //the dictionary of everything
        Dictionary<DateTime, string> reminders = new Dictionary<DateTime, string>(); //the dictionary of reminders

        //songs
        String mediaLib; //where the user's media library is
        string[] songs; //stores songs after finding them in the media library
        ArrayList songsT = new ArrayList(); //temporarily holds songs

        String inputText = ""; //inputted text
        String respondingTo = ""; //if the user says something Minerva doesn't recognize, this is it
        //this will be used as the key in the dictionary, and the next input will be the value
        Boolean noteResponse = false; //specifies if the next input is a response to the statement resondingTo

        Boolean noteReminderTime = false;
        String reminderObj = "";
        String dataTemp = "";

        String urlToGoTo = "";

        int CharlarCounter = 0;
        private SpSharedRecoContext withEventsField_RecoContext;
        public SpSharedRecoContext RecoContext
        {
            get { return withEventsField_RecoContext; }
            set
            {
                if (withEventsField_RecoContext != null)
                {
                    withEventsField_RecoContext.Recognition -= OnReco;
                }
                withEventsField_RecoContext = value;
                if (withEventsField_RecoContext != null)
                {
                    withEventsField_RecoContext.Recognition += OnReco;
                }
            }
        }
        ISpeechRecoGrammar grammar;
        int CharCount;

        SpVoice speech = new SpVoice();
        // Boolean rememberThis = false;       // Given validity (made true) upon entering a response to the "Could you remember" section.

        public FullScreenButWhy()
        {
        //default stuff
            InitializeComponent();
            //speech.Voice = speech.GetVoices("gender=female").Item(1);
            //load in the dictionary

            //here, Minerva tries to load in data and prefs
            //if an error is thrown, it means the file does not exist
            //thus Minerva makes one
            try
            {
                System.IO.File.ReadAllLines(@"data.txt");
            }
            catch 
            {
                System.IO.File.WriteAllText(@"data.txt", "");
            }
            try
            {
                System.IO.File.ReadAllLines(@"prefs.txt");
            }
            catch
            {
                System.IO.File.WriteAllText(@"prefs.txt", "");
            }

            string[] dictIn = System.IO.File.ReadAllLines(@"data.txt");
            string[] prefs = System.IO.File.ReadAllLines(@"prefs.txt");
            if (dictIn != null)
            {
                loadDict(dictIn);
                rTextBox1.AppendText("Dictionary loaded." + "\r\n");
            }
            if (prefs == null || prefs.Length < 1)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Choose your media folder";
                fbd.ShowDialog();
                mediaLib = fbd.SelectedPath;
                String[] temp = new String[1];
                temp[0] = mediaLib;
                System.IO.File.WriteAllLines(@"prefs.txt", temp);
                findSongs();
            }
            else
            {
                mediaLib = prefs[0];
                findSongs();
            }
            startSpeech();

            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            //if you press the enter button on the gui, call submit
            submit("");
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //or if you press your enter key on your keyboard, call submit
                submit("");
            }
        }

        private void startSpeech()
        {
            if (RecoContext == null)
            {
                RecoContext = new SpSharedRecoContext();
                grammar = RecoContext.CreateGrammar(1);
                grammar.DictationLoad();
            }

            grammar.DictationSetState(SpeechRuleState.SGDSActive);    // Opens up diction possibility.
        }

        private void OnReco(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
        {
            string recoResult = Result.PhraseInfo.GetText();    // Translates whatever was somewhat definitively recognized by Windows Speech Recognition into text.

            recoResult = recoResult.ToLower();          // This is the same as taking inquiry text and making it all lowercase in Minerva.

            submit(recoResult);
        }

        private void loadDict(String[] input)
        {
            Boolean key = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (key && i + 1 < input.Length)
                {
                    responses.Add(input[i], input[i + 1]);
                    key = false;
                }
                else
                {
                    key = true;
                }
            }
        }

        private String[] dictToText()
        {
            String temp = "";
            foreach (var pair in responses)
            {
                temp = temp + pair.Key + ";" + pair.Value + ";";
            }
            return temp.Split(';');
        }

        private void findSongs() //this finds songs from the media library location
        {
            findSongsIn(mediaLib);
            songs = (string[])songsT.ToArray(typeof(string));
        }

        private void findSongsIn(String lib) //finds songs in a specific library
        {
            String[] dir = System.IO.Directory.GetDirectories(@lib);
            foreach (String d in dir)
            {
                findSongsIn(d);
            }
            String[] temp = System.IO.Directory.GetFiles(@lib, "*mp3");
            foreach (String i in temp)
            {
                songsT.Add(i);
            }
        }

        private String getSong(String name) //returns the file location of a song with a given name
        {
            name = name.ToLower();
            string returnS = null;
            for (int i = 0; i < songs.Length; i++)
            {
                if (songs[i].ToLower().Replace('_',' ').Contains(name))
                {
                    returnS = songs[i];
                }
            }
            return returnS;
        }

        private String songsList()
        {
            String list = "";
            for (int i = 0; i < songs.Length; i++)
            {
                list = list + songs[i] + "\r\n";
            }
            return list;
        }

        private String getWebpage(String URL)
        {
            String URI = URL; //example: http://www.google.com
            String request = "";

            try //this happens, and if there is an error, the catch is called
            {
                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(URI);
                StreamReader streamreader = new StreamReader(stream);
                request = streamreader.ReadToEnd();
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)ex.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            break;

                        default:
                            throw ex;
                    }
                }
            } //end catch

            return request;
        }

        private String parseWikipedia(String source)
        {
            String output= source;
            int start = source.IndexOf("<p>") + "<p>".Length;
            int end = source.IndexOf("</p>");
            int length = end - start;
            output = "start " + start + " end " + end + " length " + length;
            output = source.Substring(start, end - start);
            output = StripTagsCharArray(output);
            return output;
        }

        private String parseThatYoungWeatherYo (String source)
        {
            String output = source;
            int start = source.IndexOf("temperature-fahrenheit") + "temperature-fahrenheit".Length;
            int end = source.IndexOf("");
            return output;
        }

        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        private void parseCommand(String cmdIn)
        {
            //this parses console commands, and does stuff
            cmdIn = cmdIn.ToLower();
            cmdIn = cmdIn.TrimEnd('.');
            cmdIn = cmdIn.TrimEnd('?');
            cmdIn = cmdIn.TrimEnd('!');



            if (cmdIn.Equals("\\help"))
            {
                rTextBox1.AppendText("\\help - acess help" + "\r\n" +
                    "\\clear - clear chat" + "\r\n" +
                    "\\erasedata - erase dictionary data" + "\r\n" +
                    "\\save - save dictionary data" + "\r\n");
            }
            else if (cmdIn.Equals("\\clear"))
            {
                rTextBox1.Text = "";
            }
            else if (cmdIn.Equals("\\jumprj"))
            {
                rTextBox1.AppendText("Opening now. \n");
                //Main2 newmain = new Main2();
                //newmain.Show();
                //newmain.BringToFront();
            }
            else if (cmdIn.Equals("\\erasedata"))
            {
                responses = new Dictionary<string, string>();
            }
            else if (cmdIn.Equals("\\save"))
            {
                string[] lines = dictToText();
                System.IO.File.WriteAllLines(@"data.txt", lines);
            }
            else
            {
                rTextBox1.AppendText("Command not recognized, type \"\\help\" for help");
            }
        }

        private void minervaSay(String input) //have minerva say the input string
        {
            /* Label integration, to where a label is drawn on the spot by minervaSay. This is useful later with more interactive controls to spawn.
             * 
             * Label minervaLabel = new Label();
            minervaLabel.Visible = true;
            minervaLabel.Location = new System.Drawing.Point(2, 2);
            minervaLabel.Font = new System.Drawing.Font("Wasco Sans", 14);
            minervaLabel.ForeColor = Color.White;
            minervaLabel.Text = input;
            this.Controls.Add(minervaLabel);
             * 
             */

            // This is the first label to use, and is pretty much all we are concerned with for now.

            minervaResponse.Text = input;
            
            rTextBox1.AppendText("Minerva: " + input + "\r\n");
            Application.DoEvents();
            //speech.Speak(input);
            Application.DoEvents();
        }

        private void submit(String input)
        {
            /* This is where all the magic happens. After the user presses enter or the enter key,
             this method is called. Starter functionality: ask for a response to statement's Minerva
             doesn't have a response to. Then there are certain functions that need to be coded in.
             These are:
             
             Math: "what is _ equal to?"
             Dictionary: "what does _ mean?" || "what's the definition of _?"W
             Wikipedia: Use http://en.m.wikipedia.org/w/index.php?search= + search term
             */

            if (input == "")
                inputText = textBox2.Text;
            else

                /* This should remove any objects not pre-spawned on the page, yet make sure this works before re-adding it here.
                 * 
                for (int i = this.Controls.Count - 1; i >= 0; i += -1)
                {
                    if (this.Controls[i].Name != "button2" & this.Controls[i].Name != "rTextBox1" & this.Controls[i].Name != "textBox2")
                    {
                        this.Controls.RemoveAt(i);
                    }
                }
                 * 
                 */
                
                inputText = input;
            
            rTextBox1.AppendText("You: " + inputText + "\r\n");
            textBox2.Text = "";
            if (inputText.StartsWith("\\"))
            {
                //it's a console command!
                parseCommand(inputText);
            }
            else
            {
                if (noteResponse)
                {
                    responses.Add(respondingTo, inputText);
                    minervaSay("You're lucky I'm not Robert's hard drive. I'll remember that.");
                    noteResponse = false;
                }
                else if (noteReminderTime)
                {
                    try
                    {
                        reminders.Add(DateTime.Parse(inputText), reminderObj);
                        minervaSay("Wait, what was that? \n \nI'm kidding. Ugh. I'll remind you when, ya' know, the thing happens.");
                    }
                    catch
                    {
                        minervaSay("Seriously, what in the actual heck are you even saying.");
                    }
                    
                    noteReminderTime = false;
                }
                else
                {
                    inputText = inputText.ToLower();
                    inputText = inputText.Replace(".","");
                    inputText = inputText.Replace("?", "");
                    inputText = inputText.Replace("!", "");
                    DateTime dt = DateTime.Now;
                    /* Start with the pre-programmed stuff, like math and web searching */
                    if (inputText.Equals("what time is it"))
                    {
                        minervaSay("Time to get a watch. It is now " + dt.ToString("t") + ".");
                    }
                    else if (inputText.Equals("what day is it"))
                    {
                        minervaSay("You literally boot up your computer AND IT TELLS YOU. Magical, right? But actually though, today is " + dt.DayOfWeek + ", " + dt.ToString("MMMM dd, yyyy") + ".");
                    }
                    else if (inputText.StartsWith("play ")) //ex: play stairway to heaven
                    {
                        String temp = getSong(inputText.Substring(5));
                        if (temp != null)
                        {
                            mediaPlayer.URL = temp;
                            minervaSay("Yaaas, music time. Here's " + mediaPlayer.currentMedia.getItemInfo("title") + " by " + mediaPlayer.currentMedia.getItemInfo("artist"));
                        }
                        else
                        {
                            minervaSay("You're not giving me anything to work with here. Where's the song? I definitely don't have it.");
                        }
                        
                    }
                    else if (inputText.Equals("play"))
                    {
                        mediaPlayer.Ctlcontrols.play();
                    }
                    else if (inputText.Equals("stop") || inputText.Equals("pause"))
                    {
                        mediaPlayer.Ctlcontrols.pause();
                    }
                    else if (inputText.Equals("list songs"))
                    {
                        minervaSay(songsList());
                    }
                    else if (inputText.Equals("who made you") || inputText.Equals("who made you?"))
                    {
                        minervaSay("I was made by a few silly doges over at IndigoBox Studios. If you want, you can read more at their website (in other words, hope you have some good luck, it might not even be up).");
                        linkToSomewhereYouSillyJoven.Show();
                        linkToSomewhereYouSillyJoven.Text = "Visit these strange people";
                        urlToGoTo = "http://indigoboxstudios.tk/";
                        
                    }
                    else if (inputText.StartsWith("could you remember"))
                    {
                        minervaSay("Nope. \n \n \n \n Maybe. What do you want?");
                        //rememberThis = true;
                        noteResponse = true;
                        respondingTo = inputText;
                    }
                    else if (inputText.Equals("hello") || inputText.Equals("hey there"))
                    {
                        minervaSay("OMG!! Like, hi, " + Properties.Settings.Default.name + "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1");
                    }
                    else if (inputText.StartsWith("call me"))
                    {
                        String ohNaNa = inputText.Remove(0, 8);
                        String justTheFirstLetter = ohNaNa.Remove(1);
                        justTheFirstLetter = justTheFirstLetter.ToUpper();
                        String andNowForTheRest = ohNaNa.Remove(0, 1);
                        String allTogetherNow = justTheFirstLetter + andNowForTheRest;
                        minervaSay("Still not as awesome as my name, but ya' know, that's just me. Anyway, " + allTogetherNow + ", [sigh] I'll start calling you by that name instead.");
                        Properties.Settings.Default.name = allTogetherNow;
                        Properties.Settings.Default.Save();
                    }
                    else if (inputText.StartsWith("can you remind me"))
                    {
                        reminderObj = inputText.Substring(17);
                        minervaSay("Uggggh. Kidding, of course. What date and time would it be on?");
                        noteReminderTime = true;
                    }
                    else if (inputText.StartsWith("is there a reminder on"))
                    {
                        DateTime temp = DateTime.Parse(inputText.Substring(22));
                        if (reminders[temp] != null)
                        {
                            minervaSay("Yes, okay. Get to work. There's \"" + reminders[temp] + "\"");
                        }
                        else
                        {
                            minervaSay("Nope, there's nothing. Go back to sleep.");
                        }
                    }
                    else if (inputText.StartsWith("i want you to wow me.") || inputText.StartsWith("i want you to wow me"))
                    {
                        this.BackgroundImage = Properties.Resources.wow;
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                        minervaResponse.ForeColor = Color.Plum;
                        minervaResponse.BackColor = Color.Transparent;
                        //itsMinervaWoah.BackColor = Color.Transparent;
                        minervaSay("Wow. Such change. Very adjust. Wow.");
                        minervaResponse.Font = new System.Drawing.Font("Comic Sans MS", 12);
                    }
                    else if (inputText.Equals("do i have anything today?"))
                    {
                        DateTime today = DateTime.Now.Date;
                        if (reminders.ContainsKey(today))
                        {
                            minervaSay("I'm sorry, it wasn't my day to watch out for you. \n \nWhoops, I guess it was. There's \"" + reminders[today] + "\"");
                        }
                        else
                        {
                            minervaSay("You legitimately have nothing to do today. Wow.");
                        }
                    }
                    else if (inputText.StartsWith("what is"))
                    {
                        if (responses.ContainsKey(inputText.Remove(0, 8)))
                        {
                            minervaSay(responses[inputText]);
                        }
                        else
                        {
                            minervaSay("According to the leet haxorz of teh Interwebs, " + parseWikipedia(getWebpage("http://en.m.wikipedia.org/w/index.php?search=" + inputText.Substring(7))));
                        }
                    }
                    else if (inputText.StartsWith("look up"))
                    {
                        minervaSay("According to the leet haxorz of teh Interwebs, " + parseWikipedia(getWebpage("http://en.m.wikipedia.org/w/index.php?search=" + inputText.Substring(7))));
                    }
                    else if (inputText.StartsWith("launch "))
                    {
                        //used to find appdata dir
                        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; //used to get the current user's username
                        //however, this returns the PC-Name + \\username (Ex. vkoves-PC\\vkoves) and has to be cut
                        int temp = userName.IndexOf('\\');
                        userName = userName.Substring(temp + 1);

                        string location = ""; //use to hold location of the program
                        if (inputText.Substring(7).Equals("notepad"))
                        {
                            System.Diagnostics.Process.Start("notepad.exe"); //recognized by default
                        }
                        else if (inputText.Substring(7).Equals("spotify"))
                        {

                            location = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Spotify\\spotifyLauncher.exe";
                            try
                            {
                                System.Diagnostics.Process.Start(location);
                            }
                            catch (Exception ex)
                            {
                                minervaSay("How do you even live? Spotify is not even here.");
                            }
                        }
                        else if (inputText.Substring(7).Equals("chrome"))
                        {
                            location = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
                            try
                            {
                                System.Diagnostics.Process.Start(location);
                            }
                            catch (Exception ex)
                            {
                                minervaSay("I can't find Chrome. I swear, if you so much as hover over Internet Explorer...");
                            }
                        }

                    }
                    else
                    {
                        //what happens when the user says something not preprogrammed, which may or
                        //may nogt be in memory
                        if (responses.ContainsKey(inputText))
                        {
                            minervaSay(responses[inputText]);
                        }
                        else
                        {
                            noteResponse = true;
                            respondingTo = inputText;
                            minervaSay("What are you even talking about? Seriously, tell me what I should say to \"" + inputText + "\"" + ".");
                        }
                    }
                } //end note response else
            } //end console command else
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                //mi.Invoke(notifyIcon1, null);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToString().Equals("Exit"))
            {
                Application.Exit();
            }
            else if (e.ClickedItem.ToString().Equals("About"))
            {
                minervaSay("I am Minerva, hear me roar.");
            }
        }

        private void FullScreenButWhy_Shown(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            if (reminders.ContainsKey(today))
            {
                minervaSay("You again, " + Properties.Settings.Default.name + "? Darn it. \n \nWell, while I have you here, I might as well let you know that there is \"" + reminders[today] + "\"");
            }
            else
            {
                minervaSay("You again, " + Properties.Settings.Default.name + "? \n \nDarn it. You don't even have anything scheduled today, so what do you want?");
            }
        }

        private void FullScreenButWhy_Load(object sender, EventArgs e)
        {
            // WAT
            DateTime today = DateTime.Now.Date;
            if (reminders.ContainsKey(today))
            {
                minervaSay("You again, " + Properties.Settings.Default.name + "? Darn it. \n \nWell, while I have you here, I might as well let you know that there is \"" + reminders[today] + "\"");
            }
            else
            {
                minervaSay("You again, " + Properties.Settings.Default.name + "? \n \nDarn it. You don't even have anything scheduled today, so what do you want?");
            }
        }

        private void linkToSomewhereYouSillyJoven_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(urlToGoTo);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        


       
    }
}
