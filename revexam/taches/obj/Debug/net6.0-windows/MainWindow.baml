   M S B A M L   `   `   `  ����A  =taches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:tachestaches  5          taches.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:taches     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��800��5	      $	��450��5
      .��5      � $��0,10,0,0q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $��
0,0,28,341q�5      ��5      �� �� 5   
   -   5         ��Name$ Description��5      $��21,138,400,247q�5      $��Description :��5      �� 5   
   -   5         ��Name$ description��5      $��120,138,34.4,278.8q�5      ��5      ��  �� ElementName$ datagrid�� �� Path$ SelectedItem.Description��� 5   
   $��1,173,355,185q�6   $��Priorité :��6'   �� 5   
   -   5         ��Name$ combox��5      $��104,182,527,197q�5       ��5!      ��  �� SelectedItem 5"      �� $ datagrid��$ SelectedItem.Priorite��� 5#   
   $��1,232,255,123q�6   $��
Echeance :��6'   (  "System.Windows.Controls.DatePicker  5$   
   -   5          Name$ 
datepicker��5%      $��134,239,409,137q�5&      	   SelectedDate	 5'      �� $ datagrid��$ SelectedItem.Date��� 5(   
   $��1,301,255,54q�6   $��Terminé ? :��6&   �� 5)   
   -   5        
 ��Name$
 termine��5*      $��82,306,414,70q�5+       d� 	IsChecked 5,      �� $ datagrid��$ SelectedItem.Termine��� 5-   
   -   5        $��303,354,303,13q�5-      .��6G   	Supprimer6R   �� 5.   
   -   5        $��57,349,549,18q�5.      .��6D   	Ajouter6M   �� 5/   
   -	   5        $��545,354,61,13q�5/      .��6B   Vider6I   50      51      