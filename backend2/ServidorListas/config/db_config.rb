class DbConfig
  def self.config
    {
      adapter: 'sqlserver',
      host: 'host.docker.internal',
      port: 1443,
      username: 'sa',
      password: 'Passw0rd',
      database: 'SiReMu',
      pool: 40
    }
  end
end
