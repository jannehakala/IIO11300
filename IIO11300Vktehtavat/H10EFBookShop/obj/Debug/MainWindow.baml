   M S B A M L   `   `   `  ����H  DH10EFBookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:H10EFBookShopH10EFBookShop  5   	       H10EFBookShop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:H10EFBookShop     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��725��6)   .��5	      � .+�5
   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Left=�6   .+�5      �� -   5         ��Name$ btnGetCustomers��5      $��20��66   $��10q�6B   .��6l   Hae asiakkaat EF6~   �� 5      -   5        $ getGetBooks��5      $��20��62   $��
10,0,10,10q�6>   .��6l   Hae kirjat EF6{   �� 5      -   5         ��Name$ cbCountries��5      $��26��6|   $��5,5,5,0q�6�   $y�Hidden=�6�   ��6d   �� 6�   5      �� 5      
��� ���$��60��61   $	��160��6<   .+�5      �� $��0,0,0,0q�6    Tuote68   �� 5      $��0,0,0,5q�6    Nimi67   �� 5      $��0,0,0,5q�6    
Kirjailija6=   �� 5      $��0,0,0,5q�6    Maa66   �� 5      $��0,0,0,5q�6    Vuosi68   5      �� 5      -   5         ��Name$ spBook��5   =   $	��200��6   
��� ���.+�5      �� -   5         ��Name$ tbBookAndWriter��5       $��0,0,0,0q�6h   ��69   ��  �� Path$ DisplayName� �� Mode$ OneWay=�6{   �� 5      -   5         ��Name$ txtBook��5      $��0,0,0,3q�6p   ��6/   �� $
 name�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5      -   5        $ 	txtWriter��5      $��0,0,0,3q�6s   ��61   �� $ author�$	 PropertyChanged=�6�   �� 5      -   5        $ 
txtCountry��5      $��0,0,0,3q�6P   ��62   �� $ country�6c   �� 5      -	   5        $ txtYear��5      $
��Left=�6J   $��50��6e   $��0,0,0,3q�6p   ��6/   �� $
 year�6�   �� 5      -
   5        $ btnSave��5      .��6D   
Tallenna6N   �� 5      -   5        $ btnNew��5      .��6B   Uusi6H   �� 5       -   5        $ 	btnDelete��5       .��6H   Poista6P   5!      �� 5"      
����� �$��60��6/   $	��160��6:   .+�5#      �� $��0,0,0,0q�6    	asiakas6:   �� 5$      $��0,0,0,5q�6    	etunimi6:   �� 5%      $��0,0,0,5q�6    
sukunimi6;   �� 5&      $��0,0,0,5q�6    	tilauksia6<   5'      �� 5(      -   5        $ 
spCustomer��5(   ;   $	��200��6   
����� �.+�5)      �� $��0,0,0,0q�6O   ��6    �� $ DisplayName�$ OneWay=�6b   �� 5*      $��0,0,0,3q�6d   ��6   �� $ 	firstname�$	 PropertyChanged=�6w   �� 5+      $��0,0,0,3q�6b   ��6   �� $ lastname�$	 PropertyChanged=�6u   �� 5,      $��0,0,8,3q�6L   $��20��6]   $
��Left=�6h   ��6   �� $ 
OrderCount�$ OneWay=�6h   �� 5-      -   5        $ btnGetOrders��5-      .��6O   Hae asiakkaan tilaukset6h   5.      5/      �� 50      .+�51      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 dgBooks��51         AutoGenerateColumns . $	��250��6G   $
��Auto��6T   $
��Left=�6a   ��. ��6�   �� 6�   52      53      54      55      