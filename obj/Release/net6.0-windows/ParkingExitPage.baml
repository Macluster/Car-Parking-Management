   M S B A M L   `   `   `  ���� D  @CarParker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarParker	CarParker      CarParker.ParkingExitPage   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:CarParker       N� Title$  ParkingExitPage�� � 	Resources  
  Border �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%~   &	        �� " ��.���  � �� �� " ��.R��� #��z��$ 20��._��� #��z��$��Center=�$��Center=�
�������.��� -    �Name$ MainGrid������  �� Color$ #343f56��.+��� .+��� -   	 ��Name$	 
ShowMapBtn��$��40��$��90��$��
600,30,0,0q����#ff7171$��Show Map��
�������$��0q�#��[  �� �� $	��330��$	��210��$��150,200q����#ff8882$ 20��
 J� Effect
 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 30Q�   Opacity$	 0.2Q�   	Direction$	 300Q�._��� ���#ff8882$	��300��$	��200��.+��� $��Search for slot��$��0,10,0,0q�$��18(�$��Center=�
��������� -    ��Name$ SearchEditor��$	��120��$��0,10,0,0q�$	��100��$��75(�$��0q��� $��
Slot State��$	��200��$��20(�$��Center=�
���������  �� Orientation$ 
Horizontal=�.+��� $��Customer Number��
�������$	��110���� $��:��$��15(�
��������� -    ��Name$ CustomerNumeberValue��
��������� $ 
Horizontal=�.+��� $��Parked Time��
�������$	��110���� $��:��$��15(�
��������� -   $ SearchPanelParkedTime��
��������� $��
10,10,10,1q�$ 20�����#eec4c4._��� -   $	 	SearchBtn��$��40��$	��140�����#eec4c4$��Search��$��0q�
��������� $	��290��$	��470�����#28b5b5$��490,200,0,0q�$ 30��
   $ 30Q�$	 0.2Q�$	 300Q�._��� $	��250��$	��450�����#28b5b5.+��� $��	Exit Card��
�������$��25(�$��40��
������ $��0q�$��Center=�$��0,10,0,0q��� -   $ 
Sloteditor��$	��120��$	��155��$��	0,30,0,15q�$��90(�
�������$��Center=�$��0q��� $ 
Horizontal=�.+��� $��Parked Time           ��
�������$��15(�$	��130���� $��:��$��17(�
��������� -   $ ParkedTimeLabel��
�������$��15(��� $ 
Horizontal=�.+��� $��Exit Time                ��
�������$��15(�$	��130���� $��:��$��17(�
��������� -	   $ ExitTimeLabel��
�������$��15(��� $ 
Horizontal=�.+��� $��Total Time Parked ��$��15(�
�������$	��130���� $��:��$��17(�
��������� -
   $ TimeTakeValue��$��15(�
��������� $ 
Horizontal=�.+��� $��Customer Number��$��13(�
�������$	��130��$��Center=��� $��:��$��17(�
��������� -   $ CustomerNumberLabel��$��15(�
��������� $ 
Horizontal=�.+��� -   $ 	TestLabel��$��Total Cost   :��$��25(�
��������� -   $ 	CostLabel��$��25(�
��������� $��55��$ 20�����#a7d0cd._��� -   $	 FreeTheSlotBtn��$��50��$	��200��$��Free The Slot�����#a7d0cd
�������$��0q�$��20(��� $	��370��$	��210��$��920,200q����#ff8882$ 20��
   $ 30Q�$	 0.2Q�$	 300Q�._��� ���#ff8882$	��350��$	��200��.+��� $��Edit Alotted Slot��$��0,10,0,0q�$��18(�$��Center=�
��������� $	��120��$��0,10,0,0q�$	��100��$��75(�$��0q��� $ 
Horizontal=�$��30,10,20,10q�.+��� $��Mark as Free��$��30��$��70��$��10(�$��0,0,5,0q����#343f56
�������$��0q��� $��Mark as Filled��$��30��$��70�����#343f56$��10(�
�������$��0q��� $ 
Horizontal=�.+��� $��Customer Number��
�������$	��110���� $��:��$��15(�
��������� 
��������� $ 
Horizontal=�.+��� $��Parked Time��
�������$	��110���� $��:��$��15(�
��������� 
��������� $��
10,10,10,5q�$ 20�����#eec4c4._��� $��40��$	��140�����#eec4c4$
��Edit��$��0q�
��������� -    ��Name$ 
ScrollView��
�������$��0��$
��1200��$��Visible=�$��
50,100,0,0q�.���� .+��� -    ��Name$ Scrol1Canvas��
�������$
��6000��$
��6000��