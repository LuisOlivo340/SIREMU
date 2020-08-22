package com.servidorcanciones;

import io.grpc.Server;
import io.grpc.ServerBuilder;
import java.io.IOException;
import java.util.concurrent.TimeUnit;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author IS Vega
 */
public class ServidorCanciones {

    static final Logger logger = Logger.getLogger(ServidorCanciones.class.getName());
    private Server server;

    private void start() throws IOException {
        int port = 25112;
        server = ServerBuilder.forPort(port).addService(new ManejoCancionesImpl())
                .build()
                .start();
        logger.log(Level.INFO, "Empieza el servidor de canciones, escuchando en {0}", port);
        Runtime.getRuntime().addShutdownHook(new Thread() {
            @Override
            public void run() {
                // Use stderr here since the logger may have been reset by its JVM shutdown hook.
                logger.info("*** shutting down gRPC server since JVM is shutting down");
                try {
                    ServidorCanciones.this.stop();
                } catch (InterruptedException e) {
                    logger.log(Level.SEVERE, null, e);
                }
                logger.info("*** server shut down");
            }
        });
    }

    private void stop() throws InterruptedException {
        if (server != null) {
            server.shutdown().awaitTermination(30, TimeUnit.SECONDS);
        }
    }

    /**
     * Await termination on the main thread since the grpc library uses daemon
     * threads.
     */
    private void blockUntilShutdown() throws InterruptedException {
        if (server != null) {
            server.awaitTermination();
        }
    }

    /**
     * Main launches the server from the command line.
     */
    public static void main(String[] args) throws IOException, InterruptedException {
        final ServidorCanciones servidor = new ServidorCanciones();
        servidor.start();
        servidor.blockUntilShutdown();
    }

}
