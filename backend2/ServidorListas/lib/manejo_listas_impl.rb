require 'rubygems'
require 'bundler/setup'
Bundler.require(:default)

require './app'
require './lib/protos/manejoListas_services_pb'
require './lib/excepciones'

class ManejoListasImpl < MnjListas::ManejoListas::Service

  def initialize
    @logger = Logger.new("log/mnj_listas_log.log")
    @logger.datetime_format = '%d-%m-%Y %H:%M:%S'
  end

  def agregar_quitar_canciones_lista(lista_a_a,  _unused_call)
    begin
      usuario_actual = UsuarioSet.joins(:lista_usuarios).find_by(lista_usuarios: {usuario_set_id: lista_a_a.idUsuario, lista_reproduccion_set_id: lista_a_a.idLista, esPropietario: true})
      if usuario_actual.nil?
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::UNAUTHENTICATED, Excepciones.get_usuario_no_valido)
      end
      lista_escogida = ListaReproduccionSet.find_by(id: lista_a_a.idLista)
      lista_a_a.idCanciones.each do |id_cancion|
        cancion = CancionSet.find_by(id: id_cancion)
        if lista_a_a.agregar && !lista_escogida.cancion_sets.where(id: cancion.id).any?
          lista_escogida.cancion_sets.append(cancion)
          if lista_escogida.nombre.eql?("Me gusta")
            cancion.update(likes: cancion.likes+1)
          end
        elsif !lista_a_a.agregar && lista_escogida.cancion_sets.where(id: cancion.id).any?
          lista_escogida.cancion_sets.delete(cancion)
          if lista_escogida.nombre.eql?("Me gusta")
            cancion.update(likes: cancion.likes-1)
          end
        end
      end
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => db_exception
      @logger.error(db_exception.inspect) 
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    MnjListas::RespuestaListas.new(respuesta: true)
  end
  
  def agregar_lista_a_me_gusta(lista_a_a,  _unused_call)
    begin
      nueva_union = ListaUsuario.find_or_initialize_by(usuario_set_id: lista_a_a.idUsuario, lista_reproduccion_set_id: lista_a_a.idLista)
      if nueva_union.new_record?
        if lista_a_a.agregar
          nueva_union.esPropietario = false
          nueva_union.save
          lista_actual = ListaReproduccionSet.find_by(id: lista_a_a.idLista)
          lista_actual.update(likes: lista_actual.likes+1)
        else
          raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::NOT_FOUND, Excepciones.get_lista_no_encontrada)
        end
      else
        unless lista_a_a.agregar
          nueva_union.destroy
          lista_actual = ListaReproduccionSet.find_by(id: lista_a_a.idLista)
          lista_actual.update(likes: lista_actual.likes-1)
        end
      end
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => db_exception
      @logger.error(db_exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    MnjListas::RespuestaListas.new(respuesta: true)
  end

  def buscar_listas(nombre_lista,  _unused_call)
    listas_reproduccion = []
    begin
      listas_encontradas = ListaReproduccionSet.where("nombre LIKE ?", "%#{nombre_lista.nombre}%").where(esPublica: true).take(20)
      listas_encontradas.each do |lista|
        propietario = UsuarioSet.joins(:lista_usuarios).find_by(lista_usuarios: {lista_reproduccion_set_id: lista.id, esPropietario: true})
        imagen = File.binread(lista.ilustracion)
        extension = File.extname(lista.ilustracion)
        listas_reproduccion << MnjListas::ListaReproduccion.new(id: lista.id, nombre: lista.nombre, 
          esPublica: lista.esPublica, likes: lista.likes, ilustracion: imagen, descripcion: lista.descripcion, 
          idCreador: propietario.id, nombreCreador: propietario.usuario, extensionIlustracion: extension)
      end
    rescue IOError, SystemCallError => file_exception
      @logger.error(file_exception.inspect)
      if listas_reproduccion.length == 0
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_error_interno)
      end
    rescue StandardError => exception
      @logger.error(exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    return MnjListas::ListaListas.new(listas: listas_reproduccion)
  end
  
  def consultar_mis_listas(id_usuario,  _unused_call)
    listas_usuario = []
    begin
      propietario = UsuarioSet.find_by(id: id_usuario.id)
      mis_listas = ListaReproduccionSet.joins(:lista_usuarios).where(lista_reproduccion_sets: {esDefault: false}, lista_usuarios: {usuario_set_id: id_usuario.id, esPropietario: true})
      mis_listas.each do |lista|
        imagen = File.binread(lista.ilustracion)
        extension = File.extname(lista.ilustracion)
        listas_usuario << MnjListas::ListaReproduccion.new(id: lista.id, nombre: lista.nombre, 
          esPublica: lista.esPublica, likes: lista.likes, ilustracion: imagen, descripcion: lista.descripcion, 
          idCreador: propietario.id, nombreCreador: propietario.usuario, extensionIlustracion: extension)
      end
    rescue IOError, SystemCallError => file_exception
      @logger.error(file_exception.inspect)
      if listas_usuario.length == 0
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_error_interno)
      end
    rescue StandardError => exception
      @logger.error(exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    return MnjListas::ListaListas.new(listas: listas_usuario)
  end

  def consultar_mis_listas_agregadas(id_usuario,  _unused_call)
    listas_usuario = []
    begin
      mis_listas = ListaReproduccionSet.joins(:lista_usuarios).where(lista_reproduccion_sets: {esDefault: false, esPublica: true}, lista_usuarios: {usuario_set_id: id_usuario.id, esPropietario: false})
      mis_listas.each do |lista|
        propietario = UsuarioSet.joins(:lista_usuarios).find_by(lista_usuarios: {lista_reproduccion_set_id: lista.id, esPropietario: true})
        imagen = File.binread(lista.ilustracion)
        extension = File.extname(lista.ilustracion)
        listas_usuario << MnjListas::ListaReproduccion.new(id: lista.id, nombre: lista.nombre, 
          esPublica: lista.esPublica, likes: lista.likes, ilustracion: imagen, descripcion: lista.descripcion, 
          idCreador: propietario.id, nombreCreador: propietario.usuario, extensionIlustracion: extension)
      end
    rescue IOError, SystemCallError => file_exception
      @logger.error(file_exception.inspect)
      if listas_usuario.length == 0
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_error_interno)
      end
    rescue StandardError => exception
      @logger.error(exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    return MnjListas::ListaListas.new(listas: listas_usuario)
  end

  def consultar_mis_listas_default(id_usuario,  _unused_call)
    listas_usuario_default = []
    begin
      mis_listas = ListaReproduccionSet.joins(:lista_usuarios).where(lista_reproduccion_sets: {esDefault: true}, lista_usuarios: {usuario_set_id: id_usuario.id, esPropietario: true})
      mis_listas.each do |lista|
        listas_usuario_default << MnjListas::ListaReproduccion.new(id: lista.id, nombre: lista.nombre, 
          esDefault: lista.esDefault)
      end
    rescue StandardError => exception
      @logger.error(exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    return MnjListas::ListaListas.new(listas: listas_usuario_default)
  end
  
  def crear_lista_reproduccion(lista_a_g, _unused_call)
    ilustracion = "IlustracionesListas/#{lista_a_g.idUsuario} - #{lista_a_g.listaAAgregar.nombre}#{lista_a_g.listaAAgregar.extensionIlustracion}"
    begin
      listas_usuario = ListaReproduccionSet.joins(:lista_usuarios).where(lista_usuarios: {usuario_set_id: lista_a_g.idUsuario, esPropietario: true})
      nueva_lista = listas_usuario.find_or_initialize_by(nombre: lista_a_g.listaAAgregar.nombre)
      if nueva_lista.new_record?
        File.open(ilustracion, 'wb') do |salida|
          salida.write(lista_a_g.listaAAgregar.ilustracion)
        end
        nueva_lista = ListaReproduccionSet.new
        nueva_lista.esDefault = false
        nueva_lista.nombre = lista_a_g.listaAAgregar.nombre
        nueva_lista.esPublica = lista_a_g.listaAAgregar.esPublica
        nueva_lista.ilustracion = ilustracion
        nueva_lista.likes = 0
        nueva_lista.descripcion = lista_a_g.listaAAgregar.descripcion
        nueva_lista.save
        ListaUsuario.create(usuario_set_id: lista_a_g.idUsuario, lista_reproduccion_set_id: nueva_lista.id, esPropietario: true)
      else
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::ALREADY_EXISTS, Excepciones.get_lista_registrada)
      end
    rescue IOError, SystemCallError => file_exception
      @logger.error(file_exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_error_interno)
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => db_exception
      @logger.error(db_exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    MnjListas::RespuestaListas.new(respuesta: true)
  end

  def modificar_lista_reproduccion(lista_a_g, _unused_call)
    ilustracion = "IlustracionesListas/#{lista_a_g.idUsuario} - #{lista_a_g.listaAAgregar.nombre}#{lista_a_g.listaAAgregar.extensionIlustracion}"
    begin
      lista_modificar = ListaReproduccionSet.find_by(id: lista_a_g.listaAAgregar.id)
      listas_usuario = ListaReproduccionSet.joins(:lista_usuarios).where(lista_usuarios: {usuario_set_id: lista_a_g.idUsuario, esPropietario: true})
      if !lista_a_g.listaAAgregar.nombre.eql?(lista_modificar.nombre) && listas_usuario.where(nombre: lista_a_g.listaAAgregar.nombre).exists?
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::ALREADY_EXISTS, Excepciones.get_lista_registrada)
      end
      if lista_modificar.lista_usuarios.where(usuario_set_id: lista_a_g.idUsuario, esPropietario: true).exists?
        File.delete(lista_modificar.ilustracion) if File.exist?(lista_modificar.ilustracion)
        File.open(ilustracion, 'wb') do |salida|
          salida.write(lista_a_g.listaAAgregar.ilustracion)
        end
        lista_modificar.nombre = lista_a_g.listaAAgregar.nombre
        lista_modificar.esPublica = lista_a_g.listaAAgregar.esPublica
        lista_modificar.ilustracion = ilustracion
        lista_modificar.descripcion = lista_a_g.listaAAgregar.descripcion
        lista_modificar.save
      else
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::UNAUTHENTICATED, Excepciones.get_usuario_no_valido)
      end
    rescue IOError, SystemCallError => file_exception
      @logger.error(file_exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_error_interno)
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => db_exception
      @logger.error(db_exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    MnjListas::RespuestaListas.new(respuesta: true)
  end
  
  def eliminar_lista_reproduccion(lista_a_g,  _unused_call)
    begin
      lista_eliminar = ListaReproduccionSet.find_by(id: lista_a_g.listaAAgregar.id)
      if lista_eliminar.lista_usuarios.where(usuario_set_id: lista_a_g.idUsuario, esPropietario: true).exists?
        lista_eliminar.destroy
        File.delete(lista_eliminar.ilustracion) if File.exist?(lista_eliminar.ilustracion)
      else
        raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::UNAUTHENTICATED, Excepciones.get_usuario_no_valido)
      end
    rescue IOError, SystemCallError => file_exception
      @logger.error(file_exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_error_interno)
    rescue ActiveRecord::ActiveRecordError, TinyTds::Error => db_exception
      @logger.error(db_exception.inspect)
      raise GRPC::BadStatus.new(GRPC::Core::StatusCodes::INTERNAL, Excepciones.get_conexion_bd_caida)
    end
    MnjListas::RespuestaListas.new(respuesta: true)
	end

end
