   M S B A M L   `   `   `  ����D  @TheMovies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TheMovies	TheMovies  5   	       TheMovies.NewMovieWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TheMovies     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��6* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��5* �6   .+�5   
   � $��0��6   $��0��6   
�������.+�5      ��  �� Orientation$ Vertical=�6   $��Center=�60   .+�5      �� -   5        $��TitleLbl��5      $��Center=�6g   $��0,25,0,0q�6�   ��6(   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $��
MovieIdLbl��5      $��Center=�6A   $
��0,25q�6^   ��6*   �� *Id+6^   �� 5      -   5         ��Name$ TitleTB��5       �� TextWrapping$
 Wrap=�6,   $��25��6v   $	��120��6�   $��0,25,0,0q�6�   ��6@   �� *Title+$ 	LostFocus=�6�   �� 5      -   5        $ 
DurationTB��5      $
 Wrap=�6.   $��25��6{   $	��120��6�   $��0,25,0,0q�6�   ��6B   �� *
Duration+$ 	LostFocus=�6�   �� 5      -   5        $��GenreTB��5      $
 Wrap=�6)   $��25��6y   $	��120��6�   $��0,25,0,0q�6�   ��6=   �� *Genre+$ PropertyChanged=�6�   5      5      � 5   
   $��0��6   $��1��6   
�������.+�5      �� $��Center=�6S   $	��Top=�6p   $��	0,114,0,0q�6�   ��6   �� *Title+$ PropertyChanged=�6�   �� 5       $��Center=�6P   $��Center=�6m   ��6   �� *
Duration+$ 	LostFocus=�6m   �� 5!      $��Center=�6S   $��	0,239,0,0q�6p   $	��Top=�6�   ��6   �� *Genre+$ PropertyChanged=�6�   5"      � 5#   
   $��1��6   $��0��6   
������.+�5$      �� $ 
Horizontal=�6   $��Center=�62   .+�5%      �� -   5        $��SaveBtn��5%      $	��Gem��6(    �� 	IsDefault . $��0,0,5,0q�6h   $��75��6y   $��30��6�   ��66   �� *SaveCommand+6�   �� 5&      -   5        $��	CancelBtn��5&   )    �� IsCancel . $��Annuler��6:   $��0,0,5,0q�6n   $��30��6   $��75��6�   ��6L   �� *CancelCommand+6�   5'      5(      � 5)   
   $��1��6   $��1��6   
������6,   5*      5+      