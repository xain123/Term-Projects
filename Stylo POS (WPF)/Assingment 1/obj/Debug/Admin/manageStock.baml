   M S B A M L   `   `   `  ����G  CAssingment 1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Assingment_1Assingment_1  5   	       Assingment_1.manageStock   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Assingment_1     5   	     � Title$  Manage Stock��5   	   $	��641��6   $
��1080��6,    � 	Resources 5	       
  Color1��%+   &	        ��5
   
   	#FFD6D5D5��6*   5      .��5      � ��5   
   �� 5       �� Color# �   6   .+�5   
   �� -   5         ��Name$ image1��5      $B��<D:\BCS DATA\Samester 6\C Sharp\Assingment 1\pictures\add.ico��6     J� OpacityMask �	#FF8D5252$��0,52,860,412q�6~   �� 5   
   -   5         ��Name$ label2��5      $��ADD YOUR NEW ITEM��6    $
��Left=�6<   $��
217,88,0,0q�6W   $	��Top=�6k   $	��640��6�   $��48(�6�   $��Black"�6�   $��SketchFlow Print)�6�   $��68��6�   �� 5   
   
���   �$��2q�6%   $
��Left=�69   $	��306��6T   $��
10,224,0,0q�6a   $	��Top=�6u   $
��1022��6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      5      �� 5   
   -   5        $ l1��5      $��
PRODUCT ID��6   $
��Left=�61   $��
52,246,0,0q�6L   $	��Top=�6`   $��20(�6x   $��Black"�6�   $��Times New Roman)�6�   $	��146��6�   �� 5   
   -   5        $ l2��5      $��CATEGORY��6   $
��Left=�6/   $��
52,384,0,0q�6J   $	��Top=�6^   $��20(�6v   $��Black"�6�   $��Times New Roman)�6�   $	��130��6�   �� 5   
   -   5        $ l4��5      $
��DATE��6   $
��Left=�6+   $��491,384,0,0q�6F   $	��Top=�6[   $��20(�6s   $��Black"�6�   $��Times New Roman)�6�   $	��117��6�   �� 5   
   -   5        $ l5��5      $��BRAND��6   $
��Left=�6,   $��491,321,0,0q�6G   $	��Top=�6\   $��20(�6t   $��Black"�6�   $��Times New Roman)�6�   $	��117��6�   �� 5   
   -   5        $ l6��5      $��COLOR��6   $
��Left=�6,   $��491,249,0,0q�6G   $	��Top=�6\   $��20(�6t   $��Black"�6�   $��Times New Roman)�6�   $��99��6�   �� 5    
   -   5        $ l7��5       $��
PRICE (RS)��6   $
��Left=�61   $��
52,321,0,0q�6L   $	��Top=�6`   $��20(�6x   $��Black"�6�   $��Times New Roman)�6�   $	��117��6�   �� 5!   
   -	   5        $ l8��5!      $
��SIZE��6   $
��Left=�6+   $��
52,448,0,0q�6F   $	��Top=�6Z   $��20(�6r   $��Black"�6�   $��Times New Roman)�6�   $	��117��6�   �� 5$   
   -
   5         ��Name$	 pid��5$      $
��Left=�6_   $��36��6z   $��240,246,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��216��6�   $��20(�6�   	 J� RenderTransformOrigin$	 0.196,0.554&�6�   
�������6  �� 5%   
   -   5        $ price��5%      $
��Left=�6g   $��36��6�   $��240,318,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��216��6�   $��20(�6�   (  "System.Windows.Controls.DatePicker  50   
   -   5        $��	entryDate��50      $
��Left=�6&   $��631,384,0,0q�6A   $	��Top=�6V   $	��216��6n   $��36��6z   $��20(�6�   {�.  6�   �� 52   
   -   5        
 ��Name$
 add_btn��52      $��ADD ITEM��6"   $
��Left=�65   $��869,474,0,0q�6P   $	��Top=�6e   $	��141��6}   $��42��6�   $��20(�6�   $
��Bold"�6�   $��Times New Roman)�6�   6�   �� 53   
   -   5        $
 back_btn��53      $
��BACK��6#   $
��Left=�62   $��888,103,0,0q�6M   $	��Top=�6b   $	��141��6z   $��42��6�   $��20(�6�   $
��Bold"�6�   $��Times New Roman)�6�   6�   o� 55   
   -   5         o�Name$
 menu��55      $
��Left=�6   $��36��68   $	��Top=�6D   $
��1072��6\   .@�57      m� -   5        $	��add��57      $��20(�6"   ���	#FF818181$��	_ADD ITEM��6H   {�.  m� 	IsChecked . 6l   �� 58      #��["�6   m� 59      -   5        $��update��59      $��20(�6%   $��_UPDATE ITEM��63   �� 5:      #��["�6   m� 5;      -   5        $��delete��5;      $��20(�6%   $��_DELETE ITEM��63   �� 5<      #��["�6   m� 5=      -   5        $��stock��5=      $��20(�6$   $��_STOCK REPORT��62   �� 5>      #��["�6   5?      �� 5@   
   -   5         ��Name$ category��5@      $
��Left=�6%   $	��Top=�6@   $��36��6X   $��240,383,0,0q�6d   $	��216��6z   $��20(�6�   .@�5A      �� $
��MALE��6    �� 
IsSelected . 6*   �� 5B      $��FEMALE��6   5C      �� 5D   
   -   5        $
 size��5D      $
��Left=�6!   $	��Top=�6<   $��36��6T   $��240,447,0,0q�6`   $	��216��6v   $��20(�6�   .@�5E      �� $��40��6    . 6(   �� 5F      $��41��6   �� 5G      $��42��6   �� 5H      $��43��6   �� 5I      $��44��6   �� 5J      $��45��6   5K      �� 5L   
   -   5        $ color��5L      $
��Left=�6"   $	��Top=�6=   $��36��6U   $��631,246,0,0q�6a   $	��216��6w   $��20(�6�   .@�5M      �� $��YELLOW��6    . 6,   �� 5N      $	��RED��6   �� 5O      $��BLACK��6   �� 5P      $
��BLUE��6   �� 5Q      $
��PINK��6   5R      �� 5S   
   -   5        $ brand��5S      $
��Left=�6"   $	��Top=�6=   $��36��6U   $��631,318,0,0q�6a   $	��216��6w   $��20(�6�   .@�5T      �� $
��BATA��6    . 6*   �� 5U      $��STYLO��6   �� 5V      $��SERVICE��6   �� 5W      $��BORJAN��6   5X      5\      5]      