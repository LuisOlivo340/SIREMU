   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5          SiReMu.RegistrarAlbum   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� Title$ Registrar playlist��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� -   5         ��Name$ lbTitulo��5      $��Nuevo album��6"   $��Center=�68   $��0,30,0,0q�6U   $	��Top=�6g   $��48(�6   
�������6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $	��Top=�6K   $��	0,150,0,0q�6c   .+�5      �� $ Vertical=�6   .+�5      �� -   5         ��Name$ imgIlustracion��5      $	��250��60   $	��250��6<   $
��Left=�6I   $	��Top=�6d   $��/Recursos/logoOscuro.png��6|   �� 5      -   5        $��Cargar imagen��5      $��Center=�61   $��0,30,0,0q�6N   $	��Top=�6`   $	��150��5      $��35��6%   
����=H�
�������$��16(�6t   5      �� 5      $ Vertical=�6   $��	150,0,0,0q�60   .+�5      �� -   5         ��Name$ tbNombre��5      $
��Left=�6,    �� 	MaxLength$	 100��6G   $	��Top=�6W   $	��550��6o   $��0,60,0,0q�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre��5      	   HintOpacity$		 0.8Q�6B   �� 5      -   5        $ tbCompañia��5      $
��Left=�6.   $ 50��6I   $	��Top=�6X   $	��550��6p   $��0,60,0,0q�6�   $ Compañia discográfica��5      $		 0.8Q�6Q   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5       (  "System.Windows.Controls.DatePicker  5      0sys&clr-namespace:System;assembly=mscorlib  5       -   5        
  Name$
 dpLanzamiento��5      $
��Left=�64   $��0,60,0,0q�6O   $	��Top=�6a   $	��300��6y   $		 0.8Q�6�   $ Fecha de lanzamiento��5         DisplayDateStart 
01-01-19006�      DisplayDateEnd 6K   ��  �� Mode$ OneWay=� �� Today �� Source# Z 5       5!      5"      �� 5$   
   $ 
Horizontal=�6   $��Center=�6.   $��	0,550,0,0q�6K   $	��Top=�6^   .+�5%      �� -   5        $��Cancelar��5%      $
��Left=�6(   $	��Top=�6C   $	��170��5&      $��40��6   
����  �
�������$��20(�6a   �� 5'      -   5         ��Name$ btCrearAlbum��5'      $��Crear album��6+   $��Center=�6A   $��	250,0,0,0q�6^   $	��Top=�6q   $	��170��5(      $��40��6   
���� ��
�������$��20(�6l   5)      5*      5+      