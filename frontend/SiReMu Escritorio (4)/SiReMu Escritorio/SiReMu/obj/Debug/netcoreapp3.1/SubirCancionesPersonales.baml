   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5      %    SiReMu.SubirCancionesPersonales   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� Title$  Subir canciones personales��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� -   5         ��Name$ lbTitulo��5      $ ��Subir canciones personales��6"   $��Center=�6G   $��0,30,0,0q�6d   $	��Top=�6v   $��48(�6�   
�������6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $	��Top=�6K   $��
0,150,50,0q�6c   .+�5      �� $ Vertical=�6   .+�5      �� -   5        $��Subir canciones��5      $��Center=�63   $��0,0,0,0q�6P   $	��Top=�6a   $��40��5      
���� ��
�������$��20(�6g   �� 5      -   5        $��Cargar canciones��5      $��Center=�64   $��0,50,0,0q�6Q   $��35��5      
����=H�
�������$��16(�6g   �� 5      -   5         ��Name$ imgIlustracion��5      $��0,50,0,0q�60   $	��250��6B   $	��250��6N   $
��Left=�6[   $	��Top=�6v   $��/Recursos/logoOscuro.png��6�   �� 5      -   5        $��Cargar imagen��5      $��Center=�61   $��0,30,0,0q�6N   $	��Top=�6`   $	��150��5      $��35��6%   
����=H�
�������$��16(�6t   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgCanciones��5      $��50,0,0,0q�6,   $��Center=�6>   $	��Top=�6[      AutoGenerateColumns$ False��6s      CanUserAddRows$ False��5      	   
IsReadOnly$
	 True��6*   
   SelectionMode$
 Extended=�6<      CanUserDeleteRows$
 True��6U      CanUserReorderColumns$ False��6n      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Título��6)      MinWidth$	 200Q�69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6H     NoFocus   	CellStyle# [ 6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Cancion.Nombre+6w     5!      $ Artísta��6)   $	 150Q�6:   $	 200 6I   # [ 6y    6U   �� *Cancion.Artista+6y     5"      $ Álbum��6)   $	 150Q�68   $	 200 6G   # [ 6|    6S   �� *Cancion.Album.Nombre+6|     5#      $ Género��6)   $	 100Q�69   $	 150 6H   # [ 6w    6T   �� *Cancion.Genero+6w     5$      $ 	Duración��6)   $ 70Q�6;   $ 80 6I   # [ 6y    6T   �� *Cancion.Duracion+6y   5&      5'      5(      5)      