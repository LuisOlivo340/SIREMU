﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiReMu {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
    public sealed partial class Propiedades : global::System.Configuration.ApplicationSettingsBase {
        
        private static Propiedades defaultInstance = ((Propiedades)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Propiedades())));
        
        public static Propiedades Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("127.0.0.1")]
        public string IpServidorListas {
            get {
                return ((string)(this["IpServidorListas"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25111")]
        public string PuertoServidorListas {
            get {
                return ((string)(this["PuertoServidorListas"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25112")]
        public string PuertoServidorCanciones {
            get {
                return ((string)(this["PuertoServidorCanciones"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("127.0.0.1")]
        public string IpServidorCanciones {
            get {
                return ((string)(this["IpServidorCanciones"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Me gusta")]
        public string ListaMeGusta {
            get {
                return ((string)(this["ListaMeGusta"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("524288")]
        public int TamañoMaxImagen {
            get {
                return ((int)(this["TamañoMaxImagen"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("127.0.0.1")]
        public string IpServidorCuentas {
            get {
                return ((string)(this["IpServidorCuentas"]));
            }
            set {
                this["IpServidorCuentas"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25113")]
        public string PuertoServidorCuentas {
            get {
                return ((string)(this["PuertoServidorCuentas"]));
            }
            set {
                this["PuertoServidorCuentas"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("104857600")]
        public int TamañoMaxCancion {
            get {
                return ((int)(this["TamañoMaxCancion"]));
            }
            set {
                this["TamañoMaxCancion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1048576")]
        public int BufferLecturaCancion {
            get {
                return ((int)(this["BufferLecturaCancion"]));
            }
            set {
                this["BufferLecturaCancion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\SiReMu\\\\Downloaded\\\\")]
        public string CarpetaMusicaDescargada {
            get {
                return ((string)(this["CarpetaMusicaDescargada"]));
            }
            set {
                this["CarpetaMusicaDescargada"] = value;
            }
        }
    }
}
