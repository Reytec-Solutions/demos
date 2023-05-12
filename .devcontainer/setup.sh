#!/bin/bash

echo "Configuring HTTPS..."
dotnet dev-certs https

echo "Installing tools..."
dotnet tool install -g dotnet-ef
dotnet tool install -g Microsoft.dotnet-httprepl

cd workspace

echo "Restoring packages..."
dotnet restore

echo "Running db migrations"
dotnet ef database update