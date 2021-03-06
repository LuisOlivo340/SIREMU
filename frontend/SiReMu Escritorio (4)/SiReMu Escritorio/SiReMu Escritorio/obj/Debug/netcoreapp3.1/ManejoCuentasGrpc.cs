// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/manejoCuentas.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace MnjCuentas {
  public static partial class ManejoCuentas
  {
    static readonly string __ServiceName = "mnjCuentas.ManejoCuentas";

    static readonly grpc::Marshaller<global::MnjCuentas.Usuario> __Marshaller_mnjCuentas_Usuario = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MnjCuentas.Usuario.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MnjCuentas.RespuestaCuentas> __Marshaller_mnjCuentas_RespuestaCuentas = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MnjCuentas.RespuestaCuentas.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::MnjCuentas.CambioContrasenas> __Marshaller_mnjCuentas_CambioContrasenas = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MnjCuentas.CambioContrasenas.Parser.ParseFrom);

    static readonly grpc::Method<global::MnjCuentas.Usuario, global::MnjCuentas.RespuestaCuentas> __Method_IniciarSesion = new grpc::Method<global::MnjCuentas.Usuario, global::MnjCuentas.RespuestaCuentas>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IniciarSesion",
        __Marshaller_mnjCuentas_Usuario,
        __Marshaller_mnjCuentas_RespuestaCuentas);

    static readonly grpc::Method<global::MnjCuentas.Usuario, global::MnjCuentas.RespuestaCuentas> __Method_RegistrarUsuario = new grpc::Method<global::MnjCuentas.Usuario, global::MnjCuentas.RespuestaCuentas>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RegistrarUsuario",
        __Marshaller_mnjCuentas_Usuario,
        __Marshaller_mnjCuentas_RespuestaCuentas);

    static readonly grpc::Method<global::MnjCuentas.Usuario, global::MnjCuentas.RespuestaCuentas> __Method_ModificarUsuario = new grpc::Method<global::MnjCuentas.Usuario, global::MnjCuentas.RespuestaCuentas>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ModificarUsuario",
        __Marshaller_mnjCuentas_Usuario,
        __Marshaller_mnjCuentas_RespuestaCuentas);

    static readonly grpc::Method<global::MnjCuentas.CambioContrasenas, global::MnjCuentas.RespuestaCuentas> __Method_CambiarContrasena = new grpc::Method<global::MnjCuentas.CambioContrasenas, global::MnjCuentas.RespuestaCuentas>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CambiarContrasena",
        __Marshaller_mnjCuentas_CambioContrasenas,
        __Marshaller_mnjCuentas_RespuestaCuentas);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::MnjCuentas.ManejoCuentasReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ManejoCuentas</summary>
    public partial class ManejoCuentasClient : grpc::ClientBase<ManejoCuentasClient>
    {
      /// <summary>Creates a new client for ManejoCuentas</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ManejoCuentasClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ManejoCuentas that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ManejoCuentasClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ManejoCuentasClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ManejoCuentasClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::MnjCuentas.RespuestaCuentas IniciarSesion(global::MnjCuentas.Usuario request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IniciarSesion(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::MnjCuentas.RespuestaCuentas IniciarSesion(global::MnjCuentas.Usuario request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IniciarSesion, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> IniciarSesionAsync(global::MnjCuentas.Usuario request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IniciarSesionAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> IniciarSesionAsync(global::MnjCuentas.Usuario request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IniciarSesion, null, options, request);
      }
      public virtual global::MnjCuentas.RespuestaCuentas RegistrarUsuario(global::MnjCuentas.Usuario request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegistrarUsuario(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::MnjCuentas.RespuestaCuentas RegistrarUsuario(global::MnjCuentas.Usuario request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RegistrarUsuario, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> RegistrarUsuarioAsync(global::MnjCuentas.Usuario request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegistrarUsuarioAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> RegistrarUsuarioAsync(global::MnjCuentas.Usuario request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RegistrarUsuario, null, options, request);
      }
      public virtual global::MnjCuentas.RespuestaCuentas ModificarUsuario(global::MnjCuentas.Usuario request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ModificarUsuario(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::MnjCuentas.RespuestaCuentas ModificarUsuario(global::MnjCuentas.Usuario request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ModificarUsuario, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> ModificarUsuarioAsync(global::MnjCuentas.Usuario request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ModificarUsuarioAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> ModificarUsuarioAsync(global::MnjCuentas.Usuario request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ModificarUsuario, null, options, request);
      }
      public virtual global::MnjCuentas.RespuestaCuentas CambiarContrasena(global::MnjCuentas.CambioContrasenas request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CambiarContrasena(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::MnjCuentas.RespuestaCuentas CambiarContrasena(global::MnjCuentas.CambioContrasenas request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CambiarContrasena, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> CambiarContrasenaAsync(global::MnjCuentas.CambioContrasenas request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CambiarContrasenaAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::MnjCuentas.RespuestaCuentas> CambiarContrasenaAsync(global::MnjCuentas.CambioContrasenas request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CambiarContrasena, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ManejoCuentasClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ManejoCuentasClient(configuration);
      }
    }

  }
}
#endregion
