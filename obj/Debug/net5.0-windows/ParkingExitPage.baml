   M S B A M L   `   `   `  ����D  @CarParker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarParker	CarParker  5          CarParker.ParkingExitPage   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:CarParker     5        N� Title$  ParkingExitPage��5	       � 	Resources 5       
  Border �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%   &	        �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 20��6K   ._�5      �� #��z��6$   $��Center=�6H   $��Center=�6e   
�������6�   5      5      5      5!      5#      .��5%      � -   5         �Name$ MainGrid��5%      ��5&   
   �� 5'       �� Color$ #343f56��6   .+�5+   
   �� .+�5.      �� -   5        	 ��Name$	 
ShowMapBtn��5.      $��40��6)   $��90��65   $��
600,30,0,0q�6@   ���#ff7171$��Show Map��5/      
�������$��0q�6Q   #��[  6f   �� 51   
   �� 53      $	��330��6   $	��210��6"   $��150,200q�6.   ���#ff8882$ 20��6T   
 J� Effect
 55      3  -System.Windows.Media.Effects.DropShadowEffect  56         ShadowDepth$ 30Q�6'      Opacity$	 0.2Q�68      	Direction$	 300Q�6F   ._�59      �� ���#ff8882$	��300��62   $	��200��6?   .+�5:      �� $��Search for slot��6   $��0,10,0,0q�66   $��18(�6I   $��Center=�6W   
�������6{   �� 5;      -   5         ��Name$ SearchEditor��5;      $	��120��64   $��0,10,0,0q�6@   $	��100��6R   $��75(�6_   $��0q�6m   6�   �� 5?      $��
Slot State��6    $	��200��65   $��20(�6A   $��Center=�6O   
�������6s   �� 5@       �� Orientation$ 
Horizontal=�6!   .+�5A      �� $��Customer Number��6    
�������$	��110��6M   �� 5B      $��:��6    $��15(�6,   
�������6:   �� 5C      -   5         ��Name$ CustomerNumeberValue��5C   !   
�������6?   5D      �� 5F      $ 
Horizontal=�6!   .+�5G      �� $��Parked Time��6    
�������$	��110��6I   �� 5H      $��:��6    $��15(�6,   
�������6:   �� 5I      -   5        $ SearchPanelParkedTime��5I       
�������6?   5J      �� 5L      $��
10,10,10,1q�6   $ 20��61   ���#eec4c4._�5M      �� -   5        $	 	SearchBtn��5M   !   $��40��64   $	��140��6@   ���#eec4c4$��Search��6b   $��0q�6s   
�������6�   5N      5O      5P      �� 5X      $	��290��6   $	��470��6!   ���#28b5b5$��490,200,0,0q�6C   $ 30��6X   
 5Z        5[      $ 30Q�6(   $	 0.2Q�69   $	 300Q�6G   ._�5^      �� $	��250��6   $	��450��6+   ���#28b5b5.+�5`      �� $��	Exit Card��6   
�������$��25(�6C   $��40��6Q   
������ $��0q�6v   $��Center=�6�   $��0,10,0,0q�6�   �� 5b      -   5        $ 
Sloteditor��5b      $	��120��62   $	��155��6?   $��	0,30,0,15q�6K   $��90(�6_   
�������$��Center=�5c   .   $��0q�6q   �� 5g      $ 
Horizontal=�6!   .+�5h      �� $��Parked Time           ��6    
�������$��15(�6T   $	��130��6b   �� 5i      $��:��6    $��17(�6,   
�������6:   �� 5j      -   5        $ ParkedTimeLabel��5j       
�������$��15(�6L   5k      �� 5m      $ 
Horizontal=�6!   .+�5n      �� $��Exit Time                ��6    
�������$��15(�6W   $	��130��6e   �� 5o      $��:��6    $��17(�6,   
�������6:   �� 5p      -	   5        $ ExitTimeLabel��5p       
�������$��15(�6J   5q      �� 5t      $ 
Horizontal=�6!   .+�5u      �� $��Total Time Parked ��6!   $��15(�6>   
�������$	��130��6_   �� 5v      $��:��6    $��17(�6,   
�������6:   �� 5w      -
   5        $ TimeTakeValue��5w       $��15(�67   
�������6E   5x      �� 5z      $ 
Horizontal=�6!   .+�5{      �� $��Customer Number��6    $��13(�6:   
�������$	��130��6[   $��Center=�6g   �� 5|      $��:��6    $��17(�6,   
�������6:   �� 5}      -   5        $ CustomerNumberLabel��5}       $��15(�6=   
�������6K   5~      �� 5�      $ 
Horizontal=�6!   .+�5�      �� -   5        $ 	TestLabel��5�       $��Total Cost   :��63   $��25(�6L   
�������6Z   �� 5�      -   5        $ 	CostLabel��5�       $��25(�63   
�������6A   5�      �� 5�      $��55��6   $ 20��6)   ���#a7d0cd._�5�      �� -   5        $	 FreeTheSlotBtn��5�   !   $��50��69   $	��200��6E   $��Free The Slot��6Q   ���#a7d0cd
�������$��0q�6�   $��20(�5�   7   5�      5�      5�      �� 5�      $	��370��6   $	��210��6"   $��920,200q�6.   ���#ff8882$ 20��6T   
 5�        5�      $ 30Q�6'   $	 0.2Q�68   $	 300Q�6F   ._�5�      �� ���#ff8882$	��350��62   $	��200��6?   .+�5�      �� $��Edit Alotted Slot��6   $��0,10,0,0q�68   $��18(�6K   $��Center=�6Y   
�������6}   �� 5�      $	��120��6   $��0,10,0,0q�6*   $	��100��6<   $��75(�6I   $��0q�6W   6o   �� 5�      $ 
Horizontal=�6!   $��30,10,20,10q�6:   .+�5�      �� $��Mark as Free��6!   $��30��68   $��70��6D   $��10(�6O   $��0,0,5,0q�6]   ���#343f56
�������$��0q�6�   �� 5�      $��Mark as Filled��6!   $��30��6:   $��70��6F   ���#343f56$��10(�6f   
�������$��0q�6�   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Customer Number��6    
�������$	��110��6M   �� 5�      $��:��6    $��15(�6,   
�������6:   �� 5�      
�������6!   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Parked Time��6    
�������$	��110��6I   �� 5�      $��:��6    $��15(�6,   
�������6:   �� 5�      
�������6!   5�      �� 5�      $��
10,10,10,5q�6   $ 20��61   ���#eec4c4._�5�      �� -   5        $	 EditBtn��5�   !   $��40��62   $	��140��6>   ���#eec4c4$
��Edit��6`   $��0q�6o   
�������6�   5�      5�      5�      �� 5�      -   5         ��Name$ 
ScrollView��5�      
�������$��0��6B   $
��1200��6N   $��Visible=�5�      $��
50,100,0,0q�6?   .��5�      �� .+�5�      �� -   5         ��Name$ Scrol1Canvas��5�      
�������$
��6000��6F   $
��6000��6T   6e   5�      5�      5�      5�      5�      