from django.contrib import admin
from django.urls import path, include, re_path
from frontend import views
from leads.models import Lead
from django.views.generic import TemplateView

info_dict = {
    'queryset': Lead.objects.all(),
}

urlpatterns = [
    path('admin/', admin.site.urls),
    path('api/', include('leads.urls')),
    re_path(r'^', views.FrontendAppView.as_view()),
    re_path(".*", TemplateView.as_view(template_name="index.html")),
]
