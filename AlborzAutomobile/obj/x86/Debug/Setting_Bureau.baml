   M S B A M L   `   `   `  ����  AlborzAutomobile%    AlborzAutomobile.Setting_Bureau   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Setting_Bureau��5   	   $	��300��6    $	��600��6-   $��RightToLeft=�69    � WindowStartupLocation$ CenterScreen=�6U   ���	#FFADD9FF � 	Resources 5         DataGridStyle1 �� 
TargetType&   System.Windows.Controls.DataGrid �� Property  ColumnHeaderStyle1 �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� EndPoint �� 
StartPoint � Color	 � Offset
 �� Triggers P� Property P� Value��%  &	        &	 X     �� 5   
   "  6'   .�5      ��  �@ ColumnHeaderStyle# �  62   5      �� 5
   
   "  6+   .�5      ��  � ��$ 30��6'   �� 5       � �� 5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5      � $ 	LightBlue��6'   $	 0Q�69   � 5      $ 	SteelBlue��6'   $	 1Q�69   5      5      �� 5       � ��
 �   �6+   
 5      P� 5       �@J�IsMouseOver . . �5      ��  �@�ToolTip$ Click to sort.��60   5      5      5      .��5      � .+�5   
     -   5        $��	dataGrid1��5   �      AutoGenerateColumns .  $��RightToLeft=�6/   $��10,10,12,49q�6o   $y�Visible=�6�      AlternatingRowBackground
 �����#���   6�   ��6K   ��  �� Path$ Daftar���6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ کد دفتر خانه��6B      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $	 rad�6X     5       $ نام دفتر خانه��6I    .   6%   �� $ 
namemarkaz�6`     5!      $" نشانی دفتر خانه��6E    .   6%   �� $ adress�6^   5#      �� 5$   
   -   5        $��button6��5$   R   $��ثبت��6   
�������$��31��62   $��
10,0,12,12q�6>   $��Bottom=�6a   ��5%      �� 5&      $ 0.5,1&�6&   $ 0.5,0&�67   .��5'      � $ 	#FF005DFF��6#   $	 0Q�65   � 5(      $ 	#FF000064��6#   $	 1Q�65   5)      5+      5,      5-      