   M S B A M L   `   `   `  ����   
SmallWorld    WpfApp.FenetreCarte   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  	TourDeJeu��$	��750��$
��1191�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � 	Resources    	menuStyle �� 
TargetType �� Property �� Value��%   &	        �� " ��.���  � ��$ 24(���  � ��$ Ringbearer Moyen)���  � ��$
 Bold"���  � ��$ 10q�����  �� ImageSource$# /Resources/background_jeu.jpg��.��]� .+�� -   $��	barreInfo��$��Right=�$	��220������  �� Color �� 	 �� A$		 100��
 �� R$	
 255�� �� G$	 255�� �� B$	 255�� � ColumnDefinitions �� $	��14* � � RowDefinitions �� $��5* �� -   $��
barrePerso��$
��Left=�$	��250��$��0,210,0,290q�����  �� $		 100��$	
 255��$	 255��$	 255��.+�� $��1��$��2�� �� $��5* ��� $��5* � �� $
��0.5* ��� $��1* �.+��� -   $��pseudoJ1��$��0��$��0��$��Center=�$��Center=�
Joueur 2�� -   $��infoJ1��$��0��$��1��$��Center=�$	��Top=� �� TextAlignment$
 Left=��� -   $��pseudoJ2��$��0��$��1��$��Center=�$��Center=�
Joueur 2�� -   $��infoJ2��$��1��$��1��$��Center=�$	��Top=�$
 Left=��  �� $��2* ��� $	��15* ��� $��3* �.+��� -   $
��Menu��$��0��$��0,0,0,0q�#��[  $��Center=�$��Stretch=�$ Center=�$��70���� $��1��$
��Auto=�$
��Auto=�.���� -	   $��mapGrid�� � LayoutTransform ��  �� CenterX$ 0Q� �� CenterY$ 0Q� �� ScaleX ��  �� ElementName$ uiScaleSlider�� �� Path$ Value� �� ScaleY �� $ uiScaleSlider��$ Value�� $��2��.+��� -
    ��Name$ FinTour��|�.   � Cursor$
 Hand��$��Center=�$��Center=�$	��180��$��152,46,451,2q�$��60��.��
Fin tour