   M S B A M L   `   `   `  ����D  @CarParker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarParker	CarParker  5   	       CarParker.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      #localclr-namespace:CarParker  5   	     � Title$  
MainWindow��5
   	   $	��768��6   $
��1366��6)    � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � AllowsTransparency$
 True��5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5         
font_style �� 
TargetType �� Property �� Value  tb_mouse_over	 �� ImageSource
 j� Stretch  MenuBtn_Style �� 
TargetType �� Triggers P� Property P� Value  close_style ��Name J� SnapsToDevicePixels �� 
TargetName  MenuBtns  FrameShadow3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   	Direction   Color   Opacity��%#  &	        &	     &	 R    &	 �    &	 �    &	 F    �� 5   
   " ��6#   .�5      ��  � ��$$ Fonts/Roboto-Light.ttf #Roboto)�5      �� 5       � ��$ Center=�5      �� 5!       � ��$
 Left=�5"      �� 5$       � ��
 �����5%      �� 5'       � ��$ 15(�5(      5*      �� 5,   
   $	 Assets/Grid_menu.png��6,   $

 None=�5-   /   �� 50   
   " ��6&   .�52      ��  � �� 53      �� 54      " ��6&   .R�55      �� #��z��6"   58       5:      P� 5;       �@J�IsMouseOver$
 True��6=   . �5<   "   ��  � �� 5=   &   �� 5>   *   $	 Assets/Grid_menu.png��65   5A   #   5C      5F      5J      5O      �� 5Z   
   " ��6$   .�5[      ��  � �� 5\      �� 5]      " ��6'   .R�5^      �� $ border��6"   #��z��5_   "   #��z��5`   "   $
 True��5b   "   5d       5e      P� 5g       �@J�IsMouseOver$
 True��6=   . �5h   "   �� $ border��5i   )    � ��
 �����5j   )   5l      5p      5s      5v      �� 5z   
   " ��6!   .�5{      ��  � �� 5}      �� 5~      " ��6&   .R�5�      �� $ border��6"   #��z��5�   "   #��z��5�   "   $
 True��5�   "   5�       5�      P� 5�       �@J�IsMouseOver$
 True��6=   . �5�   "   �� $ border��5�   )    � ��
 ���� 5�   )   5�      5�      5�      5�      �� 5�   
   "  �6$   .�5�      ��  �@J�Effect 5�        5�      $ 5Q�6'   $	 650Q�66   $ Black��6F   $	 0.2Q�6T   5�      5�      5�      .��5�      �  � ColumnDefinitions 5�   
   �� 5�      $��70 �6   �� 5�      $
��1310 �6   .+�5�   
   � -   5         �Name$ 	Nav_panel��5�      $��70��5�      $
��Left=�5�      ���#495464$��0��5�      .+�5�      �� -   5         ��Name$ Stack_Panel��5�      $��0,80,0,0q�6.   .+�5�      �� -   5         ��Name$ HomeBtn��5�   !   $��30��63   $��5,0,5,0q�6?   $��0q�6P   #��[ 6d   ��5�      �� 5�      -   5        	HomeImage��$	 Icons/Home.png��5�   <   $
 Uniform=�6Y   5�      �� 5�      -   5        $ UserBtn��5�      $��30��6+   $��5,30,5,0q�67   $��0q�6I   #��[ 6]   ��5�      �� 5�      -   5        	UserImage��$	 Icons/User.png��5�   8   $
 Uniform=�6U   5�      �� 5�      -   5        $ MapCreatorBtn��5�      $��30��60   $��8,30,5,0q�6<   $��0q�6O   #��[ 6c   ��5�      �� 5�   "   -   5        MapCreatorImage��$	 Icons/Edit.png��5�   F   $
 Uniform=�6c   5�      �� 5�      -	   5        $ 
ParkingBtn��5�   "   $��30��66   $��5,30,5,0q�6B   $��0q�6U   #��[ 6i   ��5�   "   �� 5�   &   -
   5        ParkingImage��$	 Icons/Parking.png��5�   G   $
 Uniform=�6g   5�      �� 5�      -   5        $ SettingsBtn��5�   "   $��30��67   $��5,30,5,0q�6C   $��0q�6V   #��[ 6j   ��5�      �� 5   "   -   5        SettingsBtnImage��$	 Icons/Settings.png��5   G   $
 Uniform=�6h   5     5     5     � 5  
   -   5        $ 	Main_Grid��5  "   
�������$��1��65   .+�5      � -   5          �Name$ ContentFrame��5       � NavigationUIVisibility$ Hidden=�6+   $��2��6K   �� 5!     -   5        $ 
GraphFrame��5!     
������ $��70,19,890,26q�6C   $��2��6Y   $y�Hidden=�6g    J� Effect 5"       5#     $ 5Q�6'   $	 0.2Q�66   $	 300Q�6D   ._�5&     �� 
������ $��1��66    �� Orientation$ 
Horizontal=�6F   $��24,42,24,21q�6_   .+�5(     �� .+�5)      � $��40��6    $	��160��6+   ���#EAD308#��[ 6M   $��Bottom=�6r   $��0,20,0,0q�6�   �� 5*     $	��MON��6    5+     �� 5-     .+�5.      � $��40��6    $	��180��6+   ���#20C14D#��[ 6O   $��Bottom=�6u   $��0,0,0,0q�6�   �� 5/     $	��TUE��6    $��Bottom=�6.   50     �� 52     .+�53      � $��40��6    $	��100��6+   $��Bottom=�68   ���#8DC7F0#��[ 6i   $��0,80,0,0q�6�   �� 54     $	��WED��6    $��Bottom=�6.   55     �� 57     .+�58      � $��40��6    $��90��6+   $��Bottom=�67   ���#74127C#��[ 6i   $��0,90,0,0q�6�   �� 59     $	��THU��6    $��Bottom=�6.   5:     �� 5=     .+�5>      � $��40��6    $��80��6+   $��Bottom=�68   ���#1F6D6D#��[ 6j   $��	0,100,0,0q�6�   �� 5?     $	��FRI��6    $��Bottom=�6.   5@     �� 5B     .+�5C      � $��40��6    $	��150��6+   $��Bottom=�69   ���#9A0C0c#��[ 6j   $��0,30,0,0q�6�   �� 5D     $	��SAT��6    $��Bottom=�6.   5E     �� 5G     .+�5H      � $��39��6    $��60��6+   ���#DB8C1C#��[ 6M   $��	0,120,0,0q�6s   �� 5I     $	��SUN��6    $��Bottom=�6.   5J     5N     5O     �� 5U     -   5        $ SlotBookingDisplayGrid��5U     $��440,19,430,26q�66   
������ $��2��6f   $y�Hidden=�6s    5V       5W     $ 5Q�6'   $	 0.2Q�66   $	 300Q�6D   ._�5Y     � $	��250��6   $	��350��6%   $��0,20,0,0q�61    5[       5\     $ 5Q�6+   $	 0.2Q�6:   $	 300Q�6H    5^     �� 5_     $��50 �6+   �� 5`     $	��250 �6+   �� 5a     $��50 �6+    � RowDefinitions 5c     �� 5d     $��40 �6(   �� 5e     $��20 �6(   �� 5f     $��20 �6(   �� 5g     $��20 �6(   �� 5h     $��20 �6(   �� 5i     $��20 �6(   �� 5j     $��20 �6(   �� 5k     $��20 �6(   �� 5l     $��20 �6(   �� 5m     $��20 �6(   �� 5n     $��20 �6(   �� 5o     $��20 �6(   .+�5w     �� $
��Slot��6   
�������$��Center=�6>   $��Center=�6a   ���#87a7b3$��0��6�   $��0��6�   $��1q�6�   �� 5x     $��Customer��6   
�������$��Center=�6C   $��Center=�6e   ���#87a7b3$��1��6�   $��0��6�   $��1q�6�   �� 5y     $
��Date��6   
�������$��Center=�6?   $��Center=�6a   ���#87a7b3$��2��6�   $��0��6�   $��1q�6�   �� 5z     ���#eeeeee$��0��61   $��1��6A   $��1q�6N   �� 5{     ���#eeeeee$��1��61   $��1��6A   $��1q�6N   �� 5|     ���#eeeeee$��2��61   $��1��6A   $��1q�6N   �� 5}     ���#eeeeee$��0��61   $��2��6A   $��1q�6N   �� 5~     ���#eeeeee$��1��61   $��2��6A   $��1q�6N   �� 5     ���#eeeeee$��2��61   $��2��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��3��6A   $��1q�6N   �� 5�     ���#eeeeee$��1��61   $��3��6A   $��1q�6N   �� 5�     ���#eeeeee$��2��61   $��3��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��4��6A   $��1q�6N   �� 5�     ���#eeeeee$��1��61   $��4��6A   $��1q�6N   �� 5�     ���#eeeeee$��2��61   $��4��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��5��6A   $��1q�6N   �� 5�     ���#eeeeee$��1��61   $��5��6A   $��1q�6N   �� 5�     ���#eeeeee$��2��61   $��5��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��6��6A   $��1q�6N   �� 5�     ���#eeeeee$��1��61   $��6��6A   $��1q�6N   �� 5�     ���#eeeeee$��2��61   $��6��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��7��6A   $��1q�6N   �� 5�     ���#eeeeee$��1��61   $��7��6A   $��1q�6N   �� 5�     ���#eeeeee$��2��61   $��7��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��8��6A   $��1q�6N   �� 5�     ���#eeeeee$��1��61   $��8��6A   $��1q�6N   �� 5�     ���#eeeeee$��2��61   $��8��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��9��6A   $��1q�6N   �� 5�     ���#eeeeee$��1��61   $��9��6A   $��1q�6N   �� 5�     ���#eeeeee$��2��61   $��9��6A   $��1q�6N   �� 5�     ���#eeeeee$��0��61   $��10��6A   $��1q�6O   �� 5�     ���#eeeeee$��1��61   $��10��6A   $��1q�6O   �� 5�     ���#eeeeee$��2��61   $��10��6A   $��1q�6O   5�     5�     �� 5�     -   5        $ CloseBtn��5�     $��40��5�     $��40��5�     $��4q�5�     #��[ 5�     $��Right=�5�     $	��Top=�5�     $��	0,10,10,0q�61    J� RenderTransformOrigin$ 0.425,0.728&�6D   ��5�     �� 5�     $	 Assets/close.png��6!   $
 UniformToFill=�6@   5�     5�     5�     5�     