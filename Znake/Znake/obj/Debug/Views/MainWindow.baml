   M S B A M L   `   `   `  ����@  <Znake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Znake.Auxiliary.ValidationZnake.Auxiliary.Validation  5   	   +clr-namespace:Znake.ModelsZnake.Models  5	   	       Znake.Views.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6c(clr-namespace:Znake.Auxiliary.Validation     5   	   +enumclr-namespace:Znake.Models     5	   	     � Title$  
Znake Game��5   	    � SizeToContent$ WidthAndHeight=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5
   	   �� *Main+   Locator �� Source# [   J� InputBindings 5      �� 5   
   
 �� Key$ Up��65    �� CommandParameter$
 Nord��6>   	 �� Command	 6   �� *NordCommand+6>   �� 5   
   $
 Down��64   $	 Sud��6?   	 6   �� *
SudCommand+6?   �� 5   
   $ Right��66   $ Ouest��6B   	 6   �� *OuestCommand+6B   �� 5   
   $
 Left��64   $	 Est��6?   	 6   �� *
EstCommand+6?   .��5      � 
 � ColumnDefinitions
 5   
   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   .+�5   
   o� $��0��6   $��0��6   .@�5      m� $
��Test��67    m� Command 6   �� *TestCommand+67   5      �� 5   
   $��1��66   $��0��6C   ��6   �� *Grille+��5      �� 5       .R�5!      A�  A� Rows$ 1��6"   5"      ��5$      �� 5%      .R�5&      �� ��6#   �� *	Colonne+��5'      �� 5(      .R�5)   "   A�  A� Columns$ 1��6.   5*      ��5,      �� 5-      .R�5.   "   �� $��1q�6)   ���	#FF000000$	��Top=�50   )   ._�51   &   �� $��25��6,   $��25��68   $��0q�6C   ��52   *   �� 53   .    �� 
TargetType" ��64    �� Triggers 54   2   �� 55   6      Znake.Models.Etat   Pomme �� Value# Z 6`    �� Binding 6B   ��  �� Path$
 Etat�.a�56   :   ��  �� Property � �� �� Value$# ../Ressources/apple_2-512.png��6S   57   7   �� 58   6      Serpent# Z 6`    6B   �� $
 Etat�.a�59   :   ��  � ��$! ../Ressources/carrevert.jpg��6S   5:   7   5<   /   5>   '   5?   #   5@      5B      5C      5E      5F      5G      