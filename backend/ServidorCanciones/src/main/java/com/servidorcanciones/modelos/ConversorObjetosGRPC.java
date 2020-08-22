package com.servidorcanciones.modelos;

import com.google.protobuf.ByteString;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import mx.uv.manejoCanciones.Album;
import mx.uv.manejoCanciones.Cancion;
import org.apache.commons.io.FilenameUtils;

/**
 *
 * @author IS Vega
 */
public class ConversorObjetosGRPC {

    private ConversorObjetosGRPC() {

    }

    public static Album convertirAlbum(AlbumSet album) throws IOException {
        File archivo;
        byte[] buffer;
        archivo = new File(album.getString("ilustracion"));
        buffer = Files.readAllBytes(archivo.toPath());
        String extensionArchivo = FilenameUtils.getExtension(archivo.getName());
        return Album.newBuilder()
                .setId(album.getInteger("id"))
                .setNombre(album.getString("nombre"))
                .setCompania(album.getString("companiaDisco"))
                .setFechaLanzamiento(album.getDate("fechaLanzamiento").toLocalDate().toString())
                .setEsPublico(album.getBoolean("esPublico"))
                .setIlustracion(ByteString.copyFrom(buffer))
                .setIdCreador(album.parent(UsuarioSet.class).getInteger("id"))
                .setNombreCreador(album.parent(UsuarioSet.class).getString("usuario"))
                .setExtensionIlustracion("." + extensionArchivo)
                .build();
    }

    public static Cancion convertirCancion(CancionSet cancion) throws IOException {
        DateTimeFormatter formatoTiempo = DateTimeFormatter.ofPattern("mm:ss");
        AlbumSet album = cancion.parent(AlbumSet.class);
        Album albumGrpc = ConversorObjetosGRPC.convertirAlbum(album);
        return Cancion.newBuilder()
                .setId(cancion.getInteger("id"))
                .setArtista(cancion.getString("artista"))
                .setDuracion(cancion.getTime("duracion").toLocalTime().format(formatoTiempo))
                .setGenero(cancion.getString("genero"))
                .setNombre(cancion.getString("nombre"))
                .setEsPRomocion(cancion.getBoolean("esPromocion"))
                .setEsPublica(cancion.getBoolean("esPublica"))
                .setLikes(cancion.getInteger("likes"))
                .setAlbum(albumGrpc)
                .build();
    }
    
    public static List<Album> convertirListaAlbums(List<AlbumSet> albumes) throws IOException {
        List<Album> albumesGrpc = new ArrayList<>();
        for (AlbumSet album : albumes) {
            albumesGrpc.add(ConversorObjetosGRPC.convertirAlbum(album));
        }
        return albumesGrpc;
    }
    
    public static List<Cancion> convertirListaCanciones(List<CancionSet> canciones) throws IOException {
        List<Cancion> albumesGrpc = new ArrayList<>();
        for (CancionSet cancion : canciones) {
            albumesGrpc.add(ConversorObjetosGRPC.convertirCancion(cancion));
        }
        return albumesGrpc;
    }

}
