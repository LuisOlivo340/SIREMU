# Generated by the protocol buffer compiler.  DO NOT EDIT!
# Source: manejoCuentas.proto for package 'mnjCuentas'

require 'grpc'
require_relative 'manejoCuentas_pb'

module MnjCuentas
  module ManejoCuentas
    class Service

      include GRPC::GenericService

      self.marshal_class_method = :encode
      self.unmarshal_class_method = :decode
      self.service_name = 'mnjCuentas.ManejoCuentas'

      rpc :IniciarSesion, MnjCuentas::Usuario, MnjCuentas::RespuestaCuentas
      rpc :RegistrarUsuario, MnjCuentas::Usuario, MnjCuentas::RespuestaCuentas
      rpc :ModificarUsuario, MnjCuentas::Usuario, MnjCuentas::RespuestaCuentas
      rpc :CambiarContrasena, MnjCuentas::CambioContrasenas, MnjCuentas::RespuestaCuentas
    end

    Stub = Service.rpc_stub_class
  end
end
