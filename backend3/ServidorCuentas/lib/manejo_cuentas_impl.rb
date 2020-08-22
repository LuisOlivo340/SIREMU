# frozen_string_literal: true

require 'rubygems'
require 'bundler/setup'
Bundler.require(:default)

require './app'
require './lib/protos/manejoCuentas_services_pb'
require './lib/excepciones'

class ManejoCuentasImpl < MnjCuentas::ManejoCuentas::Service

  def initialize
    #Asigna al logger el archivo log de este proyecto.
    @logger = Logger.new('log/mnj_cuentas_log.log')
    @logger.datetime_format = '%d-%m-%Y %H:%M:%S'
    @formato_fecha = '%Y-%m-%d'
  end

  #Valida que exista registrado un usuario según los datos recibidos y regresa la información del usuario correspondiente.
  def iniciar_sesion(cuenta, _unused_call)
    begin
      usuario_actual = UsuarioSet.find_by(usuario: cuenta.usuario)
    rescue StandardError => e
      @logger.error(e.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    if usuario_actual.nil?
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INVALID_ARGUMENT, Excepciones.get_usuario_invalido)
    end
    hash = BCrypt::Password.new(usuario_actual.contrasena)
    unless hash == cuenta.contrasenia
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INVALID_ARGUMENT, Excepciones.get_contra_invalida)
    end
    cuenta_valida = MnjCuentas::Usuario.new(id: usuario_actual.id, correo: usuario_actual.correo, usuario: usuario_actual.usuario,
                                            nombre: usuario_actual.nombre, apellido: usuario_actual.apellido, fechaNacimiento: usuario_actual.fechaNacimiento.strftime(@formato_fecha),
                                            esCreadorContenido: usuario_actual.esCreadorContenido, genero: usuario_actual.genero)
    MnjCuentas::RespuestaCuentas.new(respuesta: true, cuenta: cuenta_valida)
  end

  #Recibe los datos de un nuevo usuario y lo registra en la bd de siremu. Primero valida si no existe un usuario con el mismo nombre de usuario y correo.
  def registrar_usuario(cuenta, _unused_call)
    begin
      if UsuarioSet.where(correo: cuenta.correo).exists?
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::ALREADY_EXISTS, Excepciones.get_correo_registrado)
      end
      nuevo_usuario = UsuarioSet.find_or_initialize_by(usuario: cuenta.usuario)
      if nuevo_usuario.new_record?
        nuevo_usuario.nombre = cuenta.nombre
        nuevo_usuario.usuario = cuenta.usuario
        nuevo_usuario.apellido = cuenta.apellido
        nuevo_usuario.genero = cuenta.genero
        nuevo_usuario.correo = cuenta.correo
        nuevo_usuario.esCreadorContenido = false
        nuevo_usuario.fechaNacimiento = Date.parse(cuenta.fechaNacimiento)
        nuevo_usuario.contrasena = BCrypt::Password.create(cuenta.contrasenia, cost: 6)
        nuevo_usuario.save
        lista_me_gusta = ListaReproduccionSet.create(nombre: "Me gusta", esPublica: false, esDefault: true)
        lista_historial = ListaReproduccionSet.create(nombre: "Mi historial", esPublica: false, esDefault: true)
        ListaUsuario.create(usuario_set_id: nuevo_usuario.id, lista_reproduccion_set_id: lista_me_gusta.id, esPropietario: true)
        ListaUsuario.create(usuario_set_id: nuevo_usuario.id, lista_reproduccion_set_id: lista_historial.id, esPropietario: true)
      else
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::ALREADY_EXISTS, Excepciones.get_usuario_registrado)
      end
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => e
      @logger.error(e.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    usuario_grpc = MnjCuentas::Usuario.new(id: nuevo_usuario.id, correo: nuevo_usuario.correo, usuario: nuevo_usuario.usuario,
                                           nombre: nuevo_usuario.nombre, apellido: nuevo_usuario.apellido, fechaNacimiento: nuevo_usuario.fechaNacimiento.strftime(@formato_fecha),
                                           esCreadorContenido: nuevo_usuario.esCreadorContenido, genero: nuevo_usuario.genero)
    MnjCuentas::RespuestaCuentas.new(respuesta: true, cuenta: usuario_grpc)
  end

  #Recibe nueva información de usuario y se la asigna al usuario deseado.
  def modificar_usuario(cuenta, _unused_call)
    begin
      usuario_actual = UsuarioSet.find_by(id: cuenta.id)
      if !cuenta.usuario.eql?(usuario_actual.usuario) && UsuarioSet.where(usuario: cuenta.usuario).exists?
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::ALREADY_EXISTS, Excepciones.get_usuario_registrado)
      end
      if !cuenta.correo.eql?(usuario_actual.correo) && UsuarioSet.where(correo: cuenta.correo).exists?
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::ALREADY_EXISTS, Excepciones.get_correo_registrado)
      end
      usuario_actual.nombre = cuenta.nombre
      usuario_actual.usuario = cuenta.usuario
      usuario_actual.apellido = cuenta.apellido
      usuario_actual.genero = cuenta.genero
      usuario_actual.correo = cuenta.correo
      usuario_actual.esCreadorContenido = cuenta.esCreadorContenido
      usuario_actual.fechaNacimiento = Date.parse(cuenta.fechaNacimiento)
      usuario_actual.save
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => e
      @logger.error(e.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    usuario_grpc = MnjCuentas::Usuario.new(id: usuario_actual.id, correo: usuario_actual.correo, usuario: usuario_actual.usuario,
      nombre: usuario_actual.nombre, apellido: usuario_actual.apellido, fechaNacimiento: usuario_actual.fechaNacimiento.strftime(@formato_fecha),
      esCreadorContenido: usuario_actual.esCreadorContenido, genero: usuario_actual.genero)
    MnjCuentas::RespuestaCuentas.new(respuesta: true, cuenta: usuario_grpc)
  end

  #Reemplaza la contraseña del usuario deseado por una nueva contraseña.
  def cambiar_contrasena(cambio_contrasenas, _unused_call)
    begin
      usuario_actual = UsuarioSet.find_by(id: cambio_contrasenas.idUsuario)
      hash = BCrypt::Password.new(usuario_actual.contrasena)
      unless hash == cambio_contrasenas.contrasenaAnterior
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INVALID_ARGUMENT, Excepciones.get_contra_invalida)
      end
      usuario_actual.contrasena = BCrypt::Password.create(cambio_contrasenas.nuevaContrasena, cost: 6)
      usuario_actual.save
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => e
      @logger.error(e.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    MnjCuentas::RespuestaCuentas.new(respuesta: true)
  end
end
