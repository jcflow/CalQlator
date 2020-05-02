#!/bin/bash
dotnet build --configuration Release --output build/
python3 main.py
