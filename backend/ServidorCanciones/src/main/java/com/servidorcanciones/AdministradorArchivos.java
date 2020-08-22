package com.servidorcanciones;

/**
 *
 * @author IS Vega
 */
public class AdministradorArchivos {

    static final String CARPETA_ALBUMS = "Albums/";

    private AdministradorArchivos() {

    }

    public static String obtenerDireccionAlbum(int idUsuario, String album, boolean esPublico) {
        String carpetaPersonal;
        if (esPublico) {
            carpetaPersonal = "Publicos";
        } else {
            carpetaPersonal = "Privados";
        }
        return CARPETA_ALBUMS + idUsuario + "/" + carpetaPersonal + "/" + album;
    }
}
