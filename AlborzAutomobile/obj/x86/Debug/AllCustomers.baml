   M S B A M L   `   `   `  ����  AlborzAutomobile#    AlborzAutomobile.AllCustomers   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  لیست مشتریان��5   	   $	��600��6   $	��800��6+   $��RightToLeft=�6N   .��5      � .+�5   
   �� -   5        $��button1��5   [   $��جدید��6   $��30��6    $
��Left=�6,   $��
212,12,0,0q�6G   $	��Top=�6j   $	��120��6�   6�   a� 5   
   -   5        $��toolBarPanel1��5   >   $��26��6   $
��Left=�6#   $	��Top=�6S   $	��206��6k   .+�5      c� -   5        $��toolBar1��5   "   $��26��6   $	��200��62   ��6>   �� 5	      �� 5
   
   -   5        $��button2��5
   L   $��30��6   $
��Left=�6   $��
338,12,0,0q�68   $	��Top=�6[   $	��120��6s   $��ویرایش��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dataGrid1��5   ^      AutoGenerateColumns .  $
��Left=�6/   $��
12,48,0,12q�6J   $	��754��6o   $��RightToLeft=�6�   ��6{   ��  �� Path$ infomen�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ کد شعبه��6F      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6W      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ idshobe�6c     5      $ شماره مشتری��6D   $	 100 6Y    .  6%   �� $ idmen�6e     5      $ نام��6C   $	 100 6P    .  6%   �� $
 name�6\     5      $ نام خانوادگی��6E   $	 100 6[    .  6%   �� $ family�6g     5      $ نام پدر��6I   $	 100 6Z    .  6%   �� $ 
fathername�6f     5      $! شماره شناسنامه��6C   $	 100 6[    .  6%   �� $
 shsh�6g     5      $ کد ملی��6A   $	 100 6Q    .  6%   �� $ id�6]   5      �� 5   
   -   5        $��button3��5   Z   $��حذف��6   $��30��6   $
��Left=�6+   $��
464,12,0,0q�6F   $	��Top=�6i   $	��120��6�   6�   �� 5   
   -   5        $��button4��5   \   $��
جستجو��6   $��30��6!   $
��Left=�6-   $��
590,12,0,0q�6H   $	��Top=�6k   $	��120��6�   6�   �� 5   
   -	   5        $��label1��5   k   $��SELECT * FROM infomen��6   $��28��60   $
��Left=�6<   $��
716,12,0,0q�6W   $	��Top=�6y   $y�Hidden=�6�   $��20��6�   5      5      