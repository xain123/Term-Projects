   M S B A M L   `   `   `  ����G  CAssingment 1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Assingment_1Assingment_1  5   	       Assingment_1.stockReport   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Assingment_1     5   	     � Title$  Stock Report��5   	   $	��641��6   $
��1080��6+    � 	Resources 5
       
  Color1��%+   &	        ��5   
   	#FFD6D5D5��6*   5      .��5      � ��5   
   �� 5       �� Color# �   6   .+�5   
   �� -   5         ��Name$ image1��5      $J��DD:\BCS DATA\Samester 6\C Sharp\Assingment 1\pictures\stockReport.ico��6     J� OpacityMask �	#FF8D5252$��0,41,860,444q�6�   �� 5   
   -   5         ��Name$ label2��5      $��EFSI STOCK REPORT��6    $
��Left=�6<   $��
290,76,0,0q�6W   $	��Top=�6k   $	��640��6�   $��48(�6�   $��Black"�6�   $��SketchFlow Print)�6�   $��68��6�   �� 5   
   
���   �$��2q�6%   $
��Left=�69   $	��360��6T   $��
25,187,0,0q�6a   $	��Top=�6u   $
��1022��6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      5      o� 5   
   -   5         o�Name$
 menu��5      $
��Left=�6   $��36��68   $	��Top=�6D   $
��1072��6\   .@�5      m� -   5        $	��add��5      $��20(�6"   $��	_ADD ITEM��60   {�. 6C   �� 5      #��["�6   m� 5       -   5        $��update��5       $��20(�6%   $��_UPDATE ITEM��63   �� 5!      #��["�6   m� 5"      -   5        $��delete��5"      $��20(�6%   $��_DELETE ITEM��63   �� 5#      #��["�6   m� 5$      -   5        $��stock��5$      $��20(�6$   ���	#FF818181$��_STOCK REPORT��6I    m� 	IsChecked . 6`   �� 5%      #��["�6   5&      �� 5'   
   -   5        	 ��Name$	 back_btn��5'      $
��BACK��6#   $
��Left=�62   $��906,558,0,0q�6M   $	��Top=�6b   $	��141��6z   $��42��6�   $��20(�6�   $
��Bold"�6�   $��Times New Roman)�6�   6�   �� 5(   
   -	   5        $	 
search_btn��5(      $��Search��6%   $
��Left=�66   $��882,204,0,0q�6Q   $	��Top=�6f   $	��148��6~   $��42��6�   $��25(�6�   $
��Bold"�6�   $��Times New Roman)�6�   6�   �� 5)   
   -
   5        $	 view_btn��5)      $��View Report��6#   $
��Left=�69   $��
25,557,0,0q�6T   $	��Top=�6h   $	��187��6�   $��42��6�   $��25(�6�   $
��Bold"�6�   $��Times New Roman)�6�   6�   �� 5+   
   -   5        $ l7��5+      $
��FROM��6   $
��Left=�6+   $��
44,204,0,0q�6F   $	��Top=�6Z   $��20(�6r   $��Black"�6�   $��Times New Roman)�6�   $��79��6�   �� 5,   
   -   5        $ l8��5,      $��TO��6   $
��Left=�6)   $��472,204,0,0q�6D   $	��Top=�6Y   $��20(�6q   $��Black"�6   $��Times New Roman)�6�   $��49��6�   
 J� RenderTransformOrigin$
 	1.092,0.5&�6�   (  "System.Windows.Controls.DatePicker  5-   
   -   5        $
��from��5-      $
��Left=�6!   $��167,204,0,0q�6<   $	��Top=�6Q   $	��246��6i   $��36��6u   $��20(�6�     5.   
   -   5        $��to��5.      $
��Left=�6   $��573,204,0,0q�6:   $	��Top=�6O   $	��246��6g   $��36��6s   $��20(�6   &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dataGrid��5/      $
��Left=�6%   $��
44,251,0,0q�6@   $	��Top=�6T   $	��274��6l   $	��986��6y      AlternatingRowBackground
 ����� �� AlternationCount$ 2��50   9      SelectionMode$ Extended=�51         SelectionUnit$ FullRow=�6,      AutoGenerateColumns .     Columns 54      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Pid+  57      $ Price��6%   $	 140 64    6@   �� *Price+  58      $ Category��6%   $	 140 67    6C   �� *
Category+  59      $
 Size��6%   $	 140 63    6?   �� *Size+  5:      $ Color��6%   $	 140 64    6@   �� *Color+  5;      $ Brand��6%   $	 140 64    6@   �� *Brand+  5<      $
 Date��6%   $	 138 63    6?   �� *Date+5B      5F      5G      