FROM mcr.microsoft.com/mssql/server:2017-latest
ENV SA_PASSWORD=Passw0rd
ENV ACCEPT_EULA=Y
COPY ./database /usr/home/
WORKDIR /usr/home/
#RUN /opt/mssql-tools/bin/sqlcmd -i /usr/home/SiReMuDBv2.0.3.sql  -S localhost -U SA -P 'Passw0rd'
RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Passw0rd' -i /usr/home/SiReMuDBv2.0.3.sql && pkill sqlservr