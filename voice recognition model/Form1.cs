using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace voice_recognition_model
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices(new string[] { "hey", "hello computer","how are you doing" , "browser" , "anghami" });

        public Form1()
        {
            InitializeComponent();

            Grammar gr = new Grammar(new GrammarBuilder(clist));
            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }


        void sre_SpeechRecognized(object sender, RecognitionEventArgs e)
        {
            switch(e.Result.Text.ToString())
            {
                case "hey": ss.SpeakAsync("hello"); break;
                case "hello computer": ss.SpeakAsync("hello sir");break;
                case "how are you doing": ss.SpeakAsync("fine sir , thank you");break;
                case "browser": ss.SpeakAsync("yes sir , openning browser"); System.Diagnostics.Process.Start("microsoft-edge:http://www.google.com"); break;
                case "anghami": ss.SpeakAsync("yes sir , openning anghami"); System.Diagnostics.Process.Start("C:\\Users\\ShadyAbdelaziz\\AppData\\Local\\anghami\\Anghami.exe"); break;

            }
            textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;

        }


    }
}


