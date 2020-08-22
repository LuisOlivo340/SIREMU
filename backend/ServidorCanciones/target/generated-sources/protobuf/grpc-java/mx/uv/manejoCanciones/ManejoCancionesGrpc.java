package mx.uv.manejoCanciones;

import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.30.0)",
    comments = "Source: manejoCanciones.proto")
public final class ManejoCancionesGrpc {

  private ManejoCancionesGrpc() {}

  public static final String SERVICE_NAME = "mnjCanciones.ManejoCanciones";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Busqueda,
      mx.uv.manejoCanciones.ListaCanciones> getBuscarCancionesMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "BuscarCanciones",
      requestType = mx.uv.manejoCanciones.Busqueda.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Busqueda,
      mx.uv.manejoCanciones.ListaCanciones> getBuscarCancionesMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Busqueda, mx.uv.manejoCanciones.ListaCanciones> getBuscarCancionesMethod;
    if ((getBuscarCancionesMethod = ManejoCancionesGrpc.getBuscarCancionesMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getBuscarCancionesMethod = ManejoCancionesGrpc.getBuscarCancionesMethod) == null) {
          ManejoCancionesGrpc.getBuscarCancionesMethod = getBuscarCancionesMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.Busqueda, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "BuscarCanciones"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.Busqueda.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("BuscarCanciones"))
              .build();
        }
      }
    }
    return getBuscarCancionesMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Busqueda,
      mx.uv.manejoCanciones.ListaAlbums> getBuscarAlbumesMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "BuscarAlbumes",
      requestType = mx.uv.manejoCanciones.Busqueda.class,
      responseType = mx.uv.manejoCanciones.ListaAlbums.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Busqueda,
      mx.uv.manejoCanciones.ListaAlbums> getBuscarAlbumesMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Busqueda, mx.uv.manejoCanciones.ListaAlbums> getBuscarAlbumesMethod;
    if ((getBuscarAlbumesMethod = ManejoCancionesGrpc.getBuscarAlbumesMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getBuscarAlbumesMethod = ManejoCancionesGrpc.getBuscarAlbumesMethod) == null) {
          ManejoCancionesGrpc.getBuscarAlbumesMethod = getBuscarAlbumesMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.Busqueda, mx.uv.manejoCanciones.ListaAlbums>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "BuscarAlbumes"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.Busqueda.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaAlbums.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("BuscarAlbumes"))
              .build();
        }
      }
    }
    return getBuscarAlbumesMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.AlbumAG,
      mx.uv.manejoCanciones.RespuestaCanciones> getCrearAlbumMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "CrearAlbum",
      requestType = mx.uv.manejoCanciones.AlbumAG.class,
      responseType = mx.uv.manejoCanciones.RespuestaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.AlbumAG,
      mx.uv.manejoCanciones.RespuestaCanciones> getCrearAlbumMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.AlbumAG, mx.uv.manejoCanciones.RespuestaCanciones> getCrearAlbumMethod;
    if ((getCrearAlbumMethod = ManejoCancionesGrpc.getCrearAlbumMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getCrearAlbumMethod = ManejoCancionesGrpc.getCrearAlbumMethod) == null) {
          ManejoCancionesGrpc.getCrearAlbumMethod = getCrearAlbumMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.AlbumAG, mx.uv.manejoCanciones.RespuestaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "CrearAlbum"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.AlbumAG.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.RespuestaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("CrearAlbum"))
              .build();
        }
      }
    }
    return getCrearAlbumMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarMisCancionesMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarMisCanciones",
      requestType = mx.uv.manejoCanciones.IdUsuario.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarMisCancionesMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones> getConsultarMisCancionesMethod;
    if ((getConsultarMisCancionesMethod = ManejoCancionesGrpc.getConsultarMisCancionesMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarMisCancionesMethod = ManejoCancionesGrpc.getConsultarMisCancionesMethod) == null) {
          ManejoCancionesGrpc.getConsultarMisCancionesMethod = getConsultarMisCancionesMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarMisCanciones"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdUsuario.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarMisCanciones"))
              .build();
        }
      }
    }
    return getConsultarMisCancionesMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesEnPromocionMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarCancionesEnPromocion",
      requestType = mx.uv.manejoCanciones.IdUsuario.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesEnPromocionMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesEnPromocionMethod;
    if ((getConsultarCancionesEnPromocionMethod = ManejoCancionesGrpc.getConsultarCancionesEnPromocionMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarCancionesEnPromocionMethod = ManejoCancionesGrpc.getConsultarCancionesEnPromocionMethod) == null) {
          ManejoCancionesGrpc.getConsultarCancionesEnPromocionMethod = getConsultarCancionesEnPromocionMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarCancionesEnPromocion"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdUsuario.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarCancionesEnPromocion"))
              .build();
        }
      }
    }
    return getConsultarCancionesEnPromocionMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaAlbums> getConsultarAlbumsMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarAlbums",
      requestType = mx.uv.manejoCanciones.IdUsuario.class,
      responseType = mx.uv.manejoCanciones.ListaAlbums.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaAlbums> getConsultarAlbumsMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaAlbums> getConsultarAlbumsMethod;
    if ((getConsultarAlbumsMethod = ManejoCancionesGrpc.getConsultarAlbumsMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarAlbumsMethod = ManejoCancionesGrpc.getConsultarAlbumsMethod) == null) {
          ManejoCancionesGrpc.getConsultarAlbumsMethod = getConsultarAlbumsMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaAlbums>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarAlbums"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdUsuario.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaAlbums.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarAlbums"))
              .build();
        }
      }
    }
    return getConsultarAlbumsMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Album,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesAlbumMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarCancionesAlbum",
      requestType = mx.uv.manejoCanciones.Album.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Album,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesAlbumMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Album, mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesAlbumMethod;
    if ((getConsultarCancionesAlbumMethod = ManejoCancionesGrpc.getConsultarCancionesAlbumMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarCancionesAlbumMethod = ManejoCancionesGrpc.getConsultarCancionesAlbumMethod) == null) {
          ManejoCancionesGrpc.getConsultarCancionesAlbumMethod = getConsultarCancionesAlbumMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.Album, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarCancionesAlbum"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.Album.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarCancionesAlbum"))
              .build();
        }
      }
    }
    return getConsultarCancionesAlbumMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdLista,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesListaMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarCancionesLista",
      requestType = mx.uv.manejoCanciones.IdLista.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdLista,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesListaMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdLista, mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesListaMethod;
    if ((getConsultarCancionesListaMethod = ManejoCancionesGrpc.getConsultarCancionesListaMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarCancionesListaMethod = ManejoCancionesGrpc.getConsultarCancionesListaMethod) == null) {
          ManejoCancionesGrpc.getConsultarCancionesListaMethod = getConsultarCancionesListaMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdLista, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarCancionesLista"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdLista.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarCancionesLista"))
              .build();
        }
      }
    }
    return getConsultarCancionesListaMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Cancion,
      mx.uv.manejoCanciones.ListaCanciones> getGenerarRadioMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GenerarRadio",
      requestType = mx.uv.manejoCanciones.Cancion.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Cancion,
      mx.uv.manejoCanciones.ListaCanciones> getGenerarRadioMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.Cancion, mx.uv.manejoCanciones.ListaCanciones> getGenerarRadioMethod;
    if ((getGenerarRadioMethod = ManejoCancionesGrpc.getGenerarRadioMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getGenerarRadioMethod = ManejoCancionesGrpc.getGenerarRadioMethod) == null) {
          ManejoCancionesGrpc.getGenerarRadioMethod = getGenerarRadioMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.Cancion, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GenerarRadio"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.Cancion.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("GenerarRadio"))
              .build();
        }
      }
    }
    return getGenerarRadioMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.AlbumAG,
      mx.uv.manejoCanciones.RespuestaCanciones> getModificarAlbumMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ModificarAlbum",
      requestType = mx.uv.manejoCanciones.AlbumAG.class,
      responseType = mx.uv.manejoCanciones.RespuestaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.AlbumAG,
      mx.uv.manejoCanciones.RespuestaCanciones> getModificarAlbumMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.AlbumAG, mx.uv.manejoCanciones.RespuestaCanciones> getModificarAlbumMethod;
    if ((getModificarAlbumMethod = ManejoCancionesGrpc.getModificarAlbumMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getModificarAlbumMethod = ManejoCancionesGrpc.getModificarAlbumMethod) == null) {
          ManejoCancionesGrpc.getModificarAlbumMethod = getModificarAlbumMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.AlbumAG, mx.uv.manejoCanciones.RespuestaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ModificarAlbum"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.AlbumAG.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.RespuestaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ModificarAlbum"))
              .build();
        }
      }
    }
    return getModificarAlbumMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionAG,
      mx.uv.manejoCanciones.CancionPP> getReproducirCancionMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ReproducirCancion",
      requestType = mx.uv.manejoCanciones.CancionAG.class,
      responseType = mx.uv.manejoCanciones.CancionPP.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionAG,
      mx.uv.manejoCanciones.CancionPP> getReproducirCancionMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionAG, mx.uv.manejoCanciones.CancionPP> getReproducirCancionMethod;
    if ((getReproducirCancionMethod = ManejoCancionesGrpc.getReproducirCancionMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getReproducirCancionMethod = ManejoCancionesGrpc.getReproducirCancionMethod) == null) {
          ManejoCancionesGrpc.getReproducirCancionMethod = getReproducirCancionMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.CancionAG, mx.uv.manejoCanciones.CancionPP>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ReproducirCancion"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.CancionAG.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.CancionPP.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ReproducirCancion"))
              .build();
        }
      }
    }
    return getReproducirCancionMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionPP,
      mx.uv.manejoCanciones.RespuestaCanciones> getSubirCancionMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "SubirCancion",
      requestType = mx.uv.manejoCanciones.CancionPP.class,
      responseType = mx.uv.manejoCanciones.RespuestaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.CLIENT_STREAMING)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionPP,
      mx.uv.manejoCanciones.RespuestaCanciones> getSubirCancionMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionPP, mx.uv.manejoCanciones.RespuestaCanciones> getSubirCancionMethod;
    if ((getSubirCancionMethod = ManejoCancionesGrpc.getSubirCancionMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getSubirCancionMethod = ManejoCancionesGrpc.getSubirCancionMethod) == null) {
          ManejoCancionesGrpc.getSubirCancionMethod = getSubirCancionMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.CancionPP, mx.uv.manejoCanciones.RespuestaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.CLIENT_STREAMING)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "SubirCancion"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.CancionPP.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.RespuestaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("SubirCancion"))
              .build();
        }
      }
    }
    return getSubirCancionMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionAG,
      mx.uv.manejoCanciones.CancionPP> getDescargarCancionMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "DescargarCancion",
      requestType = mx.uv.manejoCanciones.CancionAG.class,
      responseType = mx.uv.manejoCanciones.CancionPP.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionAG,
      mx.uv.manejoCanciones.CancionPP> getDescargarCancionMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.CancionAG, mx.uv.manejoCanciones.CancionPP> getDescargarCancionMethod;
    if ((getDescargarCancionMethod = ManejoCancionesGrpc.getDescargarCancionMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getDescargarCancionMethod = ManejoCancionesGrpc.getDescargarCancionMethod) == null) {
          ManejoCancionesGrpc.getDescargarCancionMethod = getDescargarCancionMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.CancionAG, mx.uv.manejoCanciones.CancionPP>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "DescargarCancion"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.CancionAG.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.CancionPP.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("DescargarCancion"))
              .build();
        }
      }
    }
    return getDescargarCancionMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesPopularesMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarCancionesPopulares",
      requestType = mx.uv.manejoCanciones.IdUsuario.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesPopularesMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesPopularesMethod;
    if ((getConsultarCancionesPopularesMethod = ManejoCancionesGrpc.getConsultarCancionesPopularesMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarCancionesPopularesMethod = ManejoCancionesGrpc.getConsultarCancionesPopularesMethod) == null) {
          ManejoCancionesGrpc.getConsultarCancionesPopularesMethod = getConsultarCancionesPopularesMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarCancionesPopulares"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdUsuario.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarCancionesPopulares"))
              .build();
        }
      }
    }
    return getConsultarCancionesPopularesMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaAlbums> getConsultarAlbumsPopularesMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarAlbumsPopulares",
      requestType = mx.uv.manejoCanciones.IdUsuario.class,
      responseType = mx.uv.manejoCanciones.ListaAlbums.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaAlbums> getConsultarAlbumsPopularesMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaAlbums> getConsultarAlbumsPopularesMethod;
    if ((getConsultarAlbumsPopularesMethod = ManejoCancionesGrpc.getConsultarAlbumsPopularesMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarAlbumsPopularesMethod = ManejoCancionesGrpc.getConsultarAlbumsPopularesMethod) == null) {
          ManejoCancionesGrpc.getConsultarAlbumsPopularesMethod = getConsultarAlbumsPopularesMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaAlbums>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarAlbumsPopulares"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdUsuario.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaAlbums.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarAlbumsPopulares"))
              .build();
        }
      }
    }
    return getConsultarAlbumsPopularesMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesAleatoriasMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarCancionesAleatorias",
      requestType = mx.uv.manejoCanciones.IdUsuario.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesAleatoriasMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesAleatoriasMethod;
    if ((getConsultarCancionesAleatoriasMethod = ManejoCancionesGrpc.getConsultarCancionesAleatoriasMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarCancionesAleatoriasMethod = ManejoCancionesGrpc.getConsultarCancionesAleatoriasMethod) == null) {
          ManejoCancionesGrpc.getConsultarCancionesAleatoriasMethod = getConsultarCancionesAleatoriasMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarCancionesAleatorias"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdUsuario.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarCancionesAleatorias"))
              .build();
        }
      }
    }
    return getConsultarCancionesAleatoriasMethod;
  }

  private static volatile io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesPersonalesMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ConsultarCancionesPersonales",
      requestType = mx.uv.manejoCanciones.IdUsuario.class,
      responseType = mx.uv.manejoCanciones.ListaCanciones.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario,
      mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesPersonalesMethod() {
    io.grpc.MethodDescriptor<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones> getConsultarCancionesPersonalesMethod;
    if ((getConsultarCancionesPersonalesMethod = ManejoCancionesGrpc.getConsultarCancionesPersonalesMethod) == null) {
      synchronized (ManejoCancionesGrpc.class) {
        if ((getConsultarCancionesPersonalesMethod = ManejoCancionesGrpc.getConsultarCancionesPersonalesMethod) == null) {
          ManejoCancionesGrpc.getConsultarCancionesPersonalesMethod = getConsultarCancionesPersonalesMethod =
              io.grpc.MethodDescriptor.<mx.uv.manejoCanciones.IdUsuario, mx.uv.manejoCanciones.ListaCanciones>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "ConsultarCancionesPersonales"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.IdUsuario.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()))
              .setSchemaDescriptor(new ManejoCancionesMethodDescriptorSupplier("ConsultarCancionesPersonales"))
              .build();
        }
      }
    }
    return getConsultarCancionesPersonalesMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static ManejoCancionesStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<ManejoCancionesStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<ManejoCancionesStub>() {
        @java.lang.Override
        public ManejoCancionesStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new ManejoCancionesStub(channel, callOptions);
        }
      };
    return ManejoCancionesStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static ManejoCancionesBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<ManejoCancionesBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<ManejoCancionesBlockingStub>() {
        @java.lang.Override
        public ManejoCancionesBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new ManejoCancionesBlockingStub(channel, callOptions);
        }
      };
    return ManejoCancionesBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static ManejoCancionesFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<ManejoCancionesFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<ManejoCancionesFutureStub>() {
        @java.lang.Override
        public ManejoCancionesFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new ManejoCancionesFutureStub(channel, callOptions);
        }
      };
    return ManejoCancionesFutureStub.newStub(factory, channel);
  }

  /**
   */
  public static abstract class ManejoCancionesImplBase implements io.grpc.BindableService {

    /**
     */
    public void buscarCanciones(mx.uv.manejoCanciones.Busqueda request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getBuscarCancionesMethod(), responseObserver);
    }

    /**
     */
    public void buscarAlbumes(mx.uv.manejoCanciones.Busqueda request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums> responseObserver) {
      asyncUnimplementedUnaryCall(getBuscarAlbumesMethod(), responseObserver);
    }

    /**
     */
    public void crearAlbum(mx.uv.manejoCanciones.AlbumAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getCrearAlbumMethod(), responseObserver);
    }

    /**
     */
    public void consultarMisCanciones(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarMisCancionesMethod(), responseObserver);
    }

    /**
     */
    public void consultarCancionesEnPromocion(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarCancionesEnPromocionMethod(), responseObserver);
    }

    /**
     */
    public void consultarAlbums(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarAlbumsMethod(), responseObserver);
    }

    /**
     */
    public void consultarCancionesAlbum(mx.uv.manejoCanciones.Album request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarCancionesAlbumMethod(), responseObserver);
    }

    /**
     */
    public void consultarCancionesLista(mx.uv.manejoCanciones.IdLista request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarCancionesListaMethod(), responseObserver);
    }

    /**
     */
    public void generarRadio(mx.uv.manejoCanciones.Cancion request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getGenerarRadioMethod(), responseObserver);
    }

    /**
     */
    public void modificarAlbum(mx.uv.manejoCanciones.AlbumAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getModificarAlbumMethod(), responseObserver);
    }

    /**
     */
    public void reproducirCancion(mx.uv.manejoCanciones.CancionAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP> responseObserver) {
      asyncUnimplementedUnaryCall(getReproducirCancionMethod(), responseObserver);
    }

    /**
     */
    public io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP> subirCancion(
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones> responseObserver) {
      return asyncUnimplementedStreamingCall(getSubirCancionMethod(), responseObserver);
    }

    /**
     */
    public void descargarCancion(mx.uv.manejoCanciones.CancionAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP> responseObserver) {
      asyncUnimplementedUnaryCall(getDescargarCancionMethod(), responseObserver);
    }

    /**
     */
    public void consultarCancionesPopulares(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarCancionesPopularesMethod(), responseObserver);
    }

    /**
     */
    public void consultarAlbumsPopulares(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarAlbumsPopularesMethod(), responseObserver);
    }

    /**
     */
    public void consultarCancionesAleatorias(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarCancionesAleatoriasMethod(), responseObserver);
    }

    /**
     */
    public void consultarCancionesPersonales(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnimplementedUnaryCall(getConsultarCancionesPersonalesMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getBuscarCancionesMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.Busqueda,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_BUSCAR_CANCIONES)))
          .addMethod(
            getBuscarAlbumesMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.Busqueda,
                mx.uv.manejoCanciones.ListaAlbums>(
                  this, METHODID_BUSCAR_ALBUMES)))
          .addMethod(
            getCrearAlbumMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.AlbumAG,
                mx.uv.manejoCanciones.RespuestaCanciones>(
                  this, METHODID_CREAR_ALBUM)))
          .addMethod(
            getConsultarMisCancionesMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdUsuario,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_CONSULTAR_MIS_CANCIONES)))
          .addMethod(
            getConsultarCancionesEnPromocionMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdUsuario,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_CONSULTAR_CANCIONES_EN_PROMOCION)))
          .addMethod(
            getConsultarAlbumsMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdUsuario,
                mx.uv.manejoCanciones.ListaAlbums>(
                  this, METHODID_CONSULTAR_ALBUMS)))
          .addMethod(
            getConsultarCancionesAlbumMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.Album,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_CONSULTAR_CANCIONES_ALBUM)))
          .addMethod(
            getConsultarCancionesListaMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdLista,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_CONSULTAR_CANCIONES_LISTA)))
          .addMethod(
            getGenerarRadioMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.Cancion,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_GENERAR_RADIO)))
          .addMethod(
            getModificarAlbumMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.AlbumAG,
                mx.uv.manejoCanciones.RespuestaCanciones>(
                  this, METHODID_MODIFICAR_ALBUM)))
          .addMethod(
            getReproducirCancionMethod(),
            asyncServerStreamingCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.CancionAG,
                mx.uv.manejoCanciones.CancionPP>(
                  this, METHODID_REPRODUCIR_CANCION)))
          .addMethod(
            getSubirCancionMethod(),
            asyncClientStreamingCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.CancionPP,
                mx.uv.manejoCanciones.RespuestaCanciones>(
                  this, METHODID_SUBIR_CANCION)))
          .addMethod(
            getDescargarCancionMethod(),
            asyncServerStreamingCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.CancionAG,
                mx.uv.manejoCanciones.CancionPP>(
                  this, METHODID_DESCARGAR_CANCION)))
          .addMethod(
            getConsultarCancionesPopularesMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdUsuario,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_CONSULTAR_CANCIONES_POPULARES)))
          .addMethod(
            getConsultarAlbumsPopularesMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdUsuario,
                mx.uv.manejoCanciones.ListaAlbums>(
                  this, METHODID_CONSULTAR_ALBUMS_POPULARES)))
          .addMethod(
            getConsultarCancionesAleatoriasMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdUsuario,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_CONSULTAR_CANCIONES_ALEATORIAS)))
          .addMethod(
            getConsultarCancionesPersonalesMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                mx.uv.manejoCanciones.IdUsuario,
                mx.uv.manejoCanciones.ListaCanciones>(
                  this, METHODID_CONSULTAR_CANCIONES_PERSONALES)))
          .build();
    }
  }

  /**
   */
  public static final class ManejoCancionesStub extends io.grpc.stub.AbstractAsyncStub<ManejoCancionesStub> {
    private ManejoCancionesStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected ManejoCancionesStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new ManejoCancionesStub(channel, callOptions);
    }

    /**
     */
    public void buscarCanciones(mx.uv.manejoCanciones.Busqueda request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getBuscarCancionesMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void buscarAlbumes(mx.uv.manejoCanciones.Busqueda request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getBuscarAlbumesMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void crearAlbum(mx.uv.manejoCanciones.AlbumAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getCrearAlbumMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarMisCanciones(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarMisCancionesMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarCancionesEnPromocion(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarCancionesEnPromocionMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarAlbums(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarAlbumsMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarCancionesAlbum(mx.uv.manejoCanciones.Album request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarCancionesAlbumMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarCancionesLista(mx.uv.manejoCanciones.IdLista request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarCancionesListaMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void generarRadio(mx.uv.manejoCanciones.Cancion request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getGenerarRadioMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void modificarAlbum(mx.uv.manejoCanciones.AlbumAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getModificarAlbumMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void reproducirCancion(mx.uv.manejoCanciones.CancionAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP> responseObserver) {
      asyncServerStreamingCall(
          getChannel().newCall(getReproducirCancionMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP> subirCancion(
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones> responseObserver) {
      return asyncClientStreamingCall(
          getChannel().newCall(getSubirCancionMethod(), getCallOptions()), responseObserver);
    }

    /**
     */
    public void descargarCancion(mx.uv.manejoCanciones.CancionAG request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP> responseObserver) {
      asyncServerStreamingCall(
          getChannel().newCall(getDescargarCancionMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarCancionesPopulares(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarCancionesPopularesMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarAlbumsPopulares(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarAlbumsPopularesMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarCancionesAleatorias(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarCancionesAleatoriasMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void consultarCancionesPersonales(mx.uv.manejoCanciones.IdUsuario request,
        io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getConsultarCancionesPersonalesMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class ManejoCancionesBlockingStub extends io.grpc.stub.AbstractBlockingStub<ManejoCancionesBlockingStub> {
    private ManejoCancionesBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected ManejoCancionesBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new ManejoCancionesBlockingStub(channel, callOptions);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones buscarCanciones(mx.uv.manejoCanciones.Busqueda request) {
      return blockingUnaryCall(
          getChannel(), getBuscarCancionesMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaAlbums buscarAlbumes(mx.uv.manejoCanciones.Busqueda request) {
      return blockingUnaryCall(
          getChannel(), getBuscarAlbumesMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.RespuestaCanciones crearAlbum(mx.uv.manejoCanciones.AlbumAG request) {
      return blockingUnaryCall(
          getChannel(), getCrearAlbumMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones consultarMisCanciones(mx.uv.manejoCanciones.IdUsuario request) {
      return blockingUnaryCall(
          getChannel(), getConsultarMisCancionesMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones consultarCancionesEnPromocion(mx.uv.manejoCanciones.IdUsuario request) {
      return blockingUnaryCall(
          getChannel(), getConsultarCancionesEnPromocionMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaAlbums consultarAlbums(mx.uv.manejoCanciones.IdUsuario request) {
      return blockingUnaryCall(
          getChannel(), getConsultarAlbumsMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones consultarCancionesAlbum(mx.uv.manejoCanciones.Album request) {
      return blockingUnaryCall(
          getChannel(), getConsultarCancionesAlbumMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones consultarCancionesLista(mx.uv.manejoCanciones.IdLista request) {
      return blockingUnaryCall(
          getChannel(), getConsultarCancionesListaMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones generarRadio(mx.uv.manejoCanciones.Cancion request) {
      return blockingUnaryCall(
          getChannel(), getGenerarRadioMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.RespuestaCanciones modificarAlbum(mx.uv.manejoCanciones.AlbumAG request) {
      return blockingUnaryCall(
          getChannel(), getModificarAlbumMethod(), getCallOptions(), request);
    }

    /**
     */
    public java.util.Iterator<mx.uv.manejoCanciones.CancionPP> reproducirCancion(
        mx.uv.manejoCanciones.CancionAG request) {
      return blockingServerStreamingCall(
          getChannel(), getReproducirCancionMethod(), getCallOptions(), request);
    }

    /**
     */
    public java.util.Iterator<mx.uv.manejoCanciones.CancionPP> descargarCancion(
        mx.uv.manejoCanciones.CancionAG request) {
      return blockingServerStreamingCall(
          getChannel(), getDescargarCancionMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones consultarCancionesPopulares(mx.uv.manejoCanciones.IdUsuario request) {
      return blockingUnaryCall(
          getChannel(), getConsultarCancionesPopularesMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaAlbums consultarAlbumsPopulares(mx.uv.manejoCanciones.IdUsuario request) {
      return blockingUnaryCall(
          getChannel(), getConsultarAlbumsPopularesMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones consultarCancionesAleatorias(mx.uv.manejoCanciones.IdUsuario request) {
      return blockingUnaryCall(
          getChannel(), getConsultarCancionesAleatoriasMethod(), getCallOptions(), request);
    }

    /**
     */
    public mx.uv.manejoCanciones.ListaCanciones consultarCancionesPersonales(mx.uv.manejoCanciones.IdUsuario request) {
      return blockingUnaryCall(
          getChannel(), getConsultarCancionesPersonalesMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class ManejoCancionesFutureStub extends io.grpc.stub.AbstractFutureStub<ManejoCancionesFutureStub> {
    private ManejoCancionesFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected ManejoCancionesFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new ManejoCancionesFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> buscarCanciones(
        mx.uv.manejoCanciones.Busqueda request) {
      return futureUnaryCall(
          getChannel().newCall(getBuscarCancionesMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaAlbums> buscarAlbumes(
        mx.uv.manejoCanciones.Busqueda request) {
      return futureUnaryCall(
          getChannel().newCall(getBuscarAlbumesMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.RespuestaCanciones> crearAlbum(
        mx.uv.manejoCanciones.AlbumAG request) {
      return futureUnaryCall(
          getChannel().newCall(getCrearAlbumMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> consultarMisCanciones(
        mx.uv.manejoCanciones.IdUsuario request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarMisCancionesMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> consultarCancionesEnPromocion(
        mx.uv.manejoCanciones.IdUsuario request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarCancionesEnPromocionMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaAlbums> consultarAlbums(
        mx.uv.manejoCanciones.IdUsuario request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarAlbumsMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> consultarCancionesAlbum(
        mx.uv.manejoCanciones.Album request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarCancionesAlbumMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> consultarCancionesLista(
        mx.uv.manejoCanciones.IdLista request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarCancionesListaMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> generarRadio(
        mx.uv.manejoCanciones.Cancion request) {
      return futureUnaryCall(
          getChannel().newCall(getGenerarRadioMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.RespuestaCanciones> modificarAlbum(
        mx.uv.manejoCanciones.AlbumAG request) {
      return futureUnaryCall(
          getChannel().newCall(getModificarAlbumMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> consultarCancionesPopulares(
        mx.uv.manejoCanciones.IdUsuario request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarCancionesPopularesMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaAlbums> consultarAlbumsPopulares(
        mx.uv.manejoCanciones.IdUsuario request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarAlbumsPopularesMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> consultarCancionesAleatorias(
        mx.uv.manejoCanciones.IdUsuario request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarCancionesAleatoriasMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<mx.uv.manejoCanciones.ListaCanciones> consultarCancionesPersonales(
        mx.uv.manejoCanciones.IdUsuario request) {
      return futureUnaryCall(
          getChannel().newCall(getConsultarCancionesPersonalesMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_BUSCAR_CANCIONES = 0;
  private static final int METHODID_BUSCAR_ALBUMES = 1;
  private static final int METHODID_CREAR_ALBUM = 2;
  private static final int METHODID_CONSULTAR_MIS_CANCIONES = 3;
  private static final int METHODID_CONSULTAR_CANCIONES_EN_PROMOCION = 4;
  private static final int METHODID_CONSULTAR_ALBUMS = 5;
  private static final int METHODID_CONSULTAR_CANCIONES_ALBUM = 6;
  private static final int METHODID_CONSULTAR_CANCIONES_LISTA = 7;
  private static final int METHODID_GENERAR_RADIO = 8;
  private static final int METHODID_MODIFICAR_ALBUM = 9;
  private static final int METHODID_REPRODUCIR_CANCION = 10;
  private static final int METHODID_DESCARGAR_CANCION = 11;
  private static final int METHODID_CONSULTAR_CANCIONES_POPULARES = 12;
  private static final int METHODID_CONSULTAR_ALBUMS_POPULARES = 13;
  private static final int METHODID_CONSULTAR_CANCIONES_ALEATORIAS = 14;
  private static final int METHODID_CONSULTAR_CANCIONES_PERSONALES = 15;
  private static final int METHODID_SUBIR_CANCION = 16;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final ManejoCancionesImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(ManejoCancionesImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_BUSCAR_CANCIONES:
          serviceImpl.buscarCanciones((mx.uv.manejoCanciones.Busqueda) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_BUSCAR_ALBUMES:
          serviceImpl.buscarAlbumes((mx.uv.manejoCanciones.Busqueda) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums>) responseObserver);
          break;
        case METHODID_CREAR_ALBUM:
          serviceImpl.crearAlbum((mx.uv.manejoCanciones.AlbumAG) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones>) responseObserver);
          break;
        case METHODID_CONSULTAR_MIS_CANCIONES:
          serviceImpl.consultarMisCanciones((mx.uv.manejoCanciones.IdUsuario) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_CONSULTAR_CANCIONES_EN_PROMOCION:
          serviceImpl.consultarCancionesEnPromocion((mx.uv.manejoCanciones.IdUsuario) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_CONSULTAR_ALBUMS:
          serviceImpl.consultarAlbums((mx.uv.manejoCanciones.IdUsuario) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums>) responseObserver);
          break;
        case METHODID_CONSULTAR_CANCIONES_ALBUM:
          serviceImpl.consultarCancionesAlbum((mx.uv.manejoCanciones.Album) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_CONSULTAR_CANCIONES_LISTA:
          serviceImpl.consultarCancionesLista((mx.uv.manejoCanciones.IdLista) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_GENERAR_RADIO:
          serviceImpl.generarRadio((mx.uv.manejoCanciones.Cancion) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_MODIFICAR_ALBUM:
          serviceImpl.modificarAlbum((mx.uv.manejoCanciones.AlbumAG) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones>) responseObserver);
          break;
        case METHODID_REPRODUCIR_CANCION:
          serviceImpl.reproducirCancion((mx.uv.manejoCanciones.CancionAG) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP>) responseObserver);
          break;
        case METHODID_DESCARGAR_CANCION:
          serviceImpl.descargarCancion((mx.uv.manejoCanciones.CancionAG) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.CancionPP>) responseObserver);
          break;
        case METHODID_CONSULTAR_CANCIONES_POPULARES:
          serviceImpl.consultarCancionesPopulares((mx.uv.manejoCanciones.IdUsuario) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_CONSULTAR_ALBUMS_POPULARES:
          serviceImpl.consultarAlbumsPopulares((mx.uv.manejoCanciones.IdUsuario) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaAlbums>) responseObserver);
          break;
        case METHODID_CONSULTAR_CANCIONES_ALEATORIAS:
          serviceImpl.consultarCancionesAleatorias((mx.uv.manejoCanciones.IdUsuario) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        case METHODID_CONSULTAR_CANCIONES_PERSONALES:
          serviceImpl.consultarCancionesPersonales((mx.uv.manejoCanciones.IdUsuario) request,
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.ListaCanciones>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_SUBIR_CANCION:
          return (io.grpc.stub.StreamObserver<Req>) serviceImpl.subirCancion(
              (io.grpc.stub.StreamObserver<mx.uv.manejoCanciones.RespuestaCanciones>) responseObserver);
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class ManejoCancionesBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    ManejoCancionesBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return mx.uv.manejoCanciones.CancionesProto.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("ManejoCanciones");
    }
  }

  private static final class ManejoCancionesFileDescriptorSupplier
      extends ManejoCancionesBaseDescriptorSupplier {
    ManejoCancionesFileDescriptorSupplier() {}
  }

  private static final class ManejoCancionesMethodDescriptorSupplier
      extends ManejoCancionesBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    ManejoCancionesMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (ManejoCancionesGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new ManejoCancionesFileDescriptorSupplier())
              .addMethod(getBuscarCancionesMethod())
              .addMethod(getBuscarAlbumesMethod())
              .addMethod(getCrearAlbumMethod())
              .addMethod(getConsultarMisCancionesMethod())
              .addMethod(getConsultarCancionesEnPromocionMethod())
              .addMethod(getConsultarAlbumsMethod())
              .addMethod(getConsultarCancionesAlbumMethod())
              .addMethod(getConsultarCancionesListaMethod())
              .addMethod(getGenerarRadioMethod())
              .addMethod(getModificarAlbumMethod())
              .addMethod(getReproducirCancionMethod())
              .addMethod(getSubirCancionMethod())
              .addMethod(getDescargarCancionMethod())
              .addMethod(getConsultarCancionesPopularesMethod())
              .addMethod(getConsultarAlbumsPopularesMethod())
              .addMethod(getConsultarCancionesAleatoriasMethod())
              .addMethod(getConsultarCancionesPersonalesMethod())
              .build();
        }
      }
    }
    return result;
  }
}
