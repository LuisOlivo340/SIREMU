// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: manejoCanciones.proto

package mx.uv.manejoCanciones;

public interface CancionPPOrBuilder extends
    // @@protoc_insertion_point(interface_extends:mnjCanciones.CancionPP)
    com.google.protobuf.MessageOrBuilder {

  /**
   * <code>int32 idUsuario = 1;</code>
   * @return The idUsuario.
   */
  int getIdUsuario();

  /**
   * <code>.mnjCanciones.Cancion cancion = 2;</code>
   * @return Whether the cancion field is set.
   */
  boolean hasCancion();
  /**
   * <code>.mnjCanciones.Cancion cancion = 2;</code>
   * @return The cancion.
   */
  mx.uv.manejoCanciones.Cancion getCancion();
  /**
   * <code>.mnjCanciones.Cancion cancion = 2;</code>
   */
  mx.uv.manejoCanciones.CancionOrBuilder getCancionOrBuilder();

  /**
   * <code>bytes contenido = 3;</code>
   * @return The contenido.
   */
  com.google.protobuf.ByteString getContenido();

  /**
   * <code>string extensionarchivo = 4;</code>
   * @return The extensionarchivo.
   */
  java.lang.String getExtensionarchivo();
  /**
   * <code>string extensionarchivo = 4;</code>
   * @return The bytes for extensionarchivo.
   */
  com.google.protobuf.ByteString
      getExtensionarchivoBytes();
}
