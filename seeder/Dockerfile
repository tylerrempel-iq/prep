FROM elixir:1.4

RUN apt-get update -y && apt-get install -y mysql-client &&\
    apt-get install -y inotify-tools

RUN mix local.hex --force &&\
    mix local.rebar --force &&\
    mix archive.install https://github.com/phoenixframework/archives/raw/master/phoenix_new.ez --force

WORKDIR /app
EXPOSE 3001
