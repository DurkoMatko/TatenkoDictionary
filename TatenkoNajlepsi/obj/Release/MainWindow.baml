   M S B A M L   `   `   `  ���� J  FTatenkoNajlepsi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TatenkoNajlepsiTatenkoNajlepsi       TatenkoNajlepsi.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:TatenkoNajlepsi       � 
ResizeMode$  NoResize=� � Title$? 9Tatenko najlepsi najmilovanejsi, the best English speaker��$	��692��$	��961��.��� .+��� $
��Left=�$	��662��$	��Top=�$	��953��.@��� $��Exercise��.��� ���	#FFE5E5E5$��
-5,-4,0,-4q� � ColumnDefinitions �� $	��31* ��� $
��285* �.+��� $��Mode:��$
��Left=�$��	31,19,0,0q�$	��Top=�$
��Bold"�	� -   $��RadioButton1��$��SK/EN��$
��Left=�$��5.667,24,0,0q�$	��Top=� 	� 	GroupName$ ExerciseMode�� d� 	IsChecked$
 TrueY�$��1��	� -   $��RadioButton2��$��EN/SK��$
��Left=�$��65.667,24,0,0q�$	��Top=�$ ExerciseMode��$ FalseY�$��1���� $��2���� $��Stretch=�
���   �$��1��$��
0,52,0,584q�$��2���� -   $��PrimaryLanguageLabel��$��Slovak:��$
��Left=�$��	42,87,0,0q�$	��Top=��� -   $��SecondaryLanguageLabel��$��English:��$
��Left=�$��
42,344,0,0q�$	��Top=� J� RenderTransformOrigin$ 
0.16,0.474&��� $
��Left=�$��
74,109,0,0q�$	��Top=�$��70(�$	��211��$	��806��$��2������ -   $��PrimaryLanguageText�� �� TextWrapping$
 Wrap=�$��WORDICLKOIUS���� -   $��GuessTextBox��$
��Left=�$��59��$��
74,392,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��787��$��36(�$��2���� -   $��
NextButton��$
��Next��$
��Left=�$��
10,500,0,0q�$	��Top=�$	��105��$��45��$��1���� -   $��
ShowButton��$
��Show��$
��Left=�$��137,500,0,0q�$	��Top=�$	��105��$��45��$��1���� -	   $��CheckButton��$��Check��$
��Left=�$��264,500,0,0q�$	��Top=�$	��105��$��45��$��1���� -
   $��ResultLabel��$��Correct!��$y�Hidden=�
��� � �$��1��$
��Left=�$��494,462,0,0q�$	��Top=�$
��Bold"�$��72(�$	��293���� -   $��TryAgainAfterMistake��$��Try again after mistake��$��1��$
��Left=�$��
207,24,0,0q�$	��Top=�$
 TrueY��� $��
Dictionary��$��23��$	��Top=�.��� ���	#FFE5E5E5$��
-13,0,4,-5q� �� $
��169* ��� $
��783* �.+�&   System.Windows.Controls.DataGrid  -     Name$ DictionaryDataGrid��$
��Left=�$��	46,66,0,0q�$	��Top=�$	��506��$	��549��	   AutoGenerateColumns	 .  $��2������ *wordsDictionary+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  -   header1��,  &System.Windows.Controls.DataGridColumn   Header$	 Key��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 274 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *lang1+  -   header2��$ Value��$	 275  �� *lang2+�� -   $��AddWordButton��$
��Add!��$
��Left=�$��653.469,188,0,0q�$	��Top=�$��75��{�.  $��1���� $��Tatenko's dictionary��$
��Left=�$��	53,19,0,0q�$	��Top=�$
��Bold"�$��24(�$��2���� $��Add new word
��$
��Left=�$��470.469,84,0,0q�$	��Top=�$��26��$
��Bold"�$��1���� -   $��AddWordLang1Label��$��English:��$
��Left=�$��480.469,121,0,0q�$	��Top=�$��1���� -   $��AddWordLang1Labe2��$��Slovak:��$
��Left=�$��480.469,147,0,0q�$	��Top=�$��1���� -   $��
NewWord_EN��$
��Left=�$��23��$��544.469,124,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��184��$��1���� -   $��
NewWord_SK��$
��Left=�$��23��$��544.469,150,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��184��$��1���� 
���   �$��1q�$
��Left=�$	��168��$��444.469,69,0,0q�$	��Top=�$	��312��$��1���� $��
Statistics��.��� ���	#FFE5E5E5$��
-13,0,4,-5q� �� $	��23* ��� $
��215* �.+��� $��Estimate: 2 hours��$
��Left=�$��280.188,107,0,0q�$	��Top=�$
��Bold"�$��24(�$��1���� $��Price: 15 Euro/hour��$
��Left=�$��265.188,157,0,0q�$	��Top=�$
��Bold"�$��24(�$��1���� $��(Nech nezerem)��$
��Left=�$��489.188,157,0,0q�$	��Top=�$��24(�$��1���� $$��Order 'Statistics' plugin now!��$
��Left=�$��218.188,205,0,0q�$	��Top=�$	��348��$	��143��$
��Bold"�$��18(�$��1���� $$��(Payment in Bitcoin possible!)��$
��Left=�$��296.188,351,0,0q�$	��Top=�$
��Bold"�$��1���� $
��Left=�$	��635��$��10,0,0,0q�$	��Top=�$	��942��$)��#pack://application:,,,/Capture.jpeg��$��2��