   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5          SiReMu.ModificarCuenta   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SiReMu     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��20(�5      $��Medium"�5       N� Title$ Modificar cuenta��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $��	Mi Cuenta��6   $��Center=�6$   $��0,30,0,0q�6A   $	��Top=�6S   $��48(�6k   
�������6y   �� 5   
    �� Orientation$ 
Horizontal=�6   $��	0,150,0,0q�6.   $��Center=�6A   $	��Top=�6^   .+�5      �� $ Vertical=�6   $
��Left=�60   $	��Top=�6K   .+�5      �� $��Datos personales��6   $��Right=�63   $	��Top=�6O   �� 5      $��Nombre:��6   $��Right=�6*   $	��Top=�6F   $��0,40,0,0q�6^   �� 5      $��	Apellido:��6   $��Right=�6,   $	��Top=�6H   $��0,30,0,0q�6`   �� 5      $��Fecha de nacimiento:��6   $��Right=�67   $	��Top=�6S   $��0,30,0,0q�6k   �� 5      $��Género:��6   $��Right=�6*   $	��Top=�6F   $��0,30,0,0q�6^   �� 5      $"��Datos de la cuenta de SiReMu��6   $��Right=�6?   $	��Top=�6[   $��	0,100,0,0q�6s   �� 5      $��Usuario:��6   $��Right=�6+   $	��Top=�6G   $��0,40,0,0q�6_   �� 5      $��Correo electrónico:��6   $��Right=�66   $	��Top=�6R   $��0,30,0,0q�6j   �� 5      $��Contraseña:��6   $��Right=�6.   $	��Top=�6J   $��0,30,0,0q�6b   �� 5      $��Ser creador de contenido:��6   $��Right=�6<   $	��Top=�6X   $��0,30,0,0q�6p   5      �� 5       $ Vertical=�6   $��	50,50,0,0q�60   $
��Left=�6C   $	��Top=�6^   .+�5!      �� -   5         ��Name$ tbNombre��5!      $
��Left=�6,   $��0,20,0,0q�6G    �� 	MaxLength$ 40��6Y   $	��Top=�6h   $	��300��6�   6�   �� 5"      -   5        $ tbApellidos��5"      $
��Left=�6/   $��0,30,0,0q�6J   $ 40��6\   $	��Top=�6k   $	��300��6�   6�   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5%      (  "System.Windows.Controls.DatePicker  5#      0sys&clr-namespace:System;assembly=mscorlib  5%      -   5          Name$ dpNacimiento��5#      $
��Left=�63   $��0,30,0,0q�6N   $	��Top=�6`   $	��300��6x   )  #MaterialDesignThemes.Wpf.HintAssist   HintOpacity$	 0.8Q�6�      Hint$ Fecha de nacimiento��5$      	   DisplayDateStart	 
01-01-19006�   
   DisplayDateEnd
 6J   ��  �� Mode$ OneWay=� �� Today �� Source# Z 5%      �� 5&      $ 
Horizontal=�6   $��0,35,0,0q�66   $
��Left=�6H   $	��Top=�6c   .+�5'      	� -   5         	�Name$ rbHombre��5'   "    	� 	GroupName$ genero��64   $��Hombre��6G   $
��Left=�6X   $��0,0,0,0q�6s   $	��Top=�6�   6�   	� 5(      -   5        $ rbMujer��5(   "   $ genero��63   $��Mujer��6F   $
��Left=�6V   $��20,0,0,0q�6q   $	��Top=�6�   6�   	� 5)      -   5        $ rbOtro��5)   "   $ genero��62   $��
No binario��6E   $
��Left=�6Z   $��20,0,0,0q�6u   $	��Top=�6�   6�   5*      �� 5+      -   5        $ 	tbUsuario��5+      $
��Left=�6-   $��	0,170,0,0q�6H   $ 30��6[   $	��Top=�6j   $	��300��6�      
HelperText$@ :Con el deberás inicar sesión y será visible para todos.��5,      �� 5-      -   5        $ tbCorreo��5-      $
��Left=�6,   $��0,30,0,0q�6G   $ 60��6Y   $	��Top=�6h   $	��300��6�   6�   �� 5.      -	   5        $��Cambiar contraseña��5.      $��Center=�66   $��0,30,0,0q�6S   $��35��6e   
����=H�
�������$��16(�5/   4   d� 50      -
   5         d�Name$ 	tbCreador��50      $��0,35,0,0q�62   $
��Left=�6D    ) %MaterialDesignSwitchLightToggleButton#��[ 6_    � ToolTip$+ %MaterialDesignSwitchLightToggleButton��6�   51      52      �� 54   
   $ 
Horizontal=�6   $��	0,900,0,0q�6.   $��Center=�6A   $	��Top=�6^   .+�55      �� -   5        $��Cancelar��55      $��Center=�6(   $��0,0,0,0q�6E   $��Bottom=�6V   $	��170��56      $��40��6   
����=H�
�������$��20(�6m   �� 57      -   5        $��Guardar cambios��57      $��Center=�6/   $��	150,0,0,0q�6L   $��Bottom=�6_   $��40��58      
���� ��
�������$��20(�6h   59      5:      5;      