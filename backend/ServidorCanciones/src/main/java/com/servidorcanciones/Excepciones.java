package com.servidorcanciones;

/**
 *
 * @author IS Vega
 */
public class Excepciones {
    
    private Excepciones(){
        
    }

    public static final String CONEXIONBDCAIDA = "Error al conectar con la base de datos de SiReMu.";
    
    public static final String ERRORINTERNO = "Error interno del servidor de SiReMu.";
    
    public static final String ALBUMREPETIDO = "El usuario ya tiene un album registrado con ese nombre.";
    
    public static final String CANCIONREPETIDA = "Ya existe una canción con ese nombre en el album.";
    
    public static final String CANCIONNOENCONTRADA = "La canción solicitada no se encuentra registrada en la base de datos de SiReMu.";
    
    public static final String DATOSCANCIONFALTANTES = "No se recibieron los datos de la canción a subir.";
    
    public static final String NUMCANCIONESPRIVADASEXCEDIDO = "El usuario ya ha alcanzado el límite de 250 canciones privadas subidas al servidor.";
    
    public static final String NOHAYCANCIONES = "No hay canciones en esta lista de reproduccion";
}
