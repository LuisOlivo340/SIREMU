﻿#pragma checksum "..\..\..\SubirCancion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60E736F0619BE746E68BC4CA44182F6B1AAE2459"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SiReMu;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SiReMu {
    
    
    /// <summary>
    /// SubirCancion
    /// </summary>
    public partial class SubirCancion : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\SubirCancion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitulo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\SubirCancion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombre;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\SubirCancion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbArtista;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\SubirCancion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbGeneros;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\SubirCancion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAlbumes;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\SubirCancion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbArchivo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SiReMu;component/subircancion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SubirCancion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.tbNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\SubirCancion.xaml"
            this.tbNombre.LostFocus += new System.Windows.RoutedEventHandler(this.ValidarTexto);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbArtista = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\SubirCancion.xaml"
            this.tbArtista.LostFocus += new System.Windows.RoutedEventHandler(this.ValidarTexto);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbGeneros = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbAlbumes = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.tbArchivo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 34 "..\..\..\SubirCancion.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CargarCancion);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 36 "..\..\..\SubirCancion.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CrearAlbum);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 41 "..\..\..\SubirCancion.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancelar);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 43 "..\..\..\SubirCancion.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RegistrarCancion);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

