import os
import dj_database_url
from .settings import *

SECRET_KEY = os.environ.get("SECRET_KEY") or '5l#1sf!k*$e(apb*mtlmc6k4n3ywf#n()*cdk=^+x@wk=xa^*-'
DEBUG = False

DATABASES = {
    # If DATABASE_URL environment variable isn't set, use Docker Compose Postgres database.
    'default': dj_database_url.config(
        default='postgres://postgres:postgres@db:5432/leadsdb',
        conn_max_age=600,
    )
}

INSTALLED_APPS.extend(["whitenoise.runserver_nostatic"])

# Must insert after SecurityMiddleware, which is first in settings/common.py
MIDDLEWARE.insert(1, "whitenoise.middleware.WhiteNoiseMiddleware")

TEMPLATES[0]["DIRS"] = [os.path.join(BASE_DIR, "../", "client", "build")]

# Static files (CSS, JavaScript, Images)
# https://docs.djangoproject.com/en/2.1/howto/static-files/

STATICFILES_DIRS = [os.path.join(BASE_DIR, "../", "client", "build", "static")]
STATICFILES_STORAGE = "whitenoise.storage.CompressedManifestStaticFilesStorage"
STATIC_ROOT = os.path.join(BASE_DIR, "staticfiles")

STATIC_URL = "/static/"
WHITENOISE_ROOT = os.path.join(BASE_DIR, "../", "client", "build", "root")
