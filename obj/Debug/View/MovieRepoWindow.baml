   M S B A M L   `   `   `  ����D  @TheMovies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TheMovies.ViewTheMovies.View  5   	   $    TheMovies.View.MovieRepoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TheMovies.View     5   	     � Title$  MovieRepoWindow��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $��6* �6   6+   �� 5      $��1* �6   .+�5   
   � $��0��6   
�������.+�5      &   System.Windows.Controls.DataGrid  $	��500��6   $
��Left=�6#      CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  ��5      �� *	MovieRepo+ �� SelectedItem 5      �� *SelectedMovie+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Titel��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 4* 6R   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 68   �� *Title+6R     5      $ Varighed��6)   $ 2* 6X   	 6;   �� *
Duration+6X     5      $ Genre��6)   $ 4* 6R   	 68   �� *Genre+6R   5      5      � 5   
   $��1��6   
������.+�5       �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�62   .+�5!      �� -   5        $��EditMovieBtn��5!   +   $��Rediger��6   $��25��6_   $��75��6k   $��10,0,0,0q�6w   ��6?   �� *EditCommand+6�   �� 5"      -   5        $��	DeleteBtn��5"   (   $
��Slet��6   $��25��6[   $��75��6g   $
��10,0q�6r   ��69   �� *DeleteCommand+6r   �� 5#      -   5        $��NewMovieBtn��5#   +   $��Ny Film��6   $��25��6]   $��75��6i   $
��10,0q�6t   ��6>   �� *
NewCommand+6t   �� 5$      -   5        $��GetRepoMovieBtn��5$   -   $��	Hent film��6   $��25��6d   $��75��6p   $��10,0,0,0q�6{   ��6D   �� *LoadCommand+6{   �� 5%      -   5        $��SaveBth��5%   '   $	��Gem��6   $��25��6V   $��75��6b   $
��10,0q�6m   ��66   �� *SaveCommand+6m   5&      5)      5,      5-      