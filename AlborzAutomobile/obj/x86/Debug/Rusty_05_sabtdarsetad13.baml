   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.4436.18228, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   ^    AlborzAutomobile.   (AlborzAutomobile.Rusty_05_sabtdarsetad13   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   SmyDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   ^   -   5          � Title$  Rusty_05_sabtdarsetad13��5   	   $	��260��6)   $	��729��66   $��RightToLeft=�6B   
����·� � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5   �      AutoGenerateColumns .  $��RightToLeft=�6/   $
��Left=�6K   $��	12,12,0,0q�6�   $	��681��6�   $	��121��6�   $	��Top=�6�   ��6f   ��  �� Path$ parking�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ کد مرکز��6B      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $	 rad�6e     5	      $ نام مرکز��6I    . $	 100 6m    6%   �� $ 
namemarkaz�6m     5
      $ نشانی مرکز��6E    . $	 400 6k    6%   �� $ adress�6k   5      1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5        $��persianDatePicker1��5   [   $��29��6   $
��Left=�6+   $��127,143,0,0q�6F   $	��Top=�6u   $	��120��6�   $��Tahoma)�6�   6�   �� 5   
   -   5        $��textBox1��5   b   $��Tahoma)�6   $��29��6&   $
��Left=�62   $��350,143,0,0q�6M   	 �� TextAlignment$
	 Left=�6r   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $��label2��5   �   $��کد مرکز اسقاط��6   $��Tahoma)�6(   $��11(�6<   $��29��6J   $
��Left=�6V   $��253,143,0,0q�6q   $	��Top=�6�   $��91��6�   ���	#FF8142A26�   �� 5   
   -   5        $��label3��5   �   $��تاریخ ثبت نام��6   $��Tahoma)�6(   $��11(�6<   $��29��6J   $
��Left=�6V   $��
30,143,0,0q�6q   $	��Top=�6�   $��91��6�   ���	#FF8142A26�   �� 5   
   -   5        $��button1��5   [   $��ثبت��6   $��29��6   $
��Left=�6+   $��598,180,0,0q�6F   $	��Top=�6j   $��97��6�   6�   �� 5   
   -   5        $��button2��5   \   $��خروج��6   $��29��6    $
��Left=�6,   $��495,180,0,0q�6G   $	��Top=�6k   $��97��6�   6�   �� 5   
   -	   5        $��textBox2��5   b   $��Tahoma)�6   $��29��6&   $
��Left=�62   $��573,143,0,0q�6M   $
	 Left=�6r   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -
   5        $��label1��5   �   $��کد رهگیری��6   $��Tahoma)�6$   $��11(�68   $��29��6F   $
��Left=�6R   $��476,143,0,0q�6m   $	��Top=�6�   $��91��6�   ���	#FF8142A26�   5      5      