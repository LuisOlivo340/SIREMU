   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5          SiReMu.MiMusicaPersonal   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� Title$ Mi música personal��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $��Mis música personal��6   $��Center=�6.   $��0,30,0,0q�6K   $	��Top=�6]   $��48(�6u   $��0q�6�   �� 5   
   -   5         ��Name$ btReproducir��5      $
��Left=�6'   $��100,130,0,0q�6B   $	��Top=�6W   $��
Reproducir��6o   
���� ��
�������$��20(�5   ?   $	��150��6M   $��40��6Y   �� 5   
   -   5        $ btVerAlbumes��5      $
��Left=�6'   $��880,130,0,0q�6B   $	��Top=�6W   $��Albums��6o   
������ 
�������$��20(�5   7   $	��150��6E   $��40��6Q   �� 5   
   $��Center=�6   $��
0,200,0,30q�62   $	��Top=�6F    �� Orientation$ 
Horizontal=�6^   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgCanciones��5      $��Center=�6,   $��0,0,0,0q�6I   $	��Top=�6Z      AutoGenerateColumns$ False��6r      CanUserAddRows$ False��5         
IsReadOnly$
 True��6*   	   SelectionMode$	 Extended=�6<   
   CanUserReorderColumns$
 False��6~      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5        	NoPadding,  &System.Windows.Controls.DataGridColumn   	CellStyle# [ 6-      CellTemplate 5      �� 5      .R�5   "   �� -   5        $��0q�5   9   $��25��6E   $��25��6P     MouseOverVisibility#��[ 6v   
 � Tag 6)   �� .��5   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Play=�6>   $��25��6J   $��25��6U   
�������6a   5    #   5!      5#      0  *System.Windows.Controls.DataGridTextColumn  5$         Header$ Título��6)      MinWidth$	 200Q�69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6H     NoFocus# [ 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Nombre+6o     5%      $ Artísta��6)   $	 150Q�6:   $	 200 6I   # [ 6q    6U   �� *	Artista+6q     5&      $ Álbum��6)   $	 150Q�68   $	 200 6G   # [ 6t    6S   �� *Album.Nombre+6t     5'      $ Género��6)   $	 100Q�69   $	 150 6H   # [ 6o    6T   �� *Genero+6o     5(      $ 	Duración��6)   $ 70Q�6;   $ 80 6I   # [ 6q    6T   �� *
Duracion+6q   5*      �� 5+      -   5         ��Name$ lvAlbums��5+       �� SelectionMode$ Single=�6)   $��Center=�6@   $��0,0,0,0q�6]   $	��Top=�6n   $y�	Collapsed=�5,      ��5-      �� 5.      .R�5/      A�  A� Columns$ 5��6&   64   50      ��52      �� 53      .R�54      �� $ 
Horizontal=�6%   .+�55      �� $��70��6C   $��70��6N   ��6$   �� *Ilustracion+6N   �� 56      $ Vertical=�6)   $��Center=�6@   .+�57   "   �� $	��200��6M   $��10,0,0,0q�6Y   $��16(�6k   ��6,   �� *TituloPrincipal+6k   �� 58   "   $	��200��6N   $��	10,10,0,0q�6Z    J� Opacity$	 0.8Q�6m   ��6,   �� *TituloSecundario+6m   59      5:      5;      5=      �� 5>      -   5         ��Name$ panelCanciones��5>      $ Vertical=�61   $��	50,0,50,0q�6H   .+�5?      �� -   5        $ btcancionesPersonales��5?      $��Center=�68   $��0,0,0,0q�6U   $	��Top=�6f   $��Subir canciones propias��6~   
����=H�
�������$��20(�5@   M   $��40��6[   �� 5A      $��	Artista: ��6   $
��Left=�6,   $��	10,50,0,0q�6G   $	��Top=�6Z   �� 5B      -   5         ��Name$ 
cbArtistas��5B      $
��Left=�6/   $��10,5,0,0q�6J   $	��Top=�6\   $	��300��6t   �� 5C      $��	Género: ��6   $
��Left=�6+   $��	10,50,0,0q�6F   $	��Top=�6Y   �� 5D      -	   5        $ 	cbGeneros��5D      $
��Left=�6.   $��10,5,0,0q�6I   $	��Top=�6[   $	��300��6s   5E      5F      5G       � 	Resources 5I        cmClickDerecho m� Icon��%�  &	       �� 5J   
   .@�5K      m� -
   5        $��Agregar a la cola��5K       5L        5M      $ PlaylistPlay=�6.   
�������6B   5O      �� 5P      m� 5Q      -   5        $��Me gusta��5Q       5R        5S      $ 	HeartPlus=�6.   
�������6?   5U      m� 5V      -   5        $ ��Generar estación de radio��5V       5W        5X      $ Radio=�6.   
�������6;   5Z      m� 5[      -   5        $��Descargar canciones��5[       5\        5]      $ Download=�6.   
�������6>   5_      m� 5`      $��Agregar a playlist��6    5a        5b      $ PlaylistPlus=�6.   
�������6B   5d      5e      5f      5g      