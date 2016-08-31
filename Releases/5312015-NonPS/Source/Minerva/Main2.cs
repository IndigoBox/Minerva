/* 
 * Project Minerva, created by Viktor Koves and Robert Altman
 * 
 * Here's some features to add:
 * -Internet stuff
 * -Voice recognition
 * -Add speech back, but use a good voice
 * -Acessing system information (you should be able to get RAM info, CPU clock, that stuff)
 * 
 * 
 **/



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
using SpeechLib;

namespace Minerva
{
    public partial class Main2 : Form
    {
        Dictionary<string, string> responses = new Dictionary<string, string>(); //the dictionary of everything
        
        //songs
        String mediaLib;// = "C:\\Users\\vkoves\\Music\\"; //where the user's media library is
        string[] songs;
        ArrayList songsT = new ArrayList(); //temporarily holds songs

        String inputText = ""; //inputted text
        String respondingTo = ""; //if the user says something Minerva doesn't recognize, this is it
        //this will be used as the key in the dictionary, and the next input will be the value
        Boolean noteResponse = false; //specifies if the next input is a response to the statement resondingTo
        SpVoice speech = new SpVoice();

        public Main2()
        {
            //default stuff
            InitializeComponent();

            //load in the dictionary
            string[] dictIn = System.IO.File.ReadAllLines(@"data.txt");
            if (dictIn != null)
            {
                loadDict(dictIn);
                rTextBox1.AppendText(" Dictionary loaded." + "\r\n");
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose your media folder";
            fbd.ShowDialog();
            mediaLib = fbd.SelectedPath;

            findSongs();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            //if you press the enter button on the gui, call submit
            submit();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //or if you press your enter key on your keyboard, call submit
                submit();
            }
        }

        private void loadDict(String[] input)
        {
            Boolean key = true;
            for(int i = 0; i < input.Length; i++)
            {
                if (key && i+1 < input.Length)
                {
                    responses.Add(input[i], input[i+1]);
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

        /* private String parseWikipedia(String source)
        {
            
        } */

        private void parseCommand(String cmdIn)
        {
            //this parses console commands, and does stuff
            cmdIn = cmdIn.ToLower();
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
                Main2 newmain = new Main2();
                newmain.Show();
                newmain.BringToFront();
                this.Hide();
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
            rTextBox1.AppendText("Minerva: " + input + "\r\n");
        }

        private void submit()
        {
            //speech.Voice = speech.GetVoices("gender=female").Item(1);
            /* This is where all the magic happens. After the user presses enter or the enter key,
             this method is called. Starter functionality: ask for a response to statement's Minerva
             doesn't have a response to. Then there are certain functions that need to be coded in.
             These are:
             
             Math: "what is _ equal to?"
             Dictionary: "what does _ mean?" || "what's the definition of _?"W
             Wikipedia: Use http://en.m.wikipedia.org/w/index.php?search= + search term
             */
            inputText = textBox2.Text;
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
                    rTextBox1.AppendText("Minerva: " + "Response noted." + "\r\n");
                    //speech.Speak("Response Noted");
                    noteResponse = false;
                }
                else
                {
                    inputText = inputText.ToLower();
                    DateTime dt = DateTime.Now;
                    /* Start with the pre-programmed stuff, like math and web searching
                     */
                    if (inputText.Equals("what time is it?"))
                    {
                        minervaSay("It is now " + dt.ToString("t") + ".");
                    }
                    else if (inputText.Equals("what day is it?"))
                    {
                        minervaSay("Today is " + dt.DayOfWeek + ", " + dt.ToString("MMMM dd, yyyy") + ".");
                    }
                    else if (inputText.StartsWith("play ")) //ex: play stairway to heaven
                    {
                        mediaPlayer.URL = getSong(inputText.Substring(5));
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
                    else if (inputText.Equals("fetch"))
                    {
                        minervaSay(getWebpage("http://en.m.wikipedia.org/w/index.php?search=dinosaur"));
                    }
                    else
                    {

                        if (responses.ContainsKey(inputText))
                        {
                            minervaSay(responses[inputText]);
                            //speech.Speak(responses[inputText]);
                        }
                        else
                        {
                            noteResponse = true;
                            respondingTo = inputText;
                            minervaSay("I don't recognize that, please give a normal response to \"" + inputText + "\"");
                            //speech.Speak("I don't recognize that, please give a normal response to, " + inputText);
                        }
                    }
                } //end note response else
            } //end console command else
        }
    }
}
