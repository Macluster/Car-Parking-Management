   M S B A M L   `   `   `  ���� D  @CarParker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CarParker.Admin_PagesCarParker.Admin_Pages  &     CarParker.Admin_Pages.ReportPage   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:CarParker.Admin_Pages       N� Title$  
ReportPage��.��� ���#495464.+�� $	��300��$	��200��$��-800,20,0,0q�
�����_� � RowDefinitions �� $��40 ��� $	��170 ��� $��40 ��� $��50 �.+��� $��Select Date��$��0��
�������$��20(�$��Center=�&   System.Windows.Controls.Calendar  -     Name$ Calender��$��1���� -    ��Name$ 	DateLabel��$��2��$��-��
�������$��20(�$��Center=�$��Center=��� -    ��Name$ SearchButton��$��3��$��Search��
���W�.�
�������$��20(�� $	��400��$	��720�����#495464$��	190,0,0,0q� � ColumnDefinitions �� $	��120 ��� $	��120 ��� $	��120 ��� $	��120 ��� $	��120 ��� $	��120 � �� $��40 ��� $��* �.+��� -   $ TestName��$��Phone Number��
�����_�$��Center=�$��Center=�$��5q�
��������� $��1��$��Parking Time��
�����_�$��Center=�$��Center=�$��5q�
��������� $��2��$��	Exit Time��
�����_�$��Center=�$��Center=�$��5q�
��������� $��3��$
��Date��
�����_�$��Center=�$��Center=�$��5q�
��������� $��4��$��Map Name��
�����_�$��Center=�$��Center=�$��5q�
��������� $��5��$
��Slot��
�����_�$��Center=�$��Center=�$��5q�
��������� $��1��$��6�����#495464$��Hidden=�.��� -    �Name$ ContentGrid�� �� $	��120 ��� $	��120 ��� $	��120 ��� $	��120 ��� $	��120 ��� $	��120 � 