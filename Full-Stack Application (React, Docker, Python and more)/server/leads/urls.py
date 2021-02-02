from django.urls import path
from .views import LeadViewSet, api_root
from rest_framework.urlpatterns import format_suffix_patterns

lead_list = LeadViewSet.as_view({
		'get': 'list',
		'post': 'create'
	})

lead_detail = LeadViewSet.as_view({
		'get': 'retrieve',
		'put': 'update',
		'patch': 'partial_update',
		'delete': 'destroy'
	})


urlpatterns = [
    path('', api_root),
    path('leads/', lead_list, name='lead-list'),
    path('leads/<int:pk>/', lead_detail, name='lead-detail'),
]

urlpatterns = format_suffix_patterns(urlpatterns)
