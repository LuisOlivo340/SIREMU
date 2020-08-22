module Excepciones extend self
  
  def get_usuario_invalido
    return "No hay ningun usuario registrado con ese nombre de usuario."
  end
  def get_contra_invalida
    return "La contraseña es incorrecta."
  end
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

  def get_correo_registrado
    return "Ya existe un usuario registrado con ese correo."
  end

  def get_usuario_registrado
    return "Ya existe un usuario registrado con ese nombre de usuario."
  end

end 