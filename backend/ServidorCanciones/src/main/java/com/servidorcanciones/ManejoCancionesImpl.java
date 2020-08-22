package com.servidorcanciones;

import com.google.protobuf.ByteString;
import com.servidorcanciones.modelos.*;
import io.grpc.Status;
import io.grpc.stub.StreamObserver;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.sql.Time;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.logging.FileHandler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;
import mx.uv.manejoCanciones.*;
import org.apache.commons.io.FilenameUtils;
import org.javalite.activejdbc.Base;

/**
 *
 * @author IS Vega
 */
public class ManejoCancionesImpl extends ManejoCancionesGrpc.ManejoCancionesImplBase {

    static final Logger logger = Logger.getLogger(ManejoCancionesImpl.class.getName());
    static final String CARPETA_ALBUMS = "Albums/";
    static final int CHUNK_SIZE = 524288;
    static final String SQLSERVER_DRIVER = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
    static final String SIREMUDB_URL = "jdbc:sqlserver://host.docker.internal:1443;databaseName=SiReMu";
    static final String SIREMUDB_USER = "sa";
    static final String SIREMUDB_PASS = "Passw0rd";

    static {
        FileHandler fh;
        try {
            fh = new FileHandler("log/mnj_canciones_log.log", true);
            logger.addHandler(fh);
            SimpleFormatter formatter = new SimpleFormatter();
            fh.setFormatter(formatter);
            logger.setUseParentHandlers(false);
            logger.info("Primer log");
        } catch (SecurityException | IOException ex) {
            logger.log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void consultarCancionesAleatorias(IdUsuario request, StreamObserver<ListaCanciones> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<CancionSet> cancionesAleatorias = CancionSet.where("id != ? and esPublica = ? ORDER BY NEWID()", 0, "true").limit(6);
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(ConversorObjetosGRPC.convertirListaCanciones(cancionesAleatorias)).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarAlbumsPopulares(IdUsuario request, StreamObserver<ListaAlbums> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<AlbumSet> albumsPopulares = AlbumSet.where("id != ? and esPublico = ? ORDER BY fechaLanzamiento DESC", 0, true).limit(6);
            responseObserver.onNext(ListaAlbums.newBuilder().addAllAlbums(ConversorObjetosGRPC.convertirListaAlbums(albumsPopulares)).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarCancionesPopulares(IdUsuario request, StreamObserver<ListaCanciones> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<CancionSet> cancionesPopulares = CancionSet.where("id != ? and esPublica = ? ORDER BY likes DESC", 0, "true").limit(6);
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(ConversorObjetosGRPC.convertirListaCanciones(cancionesPopulares)).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    public int registrarCancion(Cancion cancion, int idUsuario, String archivo) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            UsuarioSet usuarioActual = UsuarioSet.findById(idUsuario);
            AlbumSet albumActual = new AlbumSet();
            if (!cancion.getEsPublica()) {
                int numeroCanciones = 0;
                List<AlbumSet> albumesUsuario = usuarioActual.get(AlbumSet.class, "esPublico = ?", false);
                for (AlbumSet albumSet : albumesUsuario) {
                    numeroCanciones = numeroCanciones + albumSet.getAll(CancionSet.class).size();
                }
                if (numeroCanciones >= 250) {
                    Base.close();
                    return 1;
                }
                List<AlbumSet> albumesPrivados = usuarioActual.get(AlbumSet.class, "nombre = ? and esPublico = ?", cancion.getAlbum().getNombre(), cancion.getEsPublica());
                if (!albumesPrivados.isEmpty()) {
                    albumActual = albumesPrivados.get(0);
                }
            } else {
                albumActual = AlbumSet.findById(cancion.getAlbum().getId());
            }
            if (!albumActual.get(CancionSet.class, "nombre = ?", cancion.getNombre()).isEmpty()) {
                Base.close();
                return 2;
            }
            LocalTime duracion = LocalTime.parse("00:" + cancion.getDuracion(), DateTimeFormatter.ISO_TIME);
            CancionSet nuevaCancion = new CancionSet();
            nuevaCancion.set("archivo", archivo);
            nuevaCancion.set("artista", cancion.getArtista());
            nuevaCancion.set("duracion", Time.valueOf(duracion));
            nuevaCancion.set("genero", cancion.getGenero());
            nuevaCancion.set("nombre", cancion.getNombre());
            nuevaCancion.set("esPromocion", false);
            nuevaCancion.set("likes", 0);
            nuevaCancion.set("esPublica", cancion.getEsPublica());
            albumActual.add(nuevaCancion);
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            return 3;
        } finally {
            Base.close();
        }
        return 0;
    }

    @Override
    public void reproducirCancion(CancionAG request, StreamObserver<CancionPP> responseObserver) {
        File archivo;
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            CancionSet cancionActual = CancionSet.findById(request.getCancion().getId());
            if (cancionActual == null) {
                Base.close();
                responseObserver.onError(Status.NOT_FOUND.withDescription(Excepciones.CANCIONNOENCONTRADA).asRuntimeException());
                return;
            }
            CancionSet cancionHistorial = CancionSet.findFirst("id = ?", request.getCancion().getId());
            archivo = new File(cancionActual.getString("archivo"));
            String extensionArchivo = FilenameUtils.getExtension(archivo.getName());
            responseObserver.onNext(CancionPP.newBuilder().setCancion(Cancion.newBuilder().setId(request.getCancion().getId()).build()).setExtensionarchivo("." + extensionArchivo).build());
            List<ListaUsuario> listasRelacion = ListaUsuario.where("usuario_set_id = ?", request.getIdUsuario());
            List<ListaReproduccionSet> listas = ListaReproduccionSet.where("id != ?", 0);
            List<ListaReproduccionSet> listasUsuario = new ArrayList<>();
            for (ListaUsuario listaRelacion : listasRelacion) {
                for (ListaReproduccionSet lista : listas) {
                    if (Objects.equals(listaRelacion.getInteger("lista_reproduccion_set_id"), lista.getInteger("id"))) {
                        listasUsuario.add(lista);
                    }
                }
            }
            ListaReproduccionSet listaHistorial = new ListaReproduccionSet();
            for (ListaReproduccionSet lista : listasUsuario) {
                if ("Mi historial".equals(lista.getString("nombre"))) {
                    listaHistorial = lista;
                }
            }
            CancionSetsListaReproduccionSet nuevaEntrada = new CancionSetsListaReproduccionSet();
            nuevaEntrada.set("cancion_set_id", cancionHistorial.getInteger("id"));
            nuevaEntrada.set("lista_reproduccion_set_id", listaHistorial.getInteger("id"));
            nuevaEntrada.saveIt();
            try (FileInputStream ios = new FileInputStream(archivo)) {
                byte[] buffer = new byte[CHUNK_SIZE];
                while (ios.read(buffer) != -1) {
                    responseObserver.onNext(CancionPP.newBuilder().setContenido(ByteString.copyFrom(buffer)).build());
                }
            }
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public StreamObserver<CancionPP> subirCancion(StreamObserver<RespuestaCanciones> responseObserver) {
        return new StreamObserver<CancionPP>() {
            private OutputStream salidaArchivo = null;

            @Override
            public void onNext(CancionPP pedazo) {
                if (pedazo.hasCancion()) {
                    String direccionAlbum = AdministradorArchivos.obtenerDireccionAlbum(pedazo.getIdUsuario(), pedazo.getCancion().getAlbum().getNombre(), pedazo.getCancion().getEsPublica());
                    String direccionCancion = direccionAlbum + "/" + pedazo.getCancion().getNombre() + pedazo.getExtensionarchivo();
                    int respuesta = registrarCancion(pedazo.getCancion(), pedazo.getIdUsuario(), direccionCancion);
                    switch (respuesta) {
                        case 1:
                            responseObserver.onError(Status.OUT_OF_RANGE.withDescription(Excepciones.NUMCANCIONESPRIVADASEXCEDIDO).asRuntimeException());
                            return;
                        case 2:
                            responseObserver.onError(Status.ALREADY_EXISTS.withDescription(Excepciones.CANCIONREPETIDA).asRuntimeException());
                            return;
                        case 3:
                            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
                            return;
                        default:
                            break;
                    }
                    try {
                        salidaArchivo = new FileOutputStream(new File(direccionCancion));
                    } catch (FileNotFoundException ex) {
                        logger.log(Level.SEVERE, null, ex);
                        responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
                    }
                    return;
                }
                if (salidaArchivo == null) {
                    responseObserver.onError(Status.INVALID_ARGUMENT.withDescription(Excepciones.DATOSCANCIONFALTANTES).asRuntimeException());
                    return;
                }
                try {
                    salidaArchivo.write(pedazo.getContenido().toByteArray());
                } catch (IOException ex) {
                    logger.log(Level.SEVERE, null, ex);
                    responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
                }
            }

            @Override
            public void onError(Throwable t) {
                logger.log(Level.SEVERE, null, t.getMessage());
            }

            @Override
            public void onCompleted() {
                try {
                    salidaArchivo.close();
                    responseObserver.onNext(RespuestaCanciones.newBuilder().setRespuesta(true).build());
                    responseObserver.onCompleted();
                } catch (IOException ex) {
                    logger.log(Level.SEVERE, null, ex);
                    responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
                }

            }
        };
    }

    @Override
    public void generarRadio(Cancion request, StreamObserver<ListaCanciones> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<CancionSet> cancionesRadio = CancionSet.where("genero = ? and esPublica = ? ORDER BY NEWID()", request.getGenero(), true).limit(15);
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(ConversorObjetosGRPC.convertirListaCanciones(cancionesRadio)).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarCancionesLista(IdLista request, StreamObserver<ListaCanciones> responseObserver) {
        List<Cancion> cancionesGrpc = new ArrayList<>();
        List<CancionSet> cancionesLista;
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            ListaReproduccionSet listaActual = ListaReproduccionSet.findById(request.getId());
            if (ListaUsuario.where("lista_reproduccion_set_id = ? and usuario_set_id = ? and esPropietario = ?", request.getId(), request.getIdUsuario(), true).isEmpty()) {
                cancionesLista = listaActual.get(CancionSet.class, "esPublica = ?", true);
            } else {
                cancionesLista = listaActual.getAll(CancionSet.class);
            }
            for (CancionSet cancion : cancionesLista) {
                cancionesGrpc.add(ConversorObjetosGRPC.convertirCancion(cancion));
            }
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(cancionesGrpc).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarCancionesAlbum(Album request, StreamObserver<ListaCanciones> responseObserver) {
        List<Cancion> cancionesGrpc = new ArrayList<>();
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<CancionSet> canciones = CancionSet.where("album_set_id = ?", request.getId());
            List<CancionSet> cancionesUsuarioSD = new ArrayList<>();
            for (CancionSet cancionUsuario : canciones) {
                boolean yaExiste = false;
                for (CancionSet cancionObtenida : cancionesUsuarioSD) {
                    if (Objects.equals(cancionUsuario.getInteger("id"), cancionObtenida.getInteger("id"))) {
                        yaExiste = true;
                    }
                }
                if (!yaExiste) {
                    cancionesUsuarioSD.add(cancionUsuario);
                }
            }
            for (CancionSet cancion : cancionesUsuarioSD) {
                cancionesGrpc.add(ConversorObjetosGRPC.convertirCancion(cancion));
            }
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(cancionesGrpc).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarAlbums(IdUsuario request, StreamObserver<ListaAlbums> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<AlbumSet> albumsPublicos = AlbumSet.where("usuario_set_id = ? and esPublico = 1", request.getId());
            responseObserver.onNext(ListaAlbums.newBuilder().addAllAlbums(ConversorObjetosGRPC.convertirListaAlbums(albumsPublicos)).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarCancionesEnPromocion(IdUsuario request, StreamObserver<ListaCanciones> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<AlbumSet> albums = AlbumSet.where("usuario_set_id != ?", 0);
            List<CancionSet> canciones = CancionSet.where("id != ? and esPublica = ?", 0, true).limit(10);
            List<CancionSet> cancionesUsuario = new ArrayList<>();
            List<CancionSet> cancionesUsuarioProm = new ArrayList<>();
            List<Cancion> cancionesGrpc = new ArrayList<>();
            for (CancionSet cancion : canciones) {
                for (AlbumSet album : albums) {
                    if (Objects.equals(cancion.getInteger("album_set_id"), album.getId())) {
                        cancionesUsuario.add(cancion);
                    }
                }
            }
            for (CancionSet cancion : cancionesUsuario) {
                if (Boolean.TRUE.equals(cancion.getBoolean("esPromocion"))) {
                    cancionesUsuarioProm.add(cancion);
                }
            }
            for (CancionSet cancion : cancionesUsuarioProm) {
                cancionesGrpc.add(ConversorObjetosGRPC.convertirCancion(cancion));
            }
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(cancionesGrpc).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarMisCanciones(IdUsuario request, StreamObserver<ListaCanciones> responseObserver) {
        List<Cancion> cancionesGrpc = new ArrayList<>();
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<ListaUsuario> listaUsuarios = ListaUsuario.where("usuario_set_id = ?", request.getId());
            for (ListaUsuario listaUsuario : listaUsuarios) {
                ListaReproduccionSet listaActual = ListaReproduccionSet.findById(listaUsuario.get("lista_reproduccion_set_id"));
                if (Boolean.FALSE.equals(listaActual.getBoolean("esDefault"))) {
                    List<CancionSet> cancionesLista = listaActual.get(CancionSet.class, "esPublica = ?", true);
                    for (CancionSet cancion : cancionesLista) {
                        if (cancionesGrpc.stream().noneMatch(c -> c.getId() == cancion.getInteger("id"))) {
                            cancionesGrpc.add(ConversorObjetosGRPC.convertirCancion(cancion));
                        }
                    }
                }
            }
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(cancionesGrpc).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void crearAlbum(AlbumAG request, StreamObserver<RespuestaCanciones> responseObserver) {
        UsuarioSet usuarioActual;
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            usuarioActual = UsuarioSet.findById(request.getIdUsuario());
            if (!usuarioActual.get(AlbumSet.class, "nombre = ? and esPublico = ?", request.getAlbum().getNombre(), request.getAlbum().getEsPublico()).isEmpty()) {
                Base.close();
                responseObserver.onError(Status.ALREADY_EXISTS.withDescription(Excepciones.ALBUMREPETIDO).asRuntimeException());
                return;
            }
        } catch (Exception ex) {
            Base.close();
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
            return;
        }
        String direccionAlbum = AdministradorArchivos.obtenerDireccionAlbum(request.getIdUsuario(), request.getAlbum().getNombre(), request.getAlbum().getEsPublico());
        String direccionImagen = direccionAlbum + "/" + request.getAlbum().getNombre() + request.getAlbum().getExtensionIlustracion();
        File carpetaAlbum = new File(direccionAlbum);
        if (!carpetaAlbum.exists() && !carpetaAlbum.mkdirs()) {
            Base.close();
            logger.log(Level.SEVERE, "Error al crear la carpeta del nuevo album");
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
            return;
        }
        File imagenAlbum = new File(direccionImagen);
        try (OutputStream os = new FileOutputStream(imagenAlbum)) {
            os.write(request.getAlbum().getIlustracion().toByteArray());
        } catch (IOException ex) {
            Base.close();
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
            return;
        }
        try {
            usuarioActual = UsuarioSet.findById(request.getIdUsuario());
            AlbumSet nuevoAlbum = new AlbumSet();
            nuevoAlbum.set("companiaDisco", request.getAlbum().getCompania());
            nuevoAlbum.set("fechaLanzamiento", request.getAlbum().getFechaLanzamiento());
            nuevoAlbum.set("ilustracion", direccionImagen);
            nuevoAlbum.set("nombre", request.getAlbum().getNombre());
            nuevoAlbum.set("esPublico", request.getAlbum().getEsPublico());
            usuarioActual.add(nuevoAlbum);
            responseObserver.onNext(RespuestaCanciones.newBuilder().setRespuesta(true).build());
            responseObserver.onCompleted();
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void buscarCanciones(Busqueda request, StreamObserver<ListaCanciones> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<CancionSet> cancionesEncontradas = CancionSet.where("nombre like ? and esPublica = 1", "%" + request.getNombre() + "%").limit(20).orderBy("nombre asc");
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(ConversorObjetosGRPC.convertirListaCanciones(cancionesEncontradas)).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void buscarAlbumes(Busqueda request, StreamObserver<ListaAlbums> responseObserver) {
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            List<AlbumSet> albumsEncontrados = AlbumSet.where("nombre like ? and esPublico = 1", "%" + request.getNombre() + "%").limit(20).orderBy("nombre asc");
            responseObserver.onNext(ListaAlbums.newBuilder().addAllAlbums(ConversorObjetosGRPC.convertirListaAlbums(albumsEncontrados)).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void descargarCancion(CancionAG request, StreamObserver<CancionPP> responseObserver) {
        File archivo;
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            CancionSet cancionAEnviar = CancionSet.findById(request.getCancion().getId());
            if (cancionAEnviar == null) {
                Base.close();
                responseObserver.onError(Status.NOT_FOUND.withDescription(Excepciones.CANCIONNOENCONTRADA).asRuntimeException());
                return;
            }
            archivo = new File(cancionAEnviar.getString("archivo"));
            String extensionArchivo = FilenameUtils.getExtension(archivo.getName());
            responseObserver.onNext(CancionPP.newBuilder().setCancion(Cancion.newBuilder().setId(request.getCancion().getId()).build()).setExtensionarchivo("." + extensionArchivo).build());
            try (FileInputStream archivoCancion = new FileInputStream(archivo)) {
                byte[] buffer = new byte[CHUNK_SIZE];
                while (archivoCancion.read(buffer) != -1) {
                    responseObserver.onNext(CancionPP.newBuilder().setContenido(ByteString.copyFrom(buffer)).build());
                }
            }
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

    @Override
    public void consultarCancionesPersonales(IdUsuario request, StreamObserver<ListaCanciones> responseObserver) {
        List<Cancion> cancionesGRPC = new ArrayList<>();
        try {
            Base.open(SQLSERVER_DRIVER, SIREMUDB_URL, SIREMUDB_USER, SIREMUDB_PASS);
            UsuarioSet usuarioActual = UsuarioSet.findById(request.getId());
            List<AlbumSet> albumsPrivados = usuarioActual.get(AlbumSet.class, "esPublico = ?", false).orderBy("nombre asc");
            for (AlbumSet album : albumsPrivados) {
                for (CancionSet cancion : album.getAll(CancionSet.class)) {
                    cancionesGRPC.add(ConversorObjetosGRPC.convertirCancion(cancion));
                }
            }
            responseObserver.onNext(ListaCanciones.newBuilder().addAllCanciones(cancionesGRPC).build());
            responseObserver.onCompleted();
        } catch (IOException ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.ERRORINTERNO).asRuntimeException());
        } catch (Exception ex) {
            logger.log(Level.SEVERE, null, ex);
            responseObserver.onError(Status.INTERNAL.withDescription(Excepciones.CONEXIONBDCAIDA).asRuntimeException());
        } finally {
            Base.close();
        }
    }

}
