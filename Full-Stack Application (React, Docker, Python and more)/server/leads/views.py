from django.shortcuts import render
from rest_framework import viewsets
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework.reverse import reverse
from .serializers import LeadSerializer
from .models import Lead
from rest_framework import permissions

@api_view(['GET'])
def api_root(request, format=None):
	"""
	This is the api root view. It provides the available views.
	"""
	return Response({
			'leads': reverse('lead-list', request=request, format=format),
		})

class LeadViewSet(viewsets.ModelViewSet):
	"""
	This viewset automatically provides `list`, `create`, `retrieve`,
	`update` and `destroy` actions for the current authenticated user.

	"""
	serializer_class = LeadSerializer

	def get_queryset(self):
		queryset = Lead.objects.all()
		return queryset
