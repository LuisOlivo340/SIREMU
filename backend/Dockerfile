FROM ubuntu:20.04
RUN apt-get update
RUN DEBIAN_FRONTEND="noninteractive" apt-get -y install tzdata
RUN apt -y install git
RUN apt-get install -y openjdk-8-jdk
RUN apt install maven -y
COPY ./backend /usr/home/

WORKDIR /usr/home/ServidorCanciones
RUN mvn clean
RUN mvn compile
RUN mvn clean install
#RUN mvn exec:java -Dexec.mainClass="com.servidorcanciones.ServidorCanciones" &