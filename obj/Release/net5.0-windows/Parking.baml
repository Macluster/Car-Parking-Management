   M S B A M L   `   `   `  ���� D  @CarParker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarParker	CarParker      CarParker.Parking   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:CarParker     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com    N� Title$  Parking�� � 	Resources ��%    .���� -    ��Name$ MainGrid�����#343f56.+��� $��Slots Available��
 �� Top$ 40�� �� Left$	 550��$��18(����#F9F9F9���#343f56�� -    ��Name$ AvailabeSlotLabel��$�� ��$ 40��$	 670�����#F9F9F9$��18(����#343f56�� $��Slots Filled��$ 40��$	 745��$��18(����#F9F9F9���#343f56�� -   $ FilledSlotLabel��$�� ��$ 40��$	 840�����#F9F9F9$��18(����#343f56�� -    ��Name$ 
OpenMapBtn��$��OpenMap�����#F9F9F9$��50��$	��100��$ 60��$ 20��� -    �Name$ FreeSlotInfoGrid��$	��400��$	��170��$	 200��$ 15�����#F9F9F9 � ShowGridLines$ false��	 � RowDefinitions	 �� $	��150 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 �.+��� -   $ FreeSlotLabel��$	��130��$	��130��$��A1�����#DDDDDD$��50(�$��Center=�$��Center=��� -   $ 	DateLabel��$��1��$
��Date�����#343f56$��25(�$��Center=����#DDDDDD$��5q��� -   $ 	TimeLabel��$��2��$
��Time�����#343f56$��25(�$��Center=����#DDDDDD$��5q��� -	   
 ��Name$
 
Number_Box��$��4��$��32(����#DEEDF0�� -
   $ AlotSlotBtn��$��5��$��	Alot Slot��$��20(����#194350
��������� -    ��Name$ Scrollview1��$��Visible=�$��Hidden=�$��1��$	��630��$
��1070��$	 200��$	 120��.���� .+��� -   $ Scrol1Canvas�����#495464$
��6000��$
��6000���� -   $
 DebugBox��$	��400��$	��600��$��400,200,0,0q�
���   �
��� � �$y�Hidden=�