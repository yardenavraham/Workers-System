   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	   clr-namespace:PLWPFPLWPF  5   	       PLWPF.QueriesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	   &local1clr-namespace:PLWPF     5   	     � Title$  QueriesWindow��5
   	   $	��500��6   $
��1200��6,    � 	Resources 5         styleButton �� 
TargetType �� Property �� Value �� DataType  BE.Child   PLWPF.ChildUserControl  BE.Nanny   PLWPF.NannyUserControl  BE.Contract   PLWPF.contractUserControl��%�  &	        (��     5      *, +)(�� �    5      *, +)(�� �    5      *, +)�� 5   
   " ��6$   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Segoe Print)�6+   �� 5       � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��
 �����6,   5      �� 5   
   "  6   .R�5      �� $��1q�6   ���	#FF349E9E$��2��6A   ._�5        5      5      �� 5   
   "  6   .R�5      �� $��1q�6   ���	#FFAC499A$��2��6A   ._�5        5      5      �� 5   
   "  6   .R�5      �� $��1q�6   ���	#FFAC499A$��2��6A   ._�5         5!      5"      5#      .��5$      �  � ColumnDefinitions 5%   
   �� 5&      $
��761* �6   �� 5'      $	��31* �6    � RowDefinitions 5*   
   �� 5+      $	��18* �6   �� 5,      $	��49* �6   .+�5.   
   �� -   5         ��Name$ ChildrenNoNanny��5.      $��Children who needs nanny��6*   $
��Left=�6M   $��	26,20,0,0q�6h   $	��Top=�6{   $	��213��6�   $��54��6�   #��[  6�   �� 5/   
   -   5        $ BestNannies��5/      $��The best��6&   $
��Left=�69   $��
281,42,0,0q�6T   $	��Top=�6h   $	��102��6�   $��32��6�   #��[  6�   $��11(�6�   �� 51   
   -   5        	 ��Name$
	 page��51      $��1��6'   
���   �$��2q�6H   $��2��6\   �� 52   
   -   5        
 ��Name$
 idMomComboBox��52      $
��Left=�6*   $��
386,79,0,0q�6E   $	��Top=�6Y   $	��120��6q   {�.  $��22��6�   �� 53   
   $��choose a mother:��6   $
��Left=�6+   $��
279,74,0,5q�6F   $	��102��6Z   �� 54   
   -   5        $ nanniesByAgeChildren��54      $&�� Group Nannies By Age of Children��6/   $
��Left=�6Z   $��
533,20,0,0q�6u   $	��Top=�6�   $	��249��6�   $��54��6�   #��[  6�   $��2��6  �� 55   
   -   5        $
 minOrMax��55      $
��Left=�6%   $��
640,79,0,0q�6@   $	��Top=�6T   $	��120��6l   $��22��6�   {�.  .@�56      �� $��min age��6   �� 57      $��max age��6   �� 58      $��min age sort��6   �� 59      $��max age sort��6   5:      �� 5<   
   -   5         ��Name$ contractByDistance��5<      $!��Group contracts by distance��6,   $
��Left=�6R   $��	811,5,0,0q�6m   $	��Top=�6�   $	��213��6�   $��32��6�   $��Segoe Print)�6�   
�������$��14(�6�   $
��Bold"�6�   �� 5=   
   $��min or max:��6   $
��Left=�6&   $��
560,75,0,0q�6A   $	��Top=�6U   $��75��6m   $��26��6x    J� RenderTransformOrigin$ 	0.48,-0.5&�6�   �� 5>   
   $#��Find the best nannies for you��6   $��Center=�68   $��284,0,643,89q�6U   $	��218��6k   $��Segoe Print)�6w   
�������$��14(�6�   $
��Bold"�6�   �� 5?   
   -   5        $  BestNannies_WithCompromise��5?      $��With Compromise��65   $
��Left=�6O   $��
397,42,0,0q�6j   $	��Top=�6~   $	��105��6�   $��32��6�   #��[  6�   $��11(�6�   6�   �� 5@   
   -	   5        $ contractByDistanceSort��5@      $
��Sort��61   $
��Left=�6@   $��
837,45,0,0q�6[   $	��Top=�6o   $��75��6�   #��[  6�   6�   �� 5A   
   -
   5        $ contractByDistanceNotSort��5A      $��Not Sort��64   $
��Left=�6G   $��
940,45,0,0q�6b   $	��Top=�6v   $��75��6�   #��[  6�   6�   5B      5C      