using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TatenkoNajlepsi
{

   public class Word {
      public string lang1 { get; set; }
      public string lang2 { get; set; }

      public Word(string l1, string l2) {
         lang1 = l1;
         lang2 = l2;
      }
   }

   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private string LANGUAGE1 = ConfigurationManager.AppSettings["LANGUAGE1"].ToString();
      private string LANGUAGE1_ABBR = ConfigurationManager.AppSettings["LANGUAGE1_ABBR"].ToString();
      private string LANGUAGE2 = ConfigurationManager.AppSettings["LANGUAGE2"].ToString();
      private string LANGUAGE2_ABBR = ConfigurationManager.AppSettings["LANGUAGE2_ABBR"].ToString();
      private string SUCCESS_TEXT = ConfigurationManager.AppSettings["SUCCESS_TEXT"].ToString();
      private string MISTAKE_TEXT = ConfigurationManager.AppSettings["MISTAKE_TEXT"].ToString();
      private int DELAY = Int32.Parse(ConfigurationManager.AppSettings["DELAY"].ToString());
      private string DICTIONARY_FILE = @ConfigurationManager.AppSettings["DICTIONARY_FILE"].ToString();

      private bool isInitialized = false;
      private List<Word> wordsDictionary;
      private Word currentWord;
      private Random wordRandomizer;

      public MainWindow()
      {
         InitializeComponent();
         // label initialization according to config file
         RadioButton1.Content = LANGUAGE1_ABBR + "/" + LANGUAGE2_ABBR;
         RadioButton2.Content = LANGUAGE2_ABBR + "/" + LANGUAGE1_ABBR;
         PrimaryLanguageLabel.Content = LANGUAGE1 + ":";
         SecondaryLanguageLabel.Content = LANGUAGE2 + ":";

         //add word form
         AddWordLang1Label.Content = LANGUAGE1 + ":";
         AddWordLang1Labe2.Content = LANGUAGE2 + ":";

         //read dictionary words from file
         wordsDictionary = new List<Word>();
         foreach (var line in File.ReadLines(DICTIONARY_FILE))
         {
            if (!String.IsNullOrWhiteSpace(line)) {
               wordsDictionary.Add(new Word(line.Split(',')[0], line.Split(',')[1]));
            }
         }
         this.DictionaryDataGrid.ItemsSource = wordsDictionary;
         this.wordRandomizer = new Random();
         this.spinNextWord();

         this.header1.Header = LANGUAGE1;
         this.header2.Header = LANGUAGE2;
         this.isInitialized = true;
      }

      private void NewWord_EN_TextChanged(object sender, EventArgs e) {
         enableAddButton();
      }

      private void NewWord_SK_TextChanged(object sender, EventArgs e)
      {
         enableAddButton();
      }

      private void enableAddButton() {
         AddWordButton.IsEnabled = isAddNewWordFormFilled();
      }

      private bool isAddNewWordFormFilled() {
         return NewWord_EN.Text.Length > 0 && NewWord_SK.Text.Length > 0;
      }

      private void AddWordButton_Click(object sender, RoutedEventArgs e) {
         addNewWord();
      }

      private void NextButton_Click(object sender, RoutedEventArgs e) {
         GuessTextBox.Clear();
         spinNextWord();
      }

      private void ShowButton_Click(object sender, RoutedEventArgs e)
      {
         GuessTextBox.Clear();
         GuessTextBox.Text = getCurrentSolution();
         delayedCleanupAndNewWord();
      }

      private void CheckButton_Click(object sender, RoutedEventArgs e)
      {
         checkUserSolutionLogic();
      }

      private void GuessTextBox_KeyDown(Object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter)
         {
            checkUserSolutionLogic();
         }
      }

      private void NewWordTextbox_KeyDown(Object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter)
         {
            addNewWord();
         }
      }

      private void addNewWord() {
         if (!String.IsNullOrWhiteSpace(NewWord_EN.Text) && !String.IsNullOrWhiteSpace(NewWord_SK.Text)) {
            // whoever is complaining about this, fuckoff, I know it's not effective to always open the file..have no time for proper way ATM
            using (StreamWriter sw = File.AppendText(DICTIONARY_FILE))
            {
               sw.Write(NewWord_SK.Text + ',' + NewWord_EN.Text);
               sw.WriteLine();
            }
            wordsDictionary.Add(new Word(NewWord_EN.Text, NewWord_SK.Text));
            DictionaryDataGrid.Items.Refresh();

            NewWord_EN.Clear();
            NewWord_SK.Clear();
            // no need to disable button as it gets disabled by onChange event handlers of the textboxes
         }
      }

      private async void checkUserSolutionLogic() {
         ResultLabel.Visibility = Visibility.Visible;
         if (String.Equals(GuessTextBox.Text, this.getCurrentSolution(), StringComparison.OrdinalIgnoreCase))
         {
            ResultLabel.Foreground = Brushes.Green;
            ResultLabel.Content = SUCCESS_TEXT;
            delayedCleanupAndNewWord();
         }
         else
         {
            ResultLabel.Foreground = Brushes.Red;
            ResultLabel.Content = MISTAKE_TEXT;
            if (TryAgainAfterMistake.IsChecked ?? false)
            {
               await Task.Delay(DELAY);
               ResultLabel.Visibility = Visibility.Hidden;
            }
            else
            {
               delayedCleanupAndNewWord();
            }
         }
      }

      private async void delayedCleanupAndNewWord()
      {
         await Task.Delay(DELAY);
         GuessTextBox.Clear();
         ResultLabel.Visibility = Visibility.Hidden;
         this.spinNextWord();
      }

      private void RadioButton1_CheckedChanged(object sender, RoutedEventArgs e)
      {
         // labels are null during initialization
         if (this.isInitialized)
         {
            if (RadioButton1.IsChecked ?? false)
            {
               PrimaryLanguageLabel.Content = LANGUAGE1 + ":";
               SecondaryLanguageLabel.Content = LANGUAGE2 + ":";
            }
            else {
               PrimaryLanguageLabel.Content = LANGUAGE2 + ":";
               SecondaryLanguageLabel.Content = LANGUAGE1 + ":";
            }
            // set new word when mode has changed
            GuessTextBox.Clear();
            spinNextWord();
         }
      }

      private Word getRandomWord() {
         int randomIndex = this.wordRandomizer.Next(wordsDictionary.Count);
         if (wordsDictionary.Count() == 0) {
            return new Word("","");
         } 
         return wordsDictionary[randomIndex];
      }

      private void spinNextWord() {
         currentWord = getRandomWord();
         PrimaryLanguageText.Text = getCurrentTask();
      }

      private string getCurrentSolution() {
         if (RadioButton1.IsChecked ?? false)
         {
            return currentWord.lang2;
         }
         else
         {
            return currentWord.lang1;
         }
      }

      private string getCurrentTask()
      {
         if (RadioButton1.IsChecked ?? false)
         {
            return currentWord.lang1;
         }
         else
         {
            return currentWord.lang2;
         }
      }
   }
}
