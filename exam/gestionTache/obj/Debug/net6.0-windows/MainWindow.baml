   M S B A M L   `   `   `  ����G  CgestionTache, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:gestionTachegestionTache  5          gestionTache.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:gestionTache     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��800��5	      $	��450��5
      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ taches��5      $��
0,10,0,318q�5      ��5      �� �� 5   
   $��0,116,10,244q�6   $��Description : ��6&   �� 5   
   -   5         ��Name$ description��5      $��84,131,337,259q�5      ��5      ��  �� ElementName$ taches�� �� Path$ SelectedItem.Description��� 5   
   $��4,190,92,198q�6   $��Priorite : ��6&   �� 5   
   -   5         ��Name$ PrioriteValeur��5      $	��120��5      $��
84,201,0,0q�5      $
��Left=�5      $	��Top=�5       J� RenderTransformOrigin$ 0.633,1.186&�5      ��5      ��  �� SelectedItem 5      �� $ taches��$ SelectedItem.Priorite��� 5    
   $��4,241,10,116q�6   $��Echeance : ��6&   (  "System.Windows.Controls.DatePicker  5!   
   -   5          Name$ 
datePicker��5"      $��84,248,503,132q�5#      	   SelectedDate	 5$      �� $ taches��$ SelectedItem.Date��� 5%   
   $��2,323,34,56q�6   $��Terminé ? : ��6%   �� 5&   
   -   5        
 ��Name$
 TermineValeur��5'      $��97,328,556,60q�5(       d� 	IsChecked 5)      �� $ taches��$ SelectedItem.Termine��� 5*   
   -   5        $��134,362,503,10q�5+      $��Ajouter��5-      $ 0.465,-0.414&�5.      �� 5/   
   -   5        $��356,362,281,10q�50      $��	Supprimer��52      $ 0.465,-0.414&�53      �� 54   
   -   5        $��570,362,67,10q�55      $��Vider��57      $ 0.465,-0.414&�58      59      5:      