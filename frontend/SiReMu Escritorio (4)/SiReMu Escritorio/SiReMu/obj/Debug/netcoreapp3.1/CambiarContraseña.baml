   M S B A M L   `   `   `  ����A  =SiReMu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SiReMuSiReMu  5   	       SiReMu.CambiarContraseña   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:SiReMu     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	     MaterialDesignPaper#���  5
   	   $��16(�5   	   $��Medium"�5   	     � Title$  Cambiar contraseña��5   	    � WindowStartupLocation$ CenterScreen=�6$    � WindowStyle$ ThreeDBorderWindow=�6I    J� Opacity$	 0.9Q�6j   $	��600��5   	   $	��400��6    � 
ResizeMode$ NoResize=�6"    � WindowState$ Normal=�68   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   G� -   5         G�Name$ passbViejaContraseña��5      $��Center=�64   $��0,30,0,0q�6Q   $	��Top=�6c   $	��300��6{    G� 	MaxLength$ 40��6�   )  #MaterialDesignThemes.Wpf.HintAssist   HintOpacity$	 0.8Q�5      	   Hint$	 Contraseña actual��6B   G� 5   
   -   5        $ passbNuevaContraseña��5      $��Center=�64   $��	0,125,0,0q�6Q   $	��Top=�6d   $	��300��6|   $ 40��6�   $	 0.8Q�5      $	 Nueva Contraseña��6B   
   
HelperText$
 Mínimo 8 caracteres.��5      G� 5   
   -   5        $ passbConfirmarContraseña��5      $��Center=�68   $��	0,200,0,0q�6U   $	��Top=�6h   $	��300��6�   $ 40��6�   $	 0.8Q�5      $	 Confirmar contraseña��6B   �� 5   
   -   5        $��Cambiar contraseña��5      $��Center=�6.   $��
300,0,0,50q�6K   $��Bottom=�6_   $��40��5      
���� ��
�������$��20(�6g   �� 5   
   -   5        $��Cancelar��5      $��Center=�6$   $��
0,0,300,50q�6A   $��Bottom=�6U   $	��170��5      $��40��6   
����=H�
�������$��20(�6m   5      5      