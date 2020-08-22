// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/manejoCuentas.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MnjCuentas {

  /// <summary>Holder for reflection information generated from Protos/manejoCuentas.proto</summary>
  public static partial class ManejoCuentasReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/manejoCuentas.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ManejoCuentasReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChpQcm90b3MvbWFuZWpvQ3VlbnRhcy5wcm90bxIKbW5qQ3VlbnRhcyJKChBS",
            "ZXNwdWVzdGFDdWVudGFzEhEKCXJlc3B1ZXN0YRgBIAEoCBIjCgZjdWVudGEY",
            "AiABKAsyEy5tbmpDdWVudGFzLlVzdWFyaW8iWwoRQ2FtYmlvQ29udHJhc2Vu",
            "YXMSEQoJaWRVc3VhcmlvGAEgASgFEhoKEmNvbnRyYXNlbmFBbnRlcmlvchgC",
            "IAEoCRIXCg9udWV2YUNvbnRyYXNlbmEYAyABKAkisgEKB1VzdWFyaW8SDgoG",
            "bm9tYnJlGAEgASgJEhMKC2NvbnRyYXNlbmlhGAIgASgJEg4KBmNvcnJlbxgD",
            "IAEoCRIaChJlc0NyZWFkb3JDb250ZW5pZG8YBCABKAgSFwoPZmVjaGFOYWNp",
            "bWllbnRvGAUgASgJEg4KBmdlbmVybxgGIAEoCRIPCgd1c3VhcmlvGAcgASgJ",
            "EhAKCGFwZWxsaWRvGAggASgJEgoKAmlkGAkgASgFMrMCCg1NYW5lam9DdWVu",
            "dGFzEkIKDUluaWNpYXJTZXNpb24SEy5tbmpDdWVudGFzLlVzdWFyaW8aHC5t",
            "bmpDdWVudGFzLlJlc3B1ZXN0YUN1ZW50YXMSRQoQUmVnaXN0cmFyVXN1YXJp",
            "bxITLm1uakN1ZW50YXMuVXN1YXJpbxocLm1uakN1ZW50YXMuUmVzcHVlc3Rh",
            "Q3VlbnRhcxJFChBNb2RpZmljYXJVc3VhcmlvEhMubW5qQ3VlbnRhcy5Vc3Vh",
            "cmlvGhwubW5qQ3VlbnRhcy5SZXNwdWVzdGFDdWVudGFzElAKEUNhbWJpYXJD",
            "b250cmFzZW5hEh0ubW5qQ3VlbnRhcy5DYW1iaW9Db250cmFzZW5hcxocLm1u",
            "akN1ZW50YXMuUmVzcHVlc3RhQ3VlbnRhc2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MnjCuentas.RespuestaCuentas), global::MnjCuentas.RespuestaCuentas.Parser, new[]{ "Respuesta", "Cuenta" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MnjCuentas.CambioContrasenas), global::MnjCuentas.CambioContrasenas.Parser, new[]{ "IdUsuario", "ContrasenaAnterior", "NuevaContrasena" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MnjCuentas.Usuario), global::MnjCuentas.Usuario.Parser, new[]{ "Nombre", "Contrasenia", "Correo", "EsCreadorContenido", "FechaNacimiento", "Genero", "Usuario_", "Apellido", "Id" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class RespuestaCuentas : pb::IMessage<RespuestaCuentas> {
    private static readonly pb::MessageParser<RespuestaCuentas> _parser = new pb::MessageParser<RespuestaCuentas>(() => new RespuestaCuentas());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RespuestaCuentas> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MnjCuentas.ManejoCuentasReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RespuestaCuentas() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RespuestaCuentas(RespuestaCuentas other) : this() {
      respuesta_ = other.respuesta_;
      cuenta_ = other.cuenta_ != null ? other.cuenta_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RespuestaCuentas Clone() {
      return new RespuestaCuentas(this);
    }

    /// <summary>Field number for the "respuesta" field.</summary>
    public const int RespuestaFieldNumber = 1;
    private bool respuesta_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Respuesta {
      get { return respuesta_; }
      set {
        respuesta_ = value;
      }
    }

    /// <summary>Field number for the "cuenta" field.</summary>
    public const int CuentaFieldNumber = 2;
    private global::MnjCuentas.Usuario cuenta_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MnjCuentas.Usuario Cuenta {
      get { return cuenta_; }
      set {
        cuenta_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RespuestaCuentas);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RespuestaCuentas other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Respuesta != other.Respuesta) return false;
      if (!object.Equals(Cuenta, other.Cuenta)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Respuesta != false) hash ^= Respuesta.GetHashCode();
      if (cuenta_ != null) hash ^= Cuenta.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Respuesta != false) {
        output.WriteRawTag(8);
        output.WriteBool(Respuesta);
      }
      if (cuenta_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Cuenta);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Respuesta != false) {
        size += 1 + 1;
      }
      if (cuenta_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Cuenta);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RespuestaCuentas other) {
      if (other == null) {
        return;
      }
      if (other.Respuesta != false) {
        Respuesta = other.Respuesta;
      }
      if (other.cuenta_ != null) {
        if (cuenta_ == null) {
          Cuenta = new global::MnjCuentas.Usuario();
        }
        Cuenta.MergeFrom(other.Cuenta);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Respuesta = input.ReadBool();
            break;
          }
          case 18: {
            if (cuenta_ == null) {
              Cuenta = new global::MnjCuentas.Usuario();
            }
            input.ReadMessage(Cuenta);
            break;
          }
        }
      }
    }

  }

  public sealed partial class CambioContrasenas : pb::IMessage<CambioContrasenas> {
    private static readonly pb::MessageParser<CambioContrasenas> _parser = new pb::MessageParser<CambioContrasenas>(() => new CambioContrasenas());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CambioContrasenas> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MnjCuentas.ManejoCuentasReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CambioContrasenas() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CambioContrasenas(CambioContrasenas other) : this() {
      idUsuario_ = other.idUsuario_;
      contrasenaAnterior_ = other.contrasenaAnterior_;
      nuevaContrasena_ = other.nuevaContrasena_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CambioContrasenas Clone() {
      return new CambioContrasenas(this);
    }

    /// <summary>Field number for the "idUsuario" field.</summary>
    public const int IdUsuarioFieldNumber = 1;
    private int idUsuario_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int IdUsuario {
      get { return idUsuario_; }
      set {
        idUsuario_ = value;
      }
    }

    /// <summary>Field number for the "contrasenaAnterior" field.</summary>
    public const int ContrasenaAnteriorFieldNumber = 2;
    private string contrasenaAnterior_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ContrasenaAnterior {
      get { return contrasenaAnterior_; }
      set {
        contrasenaAnterior_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "nuevaContrasena" field.</summary>
    public const int NuevaContrasenaFieldNumber = 3;
    private string nuevaContrasena_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string NuevaContrasena {
      get { return nuevaContrasena_; }
      set {
        nuevaContrasena_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CambioContrasenas);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CambioContrasenas other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IdUsuario != other.IdUsuario) return false;
      if (ContrasenaAnterior != other.ContrasenaAnterior) return false;
      if (NuevaContrasena != other.NuevaContrasena) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (IdUsuario != 0) hash ^= IdUsuario.GetHashCode();
      if (ContrasenaAnterior.Length != 0) hash ^= ContrasenaAnterior.GetHashCode();
      if (NuevaContrasena.Length != 0) hash ^= NuevaContrasena.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (IdUsuario != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(IdUsuario);
      }
      if (ContrasenaAnterior.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ContrasenaAnterior);
      }
      if (NuevaContrasena.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(NuevaContrasena);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (IdUsuario != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(IdUsuario);
      }
      if (ContrasenaAnterior.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ContrasenaAnterior);
      }
      if (NuevaContrasena.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(NuevaContrasena);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CambioContrasenas other) {
      if (other == null) {
        return;
      }
      if (other.IdUsuario != 0) {
        IdUsuario = other.IdUsuario;
      }
      if (other.ContrasenaAnterior.Length != 0) {
        ContrasenaAnterior = other.ContrasenaAnterior;
      }
      if (other.NuevaContrasena.Length != 0) {
        NuevaContrasena = other.NuevaContrasena;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            IdUsuario = input.ReadInt32();
            break;
          }
          case 18: {
            ContrasenaAnterior = input.ReadString();
            break;
          }
          case 26: {
            NuevaContrasena = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Usuario : pb::IMessage<Usuario> {
    private static readonly pb::MessageParser<Usuario> _parser = new pb::MessageParser<Usuario>(() => new Usuario());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Usuario> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MnjCuentas.ManejoCuentasReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Usuario() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Usuario(Usuario other) : this() {
      nombre_ = other.nombre_;
      contrasenia_ = other.contrasenia_;
      correo_ = other.correo_;
      esCreadorContenido_ = other.esCreadorContenido_;
      fechaNacimiento_ = other.fechaNacimiento_;
      genero_ = other.genero_;
      usuario_ = other.usuario_;
      apellido_ = other.apellido_;
      id_ = other.id_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Usuario Clone() {
      return new Usuario(this);
    }

    /// <summary>Field number for the "nombre" field.</summary>
    public const int NombreFieldNumber = 1;
    private string nombre_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Nombre {
      get { return nombre_; }
      set {
        nombre_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "contrasenia" field.</summary>
    public const int ContraseniaFieldNumber = 2;
    private string contrasenia_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Contrasenia {
      get { return contrasenia_; }
      set {
        contrasenia_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "correo" field.</summary>
    public const int CorreoFieldNumber = 3;
    private string correo_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Correo {
      get { return correo_; }
      set {
        correo_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "esCreadorContenido" field.</summary>
    public const int EsCreadorContenidoFieldNumber = 4;
    private bool esCreadorContenido_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool EsCreadorContenido {
      get { return esCreadorContenido_; }
      set {
        esCreadorContenido_ = value;
      }
    }

    /// <summary>Field number for the "fechaNacimiento" field.</summary>
    public const int FechaNacimientoFieldNumber = 5;
    private string fechaNacimiento_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FechaNacimiento {
      get { return fechaNacimiento_; }
      set {
        fechaNacimiento_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "genero" field.</summary>
    public const int GeneroFieldNumber = 6;
    private string genero_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Genero {
      get { return genero_; }
      set {
        genero_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "usuario" field.</summary>
    public const int Usuario_FieldNumber = 7;
    private string usuario_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Usuario_ {
      get { return usuario_; }
      set {
        usuario_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "apellido" field.</summary>
    public const int ApellidoFieldNumber = 8;
    private string apellido_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Apellido {
      get { return apellido_; }
      set {
        apellido_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 9;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Usuario);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Usuario other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Nombre != other.Nombre) return false;
      if (Contrasenia != other.Contrasenia) return false;
      if (Correo != other.Correo) return false;
      if (EsCreadorContenido != other.EsCreadorContenido) return false;
      if (FechaNacimiento != other.FechaNacimiento) return false;
      if (Genero != other.Genero) return false;
      if (Usuario_ != other.Usuario_) return false;
      if (Apellido != other.Apellido) return false;
      if (Id != other.Id) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Nombre.Length != 0) hash ^= Nombre.GetHashCode();
      if (Contrasenia.Length != 0) hash ^= Contrasenia.GetHashCode();
      if (Correo.Length != 0) hash ^= Correo.GetHashCode();
      if (EsCreadorContenido != false) hash ^= EsCreadorContenido.GetHashCode();
      if (FechaNacimiento.Length != 0) hash ^= FechaNacimiento.GetHashCode();
      if (Genero.Length != 0) hash ^= Genero.GetHashCode();
      if (Usuario_.Length != 0) hash ^= Usuario_.GetHashCode();
      if (Apellido.Length != 0) hash ^= Apellido.GetHashCode();
      if (Id != 0) hash ^= Id.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Nombre.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Nombre);
      }
      if (Contrasenia.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Contrasenia);
      }
      if (Correo.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Correo);
      }
      if (EsCreadorContenido != false) {
        output.WriteRawTag(32);
        output.WriteBool(EsCreadorContenido);
      }
      if (FechaNacimiento.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(FechaNacimiento);
      }
      if (Genero.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Genero);
      }
      if (Usuario_.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Usuario_);
      }
      if (Apellido.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Apellido);
      }
      if (Id != 0) {
        output.WriteRawTag(72);
        output.WriteInt32(Id);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Nombre.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Nombre);
      }
      if (Contrasenia.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Contrasenia);
      }
      if (Correo.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Correo);
      }
      if (EsCreadorContenido != false) {
        size += 1 + 1;
      }
      if (FechaNacimiento.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FechaNacimiento);
      }
      if (Genero.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Genero);
      }
      if (Usuario_.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Usuario_);
      }
      if (Apellido.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Apellido);
      }
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Usuario other) {
      if (other == null) {
        return;
      }
      if (other.Nombre.Length != 0) {
        Nombre = other.Nombre;
      }
      if (other.Contrasenia.Length != 0) {
        Contrasenia = other.Contrasenia;
      }
      if (other.Correo.Length != 0) {
        Correo = other.Correo;
      }
      if (other.EsCreadorContenido != false) {
        EsCreadorContenido = other.EsCreadorContenido;
      }
      if (other.FechaNacimiento.Length != 0) {
        FechaNacimiento = other.FechaNacimiento;
      }
      if (other.Genero.Length != 0) {
        Genero = other.Genero;
      }
      if (other.Usuario_.Length != 0) {
        Usuario_ = other.Usuario_;
      }
      if (other.Apellido.Length != 0) {
        Apellido = other.Apellido;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Nombre = input.ReadString();
            break;
          }
          case 18: {
            Contrasenia = input.ReadString();
            break;
          }
          case 26: {
            Correo = input.ReadString();
            break;
          }
          case 32: {
            EsCreadorContenido = input.ReadBool();
            break;
          }
          case 42: {
            FechaNacimiento = input.ReadString();
            break;
          }
          case 50: {
            Genero = input.ReadString();
            break;
          }
          case 58: {
            Usuario_ = input.ReadString();
            break;
          }
          case 66: {
            Apellido = input.ReadString();
            break;
          }
          case 72: {
            Id = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
