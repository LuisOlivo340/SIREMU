   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5          SiReMu.ColaDeReproduccion   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� Title$ ListaReproducción��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $��Cola de reproducción��6   $��Center=�6/   $��0,10,0,0q�6L   $	��Top=�6^   $��48(�6v   $��0q�6�   �� 5   
   $��Reproduciendo ahora��6   $��Center=�6.   $��	0,110,0,0q�6K   $	��Top=�6^   $��0q�6v   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgCancionActual��5      $��Center=�6,   $��
0,140,0,30q�6I   $	��Top=�6]      AutoGenerateColumns$ False��6u      CanUserAddRows$ False��5         
IsReadOnly$
 True��6*      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5        	NoPadding,  &System.Windows.Controls.DataGridColumn   	CellStyle# [ 6)   	   CellTemplate	 5      �� 5      .R�5      �� $��0q�65   $��25��6A   $��25��6L   
������ $��0q�6q   
������ 3  -MaterialDesignThemes.Wpf.ButtonProgressAssist
   IndicatorBackground

 ����    IndicatorForeground
 ��� �   IsIndicatorVisible$
 True��5   %      IsIndeterminate$
 True��6c   
 � Tag 5   %   �� 5      5      5       0  *System.Windows.Controls.DataGridTextColumn  5!         Header$ Título��6%      MinWidth$	 200Q�65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6D      CanUserReorder$ False��6P     NoFocus# [ 6�      
Foreground
 ��� �1  +System.Windows.Controls.DataGridBoundColumn   Binding 6g   �� *Nombre+6�     5"      $ Artísta��6%   $	 150Q�66   $	 200 6E   $ False��6Q   # [ 6�   
 ��� � 6h   �� *	Artista+6�     5#      $ Álbum��6%   $	 150Q�64   $	 200 6C   $ False��6O   # [ 6�   
 ��� � 6f   �� *Album.Nombre+6�     5$      $ Género��6%   $	 100Q�65   $	 150 6D   $ False��6P   # [ 6�   
 ��� � 6g   �� *Genero+6�     5%      $ 	Duración��6%   $ 70Q�67   $	 100 6E   $ False��6Q   # [ 6�   
 ��� � 6h   �� *
Duracion+6�   5'      �� 5(   
   $��A continuación��6   $��Center=�6)   $��	0,290,0,0q�6F   $	��Top=�6Y   $��0q�6q     5)   
   -   5        $ dgCanciones��5)      $��Center=�6(   $��
0,320,0,30q�6E   $	��Top=�6Y   $ False��6q   $ False��5*      $
 True��6*      SelectionMode$ Extended=�6<    5+        5,      # [ 6)   	 5-      �� 5.      .R�5/      �� -   5        $��0q�5/   5   $��25��6A   $��25��6L     MouseOverVisibility#��[ 6r    6%   �� .��50   "   '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$
 Play=�6:   $��25��6F   $��25��6Q   
�������6]   51      52      54        55      $ Título��6%   $	 200Q�65   $	 250 6D   $ False��6P   # [ 6�    6g   �� *Nombre+6�     56      $ Artísta��6%   $	 150Q�66   $	 200 6E   $ False��6Q   # [ 6�    6h   �� *	Artista+6�     57      $ Álbum��6%   $	 150Q�64   $	 200 6C   $ False��6O   # [ 6�    6f   �� *Album.Nombre+6�     58      $ Género��6%   $	 100Q�65   $	 150 6D   $ False��6P   # [ 6�    6g   �� *Genero+6�     59      $ 	Duración��6%   $ 70Q�67   $	 100 6E   $ False��6Q   # [ 6�    6h   �� *
Duracion+6�   5;      5=       � 	Resources 5>        cmCancionActual m� Icon  cmClickDerecho��%�  &	       &	     �� 5?   
   .@�5@      m� -   5        $��Me gusta��5@       5A      	  5B      $ 	HeartPlus=�6.   
�������6?   5D      m� 5E      $��Agregar a playlist��6    5F      	  5G      $ PlaylistPlus=�6.   
�������6B   5I      5J      �� 5L   
   .@�5M      m� -   5        $��Sacar de la lista��5M       5N      	  5O      $ DeleteEmpty=�6.   
�������6A   5Q      �� 5R      m� 5S      -   5        $��Me gusta��5S       5T      	  5U      $ 	HeartPlus=�6.   
�������6?   5W      m� 5X      $��Agregar a playlist��6    5Y      	  5Z      $ PlaylistPlus=�6.   
�������6B   5\      5]      5^      5_      