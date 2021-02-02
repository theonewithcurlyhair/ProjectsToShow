# Full Stack Developer Application

# Docker, Python, React and more

## Docs

### Install Docker

You have to make sure you first have docker installed on your machine, if it is not, please check [https://docker.com](https://docker.com) for intructions on how to.

### Build Docker Image

On the root of this directory (same where this README is), type in the following:

```bash
docker build -t server .
```

### Deploy Docker Image

There are many platforms to which you could deploy your docker image app. Some of which are: AWS, Heroku, DigitalOcean, and other to just name a few

### Run app locally for development

#### Client (front-end):

in the root client directory, type the following, and please make sure you already have the following installed on your system:

1. Node.js
2. yarn or nmp

if yes, procceed to the following in your terminal

```bash
yarn 
```
or
```bash
npm install 
```
to spin the development server on

```bash
yarn start
```
or 
```bash
npm run start 
```

#### Server (back-end):

Make sure you have Python 3 installed, alongside with pip latest version. Then install the requirements.
This is in the root directory of the django app (server) where the requirements.txt exits.

1. Create a virual environment and lets name is 'venv'

```bash
virtualenv venv
```

2. Activate virual environment

```bash
source venv/bin/activate
```
3. Install the requirements

```bash
pip install -r requirements.txt
```
4. run the Django server

```bash
python manage.py runserver
```

#### Note

You may need to run database migrations as well:

```bash
python manage.py makemigrations
python manage.py migrate
```

### More

To learn more, please check the offical React.Js, Django, and Docker documentation.
This project has been created with optimizations and responsiveness in mind, with a clear structure and clean code.
