   M S B A M L   `   `   `  ����C  ?H5Movies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:H5MoviesH5Movies  5   	       H5Movies.Movies2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:H5Movies     5   	     � Title$  Movies2��5   	   $	��300��6   $	��420��6&    � 	Resources 5	         	movieName �� XPath��%y   &	        �� 5
   
   .R�5      �� $	��200��64   
����ح�$��10(�6W   ��6   �� $ @Name��6W   5      5      .��5      �  � DataContext 5   
   � 5      -   5        	xdpMovies�� � Source$ d:\\Movies.xml?�5   1    � XPath$ /Movies/Movie��6I   6a   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ lbMovies��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6D   #��[  6i   	 �� SelectionMode$	 Single=�6�   $��10,10,10,10q�6�   ��6,   �� 6�   5      �� 5      $ Vertical=�6   .+�5      �� $��0,10,0,0q�6   
Elokuva:68   �� 5      -   5        
 ��Name$
 txtMovieName��5      $	��130��6M   ��60   �� $ @Name��6[   �� 5      
Ohjaaja:6&   �� 5      -   5        $
 txtDirectorName��5      $	��130��6T   ��63   �� $ 	@Director��6b   �� 5      Maa:6"   �� 5      -   5        $
 txtCountryName��5      $	��130��6R   ��62   �� $ @Country��6`   �� 5      	Katsottu:6'   �� 5      -   5         ��Name$ 
chkWatched��5   @    d� 	IsChecked 6   �� $ @Checked��6V   �� 5      -   5         ��Name$ btnAddMovie��5      $��Lisää elokuva��6.   $��0,5,0,0q�6F   6s   �� 5       -   5        $ btnDeleteMovie��5       $��Poista elokuva��61   $��0,5,0,0q�6J   6z   �� 5!      -	   5        $ btnSaveChanges��5!      $��Tallenna muutokset��61   $��0,5,0,0q�6N   6~   5"      5#      5$      5%      