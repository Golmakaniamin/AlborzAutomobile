   M S B A M L   `   `   `  ����  AlborzAutomobile0    *AlborzAutomobile.Setting_Dismantled_Center   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Setting_Dismantled_Center��5   	   $	��300��6+   $	��600��68    � WindowStartupLocation$ CenterScreen=�6D   $��RightToLeft=�6i   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5   �      AutoGenerateColumns .  $��RightToLeft=�6/   $��10,12,12,47q�6p   ��6K   ��  �� Path$ parking�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ کد مرکز اسقاط��6B      
IsReadOnly .     Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $	 rad�6l     5	      $  نام مرکز اسقاط��6I    .  $	 100 6t    6%   �� $ 
namemarkaz�6t     5
      $$ نشانی مرکز اسقاط��6E    .  $	 400 6r    6%   �� $ adress�6r   5      �� 5   
   -   5        $��button6��5   R   $��ثبت��6   
�������$��31��62   $��
10,0,12,10q�6>   $��Bottom=�6a   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67   .��5      �  � Color$ 	#FFFF00D8��6#    � Offset$ 0Q�65   � 5      $ Black��6#   $ 1Q�61   5      5      5      5      