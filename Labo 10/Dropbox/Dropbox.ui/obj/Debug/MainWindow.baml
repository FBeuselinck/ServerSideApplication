   M S B A M L   `   `   `  ����E  ADropbox.ui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Dropbox.ui
Dropbox.ui  5   	       Dropbox.ui.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &vclr-namespace:Dropbox.ui     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��710��6)    � DataContext 5         Dropbox.ui.Webaccess  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��150 �6   �� 5      $	��150 �6   �� 5      $	��150 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��100 �6   .+�5   
   �� $��	Username:��6   $��5q�6%   $��0��60   $��0��6=   �� 5   
   $��5q�6   $��0��6   $��1��6*   ��6:   �� *
UserName+�� 5   
   $��	Password:��6   $��5q�6%   $��0��60   $��2��6=   �� 5   
   $��5q�6   $��0��6   $��3��6*   ��6:   �� *
Password+�� 5    
   $��Login��6   $��5q�6!   $��0��6,   $��4��69   ��6I   �� *InlogCommand+�� 5!   
   $
��Load��6   $��5q�6    $��0��6+   $��5��68   &   System.Windows.Controls.DataGrid  5"   
   $��1��6   $��0��6    $��6��60   ��6D   �� *	LijstLogs+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *FileId+6L     5%      $ FileNaam��6%   $	 200 6U    67   �� *
FileName+6U     5&      $ DateTime��6%   $	 200 6Q    67   �� *Date+6Q     5'      $ UserName��6%   $	 250 6U    67   �� *
UserName+6U   5)      5*      5+      