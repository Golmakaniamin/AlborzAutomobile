   M S B A M L   `   `   `  ����  AlborzAutomobile#    AlborzAutomobile.AllCustomers   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  لیست مشتریان��5   	   $	��600��6   $	��800��6+   $��RightToLeft=�6N    � WindowStartupLocation$ CenterScreen=�6j   
������� � 	Resources 5      ��%    5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5
   D      AutoGenerateColumns .  $��12,47,12,12q�6/   $��RightToLeft=�6z      AlternatingRowBackground
 �������6U   ��  �� Path$ infomen���6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ردیف��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6P   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $	 rad�6[     5      $ کد شعبه��6F   $	 100 6W   	 . 
 6%   �� $ idshobe�6c     5      $ شماره مشتری��6D   $	 100 6Y   	 . 
 6%   �� $ idmen�6e     5      $ نام��6C   $	 100 6P   	 . 
 6%   �� $
 name�6\     5      $ نام خانوادگی��6E   $	 100 6[   	 . 
 6%   �� $ family�6g     5      $ نام پدر��6I   $	 100 6Z   	 . 
 6%   �� $ 
fathername�6f     5      $! شماره شناسنامه��6C   $	 100 6[   	 . 
 6%   �� $
 shsh�6g     5      $ کد ملی��6A   $	 100 6Q   	 . 
 6%   �� $ id�6]     5      $ تلفن همراه��6E   $	 100 6Y   	 . 
 6%   �� $ mobile�6e     5      $ تلفن منزل��6D   $	 100 6W   	 . 
 6%   �� $ phone�6c     5      $ تلفن محل کار��6H   $	 100 6^   	 . 
 6%   �� $ 	phonework�6j   5      �� 5   
   -   5        $��label1��5   k   $��SELECT * FROM infomen��6   $��28��60   $
��Left=�6<   $��
758,47,0,0q�6W   $	��Top=�6y   $y�Hidden=�6�   $��20��6�   o� 5   
   -   5        $��menu1��5      $��25��6   $	��Top=�6(   $��12(�6@   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 0Q�61   � 5      $ 	#FFBFDBFF��6#   $ 1Q�65   5      .@�5!      m� -   5        $��
جستجو��5!      6&   m� 5"      -   5        $��جدید��5"      6%   m� 5#      -   5        $��ویرایش��5#      6'   m� 5$      -   5        $��حذف��5$      6$   m� 5%      -	   5        $��چاپ��5%      6$   m� 5&      $��-��6   m� 5'      -
   5        $��mnu18��5'   1   $#��خرید و فروش نقدی��6   6>   m� 5(      -   5        $��mnu22��5(   1   $#��فروش نقد و اقساط��6   6>   m� 5)      -   5        $
��mnu4��5)   3   $'��!اجاره به شرط تملیک��6   6?   m� 5*      -   5        $
��mnu3��5*   '   $��فرسوده��6   63   5,      5-      5.      