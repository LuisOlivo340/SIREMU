   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5          SiReMu.VerAlbum   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� Title$ ListaReproducción��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� -   5         ��Name$ lbAlbum��5      $��Desconocida��6!   $
��Left=�67   $��
250,10,0,0q�6R   $	��Top=�6f   $��48(�6~   $��0q�6�   �� 5   
   -   5         ��Name$ imgIlustracion��5      $	��200��6(   $	��200��64   $
��Left=�6A   $	��Top=�6\   $��	30,25,0,0q�6t   $��/Recursos/logoOscuro.png��6�   �� 5   
   -   5        $ 	lbCreador��5      $
��Left=�6#   $��
250,85,0,0q�6>   $	��Top=�6R   $��0q�6j   �� 5   
   -   5        $ lbCompañia��5      $
��Left=�6$   $��250,130,0,0q�6?   $	��Top=�6T   $��0q�6l   $��18(�6x   �� 5   
   -   5        $ lbLanzamiento��5      $
��Left=�6'   $��250,160,0,0q�6B   $	��Top=�6W   $��0q�6o   $��16(�6{   �� 5   
   -   5         ��Name$ btReproducir��5      $
��Left=�6'   $��250,198,0,0q�6B   $	��Top=�6W   $��
Reproducir��6o   
���� ��
�������$��20(�5   <   $	��150��6J   $��40��6V   �� 5   
   -   5        $ 
btOpciones��5      $
��Left=�6%   $��420,198,0,0q�6@   $	��Top=�6U   
����  �
�������$��20(�5   $   $��50��62   $��40��6=   $��0q�6I   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Menu=�6&   $��30��62   $��30��6=   
�������6I   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgCanciones��5      $��Center=�6(   $��
0,250,0,30q�6E   $	��Top=�6Y      AutoGenerateColumns$ False��6q   	   CanUserAddRows$	 False��5      
   
IsReadOnly$

 True��6*      SelectionMode$ Extended=�6<      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         	NoPadding,  &System.Windows.Controls.DataGridColumn   	CellStyle# [ 6)      CellTemplate 5!      �� 5"      .R�5#      �� -	   5        $��0q�5#   5   $��25��6A   $��25��6L     MouseOverVisibility#��[ 6r   
 � Tag 6%   �� .��5$   "     $
 Play=�6:   $��25��6F   $��25��6Q   
�������6]   5%      5&      5(      0  *System.Windows.Controls.DataGridTextColumn  5)         Header$ Título��6%      MinWidth$	 200Q�65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6D      CanUserReorder$ False��6P     NoFocus# [ 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6g   �� *Nombre+6�     5*      $ Artísta��6%   $	 150Q�66   $	 200 6E   $ False��6Q   # [ 6�    6h   �� *	Artista+6�     5+      $ Género��6%   $	 100Q�65   $	 150 6D   $ False��6P   # [ 6�    6g   �� *Genero+6�     5,      $ 	Duración��6%   $ 70Q�67   $ 80 6E   $ False��6P   # [ 6�    6g   �� *
Duracion+6�     5-      $ Likes��6%   $ 60Q�64   $ 70 6B   $ False��6M   # [ 6~    6d   �� *Likes+6~   5/      50       � 	Resources 52        cmMenuOpciones m� Icon  cmClickDerecho��%�  &	       &	 �     �� 53   
   .@�54      m� -
   5        $��Agregar album a la cola��54       55        56      $ PlaylistPlay=�6.   
�������6B   58      �� 59      5:      �� 5<   
   .@�5=      m� -   5        $��Agregar a la cola��5=       5>        5?      $ PlaylistPlay=�6.   
�������6B   5A      �� 5B      m� 5C      -   5        $��Me gusta��5C       5D        5E      $ 	HeartPlus=�6.   
�������6?   5G      m� 5H      -   5        $ ��Generar estación de radio��5H       5I        5J      $ Radio=�6.   
�������6;   5L      m� 5M      -   5        $��Descargar canciones��5M       5N        5O      $ Download=�6.   
�������6>   5Q      m� 5R      $��Agregar a playlist��6    5S        5T      $ PlaylistPlus=�6.   
�������6B   5V      5W      5X      5Y      