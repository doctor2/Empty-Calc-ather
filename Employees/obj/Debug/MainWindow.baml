   M S B A M L   `   `   `  ����D  @Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Employees	Employees  5   	       Employees.MainWindow   5   	   !localclr-namespace:Employees  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��558��6,    � Icon$ Resources/database.ico��5   	    � 	Resources 5         TrayMenu  Open �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value 	 Close��%�  &	        &	 �     &	 �    �� 5
      .@�5      m� -   5        $��Спрятать��5      6-   �� 5      m� 5      -   5        $��
Выход��5      6*   5      �� 5      .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 
newControl��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $	 230Q�69   5      5      �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 
newControl��6�   .\�5        $ 0��6'   $	 230Q�63     5      $ 0:0:0.5��6'   $ 1Q�69   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ ToggleButton.Checked��6   	 :� 
SourceName$	 
newControl��6:   .[�5      �� #��[ 6   5       :� 5!   
   $ ToggleButton.Unchecked��6   $	 
newControl��6<   .[�5"      �� -   5        
 ��Name$
 Close_BeginStoryboard��5"      #��[ 6=   5#      .��5&      � -   5        $
��main��5&   B     BackgroundWindowResource#��[ 6    � RowDefinitions 5'   
   �� 5(      $
��Auto �6   6,   �� 5)      $��* �6   6)   �� 5*      $
��Auto �6   6,   .+�5,   
   o� .@�5-      m� $
��File��6   .@�5.      m� $	��New��6   6*   m� 5/      $
��Open��6   6+   m� 50      $
��Save��6   6+   �� 51      6   m� 52      $
��Exit��6   6+   53      54      � 55   
   $��1��6   .+�56      �� $	��150��6    �� Orientation$ 
Horizontal=�6(   $	��Top=�6A    K� ZIndex$ 2��6Y   .+�57         Employees.UserCont  -   5          Name$ 
newControl��57   !   $��
-230,0,0,0q�65   z�58      V� 59      .~�5:      �� �� 5;      �� 5<      T� 5=      5>      5@      �� 5A      $��Stretch=�6   $	��100��6=   5B      �� 5C      $��0,0,0,55q�6   $ 1��6,   .+�5D      &   System.Windows.Controls.DataGrid  -   5          Name$ 	Employeer��5D      $��29,30,70,60q�60   $ 2��6E      RowBackground �	#FFE6D3EF   AlternatingRowBackground �	#FC96CFD4���	#FF1F33EB$��3q�5F         AutoGenerateColumns .     CanUserAddRows .    
IsReadOnly .  ��6/   ��  �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50* 6-      Header$ ФИО��6Q      
FontWeight$
 Bold"�6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *FIO+6^     5J      $	 60* 6-   $ Должность��6W    69   �� *
TypePost+6W     5K      $	 70* 6-   $ 
Отдел��6X    69   �� *
Department+6X     5L      $
 100* 6-   $ Тип корочек��6V    6:   �� *	TypeCor+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5V      $ Дата��61   $	 50* 6?      CellTemplate 5W      �� 5X   "   .R�5Y   &   �� ��60   ��  �� Path$ Expiration_date� �� StringFormat$ {0:dd.MM.yyyy}��5Z   #      CellEditingTemplate 5\      �� 5]   "   .R�5^   &   �  +� FocusedElement 6+   ��   �� ElementName$  dateScheduledPicker��.+�5_   *   (	  "System.Windows.Controls.DatePicker	  ! 	 Name$! dateScheduledPicker��65   " 	  SelectedDate" 5`   5   �� $ Expiration_date�# �� Mode$# TwoWay=�$ �� ValidatesOnExceptions$ . % �� NotifyOnValidationError% . 5b   '   5c   #   5e      5g      5i      d� 5j      -   5        $
��Edit��5j      $��	0,20,10,0q�6+   $��5q�6>   $��Right=�5k   ?   $��53��6[   $��41��6f   $	��Top=�6r   5l      5m      �� 5n   
   -	   5        $��	EditPanel��5n      $��2��6'   $ 
Horizontal=�64   $��	369,0,0,0q�6M   .+�5o      �� -
   5        $
��Save��5o      $
��Save��6!   $��35��60   $��60��6<   $��10q�6G   6S   �� 5p      -   5        $��Delete��5p      $��Delete��6#   $��35��64   $��60��6@   $��10q�6K   6W   5q      5r      5s      