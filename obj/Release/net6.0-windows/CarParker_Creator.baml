   M S B A M L   `   `   `  ���� D  @CarParker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarParker	CarParker  !    CarParker.CarParker_Creator   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:CarParker       N� Title$  CarParker_Creator�� � 	Resources    MenuImage_Brush �� ImageSource j� Stretch  MenuButton_style �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 J� SnapsToDevicePixels
 �� Triggers P� Property P� Value �� 
TargetName��%�   &	        &	 &     �� $ Canvas/road.png��$
 None=��� " ��.���  � �� �� " ��.R��� $ border��#��z��#��z��$
	 True��
 P�  �@J�IsMouseOver$
 True��. ��� $ border�� � ��$ 3q�.���� ���#343f56.+��� -    ��Name$ MainGrid�����#343f56.+��� -   $ ToolBarBorder��$
��1000��$	��100��$��
130,30,0,0q����#e1e5ea �� CornerRadius$ 30��._��� -    ��Name$ StackTOOLBAR��$	��900��$��0,10,0,0q�.+���  �� Orientation$ 
Horizontal=�$��20�����#e1e5ea.+��� -    ��Name$ Filebtn��$��20��$��50��$
��File��
�����_� J� RenderTransformOrigin$ 0.5,1.76&�
 �� Top$ 21���� 
�������$ 
Horizontal=�$��57��.+��� -   $ RectBtn��$��30��$��30��$��0q� �� Right$	 500��$��10q�$
	 True��#��[ ���� $ Canvas\rectangle.png���� -   $ SlotBtn��$��30��$��30��$��10q�$	 500��$��0q�#��[ ���� $ Canvas\parking.png���� -   $ RoadBtn��$��30��$��30��$��10q�$	 500��$��0q�#��[ ���� $ Canvas\road.png���� -   $ HRoadBtn��$��30��$��30��$��10q�$	 500��$��0q�#��[ ���� $ Canvas\Hroad.png���� $��Workspace Size��$��Center=�$��Center=��� -	    ��Name$ WorkspaceSlider��$	��100��$��10q� � Maximum$
 4000Q�$��Center=��� -
   $ TollBtn��$��30��$��30��$��10q�$	 500��$��0q�#��[ ���� $ Canvas\toll.png���� -   $ Arrow��$��30��$��30��$��10q�$	 500��$��0q�#��[ ���� $ Canvas\Arrow.png���� -   $ 	Connector��$��30��$��30��$��10q�$	 500��$��0q�#��[ ���� $ Canvas\Arrow.png���� -    ��Name$ Scrollview1��$��Visible=�$	 175��$	��630��$
��1310��$��Hidden=�.���� .+��� -   $ Scrol1Canvas�����#343f56$
��6000��$
��6000���� -    ��Name$ DebugBox�� �� Left$ 30��$��400,200,100,0q�$	��400��$	��500��
�������$y�Hidden=�.��