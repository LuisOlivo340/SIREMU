   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   A =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu 5   	      SiReMu.Registrarse   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   &localclr-namespace:SiReMu     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	   $��20(�5   	   $��Medium"�5   	     � Title$  Registrarse��5   	   $	��768��6   $
��1366��6*    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$ ThreeDBorderWindow=�6\    J� Opacity$	 0.9Q�6}    � 
ResizeMode$ CanMinimize=�5   	    � WindowState$ 	Maximized=�6"   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $��Registrarse en SiReMu��6   $��Center=�60   $��0,50,0,0q�6M   $	��Top=�6_   $��48(�6w   
�������6�   �� 5   
   $��Género:��6   $
��Left=�6"   $��200,520,0,0q�6=   $	��Top=�6R   �� 5   
   -   5         ��Name$ tbNombre��5      $
��Left=�6$   $��200,250,0,0q�6?    �� 	MaxLength$ 40��6T   $	��Top=�6c   $	��300��6{   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre��5      	   HintOpacity$		 0.8Q�6:   �� 5   
   -   5        $ tbApellidos��5      $
��Left=�6'   $��200,350,0,0q�6B   $ 40��6W   $	��Top=�6f   $	��300��6~   $		 0.8Q�5      $ 	Apellidos��6>   (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 dpNacimiento��5      $
��Left=�6+   $��200,450,0,0q�6F   $	��Top=�6[   $	��300��6s   $		 0.8Q�6   $ Fecha de nacimiento��5         DisplayDateStart 
01-01-19006�      DisplayDateEnd 6J   ��  �� Mode$ OneWay=� �� Today �� Source# Z 6�   �� 5   
   -   5        $ 	tbUsuario��5      $��Right=�6%   $��0,250,200,0q�6A   $ 30��6V   $	��Top=�6e   $	��300��6}   $ Nombre de Usuario��5      $		 0.8Q�6E      
HelperText$@ :Con el deberás inicar sesión y será visible para todos.��5      �� 5   
   -   5        $ tbCorreo��5      $��Right=�6$   $��0,350,200,0q�6@   $ 60��6U   $	��Top=�6d   $	��300��6|   $		 0.8Q�5      $ Correo��6>   G� 5   
   -   5         G�Name$ passbContraseña��5      $��Right=�6/   $��0,450,200,0q�6K   $	��Top=�6`   $	��300��6x    G� 	MaxLength$ 40��6�   $		 0.8Q�5       $ Contraseña��6B   $ Mínimo 8 caracteres.��5!      G� 5"   
   -   5        $ passbConfirmarContraseña��5"      $��Right=�68   $��0,550,200,0q�6T   $	��Top=�6i   $	��300��6�   $ 40��6�   $		 0.8Q�5#      $ Confirmar contraseña��6B   �� 5$   
   -   5        $��Registrarse��5$      $��Center=�6'   $��
300,0,0,50q�6D   $��Bottom=�6X   $	��170��5%      $��40��6   
���� ��
�������$��20(�6k   �� 5&   
   -	   5        $��Cancelar��5&      $��Center=�6$   $��
0,0,300,50q�6A   $��Bottom=�6U   $	��170��5'      $��40��6   
����=H�
�������$��20(�6m   	� 5(   
   -
   5         	�Name$ rbHombre��5(       	� 	GroupName$ genero��6(   $��Hombre��6;   $
��Left=�6L   $��200,550,0,0q�6g   $	��Top=�6|   6�   	� 5)   
   -   5        $ rbMujer��5)      $ genero��6'   $��Mujer��6:   $
��Left=�6J   $��310,550,0,0q�6e   $	��Top=�6z   6�   	� 5*   
   -   5        $ rbOtro��5*      $ genero��6&   $��
No binario��69   $
��Left=�6N   $��400,550,0,0q�6i   $	��Top=�6~   6�   5+      5,      