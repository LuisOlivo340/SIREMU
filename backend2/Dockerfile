FROM ubuntu:20.04
RUN apt-get update
RUN DEBIAN_FRONTEND="noninteractive" apt-get -y install tzdata
COPY ./backend2 /usr/home/

WORKDIR /usr/home/ServidorListas
RUN apt -y install git
RUN apt-get -y  install ruby-full
RUN apt-get install -y freetds-dev
RUN apt-get install -y wget
RUN apt-get update
RUN apt-get install -y build-essential
RUN apt-get install -y libc6-dev
RUN gem install tiny_tds
RUN gem install bundler
RUN bundler install
#RUN ruby servidor.rb &