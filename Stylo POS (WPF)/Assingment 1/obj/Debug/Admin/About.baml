   M S B A M L   `   `   `  ����G  CAssingment 1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Assingment_1.AdminAssingment_1.Admin  5   
       Assingment_1.Admin.About   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2local clr-namespace:Assingment_1.Admin     5   
     � Title$  Admin Panel��5   
   $	��641��6   $
��1080��6+    � 	Resources 5       
  Color1 
 Color2 
 Color3 
 Color4 
 Color5 
 Color6 
 Color7 
 Color8��%X  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     &	 �     ��5   
   	#FF6171D6��6*   ��5   
   	#FF060676��6*   ��5	   
   	#FFD14E54��6*   ��5
   
   	#FFCFA87A��6*   ��5   
   	#FF66D875��6*   ��5   
   	#FF66D875��6*   ��5   
   	#FF75059E��6*   ��5   
   	#FF75059E��6*   5      .��5      � ���	#FFD6D5D5 � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ back_button��5      $
��BACK��6&   $
��Left=�65   $��
898,36,0,0q�6P   $	��Top=�6d   $	��148��6|   $��53��6�   $��24(�6�   $��SketchFlow Print)�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.713,0.142&�6�   6�   �� 5   
   -   5         ��Name$ label2��5      $��About The Developer��6    $
��Left=�6>   $��
154,36,0,0q�6Y   $	��Top=�6m   $	��640��6�   $��48(�6�   $��Black"�6�   $��SketchFlow Print)�6�   $��68��6�   �� 5   
   
���   �$��2q�6%   $
��Left=�69   $	��480��6T   $��
24,109,0,0q�6a   $	��Top=�6u   $
��1022��6�   ._�5      �� -   5         ��Name$ stack��5   2    �� Orientation$ 
Horizontal=�6    5      *   $Assingment_1.Admin.NegatingConverter  NegatingConverter 		 slide W� From	 g� Duration
 �� TargetProperty �� 
TargetName g� RepeatBehavior	 W� To �� ElementName �� 	Converter��%�   &	       &		      7    5      6.   �� 5      .��5      W� $ 0X�6*   $	 00:00:20D�6�   $
 X�5       $ transferCurreny��5!      $ Forever��5"       5   3   �� *Width+$ canvas��8   5"      5#      5$      z�5%      T� 5&      -   5        transferCurreny�� T� X$ 0Q�5&   B    � Triggers 5(      :� 5)       :� RoutedEvent$ StackPanel.Loaded��6#   .[�5*      �� #��[	 6*   5+      :� 5,      $ StackPanel.SizeChanged��6#   .[�5-      �� #��[	 6*   5.      .+�50      �� -   5         ��Name$ canvas��50      ��6)   �� *ActualWidth+$ stack��.+�51      �� -   5         ��Name$ A��51   8   $��S��6    $��25(�6)    �� Left$	 909��6C   
 �� Top$ 99��6U   $	��187��6e   $	��515��6r   �� 52      -   5        $ B��52   9   $��S��6    $��25(�6)   $
 2198��6D   $ 99��6W   $	��651��6g   $	��370��6s   54      55      5:      5>      5?      