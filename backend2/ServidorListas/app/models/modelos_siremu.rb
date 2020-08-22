require_relative 'application_record'

class AlbumSet < ApplicationRecord
    belongs_to :usuario_set
end

class UsuarioSet < ApplicationRecord
    has_many :album_sets
    has_many :lista_usuarios
    has_many :lista_reproduccion_sets, :through => :lista_usuarios
end

class ListaReproduccionSet < ApplicationRecord
    has_many :lista_usuarios
    has_many :usuario_sets, :through => :lista_usuarios
    has_and_belongs_to_many :cancion_sets
end

class ListaUsuario < ApplicationRecord
    belongs_to :usuario_set
    belongs_to :lista_reproduccion_set
end

class CancionSet < ApplicationRecord
    has_and_belongs_to_many :lista_reproduccion_sets
end