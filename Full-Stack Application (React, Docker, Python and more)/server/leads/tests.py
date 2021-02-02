from django.test import TestCase
from .models import Lead

class LeadModelTest(TestCase):
    def test_str_representation(self):
        lead = Lead.objects.create(
            first_name='Nikita',
            last_name='Mieshalnykov',
            email='nikita.meshalnikov@gmail.com',
            notes="this is a note",
            contacted=False,

        )
        self.assertEqual(str(lead), 'nikita.meshalnikov@gmail.com')

