   M S B A M L   `   `   `  ����K  G6 практос, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:_6_практос_6_практос  5   	   #    _6_практос.chat_window   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:_6_практос     5   	     � Title$  chat_window��5   	   $	��400��6   $	��300��6-   $	��400��6<   $	��300��6L   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��283* �6   �� 5      $
��101* �6   .+�5   
   �� -   5        $��1��5      $��Отправить��6!   $��Stretch=�65   $��1��6S   $��Stretch=�6`   6|   �� 5   
   -   5        $��Message��5      $��1��6!    �� TextWrapping$
 Wrap=�6.   $�� ��6B   $��25(�6J   $��0q�6X   �� 5   
   -   5         ��Name$ ListBox��5      $��2��6N   $��0��6b   5      5      