# Generated by Django 3.0.5 on 2021-01-25 11:31

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('leads', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='lead',
            name='notes',
            field=models.TextField(default=None),
        ),
    ]