   M S B A M L   `   `   `  ����G  CAssingment 1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Assingment_1Assingment_1  5   	       Assingment_1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Assingment_1     5   	   -   5          �Name$  window��5   	    � Title$ Login Panel��5   	   $	��641��6   $
��1080��6*   $��0q�67    � 	Resources 5	       
  Color1��%+   &	        ��5
   
   	#FFD6D5D5��6*   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��84* �6   �� 5      $
��433* �6   �� 5      $	��45* �6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��610��6:   $D��>D:\BCS DATA\Samester 6\C Sharp\Assingment 1\pictures\login.jpg��6G   $	��Top=�6�   $��-8,0,0,0q�6�   $��3��6�    J� RenderTransformOrigin$ 0.5,0.5&�6  ��6�   �� *ActualWidth+ �� ElementName$ window�� �� Mode$ OneWay=�5      �� 5   
   
���   �$��2q�6%   $��Stretch=�69   $	��270��6W   $��
0,158,86,0q�6d   $	��Top=�6x   $��1��6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      5      �� 5   
   -   5        	 ��Name$	 uname��5      $��Username��6   $
��Left=�62   $��
81,208,0,0q�6M   $	��Top=�6a   $��1��6y   $��22(�6�   $��Black"�6�   $��SketchFlow Print)�6�   $	��137��6�   �� 5   
   -   5        $
	 pass��5      $��Password��6   $
��Left=�61   $��
81,314,0,0q�6L   $	��Top=�6`   $��1��6x   $��22(�6�   $��
ExtraBlack"�6�   $	��137��6�   $��SketchFlow Print)�6�   �� 5"   
   -   5        
 ��Name$
 login_b��5"      $��LOGIN��6"   $
��Left=�62   $��576,338,0,0q�6M   $	��Top=�6}   $	��141��6�   $��42��6�   $��20(�6�   $
��Bold"�6�   $��Times New Roman)�6�   $��1��6�   �� 5%   
   -   5        $
 login_bS��5%      $
��EXIT��6#   $
��Left=�62   $��
685,65,0,0q�6M   $	��Top=�6{   $	��141��6�   $��42��6�   $��20(�6�   $
��Bold"�6�   $��Times New Roman)�6�   $��1��6�   �� 5,   
   -   5        $	 label2��5,      $��Please Log in To Proceed��6    $
��Left=�6C   $��	66,59,0,0q�6^   $	��Top=�6q   $	��493��6�   $��36(�6�   $��1��6�   $��SemiBold"�6�   $��SketchFlow Print)�6�   �� 5-   
   -   5         ��Name$ txt_username��5-      $
��Left=�6i   $��36��6�   $��269,208,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��216��6�   $��1��6�   $��20(�6�   G� 5.   
   -	   5         G�Name$ txt_password��5.      $��1��6t    G� PasswordChar$ *��6�   $
��Left=�6�   $��269,310,0,0q�6�   $	��Top=�6�   $	��216��6�   $��35��6�   $��20(�6�   54      55      