   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5   	       SiReMu.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:SiReMu     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	     MaterialDesignPaper#���  5
   	   $��Normal"�5   	   $��20(�5   	   #���   5   	     � Title$  Iniciar sesión��5   	   $	��400��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69    � WindowStyle$ ThreeDBorderWindow=�6^    J� Opacity$	 0.9Q�6    � 
ResizeMode$ CanMinimize=�5   	   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $
��Left=�6   $	��Top=�6+   $��Recursos/logoOscuro.png��6C   $��10,0,0,0q�6d   �� 5   
   -   5         ��Name$ 	tbUsuario��5      $
��Left=�6%   $��
440,47,0,0q�6@    �� TextWrapping$ NoWrap=�6T    �� 	MaxLength$	 100��6j   $	��Top=�6z   $	��250��6�   .��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$

 Cyan��6#    � Offset$	 0.5Q�60   5      .��5   #   5      G� 5   
   -   5         G�Name$ passbContraseña��5      $
��Left=�6/   $��440,127,0,0q�6J   $	��Top=�6_   $	��250��6w    G� 	MaxLength$ 50��6�   ��5      �� 5      $ 0.5,1&�6&   $	 0.5,0&�67   .��5      � $

 Cyan��6#   $	 0.5Q�60   5      5!      �� 5"   
   -   5        $��Iniciar Sesion��5"      $
��Left=�6*   $��480,195,0,0q�6E   $	��Top=�6Z   $	��170��5#      $��40��6   
���� ��
�������$��20(�6q   �� 5$   
   -   5        $��Regístrate��5$      $
��Left=�6&   $��580,302,0,0q�6A   $	��Top=�6V   $	��115��6n   $��35��6z   
����  �
�������$��16(�5%   W   �� 5&   
   $
��Left=�6   $��415,310,0,0q�6/   $
��Wrap=�6D   $��¿No tienes cuenta?��5'      $	��Top=�6.    J� OpacityMask �	#FFFF4040$��16(�5(   ,   �� 5)   
   -   5         ��Name$ lbContraseña��5)      $��Contraseña��6&   $
��Left=�6;   $��440,127,0,0q�6V   $	��Top=�6k   $	 0.8Q�6�    � Cursor$ IBeam��6�   �� 5*   
   -   5        $ 	lbUsuario��5*      $��Usuario��6#   $
��Left=�65   $��
440,47,0,0q�6P   $	��Top=�6d   $	 0.8Q�6}   $ IBeam��6�   5+      5,      