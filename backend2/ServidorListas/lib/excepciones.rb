module Excepciones extend self
  
  def get_usuario_no_valido
    return "El usuario no tiene autorización para modificar el/los recursos solicitados."
  end

  def get_conexion_bd_caida
    return "Error al conectar con la base de datos de SiReMu."
  end

  def get_lista_no_encontrada
    return "La lista de reproduccion provista no se encuentra en la base de datos de SiReMu."
  end

  def get_error_interno
    return "Error interno del servidor de SiReMu."
  end

  def get_lista_registrada
    return "El usuario ya tiene una lista registrada con ese nombre."
  end

end 