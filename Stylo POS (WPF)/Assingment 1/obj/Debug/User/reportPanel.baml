   M S B A M L   `   `   `  ����G  CAssingment 1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Assingment_1.UserAssingment_1.User  5   	   #    Assingment_1.User.reportPanel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Assingment_1.User     5   	     � Title$  Report Panel��5   	   $	��641��6   $
��1080��6+    � 	Resources 5	       
  Color1 
 Color2 
 Color3 
 Color4 
 Color5 
 Color6 
 Color7 
 Color8��%X  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     &	 �     ��5
   
   	#FF6171D6��6*   ��5   
   	#FF060676��6*   ��5   
   	#FFD14E54��6*   ��5   
   	#FFCFA87A��6*   ��5   
   	#FF66D875��6*   ��5   
   	#FF66D875��6*   ��5   
   	#FF75059E��6*   ��5   
   	#FF75059E��6*   5      .��5      � ���	#FFD6D5D5 J� RenderTransformOrigin$ 0.504,0.582&�6"   .+�5   
   �� -   5         ��Name$ label2��5      $��REPORT PANEL��6    $
��Left=�67   $��
330,40,0,0q�6R   $	��Top=�6f   $	��396��6~   $��48(�6�   $��Black"�6�   $��SketchFlow Print)�6�   $��53��6�   �� 5   
   
���   �$��2q�6%   $
��Left=�69   $	��448��6T   $��
57,131,0,0q�6a   $	��Top=�6u   $	��962��6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      5      �� 5   
   -   5        $
��Left=�5      $	��180��6,   $��114,157,0,0q�69   $	��Top=�6O   $	��334��6g   
���   � J� OpacityMask �	#FFBB7E7E��5       �� 5!       �� Color$ 	#FFDE9245��6"   ��5#      �� 5$       �� 
TargetType" ��6    �� Triggers 5%      P� 5&      	 P� Property	 �@J�IsMouseOver
 P� Value
 .  N� EnterActions 5'      �� 5(   "   .��5)   &   �� .��5*   *   t�  g� Duration$ 	0:0:0.500D�6=   	 t� To$ 2X�6R    �� TargetProperty$ BorderThickness�6Y   W� 5+   *   $ 	0:0:0.400D�6:   	 W� To$	 193X�6O   $ Height�6X   W� 5,   *   $ 	0:0:0.400D�6:   $	 344X�6O   $ Width�6X   5-   '   5.   #    N� ExitActions 51      �� 52   "   .��53   &   �� .��54   *   t� $ 	0:0:0.300D�6=   $ 0X�6R   $ BorderThickness�6Y   W� 55   *   $ 	0:0:0.500D�6:   $	 180X�6O   $ Height�6X   W� 56   *   $ 	0:0:0.500D�6:   $	 334X�6O   $ Width�6X   57   '   58   #   5:      5<      ._�5?      � .+�5@      �� -   5         ��Name$ image1��5@      $D��>D:\BCS DATA\Samester 6\C Sharp\Assingment 1\pictures\sale2.png��6(    �	#FF8D5252$��
0,0,154,10q�6�   �� 5A      -   5        $ label��5A      $��  SALE 
REPORT��6'   $
��Left=�6I   $��
165,83,0,0q�6d   $	��159��6x   $��32(�6�   $��Sitka Small)�6�   $
��Bold"�6�   $��97��6�   $	��Top=�6�   $ 0.525,1&�6�   5D      5E      �� 5G   
   -   5        $
��Left=�5G      $	��180��6,   $��628,157,0,0q�69   $	��Top=�6O   $	��334��6g   
���   �
 �   ���5H      �� 5I      $ 	#FFD68E6C��6"   ��5K      �� 5L      " ��6    5M      P� 5N      	 �@J�IsMouseOver
 .  5O      �� 5P   "   .��5Q   &   �� .��5R   *   t� $ 	0:0:0.500D�6=   $ 2X�6R   $ BorderThickness�6Y   W� 5S   *   $ 	0:0:0.400D�6:   $	 193X�6O   $ Height�6X   W� 5T   *   $ 	0:0:0.400D�6:   $	 344X�6O   $ Width�6X   5U   '   5V   #    5Y      �� 5Z   "   .��5[   &   �� .��5\   *   t� $ 	0:0:0.300D�6=   $ 0X�6R   $ BorderThickness�6Y   W� 5]   *   $ 	0:0:0.500D�6:   $	 180X�6O   $ Height�6X   W� 5^   *   $ 	0:0:0.500D�6:   $	 334X�6O   $ Width�6X   5_   '   5`   #   5b      5d      ._�5g      � .+�5h      �� -   5        $ image2��5h      $F��@D:\BCS DATA\Samester 6\C Sharp\Assingment 1\pictures\reports.png��6(    �	#FF8D5252$��
0,0,154,10q�6�   �� 5i      -   5        $ label3��5i      $�� SERVICE 
 REPORT��6(   $��148,79,12,0q�6M   $	��Top=�6b   $��91��6z   $��32(�6�   $��Sitka Small)�6�   $
��Bold"�6�   5k      5l      �� 5n   
   -   5        $
��Left=�5n      $	��180��6-   $��114,376,0,0q�6:   $	��Top=�6O   $	��334��6g   
���   ���5o      �� 5p      $ 	#FFBDBD44��6"   ��5r      �� 5s      " ��6    5t      P� 5u      	 �@J�IsMouseOver
 .  5v      �� 5w   "   .��5x   &   �� .��5y   *   t� $ 	0:0:0.500D�6=   $ 2X�6R   $ BorderThickness�6Y   W� 5z   *   $ 	0:0:0.400D�6:   $	 193X�6O   $ Height�6X   W� 5{   *   $ 	0:0:0.400D�6:   $	 344X�6O   $ Width�6X   5|   '   5}   #    5�      �� 5�   "   .��5�   &   �� .��5�   *   t� $ 	0:0:0.300D�6=   $ 0X�6R   $ BorderThickness�6Y   W� 5�   *   $ 	0:0:0.500D�6:   $	 180X�6O   $ Height�6X   W� 5�   *   $ 	0:0:0.500D�6:   $	 334X�6O   $ Width�6X   5�   '   5�   #   5�      5�      ._�5�      � .+�5�      �� -	   5        $ image3��5�      $C��=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\pictures\sto2.png��6(    �	#FF8D5252$��
0,0,154,10q�6�   �� 5�      -
   5        $ label4��5�      $�� STOCK 
REPORT��6(   $
��Left=�6J   $��
180,91,0,0q�6e   $	��Top=�6y   $��79��6�   $	��144��6�   $��30(�6�   $��Sitka Small)�6�   $
��Bold"�6�   5�      5�      �� 5�   
   -   5        $
��Left=�5�      $	��180��6,   $��628,376,0,0q�69   $	��Top=�6N   $	��334��6f   
���   ���5�      �� 5�      $ 	#FF8BE051��6"   ��5�      �� 5�      " ��6    5�      P� 5�      	 �@J�IsMouseOver
 .  5�      �� 5�   "   .��5�   &   �� .��5�   *   t� $ 	0:0:0.500D�6=   $ 2X�6R   $ BorderThickness�6Y   W� 5�   *   $ 	0:0:0.400D�6:   $	 193X�6O   $ Height�6X   W� 5�   *   $ 	0:0:0.400D�6:   $	 344X�6O   $ Width�6X   5�   '   5�   #    5�      �� 5�   "   .��5�   &   �� .��5�   *   t� $ 	0:0:0.300D�6=   $ 0X�6R   $ BorderThickness�6Y   W� 5�   *   $ 	0:0:0.500D�6:   $	 180X�6O   $ Height�6X   W� 5�   *   $ 	0:0:0.500D�6:   $	 334X�6O   $ Width�6X   5�   '   5�   #   5�      5�      ._�5�      � .+�5�      �� -   5        $ image4��5�      $C��=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\pictures\back.png��6(   
 �   �$��
0,0,154,10q�6�   �� 5�      -   5        $ label5��5�      $
��BACK��6(   $
��Left=�67   $��222,128,0,10q�6R   $	��102��6h   $��30(�6t   $��Sitka Small)�6�   $
��Bold"�6�   $ 1.157,0.643&�6�   5�      5�      5�      5�      