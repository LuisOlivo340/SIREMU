   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5          SiReMu.VentanaBusqueda   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $��	Canciones��6   $
��Left=�6$   $��	30,30,0,0q�6?   $	��Top=�6R   $��0q�6j   �� 5   
   $
��Left=�6   $��
30,60,30,0q�62   $	��Top=�6F   1  +MaterialDesignThemes.Wpf.ScrollViewerAssist   IsAutoHideEnabled$
 True��5          CornerRectangleVisibility$ 	Collapsed=�6H   $
��Auto=�5      $��Disabled=�6M   .��5      �� -   5         ��Name$ lvCanciones��5       �� SelectionMode$ Single=�6,   ��5      �� 5      .R�5      A�  A� Rows$ 2��6&   61   5      ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� $��70��6C   $��70��6N   ��6$   �� *Ilustracion+6N   �� 5      $ Vertical=�6)   $��Center=�6@   .+�5    "   �� $	��200��6M   $��10,0,0,0q�6Y   $��16(�6k   ��6,   �� *TituloPrincipal+6k   �� 5!   "   $	��200��6N   $��	10,10,0,0q�6Z    J� Opacity$	 0.8Q�6m   ��6,   �� *TituloSecundario+6m   5"      5#      5$      5&      5'      �� 5)   
   $��Albums��6   $
��Left=�6!   $��
30,300,0,0q�6<   $	��Top=�6P   $��0q�6h   �� 5*   
   $
��Left=�6   $��
30,330,0,0q�62   $	��Top=�6F   $
 True��5+      $ 	Collapsed=�6H   $
��Auto=�5,      $��Disabled=�6M   .��5-      �� -   5        $ lvAlbums��5-      $ Single=�6)   ��5.      �� 5/      .R�50      A� $ 2��6&   62   51      ��53      �� 54      .R�55      �� $ 
Horizontal=�6%   .+�56      �� $��70��6C   $��70��6N   ��6$   �� *Ilustracion+6N   �� 57      $ Vertical=�6)   $��Center=�6@   .+�58   "   �� $	��200��6M   $��10,0,0,0q�6Y   $��16(�6k   ��6,   �� *TituloPrincipal+6k   �� 59   "   $	��200��6N   $��	10,10,0,0q�6Z   $	 0.8Q�6m   ��6,   �� *TituloSecundario+6m   5:      5;      5<      5>      5?      �� 5A   
   $��Listas de reproducción��6   $
��Left=�61   $��
30,600,0,0q�6L   $	��Top=�6`   $��0q�6x   �� 5B   
   $
��Left=�6   $��30,630,0,30q�62   $	��Top=�6G   $
 True��5C      $ 	Collapsed=�6H   $
��Auto=�5D      $��Disabled=�6M   .��5E      �� -   5        $ lvListas��5E      $ Single=�6)   ��5F      �� 5G      .R�5H      A� $ 2��6&   62   5I      ��5K      �� 5L      .R�5M      �� $ 
Horizontal=�6%   .+�5N      �� $��70��6C   $��70��6N   ��6$   �� *Ilustracion+6N   �� 5O      $ Vertical=�6)   $��Center=�6@   .+�5P   "   �� $	��200��6M   $��10,0,0,0q�6Y   $��16(�6k   ��6,   �� *TituloPrincipal+6k   �� 5Q   "   $	��200��6N   $��	10,10,0,0q�6Z   $	 0.8Q�6m   ��6,   �� *TituloSecundario+6m   5R      5S      5T      5V      5W      5Y      	 � 	Resources	 5[        cmClickDerecho
 m� Icon'  !MaterialDesignThemes.Wpf.PackIcon   Kind��%�  &	       �� 5\   
   .@�5]      m� -   5        $��Agregar a la cola��5]      
 5^        5_      $ PlaylistPlay=�6.   
�������6B   5a      �� 5b      m� 5c      -   5        $��Me gusta��5c      
 5d        5e      $ 	HeartPlus=�6.   
�������6?   5g      m� 5h      -   5        $ ��Generar estación de radio��5h      
 5i        5j      $ Radio=�6.   
�������6;   5l      m� 5m      -   5        $��Descargar cancion��5m      
 5n        5o      $ Download=�6.   
�������6>   5q      m� 5r      $��Agregar a playlist��6   
 5s        5t      $ PlaylistPlus=�6.   
�������6B   5v      5w      5x      5y      