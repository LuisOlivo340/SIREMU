   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5      "    SiReMu.MisListasReproduccion   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� Title$  Mis lista de reproducción��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $��Mis playlist��6   $��Center=�6'   $��0,10,0,0q�6D   $	��Top=�6V   $��48(�6n   $��0q�6|   �� 5   
   -   5        $
��Left=�5      $��322,130,0,0q�6,   $	��Top=�6A   $��Nueva playlist��6Y   
���� ��
�������$��16(�5   7   $	��150��6E   $��40��6Q   �� 5   
   $��Mis listas creadas��6   $
��Left=�6-   $��
30,180,0,0q�6H   $	��Top=�6\   $��0q�6t   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgMisListas��5      $
��Left=�6(   $��30,210,0,30q�6C   $	��Top=�6X      AutoGenerateColumns$ False��6p      CanUserAddRows$ False��5         
IsReadOnly$
 True��6*      SelectionMode$ Single=�6<      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5        	NoPadding,  &System.Windows.Controls.DataGridColumn	   	CellStyle#	 [ 6)   
   CellTemplate
 5      �� 5      .R�5      �� -   5        $��0q�5   5   $��25��6A   $��25��6L     MouseOverVisibility#��[ 6r   
 � Tag 6%   �� .��5   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Play=�6:   $��25��6F   $��25��6Q   
�������6]   5      5      5!      0  *System.Windows.Controls.DataGridTextColumn  5"         Header$ Nombre��6%      MinWidth$	 200Q�65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6D      CanUserReorder$ False��6P     NoFocus#	 [ 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6g   �� *Nombre+6�   4	  .System.Windows.Controls.DataGridCheckBoxColumn	  5#      $ Pública��6)   $ 80Q�6:   $ 80 6H   $ False��6S   #	 [ 6�    - )MaterialDesignDataGridCheckBoxColumnStyle   ElementStyle# [ 5$   )    4 0MaterialDesignDataGridCheckBoxColumnEditingStyle   EditingElementStyle# [ 5%   )    5#   j   �� *	EsPublica+5%   )     5&      $ Likes��6%   $ 80Q�64   $ 80 6B   $ False��6M   #	 [ 6~    6d   �� *Likes+6~   5(      �� 5*   
   $��Listas que me gustan��6   $
��Left=�6/   $��520,180,0,0q�6J   $	��Top=�6_   $��0q�6w     5+   
   -   5        $ dgListasAgregadas��5+      $
��Left=�6.   $��520,210,0,30q�6I   $	��Top=�6_   $ False��6w   $ False��5,      $
 True��6*   $ Single=�6<    5-        5.      #	 [ 6)   
 5/      �� 50      .R�51      �� -   5        $��0q�51   5   $��25��6A   $��25��6L   #��[ 6p    6%   �� .��52   "     $
 Play=�6:   $��25��6F   $��25��6Q   
�������6]   53      54      56        57      $ Nombre��6%   $	 200Q�65   $	 250 6D   $ False��6P   #	 [ 6�    6g   �� *Nombre+6�     58      $ Creador��6%   $	 100Q�66   $	 150 6E   $ False��6Q   #	 [ 6�    6h   �� *NombreCreador+6�     59      $ Likes��6%   $ 80Q�64   $ 80 6B   $ False��6M   #	 [ 6~    6d   �� *Likes+6~   5;      5=       � 	Resources 5?        cmMenuMisListas m� Icon  cmMenuListasAgregadas��%�  &	       &	     �� 5@   
   .@�5A      m� -   5        $��Editar��5A       5B        5C      $
 Edit=�6.   
�������6:   5E      �� 5F      m� 5G      -   5        $��Eliminar��5G       5H        5I      $ Delete=�6.   
�������6<   5K      5L      �� 5N   
   .@�5O      m� -   5        $��Ya no me gusta��5O       5P        5Q      $ HeartBroken=�6.   
�������6A   5S      �� 5T      5U      5V      5W      