   M S B A M L   `   `   `  ���� D  @CarParker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarParker	CarParker      CarParker.MainWindow   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  #localclr-namespace:CarParker    � Title$  
MainWindow��$	��768��$
��1366�� � WindowStyle$
 None=� � 
ResizeMode$ CanResizeWithGrip=� � AllowsTransparency$
 True�� � WindowState$ 	Maximized=� � 	Resources    
font_style �� 
TargetType �� Property �� Value  tb_mouse_over	 �� ImageSource
 j� Stretch  MenuBtn_Style �� 
TargetType �� Triggers P� Property P� Value  close_style ��Name J� SnapsToDevicePixels �� 
TargetName  MenuBtns  FrameShadow3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   	Direction   Color   Opacity��%7  &	        &	 �     &	 �     &	 ]    &	     &	 �    �� " ��.���  � ��$$ Fonts/Roboto-Light.ttf #Roboto)���  � ��$ Center=���  � ��$
 Left=���  � ��
 �������  � ��$ 15(��� $	 Assets/Grid_menu.png��$

 None=��� " ��.���  � �� �� " ��.R��� #��z�� P�  �@J�IsMouseOver$
 True��. ���  � �� �� $	 Assets/Grid_menu.png���� " ��.���  � �� �� " ��.R��� $ border��#��z��#��z��$
 True�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � ��
 ������� " ��.���  � �� �� " ��.R��� $ border��#��z��#��z��$
 True�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � ��
 ���� �� "  �.���  �@J�Effect   $ 5Q�$	 650Q�$ Black��$	 0.2Q�.���  � ColumnDefinitions �� $��70 ��� $
��1310 �.+�� -    �Name$ 	Nav_panel��$��70��$
��Left=����#495464$��0��.+��� -    ��Name$ Stack_Panel��$��0,80,0,0q�.+��� -    ��Name$ HomeBtn��$��30��$��5,0,5,0q�$��0q�#��[ ���� -   	HomeImage��$	 Icons/Home.png��$
 Uniform=��� -   $ UserBtn��$��30��$��5,30,5,0q�$��0q�#��[ ���� -   	UserImage��$	 Icons/User.png��$
 Uniform=��� -   $ MapCreatorBtn��$��30��$��8,30,5,0q�$��0q�#��[ ���� -   MapCreatorImage��$	 Icons/Edit.png��$
 Uniform=��� -	   $ 
ParkingBtn��$��30��$��5,30,5,0q�$��0q�#��[ ���� -
   ParkingImage��$	 Icons/Parking.png��$
 Uniform=��� -   $ SettingsBtn��$��30��$��5,30,5,0q�$��0q�#��[ ���� -   SettingsBtnImage��$	 Icons/Settings.png��$
 Uniform=�� -   $ 	Main_Grid��
�������$��1��.+� � -     �Name$ ContentFrame��  � NavigationUIVisibility$ Hidden=�$��2���� -   $ 
GraphFrame��
������ $��70,19,890,26q�$��2��$y�Hidden=� J� Effect   $ 5Q�$	 0.2Q�$	 300Q�._��� 
������ $��1�� �� Orientation$ 
Horizontal=�$��24,42,24,21q�.+��� .+� � $��40��$	��160�����#EAD308#��[ $��Bottom=�$��0,20,0,0q��� $	��MON���� .+� � $��40��$	��180�����#20C14D#��[ $��Bottom=�$��0,0,0,0q��� $	��TUE��$��Bottom=��� .+� � $��40��$	��100��$��Bottom=����#8DC7F0#��[ $��0,80,0,0q��� $	��WED��$��Bottom=��� .+� � $��40��$��90��$��Bottom=����#74127C#��[ $��0,90,0,0q��� $	��THU��$��Bottom=��� .+� � $��40��$��80��$��Bottom=����#1F6D6D#��[ $��	0,100,0,0q��� $	��FRI��$��Bottom=��� .+� � $��40��$	��150��$��Bottom=����#9A0C0c#��[ $��0,30,0,0q��� $	��SAT��$��Bottom=��� .+� � $��39��$��60�����#DB8C1C#��[ $��	0,120,0,0q��� $	��SUN��$��Bottom=��� -   $ SlotBookingDisplayGrid��$��440,19,430,26q�
������ $��2��$y�Hidden=�   $ 5Q�$	 0.2Q�$	 300Q�._�� $	��250��$	��350��$��0,20,0,0q�   $ 5Q�$	 0.2Q�$	 300Q� �� $��50 ��� $	��250 ��� $��50 � � RowDefinitions �� $��40 ��� $��20 ��� $��20 ��� $��20 ��� $��20 ��� $��20 ��� $��20 ��� $��20 ��� $��20 ��� $��20 ��� $��20 ��� $��20 �.+��� $
��Slot��
�������$��Center=�$��Center=����#87a7b3$��0��$��0��$��1q��� $��Customer��
�������$��Center=�$��Center=����#87a7b3$��1��$��0��$��1q��� $
��Date��
�������$��Center=�$��Center=����#87a7b3$��2��$��0��$��1q��� ���#eeeeee$��0��$��1��$��1q��� ���#eeeeee$��1��$��1��$��1q��� ���#eeeeee$��2��$��1��$��1q��� ���#eeeeee$��0��$��2��$��1q��� ���#eeeeee$��1��$��2��$��1q��� ���#eeeeee$��2��$��2��$��1q��� ���#eeeeee$��0��$��3��$��1q��� ���#eeeeee$��1��$��3��$��1q��� ���#eeeeee$��2��$��3��$��1q��� ���#eeeeee$��0��$��4��$��1q��� ���#eeeeee$��1��$��4��$��1q��� ���#eeeeee$��2��$��4��$��1q��� ���#eeeeee$��0��$��5��$��1q��� ���#eeeeee$��1��$��5��$��1q��� ���#eeeeee$��2��$��5��$��1q��� ���#eeeeee$��0��$��6��$��1q��� ���#eeeeee$��1��$��6��$��1q��� ���#eeeeee$��2��$��6��$��1q��� ���#eeeeee$��0��$��7��$��1q��� ���#eeeeee$��1��$��7��$��1q��� ���#eeeeee$��2��$��7��$��1q��� ���#eeeeee$��0��$��8��$��1q��� ���#eeeeee$��1��$��8��$��1q��� ���#eeeeee$��2��$��8��$��1q��� ���#eeeeee$��0��$��9��$��1q��� ���#eeeeee$��1��$��9��$��1q��� ���#eeeeee$��2��$��9��$��1q��� ���#eeeeee$��0��$��10��$��1q��� ���#eeeeee$��1��$��10��$��1q��� ���#eeeeee$��2��$��10��$��1q��� -   $ CloseBtn��$��40��$��40��$��4q�#��[ $��Right=�$	��Top=�$��	0,10,10,0q� J� RenderTransformOrigin$ 0.425,0.728&����� $	 Assets/close.png��$
 UniformToFill=�