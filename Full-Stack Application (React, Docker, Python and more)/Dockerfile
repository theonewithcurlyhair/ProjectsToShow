FROM python:3.8

# Install curl, node, & yarn
RUN apt-get -y install curl \
  && curl -sL https://deb.nodesource.com/setup_14.x | bash \
  && apt-get install nodejs \
  && curl -o- -L https://yarnpkg.com/install.sh | bash

# Install psql so that "python manage.py dbshell" works
RUN apt-get update -qq && apt-get install -y postgresql-client

WORKDIR /app/server

# Install Python dependencies
COPY ./server/requirements.txt /app/server/
RUN pip3 install --upgrade --no-cache-dir -r requirements.txt

# Install JS dependencies
WORKDIR /app/client

COPY ./client/package.json ./client/yarn.lock /app/client/
RUN $HOME/.yarn/bin/yarn install

# Add the rest of the code
COPY . /app/

# Build static files
RUN $HOME/.yarn/bin/yarn build

# Have to move all static files other than index.html to root/
# for whitenoise middleware
WORKDIR /app/client/build

RUN mkdir root
#&& /bin/sh -c "mv *.ico *.js *.json root"

# Collect static files
#RUN mkdir /app/server/staticfiles

WORKDIR /app

# SECRET_KEY is only included here to avoid raising an error when generating static files.
# Be sure to add a real SECRET_KEY config variable in Heroku.
RUN DJANGO_SETTINGS_MODULE=server.settings_prod \
  SECRET_KEY=somethingsupersecret

RUN python3 server/manage.py collectstatic --noinput 

RUN python3 server/manage.py migrate

EXPOSE $PORT

CMD python3 server/manage.py runserver 0.0.0.0:$PORT
