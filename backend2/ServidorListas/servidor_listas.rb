require 'rubygems'
require 'bundler/setup'
require './lib/manejo_listas_impl'
require 'time'
require './app'
Bundler.require(:default)

class ServidorListas
  class << self
    def start
      iniciar_servidor_grpc
    end

    private

    def iniciar_servidor_grpc
      @server = GRPC::RpcServer.new
      @server.add_http2_port('0.0.0.0:25111', :this_port_is_insecure)
      GRPC.logger.info("... corriendo inseguramente en el puerto: ")
      puts "Empieza el servidor a las:  #{Time.new}"
      @server.handle(ManejoListasImpl)
      @server.run_till_terminated
    end
  end
end

ServidorListas.start